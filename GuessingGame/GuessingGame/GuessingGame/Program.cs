using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer;
            int playerGuess;
            string playerInput;
            string difficulty;
            string playersName;
            bool isNumberGuessed = false;

            
            Console.WriteLine("Enter your name: ");
            playersName = Console.ReadLine();

            Console.WriteLine("Choose difficulty: Easy, Normal, or Hard.");
            difficulty = Console.ReadLine();
            if (difficulty == "easy")
            {
                Random r = new Random();
                theAnswer = r.Next(1, 6);
            }
            else if (difficulty == "normal")
            {
                Random r = new Random();
                theAnswer = r.Next(1, 21);
            }
            else if (difficulty == "hard")
            {
                Random r = new Random();
                theAnswer = r.Next(1, 51);
            }
        
            while (difficulty == "easy")
                
            {
                // get player input
               
                Console.WriteLine("Enter your guess (1-20): ");
                playerInput = Console.ReadLine();

                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))
                {
                    if (playerGuess == theAnswer)
                    {
                        Console.WriteLine("You Win!!! " + playersName);
                        isNumberGuessed = true;
                    }
                    else
                    {
                        Console.WriteLine("Price is Wrong " + playersName);
                        if (playerGuess > theAnswer)
                        {
                            Console.WriteLine("Too High!");
                        }
                        else
                        {
                            Console.WriteLine("Too Low!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("That wasn't a valid number " + playersName);
                }

            } while (!isNumberGuessed);

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
