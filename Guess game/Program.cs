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
        private static Dictionary<string, string> Riddles = new Dictionary<string, string>
        {
            // { key, value }
            {"zalia zole bet ne zole su uodega bet nepele?" , "agurkas"},
            { "be ranku be koju duris atidaro", "vejas"},
            { "I pakalne letai i kalna greitai?", "snarglys"}
        };
        // foreach 

        static void Main(string[] args)
        {
            //var answers = new Dictionary<string, int>();
            

            //var guess = string.Empty;
            //// for / foreach
            //foreach (var riddle in Riddles)
            //{
            //    answers.Add(riddle.Key, 0);

            //    while (guess != riddle.Value)
            //    {
            //        Console.Write("Enter your guess ");
            //        guess = Console.ReadLine();

            //        GuessCount++;

            //        if (GuessCount == OutOfGuess && guess == "agurkas")
            //        {
            //            Console.WriteLine("Nice you get it ");
            //            Progress = Progress - 2;
            //            First = First + Progress;
            //            Console.Write("Press Enter to continue ");
            //            Console.ReadLine();
            //            return First;
            //        }
            //        else if (GuessCount == 2 && guess == "agurkas")
            //        {
            //            Console.WriteLine("Nice you get it ");
            //            Progress = Progress - 1;
            //            First = First + Progress;
            //            Console.Write("Press Enter to continue ");
            //            Console.ReadLine();
            //            return First;
            //        }
            //        else if (GuessCount == 1 && guess == "agurkas")
            //        {
            //            Console.WriteLine("Nice you get it ");
            //            First = First + Progress;
            //            Console.Write("Press Enter to continue ");
            //            Console.ReadLine();
            //            return First;
            //        }
            //        else if (GuessCount == OutOfGuess)
            //        {
            //            Console.WriteLine("You did not get it ");
            //            Progress = Progress - 3;
            //            First = First + Progress;
            //            Console.Write("Press Enter to continue ");
            //            Console.ReadLine();
            //            return First;
            //        }
            //    }
            //}

            Console.WriteLine("Welcome to riddle game you will have 3 riddles");
            Console.WriteLine("for each riddle you will have 3 guess");
            Console.WriteLine("Each Riddle worth 3 points" );
            Console.WriteLine("but each wrong guess will lose 1 point");
            Console.WriteLine("so max points in this game is 9");
            Console.WriteLine("All riddle in Lithuanian language so answers must be in Lithuania language usin only latin letters.");
            Console.WriteLine(" In the end we will count your result Good Luck");
            Console.Write("Press Enter to begin ");
            Console.ReadLine();

            foreach (var Riddle in Riddles)
            {
                Console.WriteLine(Riddle.Key, Riddle.Value);
            }

            Console.ReadLine();

            string begin = "y";

            while (begin == "y")
            {
               
                

                Console.Write("Press 'y' to restart program  or press Enter if you want shut down program ");
                string restartAgain = Console.ReadLine();

                if (restartAgain != "y")
                {
                    break;
                }
            }

            Console.ReadLine();
        }

           

        static int MainRiddles(int First)
        {

            int GuessCount = 0;
            int OutOfGuess = 3;
            int Progress = 3;
            string guess = "";

            Console.WriteLine(Riddles.Keys);

            while (guess != "agurkas")
            {
                Console.Write("Enter your guess ");
                guess = Console.ReadLine();

                GuessCount++;

                if (GuessCount == OutOfGuess && guess == "agurkas")
                {
                    Console.WriteLine("Nice you get it ");
                    Progress = Progress - 2;
                    First = First + Progress;
                    Console.Write("Press Enter to continue ");
                    Console.ReadLine();
                    return First;
                }else if (GuessCount == 2 && guess == "agurkas")
                {
                    Console.WriteLine("Nice you get it ");
                    Progress = Progress - 1;
                    First = First + Progress;
                    Console.Write("Press Enter to continue ");
                    Console.ReadLine();
                    return First;
                }else if (GuessCount == 1 && guess == "agurkas")
                {
                    Console.WriteLine("Nice you get it ");
                    First = First + Progress;
                    Console.Write("Press Enter to continue ");
                    Console.ReadLine();
                    return First;
                }else if (GuessCount == OutOfGuess)
                {
                    Console.WriteLine("You did not get it ");
                    Progress = Progress - 3;
                    First = First + Progress;
                    Console.Write("Press Enter to continue ");
                    Console.ReadLine();
                    return First;
                }
            }

            return First;

        }
        static int SecondRiddle(int Second)
        {
            int GuessCount = 0;
            int OutOfGuess = 3;
            int Progress = 3;
            string guess = "";

            Console.WriteLine("be ranku be koju duris atidaro");

           

            while (guess != "vejas")
            {
                Console.Write("Enter your guess ");
                guess = Console.ReadLine();

                GuessCount++;

                if (GuessCount == OutOfGuess && guess == "vejas")
                {
                    Console.WriteLine("Nice you get it ");
                    Progress = Progress - 2;
                    Second = Second + Progress;
                    Console.Write("Press Enter to continue ");
                    Console.ReadLine();
                    return Second;
                }
                else if (GuessCount == 2 && guess == "vejas")
                {
                    Console.WriteLine("Nice you get it ");
                    Progress = Progress - 1;
                    Second = Second + Progress;
                    Console.Write("Press Enter to continue ");
                    Console.ReadLine();
                    return Second;
                }
                else if (GuessCount == 1 && guess == "vejas")
                {
                    Console.WriteLine("Nice you get it ");
                    Second = Second + Progress;
                    Console.Write("Press Enter to continue ");
                    Console.ReadLine();
                    return Second;
                }
                else if (GuessCount == OutOfGuess)
                {
                    Console.WriteLine("You did not get it ");
                    Progress = Progress - 3;
                    Second = Second + Progress;
                    Console.Write("Press Enter to continue ");
                    Console.ReadLine();
                    return Second;
                }
            }

            return Second;

        }
        static int ThirdRiddle(int Third)
        {
            int GuessCount = 0;
            int OutOfGuess = 3;
            int Progress = 3;
            string guess = "";

            Console.WriteLine("I pakalne letai i kalna greitai?");

            while (guess != "Snarglys")
            {
                Console.Write("Enter your guess ");
                guess = Console.ReadLine();

                GuessCount++;

                if (GuessCount == OutOfGuess && guess == "snarglys")
                {
                    Console.WriteLine("Nice you get it ");
                    Progress = Progress - 2;
                    Third = Third + Progress;
                    Console.Write("Press Enter to continue ");
                    Console.ReadLine();
                    return Third;
                }
                else if (GuessCount == 2 && guess == "snarglys")
                {
                    Console.WriteLine("Nice you get it ");
                    Progress = Progress - 1;
                    Third = Third + Progress;
                    return Third;
                }
                else if (GuessCount == 1 && guess == "snarglys")
                {
                    Console.WriteLine("Nice you get it ");
                    Third = Third + Progress;
                    Console.Write("Press Enter to continue ");
                    Console.ReadLine();
                    return Third;
                }
                else if (GuessCount == OutOfGuess)
                {
                    Console.WriteLine("You did not get it ");
                    Progress = Progress - 3;
                    Third = Third + Progress;
                    Console.Write("Press Enter to continue ");
                    Console.ReadLine();
                    return Third;
                }
            }

            return Third;

        }

    }

         
        



    
}