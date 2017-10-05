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
                    case "2": StartBattleShipsVariationGame(); break;
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
            Console.WriteLine("Battleships");
            Console.WriteLine();
            Console.WriteLine("1. Opret nyt spil");
            Console.WriteLine("2. Opret variation");
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
            BattleShips battleShips = new BattleShips();
            battleShips.activeGameBoard = battleShips.GameBoardOfPlayerA;
            Console.WriteLine("Placer skibe");
            Console.WriteLine(battleShips.GetBattleShipsGameBoardView());
            Console.WriteLine();
            Console.ReadKey();
        }
        private void StartBattleShipsVariationGame()
        {
            Console.WriteLine("Koden for oprettelse af variation");
            Console.ReadKey();
        }
        
    }
}
