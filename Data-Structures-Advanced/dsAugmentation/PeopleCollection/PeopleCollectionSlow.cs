namespace CollectionOfPeople
{
    using System.Collections.Generic;
    using System.Linq;

    public class PeopleCollectionSlow : IPeopleCollection
    {
        private List<Person> _people = new List<Person>();
        public int Count => _people.Count;

        public bool Add(string email, string name, int age, string town)
        {
            if (Find(email) != null) return false;                       

            _people.Add(new Person()
            {
                Email = email,
                Name = name, 
                Age = age,
                Town = town
            });

            return true;
        }

        public bool Delete(string email)
        {
            return _people.Remove(Find(email));
        }

        public Person Find(string email)
        {
            return _people.FirstOrDefault(x=>x.Email == email);
        }

        public IEnumerable<Person> FindPeople(string emailDomain)
        {
            return _people.Where(x => x.Email.Split("@")[1] == emailDomain).OrderBy(x=>x.Email);
        }

        public IEnumerable<Person> FindPeople(string name, string town)
        {
            return _people.Where(x => x.Name == name && x.Town == town).OrderBy(e=>e.Email);
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
        {
            return _people.Where(x => x.Age >= startAge && x.Age <= endAge).OrderBy(e=>e.Age).ThenBy(x=>x.Email);
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
        {
            return _people.Where(x => x.Age >= startAge && x.Age <= endAge && x.Town == town).OrderBy(e => e.Age).ThenBy(x => x.Email);
        }
    }
}
