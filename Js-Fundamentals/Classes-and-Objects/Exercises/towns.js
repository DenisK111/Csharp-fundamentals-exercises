function townObjectFactory(array) {

    let towns = [];
    for (let data of array) {
        let splitData = data.split(' | ');
        let town = splitData[0];
        let latitude = Number(splitData[1]).toFixed(2);
        let longitude = Number(splitData[2]).toFixed(2);

        let name = {
            town,
            latitude,
            longitude,

           
        }

        towns.push(name);

    }

    towns.forEach(el=>console.log(el));

}

townObjectFactory(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']);