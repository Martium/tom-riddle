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

        static void Main(string[] args)
        {
            int Result = 0;

            Intruduction();

            Result += RiddleGame(0);

            Console.WriteLine("your score is " + Result);
            Console.WriteLine("Thanks for playing press enter to shut down program");
            Console.ReadLine();

            /* Pataisiau koda metode riddle game nepriskyriau int _maxAllowedGuessCount nes kodas nedidelis ir jo uzduotis yra tik skaiciuot iki 3 tai rasiau skaiciais bet kaip sakei suprantu
             * kodel tu taip padarei jei kazka sugalvosim perasysiu  nukopijavau tavo bool voida nes stackoverflow neradau paprastesnio o radau grynai kaip tu padarei o kaip sugalvojau butu buve
             * du nauji metodai  todel pamaniau kam to reikia vienas false kitas true */

        }
        static int RiddleGame(int Progress)
        {
            string begin = "y";

            while (begin == "y")
            {
                foreach (KeyValuePair<string, string> Riddle in Riddles)
                {
                    int GuessCount = 0;
                    Console.WriteLine(Riddle.Key);

                    while (GuessCount < 3)
                    {
                        Console.Write("Enter your guess ");
                       string guess = Console.ReadLine();

                        if (guess == Riddle.Value)
                        {
                            AnswerMessage(correct: true);
                            Progress += 3 - GuessCount;
                            break;
                        }

                        if (GuessCount == 2 & guess != Riddle.Value)
                        {
                            AnswerMessage(correct: false);
                            break;
                        }

                        GuessCount++;

                    }
                }

                break;

            }
            return Progress;
        }

        static void Intruduction()
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