function catalogue(array) {
    class Product {
        constructor(name, price) {
            this.name = name;
            this.price = price;
            this.print = () => {
                console.log(`  ${name}: ${price}`);
            }
        }
    }

    let dictionary = {};

    for (let entry of array) {
        let split = entry.split(' : ');
        let name = split.shift();
        let price = split.shift();
        let startingLetter = name[0];

        if (Object.keys(dictionary).includes(startingLetter)) {
            dictionary[startingLetter].push(new Product(name, price));
        }
        else {
            dictionary[startingLetter] = [new Product(name, price)];
        }

    }
    for (let [key, value] of Object.entries(dictionary).sort((a,b)=>a[0].localeCompare(b[0]))) {

        console.log(key);
        for (let item of value.sort((a,b)=>a.name.toLowerCase().localeCompare(b.name.toLowerCase()))) {
            item.print();

        }
    }
}

catalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
    ]
    );