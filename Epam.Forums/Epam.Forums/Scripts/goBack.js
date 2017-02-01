/// <reference path="jquery-3.1.1.min.js" />
'use strict';
(function () {
    var historyBack = document.getElementById('goBack');


    historyBack.onclick = goBack;


    function goBack() {
        window.history.back();
    }

})();
