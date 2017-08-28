'use strict';
(function () {
    var editButton = document.getElementById('editLine');

    editButton.onclick = editLine;
    function editLine() {
        var originalLine = document.getElementById('textLine').value,
            resultLine = document.getElementById('resultLine'),
            regex = /(\d+\.\d+)|(\d+)|(\+|\-|\/|\*|=)/g,
            symbol = '+-',
            result,
            counter = 0,
            item = 0,
            i,
            foundedItems = originalLine.match(regex),
            lasttItem = foundedItems[foundedItems.length - 1],
            firstItem = foundedItems[0];

        if (foundedItems === null) {
            return resultLine.value += ' Expression error';
        }
        if (symbol.indexOf(firstItem) === -1) {
            result = parseFloat(firstItem);
            counter++;
        }
        else {
            item++;
            result = parseFloat(firstItem.concat(foundedItems[1]));
        }

        for (i = 2; i < foundedItems.length; i += 2) {
            switch (foundedItems[i - counter]) {
                case '+':
                    {
                        result += parseFloat(foundedItems[i + item]);
                        continue;
                    }
                case '-':
                    {
                        result -= parseFloat(foundedItems[i + item]);
                        continue;
                    }
                case '/':
                    {
                        result /= parseFloat(foundedItems[i + item]);
                        continue;
                    }
                case '*':
                    {
                        result *= parseFloat(foundedItems[i + item]);
                        continue;
                    }
                case '=':
                    break;
                default:
                    return resultLine.value += ' Expression error';
            }
        }

        if (isNaN(result) || result === parseFloat(firstItem) || lasttItem !== '\=') {
            resultLine.value += ' Expression error';
        }
        else {
            resultLine.value += result.toFixed(2);
        }
    }
})();