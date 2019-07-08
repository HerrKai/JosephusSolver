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
            const int objectCount = 10;
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
