'use strict';
(function () {
    var redirectPageButton = document.getElementById('redirectPage');

    redirectPageButton.onclick = changeLocation;
    function changeLocation(e) {
        window.history.back();
    }
})();