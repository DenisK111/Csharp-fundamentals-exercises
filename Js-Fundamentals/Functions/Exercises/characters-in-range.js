function getCharsInRange(char1,char2){

    let index = 0;
    char1 = char1.charCodeAt(index);
    char2 = char2.charCodeAt(index);
    let minChar = Math.min(char1,char2);
    let maxChar = Math.max(char1,char2);

    let resultArray = [];

    for (let i = minChar+1; i < maxChar; i++) {
        
        resultArray.push(String.fromCharCode(i));
    }

    console.log(resultArray.join(' '));



}

getCharsInRange('C','#');