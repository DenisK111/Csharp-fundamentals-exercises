using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;
using WildFarm.Animals;


namespace WildFarm
{
    public static class Factory
    {
        public static IAnimal CreateAnimal(string type, string name, double weight, string livingRegion, string breed)
        {
            IAnimal animal = null;
            Enums.Felines felineEnum = Enum.Parse<Enums.Felines>(type);
            switch (felineEnum)
            {
                case Enums.Felines.Cat:
                    animal = new Cat(name, weight, livingRegion, breed);
                    break;
                case Enums.Felines.Tiger:
                    animal = new Tiger(name, weight, livingRegion, breed);
                    break;
            
            }
            return animal;
        }


        public static IAnimal CreateAnimal(string type, string name, double weight, double wingSize)
        {
            IAnimal animal = null;
            Enums.Birds birdsEnum = Enum.Parse<Enums.Birds>(type);

            switch (birdsEnum)
            {
                case Enums.Birds.Owl:
                    animal = new Owl(name, weight, wingSize);
                    break;
                case Enums.Birds.Hen:
                    animal = new Hen(name, weight, wingSize);
                    break;
            }

            return animal;
        }

        public static IAnimal CreateAnimal(string type, string name, double weight, string livingRegion)
        {
            IAnimal animal = null;
            Enums.MiceAndDogs miceAndDogsEnum = Enum.Parse<Enums.MiceAndDogs>(type);

            switch (miceAndDogsEnum)
            {
                case Enums.MiceAndDogs.Dog:
                    animal = new Dog(name, weight, livingRegion);
                    break;
                case Enums.MiceAndDogs.Mouse:
                    animal = new Mouse(name, weight, livingRegion);
                    break;
                
            }

            return animal;
        }

        public static IFood CreateFood(string foodName, int foodQty)
        {
            Enums.FoodNames foodEnum = Enum.Parse<Enums.FoodNames>(foodName);
            IFood food = null;
            switch (foodEnum)
            {
                case Enums.FoodNames.Vegetable:
                    food = new Vegetable(foodQty);
                    break;
                case Enums.FoodNames.Fruit:
                    food = new Fruit(foodQty);
                    break;
                case Enums.FoodNames.Meat:
                    food = new Meat(foodQty);
                    break;
                case Enums.FoodNames.Seeds:
                    food = new Seeds(foodQty);
                    break;
            }

            return food;
        }
    }
}
