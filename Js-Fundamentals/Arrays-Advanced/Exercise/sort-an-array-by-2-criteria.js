function sortBy2Criteria(array) {




    array = array.sort((a, b) => {

        if ((a.length - b.length) != 0) { return a.length - b.length }
        return a.localeCompare(b);
    });

    console.log(array.join('\n'));

}

sortBy2Criteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
sortBy2Criteria(['test', 'Default', 'omen', 'Deny']);

