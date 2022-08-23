function equalSum(arr1) {

    function sum(arr) {

        let sum = 0;

        for (const i of arr) {
            sum += i;
        }

        return sum;
    }


    let resultArr = [];
    for (let i = 0; i < arr1.length; i++) {
        
        if(sum(arr1.slice(0,i)) == sum(arr1.slice(i+1,arr1.length)))
        resultArr.push(i);
    }

    let result = resultArr.length == 0 ? 'no' : resultArr.join('\n');

    console.log(result);



}

equalSum([10, 5, 5, 99, 3, 4, 2, 5, 1, 1, 4]);