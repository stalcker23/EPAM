/// <reference path="jquery-3.1.1.intellisense.js" />
/// <reference path="jquery-3.1.1.min.js" />
'use strict';
(function () {
    var isEditStart = false,
        editButton = $('.editPostButton').click(function () {
            goEdit();
            function goEdit() {
                var element,
                    textElement = $("#postText"),
                    text = textElement.text() || textElement.val();

                if (!isEditStart) {

                    element = $(`<input type="text"
                id="postText"
                class ="post-details__content form-control"
                name="description"
                placeholder="Enter description"
                value= ${text} />`);

                    $(".editPostButton").parents("div").first().siblings().remove()
                    $(".editPostButton").parents("div").first().prepend($(element));
                    isEditStart = true;
                }
                else {
                    if (isEditStart) {

                        element = $(`<div id="postText" class="post-details__content">
                    ${text}
                    </div>`);
                        var now = new Date();


                        $.ajax({
                            url: `http://localhost:57883/Posts/EditPost`,
                            method: "POST",
                            data: {
                                "idTopic": $('#id').val(),
                                "ID": $('#idElement').val().toString(),
                                "text": $('#postText').val()
                            },
                            success: function () {
                                $("#postText").click().remove();
                                $(".editPostButton").parents("div").first().prepend($(element));
                                isEditStart = false;
                                window.location.reload()
                            }
                        })
                    }
                }
            }
        })
})();