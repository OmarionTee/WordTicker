using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTicker
{
    class WordTicker
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            string filePath = @"Resources\words.txt"; 
            string[] words;
            words = File.ReadAllLines(filePath);

            while (true)
            {
                Console.WriteLine("=== Word Ticker by OT ===");
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your number: ");
                string menuNum = Console.ReadLine();

                if (menuNum == "1")
                {
                    Game(words);
                }
                else if (menuNum == "2")
                {
                    Console.WriteLine("Goodbye.");
                    break;
                }
                else
                {
                    Console.WriteLine("Non-existent choice, enter a a proper choice or get lost.");
                    Console.ReadLine();
                }
            }
        }

        static void Game(string[] words)
        {
            Random rand = new Random();
            int lives = 3;
            int score = 0;

            while (lives > 0)
            {
                Console.Clear();
                Console.WriteLine($"Lives: {lives} | Score: {score}");

                char randomLetter = (char)rand.Next('A', 'Z' + 1);
                Console.WriteLine($"The letter is: {randomLetter}");
                Console.WriteLine("Enter a 5 letter word that starts or contains the letter. You have 15 seconds.");

                DateTime startTime = DateTime.Now;

                string playerWord = Console.ReadLine()?.ToUpper();
                TimeSpan timeTaken = DateTime.Now - startTime;

                if (timeTaken.TotalSeconds > 15)
                {
                    Console.WriteLine("Time is up. You lost a life.");
                    lives--;
                    Pause();
                    continue;
                }

                if (playerWord.Length == 5 && playerWord.Contains(randomLetter) && words.Contains(playerWord))
                {
                    Console.WriteLine("Nice, You earned 10 points.");
                    score += 10;
                }
                else
                {
                    Console.WriteLine("Word is too short/long or it does not exist. You lost a life.");
                    lives--;
                }

                Pause();
            }

            Console.Clear();
            Console.WriteLine("Game Over.");
            Console.WriteLine($"Your final score is: {score}");

            if (score > 10)
            {
                Console.WriteLine("You did well.");
            }
            else
            {
                Console.WriteLine("Better luck next time.");
            }
            
            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }


        static void Pause()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }


}
