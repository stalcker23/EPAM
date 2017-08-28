'use strict';
(function () {
    var moveToRightButton = document.getElementsByClassName('moveToRightButton'),
        moveToLefttButton = document.getElementsByClassName('moveToLefttButton'),
        moveToRightAllButton = document.getElementsByClassName('moveToRightAllButton'),
        moveToLeftAllButton = document.getElementsByClassName('moveToLeftAllButton'),
        i = 0;

    for (; i < moveToRightButton.length; i++) {
        moveToRightButton[i].onclick = moveToRight;
        moveToLefttButton[i].onclick = moveToLeft;
        moveToRightAllButton[i].onclick = moveToRightAll;
        moveToLeftAllButton[i].onclick = moveToLeftAll;
    }



    function moveAll(target, destination, source) {
        var parentNode = target.closest('.butterflyControl'),
            sourceList = parentNode.querySelector(source),
            destinationList = parentNode.querySelector(destination),
            len = sourceList.options.length,
            n;

        if (len === 0) {
            alert('Нечего переместить');
        }

        for (n = 0; n < len; n++) {
            destinationList.appendChild(sourceList.options[n]);
            n--;
            len--;
        }

        destinationList.selectedIndex === -1;
    }
    function move(target, destination, source) {
        var parentNode = target.closest('.butterflyControl'),
            sourceList = parentNode.querySelector(source),
            destinationList = parentNode.querySelector(destination),
            len = sourceList.options.length,
            n;


        if (sourceList.options.selectedIndex === -1) {
            alert('Ничего не выбрано');
        }

        for (n = 0; n < len; n++) {
            if (sourceList.options[n].selected) {
                destinationList.appendChild(sourceList.options[n]);
                n--;
                len--;
            }
        }

        destinationList.selectedIndex = -1;
    }
    function moveToLeftAll(e) {
        moveAll(e.target, '.firstList', '.secondList');
    }

    function moveToRightAll(e) {
        moveAll(e.target, '.secondList', '.firstList');
    }

    function moveToLeft(e) {
        move(e.target, '.firstList', '.secondList');
    }

    function moveToRight(e) {
        move(e.target, '.secondList', '.firstList');
    }
})();