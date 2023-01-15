// Write a JS function that calculates the date of the previous day by given year, month, and day.
// The input comes as three numeric parameters. The first element is the year, the second is the month and the third is the day.
// The output must be the return date of the previous day in the format: `{year}-{month}-{day}`

function calcDate(year,month,day){
    let date = new Date(year,month,day);
    date.setDate(date.getDate() - 1);
    return `${date.getFullYear()}-${date.getMonth()}-${date.getDate()}`
}

console.log(calcDate(1990,11,19));