using System;

namespace spil
{
    internal class GameChooser
    {
        public void StartMenu()
        {
            bool keepMenuRunning = true;
            string userInput;
            do
            {
                ShowMenuStart();
                userInput = GetUserChoice();
                switch (userInput)
                {
                    case "1": BeginTicTacToeMenu();
                        break;
                    case "2": BeginBattleshipsMenu();
                        break;
                    case "0": keepMenuRunning = false;
                        break;
                    default: ShowMenuSelectionError();
                        break;
                }
            } while (keepMenuRunning);

        }

        private void BeginBattleshipsMenu()
        {
            BattleShipsMenu battleShip = new BattleShipsMenu();
            battleShip.Show();
        }

        private void BeginTicTacToeMenu()
        {
            TicTacToeMenu ticTacToe = new TicTacToeMenu();
            ticTacToe.Show();
        }

        private void ShowMenuStart()
        {
            Console.Clear();
            Console.WriteLine("Hvad vil du spille?");
            Console.WriteLine();
            Console.WriteLine("1. TicTacToe");
            Console.WriteLine("2. Battleships");
            Console.WriteLine();
            Console.WriteLine("0. Afslut");
        }

        private string GetUserChoice()
        {
            Console.WriteLine("Vælg menu");
            return Console.ReadLine();
        }

        private void ShowMenuSelectionError()
        {
            Console.WriteLine("Ugyldigt valg");
            Console.ReadKey();
        }
    }
}