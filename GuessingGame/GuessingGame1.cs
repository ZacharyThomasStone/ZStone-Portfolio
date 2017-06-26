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
            int numberOfAttemps = 0;
            string difficulty;
            string playerInput;
            string playerName;
            bool isNumberGuessed = false;
            bool isDifficultySet = false;
            Console.WriteLine("The Guessing Game! Enter q at anytime to quit!");
            Console.WriteLine("What is your name?");
            playerName = Console.ReadLine();
          
              
            do
            {
                //Asking User to Set Difficulty 
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0}, Choose a difficulty: easy, normal, or hard?", playerName);
                difficulty = Console.ReadLine();
                //Checking if User Input is to quit.
                if (difficulty == "q")
                    break;


                if (difficulty == "easy")
                {

                    Random r = new Random();
                    theAnswer = r.Next(1, 6);
                    isDifficultySet = true;

                    do
                    {
                        // get player guess
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("{0}, enter your guess (1-5): ", playerName);
                        playerInput = Console.ReadLine();
                        numberOfAttemps++;
                        if (playerInput == "q")
                            break;

                        //Converts playerInput (string) into PlayerGuess (int)
                        if (int.TryParse(playerInput, out playerGuess))
                        {
                            if (playerGuess == theAnswer)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You Win {0}!!!", playerName);
                                Console.WriteLine("It took you {0} attempts!", numberOfAttemps);
                                isNumberGuessed = true;
                                if (numberOfAttemps == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Aren't you a smarty pants!");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong Answer, {0}!", playerName);
                                if (playerGuess > theAnswer && playerGuess >= 1 && playerGuess <= 5)
                                {
                                    Console.WriteLine("Too High!");

                                }
                                else if (playerGuess < theAnswer && playerGuess >= 1 && playerGuess <= 5)
                                {
                                    Console.WriteLine("Too Low!");

                                }
                                else if (playerGuess > 5 || playerGuess < 1)
                                {
                                    Console.WriteLine("Number is out of bounds!");
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That wasn't a valid number, {0}!", playerName);
                        }

                    } while (!isNumberGuessed);
                }
                else if (difficulty == "normal")
                {
                    //Generates number for Normal Difficulty (1-20)
                    Random r = new Random();
                    theAnswer = r.Next(1, 21);
                    isDifficultySet = true;

                    do
                    {
                        // get player input
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("{0}, enter your guess (1-20): ", playerName);
                        playerInput = Console.ReadLine();
                        numberOfAttemps++;
                        if (playerInput == "q")
                            break;

                        //Converts playerInput (string) into PlayerGuess (int)
                        if (int.TryParse(playerInput, out playerGuess))
                        {
                            if (playerGuess == theAnswer)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You Win {0}!!!", playerName);
                                Console.WriteLine("It took you {0} attempts!", numberOfAttemps);
                                isNumberGuessed = true;
                                if (numberOfAttemps == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("Aren't you a smarty pants!");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong Answer, {0}!", playerName);
                                if (playerGuess > theAnswer && playerGuess >= 1 && playerGuess <= 20)
                                {
                                    Console.WriteLine("Too High!");

                                }
                                else if (playerGuess < theAnswer && playerGuess >= 1 && playerGuess <= 20)
                                {
                                    Console.WriteLine("Too Low!");

                                }
                                else if (playerGuess > 20 || playerGuess < 1)
                                {
                                    Console.WriteLine("Number is out of bounds!");
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That wasn't a valid number, {0}!", playerName);
                        }

                    } while (!isNumberGuessed);
                }
                else if (difficulty == "hard")
                {

                    Random r = new Random();
                    theAnswer = r.Next(1, 51);
                    isDifficultySet = true;

                    do
                    {
                        // get player input
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("{0}, enter your guess (1-50): ", playerName);
                        playerInput = Console.ReadLine();
                        numberOfAttemps++;
                        if (playerInput == "q")
                            break;

                        //Converts playerInput (string) into PlayerGuess (int)
                        if (int.TryParse(playerInput, out playerGuess))
                        {
                            if (playerGuess == theAnswer)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You Win {0}!!!", playerName);
                                Console.WriteLine("It took you {0} attempts!", numberOfAttemps);
                                isNumberGuessed = true;
                                if (numberOfAttemps == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Aren't you a smarty pants!");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong Answer, {0}!", playerName);
                                if (playerGuess > theAnswer && playerGuess >= 1 && playerGuess <= 50)
                                {
                                    Console.WriteLine("Too High!");

                                }
                                else if (playerGuess < theAnswer && playerGuess >= 1 && playerGuess <= 50)
                                {
                                    Console.WriteLine("Too Low!");

                                }
                                else if (playerGuess > 50 || playerGuess < 1)
                                {
                                    Console.WriteLine("Number is out of bounds!");
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That wasn't a valid number, {0}!", playerName);
                        }

                    } while (!isNumberGuessed);

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid difficulty, {0}!", playerName);
                }
              
            } while (!isDifficultySet);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Thank you for playing!");
            Console.ReadKey();
        }
    }
}
