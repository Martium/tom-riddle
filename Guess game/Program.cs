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
            {"zalia zole bet ne zole su uodega bet ne pele?" , "agurkas"},
            { "be ranku be koju duris atidaro?", "vejas"},
            { "I pakalne letai i kalna greitai?", "snarglys"}
        };

        static void Main(string[] args)
        {
            int Result = 0;

            Intruduction();

            Result = Result + RiddleGame(0);

            Console.WriteLine("your score is " + Result);
            Console.WriteLine("Thanks for playing press enter to shut down program");
            Console.ReadLine();

            /*Programa sumazinau kaip imanoma labiau  kolkas nedadejau funkcijos pakartojimo nes manau ja veliau reikes idet programa suskaiciuoja rezultata.  Kolkas dar nesugalvojau kaip 
             padaryt kad programa  parasytu kokias misles zaidejas imine. Sumastau tik labai sudetinga varianta todel jis nebus naudingas kai bus 20 misliu ar 100 :D manau dabar reikia dadet
             misliu  kokias 5 ir kad random jas mestu ka manai? aisku net neisivaizduoju kaip tai padaryt :D */ 

        }
        static int RiddleGame(int Progress)
        {
            int GuessCount = 0;
            int First = 0;
            string guess = "";
            string begin = "y";

            while (begin == "y")
            {
                foreach (var Riddle in Riddles)
                {
                    Console.WriteLine(Riddle.Key);
                    Console.Write("Enter your guess ");
                    guess = Console.ReadLine();
                    GuessCount++;

                    while (guess != Riddle.Value)
                    {
                        Console.Write("Enter your guess ");
                        guess = Console.ReadLine();
                        GuessCount++;

                        if (GuessCount == 3 && guess == Riddle.Value)
                        {
                            Console.WriteLine("Nice you get it ");
                            First = First + 1;
                            Console.Write("Press Enter to continue ");
                            Console.ReadLine();
                            GuessCount = GuessCount - 3;
                            break;

                        }else if (GuessCount == 2 && guess == Riddle.Value)
                        {
                            Console.WriteLine("Nice you get it  ");
                            First = First + 2;
                            Console.Write("Press Enter to continue ");
                            Console.ReadLine();
                            GuessCount = GuessCount - 2;
                            break;

                        }else if (GuessCount == 1 && guess == Riddle.Value)
                        {
                            Console.WriteLine("Nice you get it ");
                            First = First + 3;
                            Console.Write("Press Enter to continue ");
                            Console.ReadLine();
                            GuessCount--;
                            break;

                        }else if (GuessCount == 3 && guess != Riddle.Value)
                        {
                            Console.WriteLine("You did not get it ");
                            First = First + 0;
                            Console.Write("Press Enter to continue ");
                            Console.ReadLine();
                            GuessCount = GuessCount - 3;
                            break;
                        }


                    }
                }

                break;

            }
            Progress = Progress + First;
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