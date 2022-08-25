function dictionary(json){
    let dictionary = [];

    for (let entry of json) {
        let jsonObj = JSON.parse(entry);

        let term =  Object.getOwnPropertyNames(jsonObj).shift();
        let definition = Object.values(jsonObj).shift();
       
        let obj = {
            term,
            definition,
            print(){
                console.log(`Term: ${this.term} => Definition: ${this.definition}`)
            }
        }

        if(dictionary.map(x=>x.term).includes(obj.term)){
            dictionary.find(x=>x.term == obj.term).definition = obj.definition;
        }
        else{
        dictionary.push(obj);
        }

    }

    dictionary.sort((a,b)=>{
        return a.term.localeCompare(b.term);
    }).forEach(x=>x.print());
}

dictionary([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Bus":"test"}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
    ]);