function getResult(num1,num2,num3){


    return substract(add(num1,num2),num3);

    function add(num1,num2){

        return num1+num2;
    }

    function substract(num1,num2){

        return num1-num2;
    }


}

console.log(getResult(3,1,2));