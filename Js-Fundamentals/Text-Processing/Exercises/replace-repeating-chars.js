function replaceChars(word) {

    for (let index = 0; index < word.length - 1; index++) {

        if (word[index] == word[index + 1]) {
            let wordArr = word.split('');
            wordArr.splice(index + 1,1);
            word = wordArr.join('');
            index--;
        }

    }
    console.log(word);
}

replaceChars('aaaaabbbbbcdddeeeedssaa');
