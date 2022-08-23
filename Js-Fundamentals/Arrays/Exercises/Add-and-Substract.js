function changeValues(array){

    let originalSum = sum(array);

    function sum(array){
        let sum = 0;
        for (const i of array) {
            sum+=i;
        }
        return sum;
    }
    for (let i = 0; i < array.length; i++) {
        
        if (array[i] % 2 == 0) {
            array[i]+=i;
        } else {
            array[i]-=i;
        }
    }

    let modifiedSum = sum(array);

    console.log(`[ ${array.join(', ')} ]`)
    console.log(originalSum);
    console.log(modifiedSum);


}

changeValues([5, 15, 23, 56, 35]);
changeValues([-5, 11, 3, 0, 2]);