function storeProvision(inStock, ordered) {

    let objStore = [];

    for (let index = 0; index < inStock.length; index += 2) {

        let item = createItem(inStock[index],Number(inStock[index+1]));

        objStore.push(item);
    }
    let listOfNames = objStore.map(el => el.name);
    for (let i = 0; i < ordered.length; i += 2) {

       

        if (listOfNames.includes(ordered[i])) {

            objStore
                .find(x => x.name == ordered[i])
                .quantity += Number(ordered[i + 1]);
        }
        else {
            let item = createItem(ordered[i],Number(ordered[i+1]));
            objStore.push(item);
        }
    }

    objStore.forEach(x=>x.print())

    function createItem(name,quantity){

        let item = {
            name,
            quantity,
            print(){
                console.log(`${this.name} -> ${this.quantity}`)
            }
        }

        return item;
    }

}

storeProvision([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]);