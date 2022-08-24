function factorialDivision(num1,num2){

    function getFactorial(num){

        let result = 1;
        for (let i = num; i > 1; i--) {
            
            result*=i;
        }

        return result;
    }

    num1 = getFactorial(num1);
    num2 = getFactorial(num2);

    let result = num1 / num2;

    console.log(result.toFixed(2));

}

factorialDivision(5,2);
factorialDivision(6,2);