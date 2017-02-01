/// <reference path="jquery-3.1.1.intellisense.js" />
/// <reference path="jquery-3.1.1.min.js" />
'use strict';
(function () {

    var editButton = document.getElementById('searchButton'),
        isEditStart = false;
    editButton.onclick = goEdit;


    function goEdit() {

        var title = $("#title").val(),
            author = $("#author").val(),
            forum = $(".forum option:selected").text(),
            topicsDetails = $('#topicsDetails').empty();
        $.ajax({
            url: `http://localhost:57883/Search/GetSearch`,
            method: 'get',
            data: {
                "title": title,
                "author": author,
                "forum": forum
            },
            success: function (data) {
                topicsDetails.append(data);
            }
        })
    }




})();
