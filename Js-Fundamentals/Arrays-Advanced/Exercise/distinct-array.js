function distinct(array){

    let unique = array.filter((value, index, self) => self.indexOf(value) === index);
    console.log(unique.join(' '));

}

distinct([7, 8, 9, 7, 2, 3, 4, 1, 2]);
