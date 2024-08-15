using Microsoft.EntityFrameworkCore;
using SONA.Models; 


//namespace kaldırdık
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Guest> Guest { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<RoomType> RoomType { get; set; }
    public DbSet<UserRegistration> UserRegistration { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Reservation>()
            .Property(r => r.TotalPrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<RoomType>()
            .Property(rt => rt.BasePrice)
            .HasColumnType("decimal(18,2)");

        
        modelBuilder.Entity<UserRegistration>()
            .HasKey(ur => ur.UserId); 

       
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Guest)
            .WithMany(g => g.Reservations)
            .HasForeignKey(r => r.GuestId)
            .OnDelete(DeleteBehavior.Restrict);

        
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Room)
            .WithMany(room => room.Reservations)
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Payment)
            .WithOne()
            .HasForeignKey<Reservation>(r => r.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Guest)
            .WithMany()
            .HasForeignKey(p => p.GuestId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<RoomType>().HasData(
     new RoomType
     {
         RoomTypeId = 1,
         TypeName = "Single",
         Capacity = 1,
         BasePrice = 100,
         IsDelete = false,
         ImageUrl = "/img/room/room-3.jpg" 
     },
     new RoomType
     {
         RoomTypeId = 2,
         TypeName = "Double",
         Capacity = 2,
         BasePrice = 150,
         IsDelete = false,
         ImageUrl = "/img/room/room-5.jpg" 
     },
     new RoomType
     {
         RoomTypeId = 3,
         TypeName = "Suite",
         Capacity = 3,
         BasePrice = 250,
         IsDelete = false,
         ImageUrl = "/img/room/room-1.jpg" 
     },
     new RoomType
     {
         RoomTypeId = 4,
         TypeName = "Family",
         Capacity = 4,
         BasePrice = 300,
         IsDelete = false,
         ImageUrl = "/img/room/room-2.jpg" 
     }
 );



        for (int i = 1; i <= 4; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                string roomNumber = $"{i * 100 + j + 1}"; 
                modelBuilder.Entity<Room>().HasData(
                    new Room { RoomId = (i - 1) * 30 + j + 1, RoomTypeId = i, RoomNumber = roomNumber, IsAvailable = true, IsDelete = false }
                );
            }
        }
    }
    }

