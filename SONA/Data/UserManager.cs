namespace SONA.Data
{
    public class UserManager
    {
        public static int? CurrentGuestId { get; set; }
        public static bool IsLogin { get; set; }

        public static int GetCurrentGuestId()
        {
            if (CurrentGuestId.HasValue)
            {
                return CurrentGuestId.Value;
            }

            throw new InvalidOperationException("No user is currently logged in.");
        }
    }
}

