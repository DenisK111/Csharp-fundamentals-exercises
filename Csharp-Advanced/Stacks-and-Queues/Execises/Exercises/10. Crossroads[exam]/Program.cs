using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace _10._Crossroads_exam_
{
    class Program
    {
        /*he is stuck in a traffic jam at a very active crossroads where a lot of accidents happen.
Your job is to keep track of traffic at the crossroads and report whether a crash happened or everyone passed the crossroads safely and our hero is one step closer to a much-desired vacation.
The road Sam is on has a single lane where cars queue up until the light goes green. When it does, they start passing one by one during the green light and the free window before the intersecting road’s light goes green. During one second only one part of a car (a single character) passes the crossroads. If a car is still at the crossroads when the free window ends, it will get hit at the first character that is still in the crossroads.
Input
•	On the first line, you will receive the duration of the green light in seconds – an integer in the range [1-100]
•	On the second line, you will receive the duration of the free window in seconds – an integer in the range [0-100]
•	On the following lines, until you receive the "END" command, you will receive one of two things:
	A car – a string containing any ASCII character, or
	The command "green" indicates the start of a green light cycle
A green light cycle goes as follows:
•	During the green light, cars will enter and exit the crossroads one by one
•	During the free window, cars will only exit the crossroads
Output
•	If a crash happens, end the program and print:
"A crash happened!"
"{car} was hit at {characterHit}."
•	If everything goes smoothly and you receive an "END" command, print:
"Everyone is safe."
"{totalCarsPassed} total cars passed the crossroads."
Constraints
•	The input will be within the constraints specified above and will always be valid. There is no need to check it explicitly.
*/

        static void Main(string[] args)
        {
            var trafficJam = new Queue<string>();
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int passedCars = 0;
            string currentCar = string.Empty;
            while (true)
            {
                string command = Console.ReadLine();
               
                if (command == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{passedCars} total cars passed the crossroads.");
                    return;
                }

                if (command == "green")
                {
                    int currGreenLight = greenLight;
                    while (currGreenLight > 0)
                    {
                        if (trafficJam.Count > 0)
                        {

                        currentCar = trafficJam.Peek();
                        currGreenLight -= trafficJam.Peek().Length;
                        trafficJam.Dequeue();
                        passedCars++;
                        }

                        else
                        {
                            break;
                        }

                    }

                    if (freeWindow+currGreenLight<0) /// greenLight -4  abcde freewindow 1 -3
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {currentCar[currentCar.Length + (freeWindow + currGreenLight)]}.");
                        return;
                    }

                    
                }

                else
                {

                    trafficJam.Enqueue(command);

                }
            }

        }
    }
}
