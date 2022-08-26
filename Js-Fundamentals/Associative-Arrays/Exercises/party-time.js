function party(array) {
    class Party {
        constructor() {
            this.Vips = [];
            this.Guests = [];
        }
    }
    let indexOfParty = array.indexOf('PARTY');
    let party = new Party();
    let invited = array.slice(0, indexOfParty)
    let attendees = array.slice(indexOfParty + 1);
    for (let entry of invited) {

        if (isNaN(entry[0])) {
            party.Guests.push(entry);
        }
        else {
            party.Vips.push(entry);
        }

    }

    for (let entry of attendees) {

        if (isNaN(entry[0])) {
            if (party.Guests.includes(entry)) {
                let index = party.Guests.indexOf(entry);
                party.Guests.splice(index, 1);
            }



        } else {
            if (party.Vips.includes(entry)) {
                let index = party.Vips.indexOf(entry);
                party.Vips.splice(index, 1);
            }
        }

    }
    let guests = party.Guests.slice(0);
let vips = party.Vips.slice(0);
let combined = vips.concat(guests);
let totalCount = combined.length;

console.log(totalCount);
console.log(combined.join('\n'));
}




party(['m8rfQBvl',
    'fc1oZCE0',
    'UgffRkOn',
    '7ugX7bm0',
    '9CQBGUeJ',
    '2FQZT3uC',
    'dziNz78I',
    'mdSGyQCJ',
    'LjcVpmDL',
    'fPXNHpm1',
    'HTTbwRmM',
    'B5yTkMQi',
    '8N0FThqG',
    'xys2FYzn',
    'MDzcM9ZK',
    'PARTY',
    '2FQZT3uC',
    'dziNz78I',
    'mdSGyQCJ',
    'LjcVpmDL',
    'fPXNHpm1',
    'HTTbwRmM',
    'B5yTkMQi',
    '8N0FThqG',
    'm8rfQBvl',
    'fc1oZCE0',
    'UgffRkOn',
    '7ugX7bm0',
    '9CQBGUeJ'
]);