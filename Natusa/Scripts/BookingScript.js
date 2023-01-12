$(document).ready(function () {
    var toPrice = parseInt($("#onPriceRes").val().slice(0, -1));
    var backPrice = 0;
    try {
        var backPrice = parseInt($("#retPriceRes").val().slice(0, -1));
    }
    catch (error) { 
    }
    var baseTotal = toPrice + backPrice;
    $("#totalPrice").val(baseTotal)
    $('#numOfTickets').on('input', function () {
        if ($('#numOfTickets').val() == 0) 
            $('#numOfTickets').val(1);
        
        var newTotal = $('#numOfTickets').val() * baseTotal;       
        $("#totalPrice").val(newTotal);
    })

})