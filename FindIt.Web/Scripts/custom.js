$(document).ready(function () {

    $(".nav > li[class!='logo']").bind("mouseover", function () {

        $(this).children("a").addClass("navhover");

        $(this).find("ul").css("display", "block");

    })

    $(".nav > li[class!='logo']").bind("mouseout", function () {

        $(this).children("a").removeClass("navhover");
        $(this).find("ul").css("display", "none");

    })





})