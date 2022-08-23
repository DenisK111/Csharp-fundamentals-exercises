function longestSequence(arr) {

    let Maxlength = 1;
    let number = 0;
    let currLength = 1;

    for (let i = 1; i < arr.length ; i++) {

        if (arr[i-1] == arr[i]) {

            currLength++;
            if (currLength > Maxlength){
                number = arr[i];
                Maxlength=currLength;
            }


        }

        else
            currLength = 1;
        

    }

    let resultArr = [];

    for (let index = 0; index < Maxlength; index++) {
        resultArr.push(number);
        
    }

    console.log(resultArr.join(' '));

}

longestSequence([1, 1, 1, 2, 3, 1, 3, 3]);