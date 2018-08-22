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
            //stores the number randomly picked that the player must guess.
            int theAnswer;
            //stores players guesses.
            int playerGuess;
            //used to store the last guess the user guessed. 
            int lastGuess = 0;
            //stores the amount of times the user attempts a guess.
            int numberOfAttemps = 0;
            //stores the difficulty level.
            string difficulty;
            //stores the input from user.
            string playerInput;
            //stores the users name.
            string playerName;
            //checks to see if the user guessed the winning number
            bool isNumberGuessed = false;
            //checks to ensure the user has set the difficulty level.
            bool isDifficultySet = false;

            //Start of game
            Console.WriteLine("The Guessing Game! Enter q at anytime to quit!");
            Console.WriteLine("What is your name?");
            playerName = Console.ReadLine();
            Console.Clear();


            do
            {
                //Asking User to Set Difficulty 
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0}, Choose a difficulty: easy, normal, or hard?", playerName);
                difficulty = Console.ReadLine();
                Console.Clear();
                //Checking if User Input is to quit.
                if (difficulty == "q")
                    break;

                if (difficulty == "easy")
                {
                    //generates the answer for easy difficulty setting.
                    Random r = new Random();
                    theAnswer = r.Next(1, 6);
                    isDifficultySet = true;

                    do
                    {
                        //get player guess.
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("{0}, enter your guess (1-5): ", playerName);
                        playerInput = Console.ReadLine();
                        Console.Clear();
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

                                if (playerGuess > theAnswer && playerGuess >= 1 && playerGuess <= 5)
                                {
                                    lastGuess = playerGuess;
                                    Console.WriteLine("Too High!");

                                }
                                else if (playerGuess < theAnswer && playerGuess >= 1 && playerGuess <= 5)
                                {
                                    lastGuess = playerGuess;
                                    Console.WriteLine("Too Low!");

                                }
                                else if (playerGuess > 5 || playerGuess < 1)
                                {
                                    lastGuess = playerGuess;
                                    Console.WriteLine("Number is out of bounds!");
                                }
                                if (lastGuess != 0)
                                {
                                    Console.WriteLine("Wrong Answer, {0}! Last Guess: {1}.", playerName, lastGuess);
                                }
                                else
                                {
                                    Console.WriteLine("Wrong Answer, {0}!", playerName);
                                }
                                Console.WriteLine("Guess again.");
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
                                Console.WriteLine("Guess again.");
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
                                Console.WriteLine("Guess again.");
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
