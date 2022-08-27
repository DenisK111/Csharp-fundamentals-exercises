function mirrorWords(string) {
    string = string.shift();
    let pairsRegex = /([@#])(?<word1>[A-Za-z]{2}[A-Za-z]+)\1\1(?<word2>[A-Za-z]{2}[A-Za-z]+)\1/g
    let matches = string.match(pairsRegex);

    if (matches == null) {
        console.log('No word pairs found!');
        console.log('No mirror words!');
        return;
    }

    console.log(`${matches.length} word pairs found!`);

    let wordObjs=[];
    pairsRegex = /([@#])(?<word1>[A-Za-z]{2}[A-Za-z]+)\1\1(?<word2>[A-Za-z]{2}[A-Za-z]+)\1/
    for (let match of matches) {

        let matching = pairsRegex.exec(match);
        let word1 = matching.groups.word1
        let word2 = matching.groups.word2;

        if(word1 == word2.split('').reverse().join('')){
            wordObjs.push([
               this.word1= word1,
                this.word2 =  word2,
                
            ]);
        }
        
    }

    if(wordObjs.length == 0){
        console.log('No mirror words!');
        return;
    }
    console.log('The mirror words are:');
    console.log(wordObjs.map(x=>`${x[0]} <=> ${x[1]}`).join(', '))

}

mirrorWords([
    '@mix#tix3dj#poOl##loOp#wl@@bong&song%4very$long@thong#Part##traP##@@leveL@@Level@##car#rac##tu@pack@@ckap@#rr#sAw##wAs#r#@w1r'
    ]
    );