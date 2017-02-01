/// <reference path="jquery-3.1.1.intellisense.js" />
/// <reference path="jquery-3.1.1.min.js" />
'use strict';
(function () {

    var editButton = document.getElementById('editButton'),
        isEditStart = false;
    editButton.onclick = goEdit;


    function goEdit() {

        var element,

            titleElement = $("#elementTitle"),
            title = titleElement.text() || titleElement.val();

        if (!isEditStart) {



            element = $(`<input type="text"
                id="elementTitle"
                class="form-control"
                name="elementTitle"
                placeholder="Enter title"
                value= ${title} />`)


            $("#elementTitle").remove();
            $("#titleDefinition").prepend($(element));
            isEditStart = true;
        }
        else {
            if (isEditStart) {


                element = $(`<h2 id="elementTitle">
                    ${title}
                    </h2>`)
                var now = new Date();

                $.ajax({
                    url: `http://localhost:57883/Users/EditUser`,
                    method: "POST",
                    data: {
                        "title": $('#elementTitle').val(),
                        "ID": $('#idElement').val().toString(),
                    },
                    success: function () {
                        $("#elementTitle").remove();
                        $("#titleDefinition").prepend($(element));

                        isEditStart = false;
                    }
                })
            }
        }
    }

})();
