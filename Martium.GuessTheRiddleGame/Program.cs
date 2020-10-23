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
        private static int GameNumber = 1;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            StartIntro();

            StartMainGame();

            EndGame();
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

        static Dictionary<string, int> StartGame()
        {
            Dictionary<string, int> playerResult = new Dictionary<string, int> { };
            ShuffleRiddles();

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
                        int collectedRiddlePoints = GuessLimit * SingleGuessPoints - guessCount;
                        playerResult.Add(riddle.Key, collectedRiddlePoints);
                        break;
                    }

                    if (guessCount == GuessLimit - 1 & guess != riddle.Value)
                    {
                        GiveAnswer(correct: false, lastAttempt: true);
                        playerResult.Add(riddle.Key, 0);
                        break;
                    }

                    GiveAnswer(correct: false);
                    guessCount++;
                }
            }

            return playerResult;
        }

        private static void ShuffleRiddles()
        {
            Random random = new Random();
            Riddles = Riddles.OrderBy(x => random.Next())
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

        private static void ShowPlayerResult(Dictionary<string, int> playerResult)
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine();

            int collectedPlayerPoints = playerResult.Sum(playerAnswer => playerAnswer.Value);
            int maximumPoints = Riddles.Count * SingleGuessPoints * GuessLimit;

            Console.WriteLine($"Mįslės išspręstos. Surinkti taškai: {collectedPlayerPoints} / {maximumPoints}");
            Console.WriteLine("Taškų paskirstymas: ");
            Console.WriteLine();

            foreach (KeyValuePair<string, int> playerResults in playerResult)
            {
                ConsoleColor color;

                if (playerResults.Value == GuessLimit)
                {
                     color = ConsoleColor.DarkGreen;
                }
                else if (playerResults.Value == 0)
                {
                     color = ConsoleColor.DarkRed;
                }
                else
                {
                     color = ConsoleColor.DarkYellow;
                }

                WriteColoredMessage($" { playerResults.Key} -> {playerResults.Value}", color);
            }
        }
        private static void StartMainGame()
        {
            string repeatGame = "y";

            while(repeatGame == "y")
            {
                ShowGameNumber();

                Dictionary<string, int> playerResult = StartGame();

                ShowPlayerResult(playerResult);

                SeperateGames();

                AskRepeat();

                string repeatAgainGame = Console.ReadLine();
                repeatGame = repeatAgainGame;
                ++GameNumber;
            }
        }

        private static void ShowGameNumber()
        {
            Console.WriteLine();
            Console.WriteLine($"================================= GAME #{GameNumber} =================================");
            Console.WriteLine();
        }

        private static void SeperateGames()
        {
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            Console.WriteLine();
        }

        private static void AskRepeat()
        {
            Console.WriteLine("Jei norite pakartoti žaidimą spauskite klavišą 'y' ir paspauskite ENTER");
            Console.Write("kitu atveju spauskite Enter: ");
        }

        private static void EndGame()
        {
            Console.WriteLine();
            Console.WriteLine("Dėkui, kad žaidėte! Spauskite ENTER klavišą, kad išjungti žaidimą:");
            Console.ReadLine();
        }
    }
}