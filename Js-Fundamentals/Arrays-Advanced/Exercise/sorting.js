function sort(array){

    array=array.map(Number);
    if(array.length<=1){
        console.log(array.join(' '));
        return;
    }

    array=array.sort((a,b)=>a-b);

    let smallArray = array.slice(0,array.length/2);
    let largeArray = array.slice(array.length/2,array.length);
    largeArray=largeArray.sort((a,b)=>b-a);

    let endArray = [];

    
    for (let i = 0; i < smallArray.length; i++) {
        
        endArray.push(largeArray[i]);
        endArray.push(smallArray[i]);        
    }

    if(array.length%2!=0){
        endArray.push(largeArray[largeArray.length-1]);
    }

    
    console.log(endArray.join(' '));

    

}

sort([1,5,3,2,7]);