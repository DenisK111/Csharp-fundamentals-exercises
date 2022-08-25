function inventory(array){
    
    class Hero{
        constructor(name,level,items){
            this.name=name;
            this.level=level;
            this.items=items;
            this.print = () => {
                console.log(`Hero: ${this.name}`);
                console.log(`level => ${this.level}`);
                console.log(`items => ${this.items.join(', ')}`);
            }
        }
    }

    let heroRegisrty = [];


    for (let entry of array) {

        let split = entry.split(' / ');
        let name = split.shift();
        let level = Number(split.shift());
        let items = split.shift().split(', ');
        
        heroRegisrty.push(new Hero(name,level,items));
        
    }

    heroRegisrty.sort((a,b)=>{
        return a.level - b.level;
    }).forEach(x=>x.print());
}

inventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]);