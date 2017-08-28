var separators = ['.', ' ', '?', '\t', ',', ':', '!'];
var counterOfDeletedSymbols=0;
function editLine() {
    var originalLine;
    originalLine = document.getElementById("textLine").value + " ";
    alert("Линия без повторяющихся символов в слове: " + editLineByEachWord(originalLine));
}

function editLineByEachWord(originalLine) {
   var lastIndexOfSeparator = 0;
    var i = 0;
    for (i; i < originalLine.length; i++) {
        if (separators.indexOf(originalLine[i]) > -1) {            
            originalLine = editLineByCurrentWord(originalLine,i,lastIndexOfSeparator);
            i=i-counterOfDeletedSymbols;
            lastIndexOfSeparator = i+1;
        }

    }

    return originalLine;
}
function editLineByCurrentWord(originalLine,i,lastIndexOfSeparator) {

    var j = 0,
        k;
        currentWord = originalLine.slice(lastIndexOfSeparator, i); 
          
        counterOfDeletedSymbols=0;
        var repiteableSymbols = '';
          for (j; j < currentWord.length; j++) { 
           if(currentWord.lastIndexOf(currentWord[j])!=j){
           repiteableSymbols=repiteableSymbols+currentWord[j];
           }

          }
   
        for (j=0;j<originalLine.length;j++)
        {           
            if(repiteableSymbols.includes(originalLine[j]))
            {
            originalLine=originalLine.replace(originalLine[j], '');            
            j--
            counterOfDeletedSymbols++;
            }            
        }    
 
    return originalLine;
}

