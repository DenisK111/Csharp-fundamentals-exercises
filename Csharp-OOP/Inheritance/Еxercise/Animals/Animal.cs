using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        const string errorMessage = "Invalid input!";
        string sound = "...";
        private int age;
        bool isFailed;
        private GenderEnum gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender == "Male" ? GenderEnum.Male : gender == "Female" ? GenderEnum.Female : GenderEnum.invalid;
        }
        public bool IsFailed { get { return isFailed; } private set { isFailed = value; } }
        public string Name { get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    Error();
                }


                age = value;


            }
        }
        public GenderEnum Gender
        {
            get { return gender; }
            set

            {


                if (value == GenderEnum.invalid)
                {
                    Error();
                    return;
                }



                this.gender = value;
            }
        }

        protected virtual string Sound { get { return sound; } set { } }
        public enum GenderEnum
        {
            Male,
            Female,
            invalid
        }

        public string ProduceSound()
        {
            return this.Sound;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());

            return sb.ToString().TrimEnd();
        }

        private void Error()
        {
            isFailed = true;
            Console.WriteLine(errorMessage);

        }
    }
}
