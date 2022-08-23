function rotate(arr1,rotations){



for (let i = 0; i < rotations; i++) {
    
let element = arr1.shift();
arr1.push(element);
    
}

console.log(arr1.join(' '));

}

rotate([51, 47, 32, 61, 21], 2);
