function train(array){

    let wagons = array.shift();
    let capacity = Number(array.shift());

    wagons = wagons.split(' ').map(Number);

    for (const input of array) {

        let command = input.split(' ');

        if(command.length === 2){

            wagons.push(Number(command[1]));
        }
        else{
            for (let i = 0; i < wagons.length; i++) {
                
                if(Number(command[0]) + wagons[i] <= capacity){
                    wagons[i] += Number(command[0]);
                    break;
                }
            }
        }
        
    }

    console.log(wagons.join(' '));

}

train(['32 54 21 12 4 0 23',
'75',
'Add 10',
'Add 0',
'30',
'10',
'75']);