function topInteger(arr1){

    var resultArr = [];

    for (let i = 0; i < arr1.length-1; i++) {
              
         let isLargest = true;
        for (let j = i+1; j < arr1.length; j++) {
                 
            if (arr1[i]<=arr1[j]) {
                isLargest=false;
            }
            
            
            
        }

        if(isLargest)
            resultArr.push(arr1[i]);
    }

    resultArr.push(arr1[arr1.length-1]);

    console.log(resultArr.join(' '));


}

topInteger([14, 24, 3, 19, 15, 17]);