using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spil
{
    class BattleShipsMenu
    {
        BattleShips battleShips { get; set; }
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
            if (battleShips != null)
            {
                Console.WriteLine(battleShips.GetBattleShipsGameBoardView());
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
            battleShips = new BattleShips();
            for (int i = 0; i < battleShips.player.Length; i++)
            {
                battleShips.player[battleShips.battleShipCurrentPlayer].name = battleShips.GetPlayerName();
                for (int j = 0;  j < 9;  j++)
                {
                    bool shouldPickNewCoordinates = true;
                    do
                    {
                        int xKoordinat;
                        int yKoordinat;
                        Console.WriteLine(battleShips.GetBattleShipsGameBoardView());
                        Console.WriteLine();
                        Console.WriteLine("Du er ved, at placere " + battleShips.player[battleShips.battleShipCurrentPlayer].shipNames[j] + ", som er " + battleShips.player[battleShips.battleShipCurrentPlayer].shipLengths[j] + " felter langt.");
                        Console.WriteLine("Skriv skibets x-koordinat");
                        xKoordinat = battleShips.GetNumberFromPlayer();
                        Console.WriteLine("Skriv skibets y-koordinat");
                        yKoordinat = battleShips.GetNumberFromPlayer();
                        bool isEastClear = battleShips.ValidateShipDirection(xKoordinat, yKoordinat, battleShips.player[battleShips.battleShipCurrentPlayer].shipLengths[j], 'e');
                        bool isWestClear = battleShips.ValidateShipDirection(xKoordinat, yKoordinat, battleShips.player[battleShips.battleShipCurrentPlayer].shipLengths[j], 'w');
                        bool isNorthClear = battleShips.ValidateShipDirection(xKoordinat, yKoordinat, battleShips.player[battleShips.battleShipCurrentPlayer].shipLengths[j], 'n');
                        bool isSouthClear = battleShips.ValidateShipDirection(xKoordinat, yKoordinat, battleShips.player[battleShips.battleShipCurrentPlayer].shipLengths[j], 's');
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
                            int shipDirection = battleShips.GetNumberFromPlayer();
                            battleShips.PlaceShip(xKoordinat, yKoordinat, battleShips.player[battleShips.battleShipCurrentPlayer].shipLengths[j], shipDirection, battleShips.player[battleShips.battleShipCurrentPlayer].shipChar[j]);
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
                battleShips.SmokeScreen();
                battleShips.EndTurn();
                Console.Clear();
            }
        }
    }
}
