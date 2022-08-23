function iS(array) {
    let filteredArray=[];
    do {            
        filteredArray = array;
        array = array.filter((x, i) => x >= array[i - 1 >= 0 ? i-1 : 0]);
    }
    while (filteredArray.length != array.length);
    console.log(filteredArray.join(' '));
}

iS([20, 3, 2, 15, 6, 1]);
iS([1, 2, 3, 4]);