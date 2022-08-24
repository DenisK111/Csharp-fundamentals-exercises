function sumEvenOdd(input){

    input = String(input);

    let oddSum = 0;
    let evenSum = 0;

    for (const digit of input) {
        

        let num = Number(digit);

        if (num % 2==0) {
            evenSum+=num;
        }
        else{
            oddSum+=num;
        }

    }

    return `Odd sum = ${oddSum}, Even sum = ${evenSum}`;


}

console.log(sumEvenOdd(12414));