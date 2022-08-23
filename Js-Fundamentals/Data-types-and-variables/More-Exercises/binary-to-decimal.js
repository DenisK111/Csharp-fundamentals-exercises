function binaryToDecimal(binaryNum){

    let result = 0;

    for (let i = 0; i < binaryNum.length; i++) {
        
        if (binaryNum[binaryNum.length-1-i] == 1) {

            result+=Math.pow(2,i);
            
        }
    }

    console.log(result);

}

binaryToDecimal('00001001');
binaryToDecimal('11110000');