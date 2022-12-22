$(document).ready(function () {


    $("#depDate").attr({ "min": new Date().toJSON().split('T')[0] })

    $("#depDate").change(function () {
        $("#retDate").attr({ "min": $("#depDate").val() })
    })


    $('input[name=wayRadio]').change(function () {
        if ($(this).val() == "oneWay") { 
            $(".returnInput").fadeOut();
            $("#retDate").val("");
            $("#retTime").val("");
        }
        if ($(this).val() == "bothWay") {
            $(".returnInput").fadeIn();
        }
    })
})