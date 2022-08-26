function cutReverse(word){

    let string1 = word.substring(0,word.length/2);
    let string2 = word.substring(word.length/2);

    console.log(reverseString(string1));
    console.log(reverseString(string2));
    function reverseString(str) {
        return str.split("").reverse().join("");
    }
}
cutReverse('tluciffiDsIsihTgnizamAoSsIsihT');