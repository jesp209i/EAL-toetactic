using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spil
{
    class BattleShipsMenu
    {
        BattleShips BattleShips { get; set; }
        public void Show()
        {

            bool running = true;
            string choice = "";
            do
            {
                ShowMenu();
                choice = GetUserChoise();
                switch (choice)
                {
                    case "1": StartBattleShipsNormalGame(); break;
                    case "3": running = false; break;
                    default: ShowMenuSelectionError(); break;
                }
            } while (running);
        }
        private void ShowMenu()
        {
            Console.Clear();
            if (BattleShips != null)
            {
                Console.WriteLine(BattleShips.GetBattleShipsGameBoardView());
            }
            Console.WriteLine(" _______  _______  _______  _______  ___      _______  _______  __   __  ___   _______  _______ ");
            Console.WriteLine("|  _    ||   _   ||       ||       ||   |    |       ||       ||  | |  ||   | |       ||       |");
            Console.WriteLine("| |_|   ||  |_|  ||_     _||_     _||   |    |    ___||  _____||  |_|  ||   | |    _  ||  _____|");
            Console.WriteLine("|       ||       |  |   |    |   |  |   |    |   |___ | |_____ |       ||   | |   |_| || |_____ ");
            Console.WriteLine("|  _   | |       |  |   |    |   |  |   |___ |    ___||_____  ||       ||   | |    ___||_____  |");
            Console.WriteLine("| |_|   ||   _   |  |   |    |   |  |       ||   |___  _____| ||   _   ||   | |   |     _____| |");
            Console.WriteLine("|_______||__| |__|  |___|    |___|  |_______||_______||_______||__| |__||___| |___|    |_______|");
            Console.WriteLine();
            Console.WriteLine("1. Opret nyt spil");
            Console.WriteLine("3. Gå tilbage");
        }
        private string GetUserChoise()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }
        private void ShowMenuSelectionError()
        {
            Console.WriteLine("Ugyldigt valg.");
            Console.ReadLine();
        }
        private void StartBattleShipsNormalGame()
        {
            Console.Clear();
            BattleShips = new BattleShips();
            for (int i = 0; i < BattleShips.player.Length; i++)
            {
                BattleShips.player[BattleShips.battleShipCurrentPlayer].name = BattleShips.GetPlayerName();
                for (int j = 0;  j < 9;  j++)
                {
                    bool shouldPickNewCoordinates = true;
                    do
                    {
                        int xKoordinat;
                        int yKoordinat;
                        Console.WriteLine(BattleShips.GetBattleShipsGameBoardView());
                        Console.WriteLine();
                        Console.WriteLine("Du er ved, at placere " + BattleShips.player[BattleShips.battleShipCurrentPlayer].shipNames[j] + ", som er " + BattleShips.player[BattleShips.battleShipCurrentPlayer].shipLengths[j] + " felter langt.");
                        Console.WriteLine("Skriv skibets x-koordinat");
                        xKoordinat = BattleShips.GetNumberFromPlayer();
                        Console.WriteLine("Skriv skibets y-koordinat");
                        yKoordinat = BattleShips.GetNumberFromPlayer();
                        bool isEastClear = BattleShips.ValidateShipDirection(xKoordinat, yKoordinat, BattleShips.player[BattleShips.battleShipCurrentPlayer].shipLengths[j], 'e');
                        bool isWestClear = BattleShips.ValidateShipDirection(xKoordinat, yKoordinat, BattleShips.player[BattleShips.battleShipCurrentPlayer].shipLengths[j], 'w');
                        bool isNorthClear = BattleShips.ValidateShipDirection(xKoordinat, yKoordinat, BattleShips.player[BattleShips.battleShipCurrentPlayer].shipLengths[j], 'n');
                        bool isSouthClear = BattleShips.ValidateShipDirection(xKoordinat, yKoordinat, BattleShips.player[BattleShips.battleShipCurrentPlayer].shipLengths[j], 's');
                        if (isSouthClear || isWestClear || isNorthClear || isSouthClear)
                        {
                            if (isEastClear)
                            {
                                Console.WriteLine("Tryk 1 for at placere skibet mod øst");
                            }
                            if (isWestClear)
                            {
                                Console.WriteLine("Tryk 2 for at placere skibet mod vest");
                            }
                            if (isNorthClear)
                            {
                                Console.WriteLine("Tryk 3 for at placere skibet mod nord");
                            }
                            if (isSouthClear)
                            {
                                Console.WriteLine("Tryk 4 for at placere skibet mod syd");
                            }
                            int shipDirection = BattleShips.GetNumberFromPlayer();
                            BattleShips.PlaceShip(xKoordinat, yKoordinat, BattleShips.player[BattleShips.battleShipCurrentPlayer].shipLengths[j], shipDirection, BattleShips.player[BattleShips.battleShipCurrentPlayer].shipChar[j]);
                            Console.Clear();
                            shouldPickNewCoordinates = false;
                        }
                        else
                        {
                            Console.WriteLine("Der er ikke plads til skibet her. Vælg et nyt koordinatsæt");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    } while (shouldPickNewCoordinates);  
                }
                BattleShips.SmokeScreen();
                BattleShips.EndTurn();
                Console.Clear();
            }
        }

        private void PlayerShootsAtShips()
        {

            bool gameIsNotDone = true;
            do
            {
                bool notReadyToEndTurn = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine(BattleShips.GetBattleShipsGameBoardView());
                    Console.WriteLine(BattleShips.player[BattleShips.battleShipCurrentPlayer].name + " Skyd mod din modstander:");
                    Console.WriteLine("Skriv X koordinat");
                    int xKoordinat = BattleShips.GetNumberFromPlayer();
                    Console.WriteLine("\nSkriv Y koordinat");
                    int yKoordinat = BattleShips.GetNumberFromPlayer();

                    switch (BattleShips.FireShotsAtOppositePlayersBoardAndMarkMyShots(xKoordinat, yKoordinat))
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine(BattleShips.GetBattleShipsGameBoardView());
                            Console.WriteLine("Kaptajn, du har sunket et skib!");
                            notReadyToEndTurn = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine(BattleShips.GetBattleShipsGameBoardView());
                            Console.WriteLine("Splitte mine bramsejl, du har ramt et skib");
                            notReadyToEndTurn = false;
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine(BattleShips.GetBattleShipsGameBoardView());
                            Console.WriteLine("Det var uheldigvis en forbier... :( ");
                            notReadyToEndTurn = false;
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine(BattleShips.GetBattleShipsGameBoardView());
                            Console.WriteLine("Du har allerede skudt der... Prøv igen, Snotskovl! :)");
                            break;
                    }
                } while (notReadyToEndTurn);
                if (BattleShips.HasAnyoneWonTheGame())
                {
                    this.WeHaveAWinner();
                    gameIsNotDone = false;
                }
                else
                {
                    Console.WriteLine("Tryk en tast for at fortsætte.");
                    Console.ReadKey();
                    BattleShips.SmokeScreen();
                    BattleShips.EndTurn();
                }

            } while (gameIsNotDone);

        }

        private void WeHaveAWinner()
        {
            Console.Clear();
            Console.WriteLine(this.BattleShips.GetBattleShipsGameBoardView());
            Console.WriteLine("Tillykke Kaptajn " + BattleShips.player[BattleShips.battleShipCurrentPlayer].name + "!\nDu har vundet spillet!\nTryk en tast for at komme tilbage til menuen");
            Console.ReadKey();
            BattleShips = null;
        }

    }
}
