$(document).ready(function () {
    const courseIcon = $(".course-icon").eq(0);
    const registerBtn = $(".registration-btn-float").eq(0);
    const courseName = $(".course-name").eq(0);

    registerBtn.click(() => {
        localStorage.setItem("CurrentCourse", JSON.stringify(courseName.text()));
    });

    $(window).scroll(() => {
        const elementRect = courseIcon[0].getBoundingClientRect();

        if (elementRect.top > window.innerHeight || elementRect.bottom <= 0) {
            if (registerBtn.hasClass("registration-btn-float")) {
                registerBtn.removeClass("registration-btn-float").addClass("registration-btn");
            }
        }
    });
});