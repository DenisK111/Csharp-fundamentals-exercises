function gladiators(array) {

    class Gladiator {
        constructor(name, technique, skill) {
            this.name = name;
            this.techniques = new Map([[technique, skill]]);
            this.getTotalSkillPoints = () =>{
                return Array.from(this.techniques.entries()).map(x=>x[1])
                .reduce((agg,el)=>{
                    return agg+el;
                },0);
            }
            this.print = () => { 
                let totalSkill = this.getTotalSkillPoints();

                console.log(`${this.name}: ${totalSkill} skill`);
                let iterator = Array.from(this.techniques.entries()).sort((a,b)=>{
                    return b[1] - a[1]
                    ||
                    a[0].localeCompare(b[0]);
                });
                iterator.forEach(x=>console.log(`- ${x[0]} <!> ${x[1]}`));
            }
        }
    }
    let gladiatorsArr = [];
    for (let entry of array) {


        if (entry == 'Ave Cesar') {
            break;
        }

        let read = entry.split(' -> ').length == 3 ? entry.split(' -> ') : entry.split(' vs ');
        let gladiator1 = read[0];
        if (read.length == 3) {
            let technique = read[1];
            let skill = Number(read[2]);
            createOrUpdateGladiator(gladiator1, technique, skill);
        }else{
            let gladiator2 = read[1];
            battle(gladiator1, gladiator2);
        }
      
    }

    gladiatorsArr
    .sort((a,b)=>{
        return b.getTotalSkillPoints() - a.getTotalSkillPoints()
        ||
        a.name.localCompare(b.name);
        
    })
    .forEach(x=>x.print())

    function createOrUpdateGladiator(name, technique, skill) {

        let gladiator = gladiatorsArr.find(x => x.name == name);
        if (gladiator == undefined) {
            gladiator = new Gladiator(name, technique, skill);
            gladiatorsArr.push(gladiator);
        } else if (gladiator.techniques.has(technique)) {
            let skillValue = gladiator.techniques.get(technique);
            gladiator.techniques.set(technique, Math.max(skill, skillValue));
        } else {
            gladiator.techniques.set(technique, skill);
        }


    }

    function battle(name1, name2) {
        
        let gladiator1 = gladiatorsArr.find(x => x.name == name1);
        let gladiator2 = gladiatorsArr.find(x => x.name == name2);

        if(gladiator1 == undefined || gladiator2 == undefined){
            return;
        }

        let glad2Techniques = Array.from(gladiator2.techniques.keys());
        let isBattle=false;
        for (let key of gladiator1.techniques.keys()) {
            if(glad2Techniques.includes(key)){
                isBattle=true;
                break;
            }
        }

        if(isBattle){
            let glad1Points = gladiator1.getTotalSkillPoints();
            let glad2Points = gladiator2.getTotalSkillPoints();

            if (glad1Points == glad2Points){
                return;
            }else if(glad1Points>glad2Points){
                gladiatorsArr.splice(gladiatorsArr.indexOf(gladiator2),1);
            }else{
                gladiatorsArr.splice(gladiatorsArr.indexOf(gladiator1),1);
            }
        }

    }
}

//gladiators([
    'Peter -> BattleCry -> 400',
    'Alex -> PowerPunch -> 300',
    'Stefan -> Duck -> 200',
    'Stefan -> Tiger -> 250',
    'Ave Cesar'
//]);


gladiators([
    'Peter -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 250',
    'Peter vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Maximilian',
    'Ave Cesar'
]);