function recordCars(array) {

    let parking = new Set();
    for (let car of array) {
        let split = car.split(', ')

        if (split[0] == 'IN') {
            parking.add(split[1]);
        }
        else {parking.delete(split[1]); }
    }
    console.log(Array.from(parking.entries())
    .map(x=>x[1])
    .sort((a,b)=>a.localeCompare(b))
    .join('\n'));
}

recordCars(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']);