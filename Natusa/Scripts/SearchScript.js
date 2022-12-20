$(document).ready(function () {

    $(".returnInput").css({ "display": "none"});
    
})

$('input[name=wayRadio]').change(function () {
        if ($(this).val() == "oneWay") { 
            $(".returnInput").fadeOut();
        }
        if ($(this).val() == "bothWay") {
            $(".returnInput").fadeIn();
        }
    })