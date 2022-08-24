function checkPalindrome(array){

    for (const num of array) {
     
        let entry = String(num);
        let isPalindrome=true;
        for (let i = 0; i <= entry.length / 2 -1 ; i++) {
            if(entry[i] != entry[entry.length-1-i]){
                isPalindrome=false;
                break;
            }
            
        }

        console.log(isPalindrome);
    }

}

checkPalindrome([123,323,421,121]);