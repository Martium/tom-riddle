﻿using System;
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

            StartGames();

            EndGame();
        }

        static void StartIntro()
        {
            Console.WriteLine("Sveiki atvykę į mįslių žaidimą!");
            WriteAndSeperateText("TAISYKLĖS:", addNewLineBeforeText: true);
            Console.WriteLine($"* jūs turėsite įminti {Riddles.Count} mįslių");
            Console.WriteLine($"* kiekvienai mįslei įminti turėsite {GuessLimit} bandymus");
            Console.WriteLine($"* kiekviena mįslė yra verta {GuessLimit * SingleGuessPoints} taškų");
            Console.WriteLine($"* kiekvienas neteisingas spėjimas kainuos {SingleGuessPoints} tašką");
            WriteAndSeperateText("Sėkmės! Spauskite ENTER klavišą, kad pradėti žaidimą:",addNewLineBeforeText: true);
            Console.ReadLine();
        }

        static Dictionary<string, int> PlayGame()
        {
            Dictionary<string, int> playerResult = new Dictionary<string, int> { };
            ShuffleRiddles();

            foreach (KeyValuePair<string, string> riddle in Riddles)
            {
                int guessCount = 0;
                Console.WriteLine("------------------------------------------------------------------------------");
                WriteAndSeperateText(riddle.Key,addNewLineBeforeText: true, addNewLineAfterText:true);

                while (guessCount < GuessLimit)
                {
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
            Console.WriteLine();
            Console.WriteLine("==================================================================");

            int collectedPlayerPoints = playerResult.Sum(playerAnswer => playerAnswer.Value);
            int maximumPoints = Riddles.Count * SingleGuessPoints * GuessLimit;

            WriteAndSeperateText($"Mįslės išspręstos. Surinkti taškai: {collectedPlayerPoints} / {maximumPoints}", addNewLineBeforeText: true);
            WriteAndSeperateText("Taškų paskirstymas: ");

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
        private static void StartGames()
        {
            int gameNumber = 1;
            string repeatGame = "y";

            while(repeatGame == "y")
            {
                WriteAndSeperateText($"================================= GAME #{gameNumber} =================================", addNewLineBeforeText:true, addNewLineAfterText:true);

                Dictionary<string, int> playerResult = PlayGame();

                ShowPlayerResult(playerResult);

                repeatGame = AskRepeat();
               
                gameNumber++;
            }
        }

        private static void WriteAndSeperateText(string message,bool addNewLineBeforeText = false, bool addNewLineAfterText = false)
        {
            if (addNewLineBeforeText)
            {
                Console.WriteLine();
            }

                Console.WriteLine(message);

            if (addNewLineAfterText)
            {
                Console.WriteLine();
            }
        }

        private static string AskRepeat()
        {
            WriteAndSeperateText("Jei norite pakartoti žaidimą spauskite klavišą 'y' ir paspauskite ENTER", addNewLineBeforeText: true);
            Console.Write("kitu atveju spauskite Enter: ");
            string repeatAgainGame = Console.ReadLine();
            return repeatAgainGame;
        }

        private static void EndGame()
        {
            WriteAndSeperateText("Dėkui, kad žaidėte! Spauskite ENTER klavišą, kad išjungti žaidimą: ",addNewLineBeforeText: true, addNewLineAfterText: true);
            Console.ReadLine();
        }
    }
}