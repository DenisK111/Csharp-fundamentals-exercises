namespace VaccOps.Models
{
    public class Patient
    {
        public Patient(string name, int height, int age, string town)
        {
            this.Name = name;
            this.Height = height;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Patient)
            {
                var entity = (Patient)obj;
                return entity.Name == this.Name;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
