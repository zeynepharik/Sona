document.getElementById('booking-form').addEventListener('submit', function (event) {
    event.preventDefault(); 
    window.location.href = 'search-results.html'; 
var selectOptionElement = document.querySelector('.select-option');


document.getElementById('guest').addEventListener('change', function () {
    var selectedValue = this.value;
    console.log('Selected guest number:', selectedValue);
});
$(document).ready(function () {
    $('select').niceSelect();
});


$(document).ready(function () {
    
    var modal = $("#reservationModal");
    var closeBtn = $(".close-btn");

    
    function openModal(details) {
        $("#reservationDetails").text(details);
        modal.show();
    }

    
    closeBtn.on("click", function () {
        modal.hide();
    });

   
    $(window).on("click", function (event) {
        if ($(event.target).is(modal)) {
            modal.hide();
        }
    });

    
    function handleReservationSuccess(details) {
        openModal(details);
    }

    
});
