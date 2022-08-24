function bomb(array,specialNum){

    let num = specialNum[0];
    let power = specialNum[1];
    
    while(array.includes(num)){

        let index = array.indexOf(num);
        let startIndex = index-power;
        let detonated = 1 + power * 2;

        if(startIndex<0){
            detonated+=startIndex;
            startIndex=0;
        }
    

         array.splice(startIndex,detonated);


    }

    console.log(array.reduce((acc,el)=>{
        return acc+el;
    },0));

}


bomb([1,4, 2, 2, 4, 2, 2, 2, 9],
    [4, 2]);