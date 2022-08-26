function words(text){

    while(text.includes('#')){

        let index = text.indexOf('#');
        text = text.substring(index+1);
        let count = 0;
        for (const char of text) {
            if(char.includes('.') || char.includes(',') || char.includes(':') || char.includes('?') || char.includes('!') || char.includes(';')){
                console.log(text.substring(0,count));
                break;
            }
            if(char==' ' && count > 0){
                console.log(text.substring(0,count));
                break;
            }
            if(!isLetter(char)){
                break;
            }

            if(count == text.length-1){
                console.log(text.substring(0,count+1));
            }
           

            count++;
            
        }
    }


    function isLetter(char){

        if((char.charCodeAt(0)>= 'a'.charCodeAt(0) 
        && char.charCodeAt(0)<= 'z'.charCodeAt(0))
        || (char.charCodeAt(0)>= 'A'.charCodeAt(0) 
        && char.charCodeAt(0)<= 'Z'.charCodeAt(0))){
            return true;
        }
        return false;


    }
}

words('Nowadays everyone uses # to tag a #special word in #socialMedia');