function passwordValidator(word) {
    let isValid = true;

    if (word.length < 6 || word.length > 10) {
        console.log('Password must be between 6 and 10 characters');
        isValid=false;
    }
    let errorLogged = false;
    let numCount = 0;
    for (const char of word) {
        
        if(!isNaN(char)){
            numCount++;
        }
        let asciiValue = char.codePointAt(0);

      if (!errorLogged
        && !(asciiValue >= 'a'.codePointAt(0) && asciiValue <= 'z'.codePointAt(0)) 
        && !(asciiValue >= 'A'.codePointAt(0) && asciiValue <= 'Z'.codePointAt(0))
        && isNaN(char))
        {
            console.log('Password must consist only of letters and digits');
            errorLogged = true;
            isValid=false;
        }

    }

    if  (numCount<2){
        console.log('Password must have at least 2 digits');
        isValid=false;
    }

    if(isValid){
        console.log('Password is valid');
    }


}

passwordValidator('logIn');
passwordValidator('MyPass123');
passwordValidator('Pa$s$s');