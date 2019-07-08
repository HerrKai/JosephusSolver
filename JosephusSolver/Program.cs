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
            bool correctInput = false;
            int objectCount = -1;
            while (!correctInput)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Number of objects: ");
                try
                {
                    objectCount = Convert.ToInt32(Console.ReadLine());
                    correctInput = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your input could not be converted into a number");
                }
            }
            bool[] objects = new bool[objectCount];
            bool isSolved = false;
            int index = 0;
            bool killNext = false;
            int survivor = -1;
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
                }
                else
                {
                    if (!objects[index])
                    {
                        killNext = true;
                    }
                    index++;
                }
            }
            Console.WriteLine(survivor + 1);
            Console.ReadKey();
        }
    }
}
