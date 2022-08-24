// As a gladiator, Peter has a cool Inventory. He loves to buy new equipment. You are given Peter’s inventory with all of his equipment -> strings, separated by whitespace. 
// You may receive the following commands:
// ⦁	Buy {equipment}
// ⦁	Trash {equipment}
// ⦁	Repair {equipment}
// ⦁	Upgrade {equipment}-{upgrade}
// If you receive the Buy command, you should add the equipment at the last position in the inventory, but only if it isn't bought already.
// If you receive the Trash command, delete the equipment if it exists.
// If you receive the Repair command, you should repair the equipment if it exists and place it in the last position.
// If you receive the Upgrade command, you should check if the equipment exists and insert after it the upgrade in the following format: "{equipment}:{upgrade}".

function gladiator(array) {

    let inventory = array.shift();
    inventory = inventory.split(' ');

    for (let index = 0; index < array.length; index++) {

        let command = array[index].split(' ');
        let action = command[0];
        let equipment = command[1];

        switch (action) {
            case 'Buy':
                if (!inventory.includes(equipment)) {
                    inventory.push(equipment);
                }
                break;
            case 'Trash':
                inventory = inventory.filter(x => x !== equipment);

                break;
            case 'Repair':
                if (inventory.includes(equipment)) {
                    inventory = inventory.filter(x => x !== equipment);
                    inventory.push(equipment);
                }
                break;
            case 'Upgrade':
                let split = equipment.split('-');
                let item = split[0];
                let upgrade = split[1];

                if(inventory.includes(item)){
                    let index = inventory.indexOf(item);
                    inventory.splice(index+1,0,`${item}:${upgrade}`);
                }

                break;

            default:
                break;
        }

    }

    console.log(inventory.join(' '));


}

gladiator(['SWORD Shield Spear',
'Buy Bag',
'Trash Shield',
'Repair Spear',
'Upgrade SWORD-Steel']);