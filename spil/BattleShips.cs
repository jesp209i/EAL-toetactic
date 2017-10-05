using System;
namespace spil
{
    public class BattleShips
    {
        public char[,] GameBoardOfPlayerA { get; set; }
        public char[,] GameBoardOfPlayerB { get; set; }

        //char array variabel
        public char[,] activeGameBoard { get; set; }
        public BattleShips()
        {
            GameBoardOfPlayerA = new char[10, 10]
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            };
            GameBoardOfPlayerB = new char[10, 10] 
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            };
        }
        public string GetBattleShipsGameBoardView()
        {

            string resultat = "";
            resultat = resultat + "Y\n";
            resultat = resultat + "   ___________________________________________________________ \n";
            resultat = resultat + "9 |  " + activeGameBoard[0, 9] + "  |  " + activeGameBoard[1, 9] + "  |  " + activeGameBoard[2, 9] + "  |  " + activeGameBoard[3, 9] + "  |  " + activeGameBoard[4, 9] + "  |  " + activeGameBoard[5, 9] + "  |  " + activeGameBoard[6, 9] + "  |  " + activeGameBoard[7, 9] + "  |  " + activeGameBoard[8, 9] + "  |  " + activeGameBoard[9, 9] + "  |\n";
            resultat = resultat + "  |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|\n";
            resultat = resultat + "8 |  " + activeGameBoard[0, 8] + "  |  " + activeGameBoard[1, 8] + "  |  " + activeGameBoard[2, 8] + "  |  " + activeGameBoard[3, 8] + "  |  " + activeGameBoard[4, 8] + "  |  " + activeGameBoard[5, 8] + "  |  " + activeGameBoard[6, 8] + "  |  " + activeGameBoard[7, 8] + "  |  " + activeGameBoard[8, 8] + "  |  " + activeGameBoard[9, 8] + "  |\n";
            resultat = resultat + "  |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|\n";
            resultat = resultat + "7 |  " + activeGameBoard[0, 7] + "  |  " + activeGameBoard[1, 7] + "  |  " + activeGameBoard[2, 7] + "  |  " + activeGameBoard[3, 7] + "  |  " + activeGameBoard[4, 7] + "  |  " + activeGameBoard[5, 7] + "  |  " + activeGameBoard[6, 7] + "  |  " + activeGameBoard[7, 7] + "  |  " + activeGameBoard[8, 7] + "  |  " + activeGameBoard[9, 7] + "  |\n";
            resultat = resultat + "  |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|\n";
            resultat = resultat + "6 |  " + activeGameBoard[0, 6] + "  |  " + activeGameBoard[1, 6] + "  |  " + activeGameBoard[2, 6] + "  |  " + activeGameBoard[3, 6] + "  |  " + activeGameBoard[4, 6] + "  |  " + activeGameBoard[5, 6] + "  |  " + activeGameBoard[6, 6] + "  |  " + activeGameBoard[7, 6] + "  |  " + activeGameBoard[8, 6] + "  |  " + activeGameBoard[9, 6] + "  |\n";
            resultat = resultat + "  |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|\n";
            resultat = resultat + "5 |  " + activeGameBoard[0, 5] + "  |  " + activeGameBoard[1, 5] + "  |  " + activeGameBoard[2, 5] + "  |  " + activeGameBoard[3, 5] + "  |  " + activeGameBoard[4, 5] + "  |  " + activeGameBoard[5, 5] + "  |  " + activeGameBoard[6, 5] + "  |  " + activeGameBoard[7, 5] + "  |  " + activeGameBoard[8, 5] + "  |  " + activeGameBoard[9, 5] + "  |\n";
            resultat = resultat + "  |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|\n";
            resultat = resultat + "4 |  " + activeGameBoard[0, 4] + "  |  " + activeGameBoard[1, 4] + "  |  " + activeGameBoard[2, 4] + "  |  " + activeGameBoard[3, 4] + "  |  " + activeGameBoard[4, 4] + "  |  " + activeGameBoard[5, 4] + "  |  " + activeGameBoard[6, 4] + "  |  " + activeGameBoard[7, 4] + "  |  " + activeGameBoard[8, 4] + "  |  " + activeGameBoard[9, 4] + "  |\n";
            resultat = resultat + "  |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|\n";
            resultat = resultat + "3 |  " + activeGameBoard[0, 3] + "  |  " + activeGameBoard[1, 3] + "  |  " + activeGameBoard[2, 3] + "  |  " + activeGameBoard[3, 3] + "  |  " + activeGameBoard[4, 3] + "  |  " + activeGameBoard[5, 3] + "  |  " + activeGameBoard[6, 3] + "  |  " + activeGameBoard[7, 3] + "  |  " + activeGameBoard[8, 3] + "  |  " + activeGameBoard[9, 3] + "  |\n";
            resultat = resultat + "  |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|\n";
            resultat = resultat + "2 |  " + activeGameBoard[0, 2] + "  |  " + activeGameBoard[1, 2] + "  |  " + activeGameBoard[2, 2] + "  |  " + activeGameBoard[3, 2] + "  |  " + activeGameBoard[4, 2] + "  |  " + activeGameBoard[5, 2] + "  |  " + activeGameBoard[6, 2] + "  |  " + activeGameBoard[7, 2] + "  |  " + activeGameBoard[8, 2] + "  |  " + activeGameBoard[9, 2] + "  |\n";
            resultat = resultat + "  |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|\n";
            resultat = resultat + "1 |  " + activeGameBoard[0, 1] + "  |  " + activeGameBoard[1, 1] + "  |  " + activeGameBoard[2, 1] + "  |  " + activeGameBoard[3, 1] + "  |  " + activeGameBoard[4, 1] + "  |  " + activeGameBoard[5, 1] + "  |  " + activeGameBoard[6, 1] + "  |  " + activeGameBoard[7, 1] + "  |  " + activeGameBoard[8, 1] + "  |  " + activeGameBoard[9, 1] + "  |\n";
            resultat = resultat + "  |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|\n";
            resultat = resultat + "0 |  " + activeGameBoard[0, 0] + "  |  " + activeGameBoard[1, 0] + "  |  " + activeGameBoard[2, 0] + "  |  " + activeGameBoard[3, 0] + "  |  " + activeGameBoard[4, 0] + "  |  " + activeGameBoard[5, 0] + "  |  " + activeGameBoard[6, 0] + "  |  " + activeGameBoard[7, 0] + "  |  " + activeGameBoard[8, 0] + "  |  " + activeGameBoard[9, 0] + "  |\n";
            resultat = resultat + "  |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|\n";
            resultat = resultat + "     0     1     2     3     4     5     6     7     8     9    X";

            return resultat;

        }

        public string GetPlayerName()
        {
            Console.WriteLine("Indtast dit navn");
            string getPlayerName = Console.ReadLine();
            return getPlayerName;
        }

        public void PlaceShip(string shipName, int shipLength)
        {
            Console.WriteLine("Indtast X og Y koordinater for stævnen på " + shipName);
            string firstPlacement = Console.ReadLine();
            int xKoordinat;
            int yKoordinat;
            if (firstPlacement.Length == 2 && int.TryParse(firstPlacement, out int s))
            {
                xKoordinat = (int) firstPlacement[0];
                yKoordinat = (int) firstPlacement[1];

            }
            else
            {
                Console.WriteLine("Ugyldigt");
            }
        }

        public void ValidatePlacement(int xKoordinat, int yKoordinat)
            {
                
            }
    }
    
}