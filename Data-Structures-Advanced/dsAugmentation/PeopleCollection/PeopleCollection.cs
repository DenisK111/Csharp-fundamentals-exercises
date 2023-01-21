namespace CollectionOfPeople
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PeopleCollection : IPeopleCollection
    {
      
        private Dictionary<string, Person> _peopleByEmail = new Dictionary<string, Person>();
        private Dictionary<string, SortedSet<Person>> _peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();  
        private Dictionary<string, SortedSet<Person>> _peopleByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        private SortedDictionary<int,SortedSet<Person>> _peopleByAgeRange = new SortedDictionary<int, SortedSet<Person>>();


        public int Count => _peopleByEmail.Count;


        
        private string GenerateNameTownKey(string name, string town)
        {
            return $"{name}!{town}";
        }
        public bool Add(string email, string name, int age, string town)
        {
            if (_peopleByEmail.ContainsKey(email)) return false;

            var person = new Person()
            {
                Email = email,
                Name = name,
                Age = age,
                Town = town

            };

            _peopleByEmail.Add(email, person);
            var domain = email.Split("@")[1];
            this._peopleByEmailDomain              
                .AppendValueToKey(domain,person);
            this._peopleByNameAndTown
                .AppendValueToKey(GenerateNameTownKey(name,town),person);
            this._peopleByAgeRange
                .AppendValueToKey(person.Age, person);

            return true;
        }

        public bool Delete(string email)
        {
            var person = this.Find(email);
            if(person == null) return false;
            _peopleByEmailDomain[email.Split("@")[1]].Remove(person);
            _peopleByNameAndTown[GenerateNameTownKey(person.Name, person.Town)].Remove(person);
            _peopleByAgeRange[person.Age].Remove(person);
           return _peopleByEmail.Remove(email);
        }

        public Person Find(string email)
        {
            return _peopleByEmail.GetValueOrDefault(email);
        }

        public IEnumerable<Person> FindPeople(string emailDomain) => _peopleByEmailDomain.GetValuesForKey(emailDomain);
       

        public IEnumerable<Person> FindPeople(string name, string town) => _peopleByNameAndTown.GetValuesForKey(GenerateNameTownKey(name,town));
        

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
        {
            return this._peopleByAgeRange
                .SkipWhile(x=>x.Key<startAge)
                .TakeWhile(x=>x.Key<=endAge)
                .SelectMany(x=>x.Value);      
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
        {
            var result = this._peopleByAgeRange
                .SkipWhile(x => x.Key < startAge)
                .TakeWhile(x => x.Key <= endAge);

            foreach (var kvp in result)
            {
                foreach (var item in kvp.Value)
                {
                    if (item.Town == town)
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
