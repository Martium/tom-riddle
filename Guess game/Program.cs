using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
            {"Žalia žole, bet ne žole su uodega, bet ne pelė?" , "agurkas"},
            { "Be rankų, be kojų duris atidaro?", "vejas"},
            { "Į pakalnę lėtai, į kalną greitai?", "snarglys"}
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            StartIntro();

            int result = StartGame();

            Console.WriteLine("Mįslės išspręstos. Surinkti taškai: " + result + " / 9");
            Console.WriteLine("");
            Console.WriteLine("Dėkui, kad žaidėte! Spauskite ENTER klavišą, kad išjungti žaidimą:");
            Console.ReadLine();
        }
        
        static void StartIntro()
        {
            Console.WriteLine("Sveiki atvykę į mįslių žaidimą!");
            Console.WriteLine("");
            Console.WriteLine("TAISYKLĖS:");
            Console.WriteLine("* jūs turėsite įminti 3 mįsles");
            Console.WriteLine("* kiekvienai mįslei įminti turėsite 3 bandymus");
            Console.WriteLine("* kiekviena mįslė yra verta 3 taškų");
            Console.WriteLine("* kiekvienas neteisingas spėjimas kainuos vieną tašką");
            Console.WriteLine("");
            Console.WriteLine("Sėkmės! Spauskite ENTER klavišą, kad pradėti žaidimą:");
            Console.ReadLine();
        }
        
        static int StartGame()
        {
            int progress = 0;
            int guessLimit = 3;

                foreach (KeyValuePair<string, string> riddle in Riddles)
                {
                    int guessCount = 0;
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine(riddle.Key);

                    while (guessCount < guessLimit)
                    {
                       Console.Write("Įveskite savo spėjimą: ");
                       string guess = Console.ReadLine();
                       Console.WriteLine("");

                        if (guess == riddle.Value)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            GiveAnswer(correct: true);
                            Console.ResetColor();
                            progress += guessLimit - guessCount;
                            break;
                        }

                        if (guessCount == guessLimit - 1 & guess != riddle.Value)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            GiveAnswer(correct: false);
                            Console.ResetColor();
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Neteisingai.Bandykite dar kart!");
                        Console.ResetColor();
                        Console.WriteLine("");
                        guessCount++;
                    }
                }

            return progress;
        }

        private static void GiveAnswer(bool correct)
        {
            Console.WriteLine(correct ? "Teisingai!" : "Neteisingai. Visi spėjimai išnaudoti!");

        }
    }
}