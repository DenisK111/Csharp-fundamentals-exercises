using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int bhp, string regNumber)
        {
            Make = make;
            Model = model;
            RegistrationNumber = regNumber;
            HorsePower = bhp;

        }

        /*•	Make: string
•	Model: string
•	HorsePower: int
•	RegistrationNumber: string
*/

        public string Make { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public int HorsePower
        
        { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"HorsePower: {this.HorsePower}");
            sb.AppendLine($"RegistrationNumber: {this.RegistrationNumber}");
            return sb.ToString().Trim();
        }

    }
}