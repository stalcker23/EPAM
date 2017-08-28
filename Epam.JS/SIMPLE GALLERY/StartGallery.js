'use strict';
(function() {
    var pauseButton = document.getElementById('openPage');

    pauseButton.onclick = openWindow;

    function openWindow() {
        window.open(document.getElementById('text').textContent);
    }
})();