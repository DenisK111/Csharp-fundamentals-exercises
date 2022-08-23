function printChessBoard(num) {

    console.log('<div class="chessboard">');
    let black = '<span class="black"></span>';
    let white = '<span class="white"></span>';

    for (let i = 1; i <= num; i++) {

        console.log('<div>');
        if (i % 2 != 0) {
            for (let odd = 1; odd <= num; odd++) {
                if (odd % 2 != 0) {
                    console.log(black);

                }

                else console.log(white);


            }

        }
        else {
            for (let even = 1; even <= num; even++) {
                if (even % 2 != 0) {
                    console.log(white);

                }

                else console.log(black);


            }

        }
        console.log('</div>');
    }


    console.log('</div>')
}