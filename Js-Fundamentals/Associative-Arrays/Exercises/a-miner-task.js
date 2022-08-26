function mining(array){

    let map = new Map();

    for (let index = 0; index < array.length; index+=2) {
        if(map.has(array[index])){
        let currValue = map.get(array[index]);
        map.set(array[index],currValue+Number(array[index+1]))
        }
        else{
            map.set(array[index],Number(array[index+1]));
        }
        
    }
    let output = Array.from(map)
    output.forEach(x=>console.log(`${x[0]} -> ${x[1]}`));

    
}

mining([
    'Gold',
    '155',
    'Silver',
    '10',
    'Copper',
    '17'
    ]);