// Write a function that takes two positive numbers as input and compute the greatest common divisor.	
// The input comes as two positive integer numbers.
// The output should be printed on the console.


function gcg(num1,num2){

    let index = 2;
    let gcg = 1;
    while(Math.min(num1,num2) >= index){
        if (num1 % index === 0 && num2 % index === 0) {
            gcg = index;
        }
        
        index++;
    }

    return gcg;
}

console.log(gcg(5,10));
console.log(gcg(9,15));