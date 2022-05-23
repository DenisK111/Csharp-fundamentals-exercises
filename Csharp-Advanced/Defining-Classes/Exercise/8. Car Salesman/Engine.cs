using System.Text;

namespace _8._Car_Salesman
{
    /*•	Model: a string property.
•	Power: an int property.
•	Displacement: an int property, it is optional.
•	Efficiency: a string property, it is optional.
*/
    public class Engine
    {
        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {

            Efficiency = efficiency;
            Displacement = displacement;

        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {

            Efficiency = efficiency;

        }

        public Engine(string model,int power, int displacement) : this(model,power)
        {
           
            Displacement = displacement;
            
        }

        public Engine(string model,int power)
        {
            Model = model;
            Power = power;
            Displacement = -1;
            Efficiency = "n/a";
        }


        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        /* "{CarModel}:
  {EngineModel}:
    Power: {EnginePower}
    Displacement: {EngineDisplacement}
    Efficiency: {EngineEfficiency}
  Weight: {CarWeight}
  Color: {CarColor}"*/
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
                      

            sb.AppendLine($"\t{this.Model}:");
            sb.AppendLine($"\t\tPower: {this.Power}");
            if (Displacement == -1)
            {
                sb.AppendLine("\t\tDisplacement: n/a");
            }

            else
            {
                sb.AppendLine($"\t\tDisplacement: {this.Displacement}");
            }
            sb.AppendLine($"\t\tEfficiency: {this.Efficiency}");

            return sb.ToString().TrimEnd();

        }
    }
}