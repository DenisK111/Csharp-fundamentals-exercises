function oddOccurances(array){


    let dictionary = new Map();
    array=array.split(' ').map(x=>x.toLowerCase());

    for (let entry of array) {

        if(dictionary.has(entry)){
            let value = dictionary.get(entry)
            dictionary.set(entry,++value);
        }

        else{
            dictionary.set(entry,1);
        }
        
    }

    let newDictionary=dictionary.entries();
    let dictArray = Array.from(newDictionary);
    console.log(dictArray.filter(x=>x[1] % 2 != 0).map(x=>x[0]).join(' '));
    

}

oddOccurances('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');