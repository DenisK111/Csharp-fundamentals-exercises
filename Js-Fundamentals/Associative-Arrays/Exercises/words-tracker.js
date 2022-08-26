function wordCount(array) {
    let words = array.shift().split(' ');

    let wordsObj = {};

    for (let word of words) {
        wordsObj[word] = 0;
    }

    for (let entry of array) {
        if(wordsObj.hasOwnProperty(entry)){
            wordsObj[entry]++;
        }
    }

    let kvps = Object.entries(wordsObj);
    for (let [key,value] of kvps.sort((a,b)=>b[1]-a[1])) {
        console.log(`${key} - ${value}`);
    }


}

wordCount([
    'is the', 
    'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']);