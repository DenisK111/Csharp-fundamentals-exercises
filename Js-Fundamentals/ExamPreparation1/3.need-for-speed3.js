// On the first line of the standard input, you will receive an integer n – the number of cars that you can obtain. On the next n lines, the cars themselves will follow with their mileage and fuel available, separated by "|" in the following format:
// "{car}|{mileage}|{fuel}"
// Then, you will be receiving different commands, each on a new line, separated by " : ", until the "Stop" command is given:
// "Drive : {car} : {distance} : {fuel}":
// You need to drive the given distance, and you will need the given fuel to do that. If the car doesn't have enough fuel, print: "Not enough fuel to make that ride"
// If the car has the required fuel available in the tank, increase its mileage with the given distance, decrease its fuel with the given fuel, and print: 
// "{car} driven for {distance} kilometers. {fuel} liters of fuel consumed."
// You like driving new cars only, so if a car's mileage reaches 100 000 km, remove it from the collection(s) and print: "Time to sell the {car}!"
// "Refuel : {car} : {fuel}":
// Refill the tank of your car. 
// Each tank can hold a maximum of 75 liters of fuel, so if the given amount of fuel is more than you can fit in the tank, take only what is required to fill it up. 
// Print a message in the following format: "{car} refueled with {fuel} liters"
// "Revert : {car} : {kilometers}":
// Decrease the mileage of the given car with the given kilometers and print the kilometers you have decreased it with in the following format:
// "{car} mileage decreased by {amount reverted} kilometers"
// If the mileage becomes less than 10 000km after it is decreased, just set it to 10 000km and 
// DO NOT print anything.
// Upon receiving the "Stop" command, you need to print all cars in your possession in the following format:
// "{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt."
// Input/Constraints
// The mileage and fuel of the cars will be valid, 32-bit integers, and will never be negative.
// The fuel and distance amounts in the commands will never be negative.
// The car names in the commands will always be valid cars in your possession.
// Output
// All the output messages with the appropriate formats are described in the problem description.

function needForSpeed(array) {


    class Car {
        constructor(model, mileage, fuel) {
                this.model = model,
                this.mileage = mileage,
                this.fuel = fuel,
                this.print = () => {
                    console.log(`${this.model} -> Mileage: ${this.mileage} kms, Fuel in the tank: ${this.fuel} lt.`);
                }
        }
    }
    let countOfCars = Number(array.shift());
    let cars = [];
    for (let index = 0; index < countOfCars; index++) {

        let car = array.shift().split('|');
        let model = car[0];
        let mileage = Number(car[1]);
        let fuel = Number(car[2]);
        cars.push(new Car(model, mileage, fuel));

    }

    let command;
    while (command != 'Stop') {

        command = array.shift();

        let split = command.split(' : ');
        let order = split[0];
        let car = split[1];
        let distance, fuel;
        let carObj = cars.find(x => x.model == car);

        switch (order) {
            case 'Drive':
                distance = Number(split[2]);
                fuel = Number(split[3]);
                driveCar(carObj, fuel, distance);

                break;
            case 'Refuel':
                fuel = Number(split[2]);
                refuel(carObj, fuel);

                break;
            case 'Revert':
                distance = Number(split[2]);
                revert(carObj, distance);

                break;


        }

    }

    cars.forEach(x => x.print());

    function revert(carObj, distance) {
        // "Revert : {car} : {kilometers}":
        // Decrease the mileage of the given car with the given kilometers and print the kilometers you have decreased it with in the following format:
        // "{car} mileage decreased by {amount reverted} kilometers"
        // If the mileage becomes less than 10 000km after it is decreased, just set it to 10 000km and 
        // DO NOT print anything.

        carObj.mileage -= distance;
        if (carObj.mileage >= 10000) {
            console.log(`${carObj.model} mileage decreased by ${distance} kilometers`);
        }
        else {
            carObj.mileage = 10000;
        }
    }

    function refuel(carObj, fuel) {
        // "Refuel : {car} : {fuel}":
        // Refill the tank of your car. 
        // Each tank can hold a maximum of 75 liters of fuel, so if the given amount of fuel is more than you can fit in the tank, take only what is required to fill it up. 
        // Print a message in the following format: "{car} refueled with {fuel} liters"

        carObj.fuel += fuel;
        let overFueled = 0;
        if (carObj.fuel > 75) {
            overFueled = carObj.fuel - 75;
            carObj.fuel = 75;
        }

        console.log(`${carObj.model} refueled with ${fuel - overFueled} liters`);

    }

    function driveCar(car, fuel, distance) {
        if (car.fuel < fuel) {
            console.log("Not enough fuel to make that ride");
            return;
        }

        car.mileage += distance;
        car.fuel -= fuel;

        console.log(`${car.model} driven for ${distance} kilometers. ${fuel} liters of fuel consumed.`);

        if (car.mileage >= 100000) {
            console.log(`Time to sell the ${car.model}!`)
            cars.splice(cars.indexOf(car), 1);
        }

    }

}

needForSpeed([
    '3',
    'Audi A6|38000|62',
    'Mercedes CLS|11000|35',
    'Volkswagen Passat CC|45678|5',
    'Drive : Audi A6 : 543 : 47',
    'Drive : Mercedes CLS : 94 : 11',
    'Drive : Volkswagen Passat CC : 69 : 8',
    'Refuel : Audi A6 : 50',
    'Revert : Mercedes CLS : 500',
    'Revert : Audi A6 : 30000',
    'Stop'
]);