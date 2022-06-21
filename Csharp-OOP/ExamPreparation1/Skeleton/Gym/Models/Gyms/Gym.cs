using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Equipment;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
       

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }

        public string Name
        {
            get { return name; }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }


        public int Capacity { get; }


        public double EquipmentWeight => Equipment.Select(x=>x.Weight).Sum();

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {


                athlete.Exercise();

            }
        }

        public string GymInfo()
        {
            /* "{gymName} is a {gymType}:
Athletes: {athleteName1}, {athleteName2}, {athleteName3} (…) / No athletes
Equipment total count: {equipmentCount}
Equipment total weight: {equipmentWeight} grams"
*/
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            if (Athletes.Count == 0)
            {
                sb.AppendLine("Athletes: No athletes");
            }

            else
            {
                sb.AppendLine($"Athletes: {string.Join(", ", Athletes.Select(x => x.FullName))}");
            }

            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();

        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}
