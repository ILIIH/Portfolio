document.addEventListener("DOMContentLoaded", function () {
     $(document).ready(function () {
        $(".bar-item").click(function () {
            var chosenPartial = $(this).attr("id");
            loadPartialView(chosenPartial);
        });

        function loadPartialView(chosenPartial) {
            url = "";
            console.log(chosenPartial);

            switch (chosenPartial) {
                case "projects":
                    url = "/MyProjects/"
                    break;
                case "general_information":
                    url = "/Courses/"
                    break;
                case "my_courses":
                    url = "/Courses/"
                    break;
                case "cart":
                    url = "/Cart/"
                    break;
                default:
                url = "/Courses/"
                    break;
            }

            $.ajax({
                url: url,
                type: 'GET',
                success: function (result) {
                    console.log(result);
                    $("#main-content-column").html(result);
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
    }); 
});
