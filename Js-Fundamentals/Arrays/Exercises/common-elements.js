function commonElements(arr1,arr2){

    let resultArr = [];
    for (const i of arr1) {
        if (arr2.includes(i)) {
            resultArr.push(i);
        }
    }

    console.log(resultArr.join('\n'));

}

commonElements(['Hey', 'hello', 2, 4, 'Peter', 'e'],
['Petar', 10, 'hey', 4, 'hello', '2']);