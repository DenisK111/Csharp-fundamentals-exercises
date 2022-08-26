function company(array){

    class Company{
        constructor(name){
            this.name = name,
            this.employees = new Set();
            this.print = () =>{
                console.log(this.name);
                this.employees.forEach(x=>console.log(`-- ${x}`));
            }
        }
    }

    let companies = [];

    for (let company of array) {

        let split = company.split(' -> ');
        let name = split.shift();
        let employee = split.shift();
        let companyObj = companies.find(x=>x.name == name);
        if(companyObj == undefined){
            companyObj=new Company(name);
            companies.push(companyObj);
        }
        companyObj.employees.add(employee);
               
    }

    companies=companies.sort((a,b)=>{
        return a.name.localeCompare(b.name);
    })

    companies.forEach(x=>x.print());



}

company([
    'SoftUni -> AA12345',
    'SoftUni -> BB12345',
    'Microsoft -> CC12345',
    'HP -> BB12345'
    ]);