function addDigits (num){

    let sum = 0;

    num = num.toString();

    for (const element of num) {

        let variable = Number(element);
     sum+=variable;
    }

    console.log(sum);

}

addDigits(245678);
addDigits(97561);
addDigits(543);
