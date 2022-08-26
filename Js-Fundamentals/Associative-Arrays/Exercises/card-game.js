function cardValue(array) {
    class Player {
        constructor(name) {
            this.name = name,
                this.cards = new Set();
                this.printDetails=()=>{
                   let values = this.cards.values();
                   let sum = 0;
                   Array.from(values).forEach(x=>sum+=getCardValue(x));
                   console.log(`${this.name}: ${sum}`);
                }
        }
    }

    let values = {
        2: 2,
        3: 3,
        4: 4,
        5: 5,
        6: 6,
        7: 7,
        8: 8,
        9: 9,
        '10': 10,
        J: 11,
        Q: 12,
        K: 13,
        A: 14,
    }

    let multipliers = {
        S: 4,
        H: 3,
        D: 2,
        C: 1,
    }

    let allPlayers = [];

    for (let entry of array) {
        let split = entry.split(': ');
        let name = split.shift();
        let cards = split[0].split(', ')
        let player = allPlayers.find(x => x.name == name);
        if (player == undefined) {
            player = new Player(name);
            allPlayers.push(player);
        }
        cards.forEach(x=>player.cards.add(x))
        
       
    }
    allPlayers.forEach(x=>x.printDetails());

    function getCardValue(card) {
        let power = card[0];
        let value = card[1];
        if(card.length == 3){
                power=10,
                value=card[2]
        }
      return values[power] * multipliers[value];
       
    }

}

cardValue([
    'Peter: 2C, 4H, 9H, AS, QS',
    'Tomas: 3H, 10S, JC, KD, 5S, 10S',
    'Andrea: QH, QC, QS, QD',
    'Tomas: 6H, 7S, KC, KD, 5S, 10C',
    'Andrea: QH, QC, JS, JD, JC',
    'Peter: JD, JD, JD, JD, JD, JD'
    ]);