using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Car_Salesman
{
    /* •	Model: a string property.
•	Engine: a property holding the engine object.
•	Weight: an int property, it is optional.
•	Color: a string property, it is optional.
*/
    class Car
    {
        public Car(string model, Engine engine, int weight,string color) : this(model, engine)
        {
            Color = color;
            Weight = weight;
        }
        public Car(string model,Engine engine,string color) : this(model,engine)
        {
            Color = color;
        }
        public Car(string model, Engine engine, int weight) : this(model,engine)
        {

            Weight = weight;
        }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Color = "n/a";
            Weight = -1;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }

        /* Your task is to print all the cars in the order they were received and their information in the format defined below. If any of the optional fields are missing, print "n/a" in its place:
"{CarModel}:
  {EngineModel}:
    Power: {EnginePower}
    Displacement: {EngineDisplacement}
    Efficiency: {EngineEfficiency}
  Weight: {CarWeight}
  Color: {CarColor}"
*/
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine(this.Engine.ToString());
            if (this.Weight == -1)
            {
                sb.AppendLine("\tWeight: n/a");
            }
            else
            {
            sb.AppendLine($"\tWeight: {this.Weight}");

            }
            sb.AppendLine($"\tColor: {this.Color}");
            
            return sb.ToString().TrimEnd();
        }
    }
}
