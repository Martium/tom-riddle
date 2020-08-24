using System;
using System.Collections.Generic;
using System.Linq;

namespace Martium.GuessTheRiddleGame
{
    internal class Program
    {
        private static Dictionary<string, string> Riddles = new Dictionary<string, string>
        {
            { "Žalia žole, bet ne žole su uodega, bet ne pelė?" , "agurkas" },
            { "Be rankų, be kojų duris atidaro?", "vejas" },
            { "Į pakalnę lėtai, į kalną greitai?", "snarglys" },
            { "Nei gimsta, nei auga, nei miršta, o yra?" , "akmuo" },
            { "Nors mus supa ir spaudžia, bet jo nematom?" , "oras" },
            { "Rudenį gimsta, pavasarį miršta?" , "sniegas" },
            { "Šimtais skaito, tūkstančiais skaito ir niekaip nesuskaito?" , "zvaigzdes" },
            { "Skaisti graži mergužėlė mėlynoj pievoj vaikštinėja?" , "saule" },
            { "Mažas vyrukas, aštrus kirvukas?" , "bite" },
            { "Mažas žirgelis dideliais žingsniais bėga?" , "ziogas" }
        };

        private static int SingleGuessPoints = 1;
        private static int GuessLimit = 3;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            StartIntro();

            int playerResult = StartGame();

            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine();
            int maxResult = Riddles.Count * SingleGuessPoints * GuessLimit;
            Console.WriteLine($"Mįslės išspręstos. Surinkti taškai: {playerResult} / {maxResult}");
            Console.WriteLine();
            Console.WriteLine("Dėkui, kad žaidėte! Spauskite ENTER klavišą, kad išjungti žaidimą:");
            Console.ReadLine();
        }

        static void StartIntro()
        {
            Console.WriteLine("Sveiki atvykę į mįslių žaidimą!");
            Console.WriteLine();
            Console.WriteLine("TAISYKLĖS:");
            Console.WriteLine($"* jūs turėsite įminti {Riddles.Count} mįslių");
            Console.WriteLine($"* kiekvienai mįslei įminti turėsite {GuessLimit} bandymus");
            Console.WriteLine($"* kiekviena mįslė yra verta {GuessLimit * SingleGuessPoints} taškų");
            Console.WriteLine($"* kiekvienas neteisingas spėjimas kainuos {SingleGuessPoints} tašką"); 
            Console.WriteLine();
            Console.WriteLine("Sėkmės! Spauskite ENTER klavišą, kad pradėti žaidimą:");
            Console.ReadLine();
        }

        static int StartGame()
        {
            int progress = 0;
            ShuffleDictionary();

            foreach (KeyValuePair<string, string> riddle in Riddles)
            {
                int guessCount = 0;
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine(riddle.Key);

                while (guessCount < GuessLimit)
                {
                    Console.WriteLine();
                    Console.Write("Įveskite savo spėjimą: ");
                    string guess = Console.ReadLine();

                    if (guess == riddle.Value)
                    {
                        GiveAnswer(correct: true);
                        progress += GuessLimit * SingleGuessPoints - guessCount; 
                        break;
                    }

                    if (guessCount == GuessLimit - 1 & guess != riddle.Value)
                    {
                        GiveAnswer(correct: false, lastAttempt: true);
                        break;
                    }

                    GiveAnswer(correct: false);
                    guessCount++;
                }
            }

            return progress;
        }

        private static void ShuffleDictionary()
        {
            Random shuffle = new Random();
            Riddles = Riddles.OrderBy(x => shuffle.Next())
              .ToDictionary(item => item.Key, item => item.Value);
        }

        private static void GiveAnswer(bool correct, bool lastAttempt = false)
        {
            if (correct)
            {
                WriteColoredMessage("Teisingai!", ConsoleColor.DarkGreen);
            }
            else if (!lastAttempt)
            {
                WriteColoredMessage("Neteisingai. Bandykite dar kart!", ConsoleColor.DarkYellow);
            }
            else
            {
                WriteColoredMessage("Neteisingai. Visi spėjimai išnaudoti!", ConsoleColor.DarkRed);
            }
        }

        private static void WriteColoredMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}