$(document).ready(function () {
    var navbarBtn = $(".navbar_icon").eq(0);
    const navbarLayout = $("#navbar_layout");

    navbarBtn.click(function () {
        const isOverlayVisible = navbarLayout.css("left") === "0px";

        if (isOverlayVisible) {
            navbarLayout.css("left", "-100%");
            if (navbarBtn.hasClass("navbar-expanded")) {
                console.log("navbar-expanded");
                navbarBtn.removeClass("navbar-expanded").addClass("navbar-closed");
            }
        } else {
            navbarLayout.css("left", "0");
            if (navbarBtn.hasClass("navbar-closed")) {
                console.log("navbar-closed");
                navbarBtn.removeClass("navbar-closed").addClass("navbar-expanded");
            }
        }
    });
});
