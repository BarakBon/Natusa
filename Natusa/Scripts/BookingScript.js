$(document).ready(function () {
    var baseTotal = parseInt($("#priceRes").val().slice(0, -1)); // TODO: need to calc the other row
    $("#totalPrice").val(baseTotal)
    $('#numOfTickets').on('input', function () {
        if ($('#numOfTickets').val() == 0) 
            $('#numOfTickets').val(1);
        
        var newTotal = $('#numOfTickets').val() * baseTotal;       
        $("#totalPrice").val(newTotal);
    })

})