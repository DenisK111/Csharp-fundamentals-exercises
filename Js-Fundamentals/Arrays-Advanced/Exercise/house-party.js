function party(array) {

    let namesArray = [];

    for (const element of array) {
        
        let elArray = element.split(' ');

        if(elArray.length === 3){

            if(namesArray.includes(elArray[0])){
                console.log(`${elArray[0]} is already in the list!`);
            }
            else{
                namesArray.push(elArray[0]);
            }

        }

        else{

            if(namesArray.includes(elArray[0])){
                namesArray.splice(namesArray.indexOf(elArray[0]),1);
            }

            else{
                console.log(`${elArray[0]} is not in the list!`);
            }

        }
        
    }

    console.log(namesArray.join('\n'));


}

party(['Allie is going!',
'George is going!',
'John is not going!',
'George is not going!']);