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
                class ="form-control leftstr h4"
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
            $("#reply").hide();
            isEditStart = true;
        }
        else {
            if (isEditStart) {

                element = $(`<div id="description" class="leftstr h4">
                    ${description}
                    </div>`);

                secondElement = $(`<h2 id="elementTitle">
                    ${title}
                    </h2>`)
                var now = new Date();

                $('#modifyDate').html("Upadte time: " + now.toUTCString());
                //$("#description").remove();
                //$("#title").remove();
                //$("#elementTitle").prepend($(secondElement));
                //$("#elementDetails").prepend($(element));
                $.ajax({
                    url: `http://localhost:57883/Topics/EditTopic`,
                    method: "POST",
                    data: {
                        "title": $('#titleElement').val(),
                        "ID": $('#idElement').val().toString(),
                        "description": $('#description').val()
                    },
                    success: function () {
                        $("#description").remove();
                        $("#elementTitle").remove();
                        $("#titleDefinition").prepend($(secondElement));
                        $("#elementDetails").prepend($(element));
                        $("#delete").show();
                        $("#reply").show();
                        isEditStart = false;
                    }
                })
            }
        }
    }

})();
