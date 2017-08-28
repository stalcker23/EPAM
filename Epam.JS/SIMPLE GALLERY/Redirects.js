'use strict';
(function() {
    var deadline = 2,
        pauseButton = document.getElementById('pauseTimer'),
        item = true;



    pauseButton.onclick = pauseTimer;

    function pauseTimer(e) {
        if (item) {
            item = false;
            pauseButton.value = 'Start';
        }
        else {
            item = true;
            pauseButton.value = 'Pause';
        }
    }

    initializeClock('clockdiv', deadline);

    function initializeClock(id, endtime) {
        var clock = document.getElementById(id),
            counter = -1,
            t;

        function updateClock() {
            if (item) {
                counter++;
                t = endtime - counter;
                clock.innerText = t;
                if (t <= 0) {
                    window.location.replace(document.getElementById('text').textContent);
                    history.pushState(null, document.title.textContent, document.title.textContent);
                }
            }
        }
        updateClock();
        setInterval(updateClock, 1000);
    }
})();