function wall(nums) {

    let array = nums.map(Number);
    let concrete = 195;
    let costPerConcrete = 1900;
    let concreteArray = [];
    array = array.filter(x => x < 30);
    while (array.length > 0) {

        concreteArray.push(concrete * array.length);
        array = array.map(x => {
            return x + 1;
        });

        array = array.filter(x => x < 30);
    }

    let totalCost = concreteArray.reduce((agg, el) => agg + el, 0) * costPerConcrete;
    console.log(concreteArray.join(', '));
    console.log(`${totalCost} pesos`);
}

wall([21, 25, 28]);