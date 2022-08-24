// Write a function that receives an array of integers and an array of string commands and executes them over the array. The commands are as follows:
// ⦁	add <index> <element> – adds element at the specified index (elements right from this position inclusively are shifted to the right).
// ⦁	addMany <index><element 1> <element 2> … <element n> – adds a set of elements at the specified index.
// ⦁	contains <element> – prints the index of the first occurrence of the specified element (if exists) in the array or -1 if the element is not found.
// ⦁	remove <index> – removes the element at the specified index.
// ⦁	shift <positions> – shifts every element of the array the number of positions to the left (with rotation).
// ⦁	For example, [1, 2, 3, 4, 5] -> shift 2 -> [3, 4, 5, 1, 2]
// ⦁	sumPairs – sums the elements in the array by pairs (first + second, third + fourth, …).
// ⦁	For example, [1, 2, 4, 5, 6, 7, 8] -> [3, 9, 13, 8].
// ⦁	print – stop receiving more commands and print the last state of the array in the following format:
//          `[ {element1}, {element2}, …elementN} ]`
//   Note: The elements in the array must be joined by comma and space (, ).


function arrayManipulator(array, commands) {

    for (let i = 0; i < commands.length; i++) {

        let command = commands[i].split(' ');

        let action = command[0];

        switch (action) {
            case 'add':
                array.splice(Number(command[1]), 0, Number(command[2]));
                break;
            case 'addMany':
                array.splice(Number(command[1]), 0, ...command.slice(2, command.length).map(Number))
                break;
            case 'contains':
                console.log(array.indexOf(Number(command[1])));
                break;

            case 'remove':
                array.splice(Number(command[1]), 1);
                break;
            case 'shift':
                for (let index = 0; index < Number(command[1]); index++) {
                    let item = array.shift();
                    array.push(item);
                }
                break;
            case 'sumPairs':

                let newArray = [];

                for (let index = 0; index < array.length; index += 2) {

                    if (index + 1 == array.length) {
                        newArray.push(array[index]);
                        break;
                    }

                    newArray.push(array[index] + array[index + 1])

                }

                array = newArray.slice(0);

                break;
            case 'print':

                console.log(`[ ${array.join(', ')} ]`);
                return;

        }

    }

}

arrayManipulator([1, 2, 4, 5, 6, 7],
    ['sumPairs','add 1 8', 'contains 1', 'contains 3', 'print']);
arrayManipulator([1, 2, 3, 4, 5],
    ['sumPairs','addMany 5 9 8 7 6 5', 'contains 15', 'remove 3', 'shift 1', 'print']);