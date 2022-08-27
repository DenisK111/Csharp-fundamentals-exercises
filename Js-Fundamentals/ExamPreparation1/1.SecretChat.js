// On the first line of the input, you will receive the concealed message. After that, until the "Reveal" command is given, you will receive strings with instructions for different operations that need to be performed upon the concealed message to interpret it and reveal its actual content. There are several types of instructions, split by ":|:"
// "InsertSpace:|:{index}":
// Inserts a single space at the given index. The given index will always be valid.
// "Reverse:|:{substring}":
// If the message contains the given substring, cut it out, reverse it and add it at the end of the message. 
// If not, print "error".
// This operation should replace only the first occurrence of the given substring if there are two or more occurrences.
// "ChangeAll:|:{substring}:|:{replacement}":
// Changes all occurrences of the given substring with the replacement text.
// Input / Constraints
// On the first line, you will receive a string with a message.
// On the following lines, you will be receiving commands, split by ":|:".
// Output
// After each set of instructions, print the resulting string. 
// After the "Reveal" command is received, print this message:
// "You have a new text message: {message}"

function secretChat(array) {
    let message = array.shift();

    for (let entry of array) {
        let isPrint = true;
        if (entry == 'Reveal') {
            break;
        }

        let split = entry.split(':|:');

        let command = split[0];
        switch (command) {
            case 'Reverse':

                let substring = split[1];
                if(!message.includes(substring)){
                    console.log('error');
                    isPrint=false;
                }else{
                    let index = message.indexOf(substring);
                    message = message.split('');
                    message.splice(index,substring.length);
                    message = message.join('');
                    
                    substring = substring.split('').reverse().join('');
                    message = message.concat(substring);
                }
                break;
            case 'InsertSpace':

                let index = Number(split[1]);
                message = message.split('');
                message.splice(index,0,' ');
                message = message.join('');

                break;
            case 'ChangeAll':
                let substringC = split[1];
                let replacement = split[2];
                while(message.includes(substringC)){
                    message = message.replace(substringC,replacement);
                }

                break;

            default:
                break;
        }
        if(isPrint){
        console.log(message)
        }

    }

    console.log(`You have a new text message: ${message}`);
}

secretChat([
    'heVVodar!gniV',
    'ChangeAll:|:V:|:l',
    'Reverse:|:!gnil',
    'InsertSpace:|:5',
    'Reveal'
  ]);