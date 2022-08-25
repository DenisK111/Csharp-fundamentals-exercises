function employees(names) {


    class Employee {
        constructor(name, id) {
            this.name = name,
            this.id = id
            this.details = () => `Name: ${this.name} -- Personal Number: ${this.id}`;
        }
    }
    let employees = [];
    for (let name of names) {

        let employee = new Employee(name,name.length);
        employees.push(employee);
    }

    employees.forEach(e=>console.log(e.details()));

}

employees([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]);