function showLoadingBar(num){

    let arr = Array(10).fill('.');

    let bars = num / 10;

    arr = arr.fill('%',0,bars);

    if (num<100){

        console.log(`${num}% [${arr.join('')}]`);
        console.log('Still loading...')

    }

    else{

        console.log(`${num}% Complete!`);
        console.log(`[${arr.join('')}]`);
    }

}

showLoadingBar(100);
