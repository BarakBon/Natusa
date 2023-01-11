$(document).ready(function () {
    var baseTotal = parseInt($("#onPriceRes").val().slice(0, -1)) + parseInt($("#retPriceRes").val().slice(0, -1));
    $("#totalPrice").val(baseTotal)
    $('#numOfTickets').on('input', function () {
        if ($('#numOfTickets').val() == 0) 
            $('#numOfTickets').val(1);
        
        var newTotal = $('#numOfTickets').val() * baseTotal;       
        $("#totalPrice").val(newTotal);
    })

})