// Write a function that takes an integer number as an input and check if all the digits in a given number are the same or not.
// Print on the console true if all numbers are the same and false if not. On the next line print the sum of all digits.
// The input comes as an integer number.
// The output should be printed on the console.

function sameNumbers(number){
    let numberAsString = String(number)

    let firstLetter = numberAsString[0];

    let isSame = true;
    let sum = 0;
    for (const i of numberAsString) {
        if (i !== firstLetter) {
            isSame=false;            
        }
        sum+=Number(i);
    }

    console.log(isSame);
    console.log(sum);
}

sameNumbers(2222222);
sameNumbers(1234);