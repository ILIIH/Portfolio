$(function () {
    $(".bar-item").click(function () {
        console.log("clicked item");
        var chosenPartial = $(this).attr("id");
        loadPartialView(chosenPartial);
    });

    $(".course_details_btn").click(function () {
        console.log("clicked course_details_btn");
        loadPartialView("course/name");
    });

    function loadPartialView(chosenPartial) {
        var url = "";

        switch (chosenPartial) {
            case "projects":
                url = "/MyProjects/";
                break;
            case "general_information":
            case "my_courses":
                url = "/Courses/";
                break;
            case "cart":
                url = "/Cart/";
                break;
            case "course":
                url = "/CourseDetailsModel/";
                break;
            case "course/name":
                url = "/CourseDetailsModel/name";
                break;
            default:
                url = "/Courses/";
                break;
        }

        $.ajax({
            url: url,
            type: 'GET',
            success: function (result) {
                $("#main-content-column").html(result);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
});
