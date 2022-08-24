function testPerfectNumber(num){

    function getPositiveDivisors(num){

        let arr = [];

        for (let i = 1; i < num; i++) {
            
            if(num%i == 0){
                arr.push(i);
            }
            
        }

        return arr;

    }

    let arr = getPositiveDivisors(num);

    if(num == arr.reduce((previousValue, currentValue) => previousValue + currentValue,
    0)){
        console.log('We have a perfect number!');
    }

    else{
        console.log('It\'s not so perfect.');
    }


}

