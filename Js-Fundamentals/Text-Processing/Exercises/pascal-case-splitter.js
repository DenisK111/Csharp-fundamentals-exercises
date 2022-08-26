function pascalSplit(word){
    let array = [];

    let startIndex = 0;
    for(let index = 0;index<word.length;index++){

        if(word[index].charCodeAt(0) >= 'A'.charCodeAt(0)
         && word[index].charCodeAt(0) <= 'Z'.charCodeAt(0))
         {
            array.push(word.substring(startIndex,index));
            startIndex=index;
         }

         if(index == word.length-1){
            array.push(word.substring(startIndex,word.length));
         }
    }
    array.shift();
    console.log(array.join(', '));
}

pascalSplit('SplitMeIfYouCanHaHaYouCantOrYouCan');