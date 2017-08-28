'use strict';
(function () {
    var redirectToStartPageButton = document.getElementById('redirectToStart'),
        windowCloseButton = document.getElementById('windowClose');

    redirectToStartPageButton.onclick = changeLocation;
    windowCloseButton.onclick = windowClose;
    function changeLocation(e) {
        window.location = document.getElementById('text').textContent;
    }
    function windowClose(e) {
        window.close();
    }
})();