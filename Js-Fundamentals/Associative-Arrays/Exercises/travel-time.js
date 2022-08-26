// Write a function that collects and orders information about travel destinations.
// As input, you will receive an array of strings.
// Each string will consist of the following information with the format:
// "Country name > Town name > Travel cost"

// The Country name will be a string, the Town name will be a unique string, Travel cost will be a number.
// If you receive the same Town name twice, you should keep the cheapest offer. Have in mind that one Country may have several Towns to visit.
// After you finish the organizational part, you need to let Steven know which destination point to visit first. The order will be as follows:  First sort Country names alphabetically and then sort by lowest Travel cost.

function travel(array){

    class Country{
        constructor(name){
            this.name=name;
            this.towns = new Map();
            this.print = () => {
                console.log(`${this.name} -> ${Array.from(this.towns.entries()).sort((a,b)=>a[1]-b[1]).map(x=>`${x[0]} -> ${x[1]}`).join(' ')}`)
            }
        }
    }

    let listOfCountries = [];
    for (const entry of array) {
        
        let split = entry.split(' > ');
        let name = split.shift();
        let town = split.shift();
        let cost = Number(split.shift());
        let country = listOfCountries.find(x=>x.name == name);
        if(country==undefined){
            country = new Country(name);
            country.towns.set(town,cost);
            listOfCountries.push(country);
        }else{
            if(country.towns.has(town)){
                let value = country.towns.get(town);
                country.towns.set(town,Math.min(value,cost));
            }else{
                country.towns.set(town,cost);
            }
        }
    }

    listOfCountries.sort((a,b)=>{
        let travelCostA = Array.from(a.towns.entries()).map(y=>y[1])
        .reduce((agg,el)=>{
            return agg+el
        },0);
        let travelCostB =  Array.from(b.towns.entries()).map(y=>y[1])
        .reduce((agg,el)=>{
            return agg+el
        },0);

        return a.name.localeCompare(b.name) || travelCostA - travelCostB;
    })
    .forEach(x=>x.print());


        
}

travel([
    'Bulgaria > Sofia > 25000',
    'Bulgaria > Sofia > 25000',
    'Kalimdor > Orgrimar > 25000',
    'Albania > Tirana > 25000',
    'Bulgaria > Varna > 25010',
    'Bulgaria > Lukovit > 10'
    ]);