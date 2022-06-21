using Gym.Core.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gym.Models.Athletes;
using Gym.Repositories.Contracts;
using Gym.Models.Equipment.Contracts;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private readonly ICollection<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

       

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var desiredGym = gyms.First(x => x.Name == gymName);
            var validTypes = new string[] { "Boxer", "Weightlifter" };

            if (desiredGym.GetType().Name == "BoxingGym" && athleteType == "Boxer")
            {
                desiredGym.AddAthlete(new Boxer(athleteName, motivation, numberOfMedals));
            }

            else if (desiredGym.GetType().Name == "WeightliftingGym" && athleteType == "Weightlifter")
            {
                desiredGym.AddAthlete(new Weightlifter(athleteName, motivation, numberOfMedals));
            }

            else if (!validTypes.Contains(athleteType))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            else
            {
                return "The gym is not appropriate.";
            }

            return $"Successfully added {athleteType} to {gymName}.";

        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell" )
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            else if (equipmentType == "BoxingGloves")
            {
                equipment.Add(new BoxingGloves());
            }

            else
            {
                equipment.Add(new Kettlebell());
            }

            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            else if (gymType == "BoxingGym")
            {
                gyms.Add(new BoxingGym(gymName));
            }

            else
            {
                gyms.Add(new WeightliftingGym(gymName));
            }

            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.First(x => x.Name == gymName);
            var weight = gym.EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {weight:f2} grams.";

        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (gyms.Select(x=>x.Name).Contains(gymName) && equipment.Models.Select(x=>x.GetType().Name).Contains(equipmentType))
            {
                if (typeof(BoxingGloves).Name == equipmentType)
                {
                    gyms.First(x => x.Name == gymName).AddEquipment(new BoxingGloves());
                    
                }

                if (typeof(Kettlebell).Name == equipmentType)
                {
                    gyms.First(x => x.Name == gymName).AddEquipment(new Kettlebell());

                }

                equipment.Remove(equipment.Models.FirstOrDefault(x => x.GetType().Name == equipmentType));
                return $"Successfully added {equipmentType} to {gymName}.";




            }

            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment,equipmentType)); //CHECK LATER
            }

            
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var item in gyms)
            {
                sb.AppendLine(item.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.First(x => x.Name == gymName);
            gym.Exercise();
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }

        
    }
}
