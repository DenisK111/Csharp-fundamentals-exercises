function dungeonestDark(arr) {

    let string = arr[0];

    let initialHealth = 100;
    let health = initialHealth;
    let coins = 0;
    let bestRoom = 0;
    let stringArr = string.split('|')
    let isDead = false;
    for (let i = 0; i < stringArr.length; i++) {

        let roomParts = stringArr[i].split(' ');

        let monsterItem = roomParts[0];
        let value = Number(roomParts[1]);

        switch (monsterItem) {
            case 'potion':
                if (health + value > initialHealth) {
                    value = initialHealth - health;

                }
                health += value;
                console.log(`You healed for ${value} hp.`);
                console.log(`Current health: ${health} hp.`);
                break;
            case 'chest':
                console.log(`You found ${value} coins.`);
                coins += value;
                break;
            default:
                health -= value;
                if (health > 0)
                    console.log(`You slayed ${monsterItem}.`);
                else {
                    console.log(`You died! Killed by ${monsterItem}.`)
                    isDead = true;
                    bestRoom = i+1;
                }


                break;
        }

        if (isDead) break;

    }

    if (isDead) console.log(`Best room: ${bestRoom}`);
    else {
        console.log('You\'ve made it!');
        console.log(`Coins: ${coins}`);
        console.log(`Health: ${health}`);

    }


}

dungeonestDark(["cat 10|potion 30|orc 10|chest 10|snake 25|chest 110"]);

//You have initial health 100 and initial coins 0. You will be given a string, representing the dungeon's rooms. Each room is separated with '|' (vertical bar): "room1|room2|room3…"
// Each room contains - an item or a monster; and a number. They are separated by a single space.
// ("item/monster number").
// If the first part is "potion":
// You are healed with the number in the second part. However, your health cannot exceed your initial health (100).
// Print: `You healed for {healing-number} hp.`
// After that, print your current health: `Current health: {number} hp.`
// If the first part is "chest":
// You have found some coins, the number in the second part.
// Print: `You found {coins} coins.`
// In any other case, you are facing a monster, you are going to fight.
// The second part of the room contains the attack of the monster, and the first the monster's name. You should remove the monster's attack from your health.
// your healt.
//If you are not dead (health > 0) you have slain the monster, and you should print:
//                                   `You slayed {monster-name}.`
// If you have died, print: `You died! Killed by {monster-name}.` and your quest is over.
// Print the best room you`ve to manage to reach: `Best room: {room}`.
// If you managed to go through all the rooms in the dungeon, print on the next three lines:
// "You've made it!"
// "Coins: {coins}"
// "Health: {health}"
// Input
// You receive an array with one element- string, representing the dungeon's rooms, separated with '|' (vertical bar): ["room1|room2|room3…"].


