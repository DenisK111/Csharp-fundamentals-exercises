function generateMatrix(num){

    let symbol = num;
    for (let row = 0; row < num; row++) {
        
        let arr = [];

        for (let col = 0; col < num; col++) {
            
            arr.push(symbol);
            
        }

        console.log(arr.join(' '));
        
    }

}

generateMatrix(7);