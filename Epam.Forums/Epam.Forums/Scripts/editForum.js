/// <reference path="jquery-3.1.1.intellisense.js" />
/// <reference path="jquery-3.1.1.min.js" />
'use strict';
(function () {
    var editButton = document.getElementById('editButton'),
        isEditStart = false;

    editButton.onclick = goEdit;



    function goEdit() {

        var element,
            secondElement,

            descriptionElement = $("#description"),
            description = descriptionElement.text() || descriptionElement.val(),

            titleElement = $("#elementTitle"),
            title = titleElement.text() || titleElement.val();

        if (!isEditStart) {

            element = $(`<input type="text"
                id="description"
                class ="form-control"
                name="description"
                placeholder="Enter description"
                value= ${description} />`);

            secondElement = $(`<input type="text"
                id="elementTitle"
                class="form-control"
                name="elementTitle"
                placeholder="Enter title"
                value= ${title} />`)

            $("#description").remove();
            $("#elementTitle").remove();
            $("#titleDefinition").prepend($(secondElement));
            $("#elementDetails").prepend($(element));
            $("#delete").hide();
            $("#add").hide();
            isEditStart = true;
        }
        else {
            if (isEditStart) {

                element = $(`<div id="description" class="forum-details__desc">
                    ${description}
                    </div>`);

                secondElement = $(`<h2 id="elementTitle">
                    ${title}
                    </h2>`)
                var now = new Date();


                $.ajax({
                    url: `http://localhost:57883/Forums/EditForum`,
                    method: "POST",
                    data: {
                        "title": $('#elementTitle').val(),
                        "ID": $('#idElement').val().toString(),
                        "description": $('#descriptionElement').val()
                    },
                    success: function () {
                        $("#description").remove();
                        $("#elementTitle").remove();
                        $("#titleDefinition").prepend($(secondElement));
                        $("#elementDetails").prepend($(element));
                        $("#delete").show();
                        $("#add").show();
                        isEditStart = false;
                    }
                })
            }
        }
    }

})();
