$(document).ready(function () {
    var pageWidth = $(window).width();

    $("#hide").click(function () {
        $("#pushleft").removeClass('newClass');
    });
    $("#show").click(function () {
        $("#pushleft").addClass('newClass');
    });
});