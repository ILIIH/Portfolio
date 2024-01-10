$(document).ready(function () {
    var cart = localStorage.getItem("CartArr");
    cart = Object.values(JSON.parse(cart));

    var emptyCart = $(".empty-cart");
    var fullCart = $(".fullCart");
    var fullPrice = $(".total-text");

    cart = cart.filter((value, index, self) => {
        return self.indexOf(value) === index;
    });

    if (cart.length > 0) {
        emptyCart.css("display", "none");
        emptyCart.css("visibility", "hidden");
        fullCart.css("visibility", "visible");

        $.each(cart, function (index, item) {
            let cartItemWrapper = $("<div>").addClass("item");

            let imgDiv = $("<div>");
            let imgElement = $("<img>").attr("src", "image/ai_icon.png").addClass("cart-img");
            imgDiv.append(imgElement);

            let cartInfo = $("<div>").addClass("cart-item-info");

            let textDateDiv = $("<div>").text("date : 07/12/2023");
            let textPriceDiv = $("<div>").text("price : 33£");
            let courseName = $("<div>").text(item);

            cartInfo.append(courseName);
            cartInfo.append(textDateDiv);
            cartInfo.append(textPriceDiv);

            cartItemWrapper.append(cartInfo);
            cartItemWrapper.append(imgDiv);

            fullCart.append(cartItemWrapper);
        });

        fullPrice.text("TOTAL " + 33 * cart.length + "£");
    } else {
        emptyCart.css("display", "block");
        emptyCart.css("visibility", "visible");
        fullCart.css("display", "none");
        fullCart.css("visibility", "hidden");
    }
});
