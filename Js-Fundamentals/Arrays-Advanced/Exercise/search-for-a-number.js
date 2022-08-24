// You will receive two arrays of integers. The second array is containing exactly three numbers. 
// The first number represents the number of elements you have to take from the first array (starting from the first one).
// The second number represents the number of elements you have to delete from the numbers you took (starting from the first one). 
// The third number is the number we search in our collection after the manipulations. 
// As output print how many times that number occurs in our array in the following format: 
// "Number {number} occurs {count} times."

function searchNum(array,opArray){

    let sliceNum = opArray[0];
    let deleteNum = opArray[1];
    let searchNum = opArray[2];

    let sliced = array.slice(0,sliceNum);
    sliced.splice(0,deleteNum);

    let filteredArray = sliced.filter(x=>x==searchNum);

    console.log(`Number ${searchNum} occurs ${filteredArray.length} times.`);


}

searchNum([5, 2, 3, 4, 1, 6],
    [5, 2, 3]);
    searchNum([7, 1, 5, 8, 2, 7],
        [3, 1, 5]);
