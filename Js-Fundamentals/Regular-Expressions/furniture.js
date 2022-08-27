function furniture(array) {

    let items = [];
    for (let entry of array) {

        if (entry == 'Purchase') {
            break;
        }

        let regex = />>(?<name>[A-Z][A-Za-z]*)<<(?<price>[\d]+(\.?[\d]+)?)!(?<quantity>[\d]+)/g
        let match = regex.exec(entry);
        if (match != null) {
            let name = match.groups.name;
            let price = Number(match.groups.price);
            let quantity = Number(match.groups.quantity);
            items.push({
                name,
                price,
                quantity
            })
        }


    }
    console.log('Bought furniture:')
    items.forEach(x=>console.log(x.name))
    let totalPrice = items.map(x=>x.price * x.quantity).reduce((agg,el)=>{
        return agg+el;
    },0);
    console.log('Total money spend: ' + totalPrice.toFixed(2));
}

furniture(['>>Sofa<<312.23!3',
'>>TV<<300!5',
'>Invalid<<!5',
'Purchase']
);