using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses

{

    /* •	Model: a string property
•	Engine: a class with two properties – speed and power,
•	Cargo: a class with two properties – type and weight 
•	Tires: a collection of exactly 4 tires. Each tire should have two properties: age and pressure.
*/

/* "{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"*/
public class Car
{
    public Car(string model,int engineSpeed,int enginePower,int cargoWeight,string cargoType,decimal tirePressure1,int tireAge1, decimal tirePressure2, int tireAge2, decimal tirePressure3, int tireAge3, decimal tirePressure4, int tireAge4)
    {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoType, cargoWeight);
            Tire = new Tire[] { new Tire(tirePressure1, tireAge1),
            new Tire(tirePressure2, tireAge2),
            new Tire(tirePressure3, tireAge3),
            new Tire(tirePressure4, tireAge4)};
    }

    public string Model { get; set; }

    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public Tire[] Tire { get; set; }
}
}
