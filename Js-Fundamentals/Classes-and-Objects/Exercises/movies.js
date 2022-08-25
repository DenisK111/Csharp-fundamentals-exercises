function addMovies(array) {

    let moviesArray = [];
    let addSeparator = 'addMovie'
    let directorSeparator = 'directedBy';
    let dateSeparator = 'onDate';

    for (let movie of array) {

        let entry;
        if (movie.includes(addSeparator)) {
            
            let movieEntry = movie.slice(addSeparator.length).trim();
            checkAndAddMovie(movieEntry);

            continue;
        }

        if (movie.includes(directorSeparator)) {
            entryName = getMovieName(directorSeparator, movie);
            
            if (checkIfInMoviesArray(entryName)) {
                moviesArray
                    .find(x => x.name == entryName)
                    .director
                    =
                    getMovieData(directorSeparator, movie);
            }
            continue;
        }

        if (movie.includes(dateSeparator)) {
            entryName = getMovieName(dateSeparator, movie);
            
            if (checkIfInMoviesArray(entryName)) {
                moviesArray
                    .find(x => x.name == entryName)
                    .date
                    =
                    getMovieData(dateSeparator, movie);
            }
        }
    }

    let eligibleMovies = moviesArray
        .filter(movie => movie.date != undefined && movie.director != undefined);


        for (let movie of eligibleMovies) {
            console.log(JSON.stringify(movie));
        }
    
        

    function checkAndAddMovie(movieEntry) {
        if (!checkIfInMoviesArray(movieEntry)) {
            addMovie(movieEntry);
        }
    }

    function addMovie(name) {
        moviesArray.push(createMovie(name));
    }
    function getMovieData(separatorString, movie) {
        return movie.slice(movie.indexOf(separatorString) + separatorString.length, movie.length)
            .trim()
    }

    function checkIfInMoviesArray(entryName) {
        return moviesArray.map(x => x.name).includes(entryName);
    }
    function getMovieName(separatorString, movie) {

        return movie.slice(0, movie.indexOf(separatorString)).trim();

    }
    function createMovie(name) {
        let movie = {
            name
            
        }

        return movie;

    }

}
addMovies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]);