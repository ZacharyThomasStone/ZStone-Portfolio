using System;

namespace Factorizor.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int counter = 0;
            int num, x, n;
            Console.Write("What number would you like to factor? ");
            num = int.Parse(Console.ReadLine());
            Console.Write("The factors of {0} are: ", num);
            n = num;

            for (x = 1; x < num; x++)
            {
                if (num % x == 0)
                {
                    Console.Write("{0} ", x);
                    counter++;
                    sum = sum + x;

                }

            }
            if (sum == n)
            {
                Console.Write(Environment.NewLine + "{0} is a perfect number!", num);
            }
            else
            {
                Console.Write(Environment.NewLine + "{0} is not a perfect number!", num);
            }
            if (counter == 2)
            {
                Console.Write(Environment.NewLine + "{0} is a prime number!", num);
            }
            else
            {
                Console.Write(Environment.NewLine + "{0} is not prime number!", num);
            }

            Console.ReadLine();
        }

    }
}
