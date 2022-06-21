using Gym.Models.Athletes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete

    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;
        private int stamina;


        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            Stamina = stamina;
            NumberOfMedals = numberOfMedals;
        }

        public string FullName
        {
            get { return fullName; }
          private set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }

                fullName = value;
            }
        }



        public string Motivation
        {
            get { return motivation; }
           private set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }
                motivation = value;
            }
        }

        public int Stamina { get { return stamina; } protected set {

                if (value>100)
                {
                    stamina = 100;
                    throw new ArgumentException(ExceptionMessages.InvalidStamina);
                }

                stamina = value;
            } }

        public int NumberOfMedals
        {
            get { return numberOfMedals; }
           private set
            {

                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                numberOfMedals = value;
            }
        }

        public abstract void Exercise();
       
       
    }
}
