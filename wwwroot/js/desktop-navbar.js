var allBarItems = document.querySelectorAll(".bar-item");

allBarItems.forEach(function (bar_item) {
  bar_item.addEventListener("click", function () {
    allBarItems.forEach(function (item) {
      item.classList.remove("choosed");
      item.classList.add("unchoosed");
    });

    bar_item.classList.add("choosed");
    bar_item.classList.remove("unchoosed");
  });
});
