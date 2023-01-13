// Write a function that calculates how long it takes a student to get to university. 
// The function takes three numbers:
// ⦁	The first is the number of steps the student takes from their home to the university
// ⦁	Тhe second number is the length of the student's footprint in meters
// ⦁	Тhe third number is the student speed in km/h
// Every 500 meters the student rests and takes a 1-minute break.
// Calculate how long the student walks from home to university and print on the console the result in the following format: `hours:minutes:seconds`.
// The input comes as three numbers.
// The output should be printed on the console.


function timeToWalk(steps,footprintLthInM,stdSpeed){
    let distanceInM = steps * footprintLthInM;  
    let distanceInKm = distanceInM / 1000;
    let kmPerSec = stdSpeed / 3600;
    let timeInSec = distanceInKm / kmPerSec + 1;
    timeInSec+=(Math.floor(distanceInM/500)) * 60;
    let date = new Date(0);
    date.setSeconds(timeInSec);    
    let timeString = date.toISOString();   
    return timeString.substring(11, 19);
}

console.log(timeToWalk(2564, 0.70, 5.5))
