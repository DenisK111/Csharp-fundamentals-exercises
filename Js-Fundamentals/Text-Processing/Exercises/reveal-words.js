function words(array,text){

    let split = array.split(', ');
while(text.includes('*')){
    for(let entry of split){
        text = text.replace('*'.repeat(entry.length),entry);
    }
}
console.log(text);

}

words('great, learning',
'softuni is ***** place for ******** new programming languages');