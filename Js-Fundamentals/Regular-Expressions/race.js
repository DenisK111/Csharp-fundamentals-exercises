function race(array){

    let participants = array.shift();
    participants=participants.split(', ');

    let participantsMap = new Map();

    for (let entry of participants) {
        participantsMap.set(entry,0);
    }


    for(let entry of array){
        if (entry == 'end of race')
        {break;}

        let name = entry.match(/[A-Za-z]/g).join('');
        let score = entry.match(/[\d]/g).map(Number).reduce((agg,el)=>{return agg+el},0);

        if(participantsMap.has(name)){
            let value = participantsMap.get(name);
            participantsMap.set(name,value+score);
        }
        

        
    }

    let sortedArray = Array.from(participantsMap.entries())
        .sort((a,b)=>{
            return b[1] - a[1];
        }).slice(0,3);

    console.log(`1st place: ${sortedArray[0][0]}`);
    console.log(`2nd place: ${sortedArray[1][0]}`);
    console.log(`3rd place: ${sortedArray[2][0]}`);

}

race(['George, Peter, Bill, Tom',
'G4e@55or%6g6!68e!!@ ',
'R1@!3a$y4456@',
'B5@i@#123ll',
'G@e54o$r6ge#',
'7P%et^#e5346r',
'T$o553m&6',
'end of race']);