using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private double health;
        private double armor;
        
        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor =  armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        // TODO: Implement the rest of the class.

        public string Name { get { return name; } private set {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            } }
        public double BaseHealth { get; }
        public double Health
        {
            get { return health; }
            set
            {
               
                if (value <= 0)
                {
                    health = 0;
                    IsAlive = false;
                }

                else if (value > BaseHealth)
                {
                    health = BaseHealth;
                }

                else
                {
                    health = value;
                }
            }
        }
        public double BaseArmor { get; }
        public double Armor
        {
            get { return armor; }
            protected set
            {
               
                    if (value < 0)
                    {
                        armor = 0;
                    }

                    else if (value > BaseArmor)
                    {
                        armor = BaseArmor;
                    }

                    else
                    {
                        armor = value;
                    }
               
            }
        }
        public double AbilityPoints { get; protected set; }

        public Bag Bag { get; private set; }


        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (Armor > hitPoints)
            {
                Armor -= hitPoints;
                return;

            }

            else if (Armor <= hitPoints)
            {
                hitPoints -= Armor;
                Armor = 0;
            }

            if (Health > hitPoints)
            {
                Health -= hitPoints;
            }

            else
            {
                Health = 0;
                IsAlive = false;
            }

            return;
        }

        public void UseItem(Item item)
        {

            EnsureAlive();
            item.AffectCharacter(this);
        }

    }
}