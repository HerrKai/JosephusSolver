using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephusSolver
{
    class Program
    {
        static void Main(string[] args)
        {
        start:
            bool correctInput = false;
            int objectCount = -1;
            while (!correctInput)
            {
                Console.Write("Number of objects: ");
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    objectCount = Convert.ToInt32(Console.ReadLine());
                    if (objectCount > 0)
                    {
                        correctInput = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The number must be larger then zero");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your input could not be converted into a number");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            bool[] objects;
            try
            {
                objects = new bool[objectCount];
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The number is too large");
                Console.ForegroundColor = ConsoleColor.Gray;
                goto start;
            }
            correctInput = false;
            bool showSteps = false;
            while (!correctInput)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Do you want to see ALL steps [SLOWER](y/n): ");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKey pressedKey = Console.ReadKey().Key;
                Console.WriteLine();
                if (pressedKey == ConsoleKey.Y || pressedKey == ConsoleKey.N)
                {
                    if (pressedKey == ConsoleKey.Y)
                    {
                        showSteps = true;
                    }
                    correctInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please press y (Y) or n (N)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            int stepDelay = -1;
            if (showSteps)
            {
                correctInput = false;
                while (!correctInput)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Extra delay between operations (in seconds): ");
                    Console.ForegroundColor = ConsoleColor.White;
                    try
                    {
                        stepDelay = Convert.ToInt32(Console.ReadLine());
                        if (objectCount > 0)
                        {
                            correctInput = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The number must be larger then zero");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your input could not be converted into a number");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
            Console.Clear();
            bool isSolved = false;
            int index = 0;
            bool killNext = false;
            int survivor = -1;
            int killerIndex = 0;
            DateTime startingTime = DateTime.Now;
            while (!isSolved)
            {
                if (index >= objectCount)
                {
                    index = 0;
                    int alive = 0;
                    int counter = 0;
                    foreach (bool tmpObject in objects)
                    {
                        if (alive > 1)
                        {
                            break;
                        }
                        if (!tmpObject)
                        {
                            alive++;
                            survivor = counter;
                        }
                        counter++;
                    }
                    if (alive == 1)
                    {
                        isSolved = true;
                    }
                }
                if (killNext && !objects[index])
                {
                    objects[index] = true;
                    killNext = false;
                    index++;
                    if (showSteps)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(killerIndex + 1);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" removed ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(index);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        System.Threading.Thread.Sleep(stepDelay * 1000);
                    }
                }
                else
                {
                    if (!objects[index])
                    {
                        killNext = true;
                        killerIndex = index;
                    }
                    index++;
                }
            }
            DateTime endingTime = DateTime.Now;
            TimeSpan duration = endingTime - startingTime;
            if (showSteps)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nPress any key to continue");
                Console.ReadKey();
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Number of objects:\t");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(objectCount);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Last object:\t\t");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(survivor + 1);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Seconds elapsed:\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(duration.TotalSeconds);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPress any key to exit this application");
            Console.ReadKey();
        }
    }
}
