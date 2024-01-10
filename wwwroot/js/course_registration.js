$(document).ready(function () {
    function initMap() {
        const myLatLng = { lat: 37.7749, lng: -122.4194 };
        const map = new google.maps.Map($("#map")[0], {
            zoom: 13,
            center: myLatLng,
        });

        const marker = new google.maps.Marker({
            position: myLatLng,
            map: map,
            title: "User Location",
        });
    }

    function getFromLocalStorage(key) {
        const storedValue = localStorage.getItem(key);
        return storedValue ? JSON.parse(storedValue) : null;
    }

    const currentCourse = getFromLocalStorage("CurrentCourse");
    const registrationBtn = $(".registration-btn-float");

    registrationBtn.click(function () {
        const emailInput = $("#email");
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (!emailRegex.test(emailInput.val())) {
            alert("Please enter a valid email address");
        } else {
            let cart = getFromLocalStorage("CartArr") || [];
            cart.push(currentCourse);
            localStorage.setItem("CartArr", JSON.stringify(cart));

            $(".registration-form")[0].submit();
        }
    });

    // Initialize map after DOM is loaded
    initMap();
});
