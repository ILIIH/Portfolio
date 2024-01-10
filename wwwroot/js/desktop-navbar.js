$(document).ready(function () {
    var allBarItems = $(".bar-item");

    allBarItems.click(function () {
        allBarItems.removeClass("choosed").addClass("unchoosed");
        $(this).addClass("choosed").removeClass("unchoosed");
    });
});
