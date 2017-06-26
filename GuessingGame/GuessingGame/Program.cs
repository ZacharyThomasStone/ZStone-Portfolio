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
            string difficulty;
            string playerInput;
            string playerName;
            bool isNumberGuessed = false;

            Console.WriteLine("What is your name?");
            playerName = Console.ReadLine();

            Console.WriteLine("{0} Choose a difficulty: easy, normal, or hard.",playerName);
            difficulty = Console.ReadLine();
            if (difficulty == "easy")
            {

                Random r = new Random();
                theAnswer = r.Next(1, 6);

                do
                {
                    // get player input
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0} Enter your guess (1-5): ",playerName);
                    playerInput = Console.ReadLine();

                    //attempt to convert the string to a number
                    if (int.TryParse(playerInput, out playerGuess))
                    {
                        if (playerGuess == theAnswer)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You Win {0}!!!",playerName);
                            isNumberGuessed = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong Answer! {0}", playerName);
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That wasn't a valid number {0}!",playerName);
                    }

                } while (!isNumberGuessed);
            }
            if (difficulty == "normal")
            {

                Random r = new Random();
                theAnswer = r.Next(1, 21);

                do
                {
                    // get player input
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0},Enter your guess (1-20): ",playerName);
                    playerInput = Console.ReadLine();

                    //attempt to convert the string to a number
                    if (int.TryParse(playerInput, out playerGuess))
                    {
                        if (playerGuess == theAnswer)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You Win {0}!!!",playerName);
                            isNumberGuessed = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong Answer! {0}",playerName);
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That wasn't a valid number {0}!",playerName);
                    }

                } while (!isNumberGuessed);
            }
            if (difficulty == "hard")
            {

                Random r = new Random();
                theAnswer = r.Next(1, 51);

                do
                {
                    // get player input
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0} Enter your guess (1-50): ",playerName);
                    playerInput = Console.ReadLine();

                    //attempt to convert the string to a number
                    if (int.TryParse(playerInput, out playerGuess))
                    {
                        if (playerGuess == theAnswer)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You Win {0}!!!",playerName);
                            isNumberGuessed = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong Answer! {0}", playerName);
                            if (playerGuess > theAnswer && playerGuess >= 1 && playerGuess <= 50)
                            {
                                Console.WriteLine("Too High!");
                                
                            }
                            else if (playerGuess < theAnswer && playerGuess >= 1 && playerGuess <= 50)
                            {
                                Console.WriteLine("Too Low!");
                               
                            }
                            else if (playerGuess > 51 || playerGuess < 1)
                            {
                                Console.WriteLine("Number out of bounds!");
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That wasn't a valid number {0}!",playerName);
                    }

                } while (!isNumberGuessed);
            }
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
