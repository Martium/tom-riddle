using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Guess_game
{
    class Program
    {

        static void Main(string[] args)
        {

            StartIntro();

            int result = StartGame();

            Console.WriteLine("your score is " + result);
            Console.WriteLine("Thanks for playing press enter to shut down program");
            Console.ReadLine();

        }

        private static void AnswerMessage(bool correct)
        {
            Console.WriteLine(correct ? "Nice you get it " : "You did not get it ");

            Console.Write("Press Enter to continue ");
            Console.ReadLine();
        }

        private static Dictionary<string, string> Riddles = new Dictionary<string, string>
        {
            {"zalia zole bet ne zole su uodega bet ne pele?" , "agurkas"},
            { "be ranku be koju duris atidaro?", "vejas"},
            { "I pakalne letai i kalna greitai?", "snarglys"}
        };
        static int StartGame()
        {
            int progress = 0;
            int guessLimit = 3;
            string begin = "";

            while (begin == "")
            {
                foreach (KeyValuePair<string, string> Riddle in Riddles)
                {
                    int guessCount = 0;
                    Console.WriteLine(Riddle.Key);

                    while (guessCount < guessLimit)
                    {
                        Console.Write("Enter your guess ");
                       string guess = Console.ReadLine();

                        if (guess == Riddle.Value)
                        {
                            AnswerMessage(correct: true);
                            progress += guessLimit - guessCount;
                            break;
                        }

                        if (guessCount == guessLimit - 1 & guess != Riddle.Value)
                        {
                            AnswerMessage(correct: false);
                            break;
                        }

                        guessCount++;

                    }
                }

                break;

            }
            return progress;
        }

        static void StartIntro()
        {
            Console.WriteLine("Welcome to riddle game you will have 3 riddles");
            Console.WriteLine("for each riddle you will have 3 guess");
            Console.WriteLine("Each Riddle worth 3 points");
            Console.WriteLine("but each wrong guess will lose 1 point");
            Console.WriteLine("so max points in this game is 9");
            Console.WriteLine("All riddle in Lithuanian language so answers must be in Lithuania language usin only latin letters.");
            Console.WriteLine(" In the end we will count your result Good Luck");
            Console.Write("Press Enter to begin ");
            Console.ReadLine();
        }
    }

}