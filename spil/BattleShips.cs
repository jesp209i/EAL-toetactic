using System;
namespace spil
{
    public class BattleShips
    {
        public BattleShipsPlayer[] player;
        public int BattleShipsPlayerTurn = 0;

        //public char[,] GameBoardOfPlayerA { get; set; }
        //public char[,] GameBoardOfPlayerB { get; set; }

        //char array variabel
        public char[,] activeGameBoard { get; set; }
        public BattleShips()
        {
            player = new BattleShipsPlayer[2] {new BattleShipsPlayer(), new BattleShipsPlayer()};
        }
        public bool ValidateShipDirection(int xKoordinat, int yKoordinat, int lengthOfShip, char directionOfShip)
        {
            bool isTheDirectionValid = true;
            int retning = 1;
            if (directionOfShip == 'w' || directionOfShip == 's')
            {
                retning = -1;
            }

            if (directionOfShip == 'w' || directionOfShip == 'e')
            {
                for (int i = 0; i < lengthOfShip; i++)
                { 
                    if (activeGameBoard[xKoordinat + (i * retning), yKoordinat] != ' ' || xKoordinat + (i * retning) < 0 || yKoordinat + (i * retning) > 9)

                    {
                        return false;
                    }
                    else
                    {
                        if (activeGameBoard[xKoordinat + (i * retning), yKoordinat] != ' ')
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                isTheDirectionValid = true;
            }
            if (directionOfShip == 'n' || directionOfShip == 's')
            {
                for (int i = 0; i < lengthOfShip; i++)
                {
                    if (activeGameBoard[xKoordinat, yKoordinat + (i * retning)] != ' ' || yKoordinat + (i * retning) < 0 || yKoordinat + (i * retning) > 9)
                    {
                        return false;
                    }
                    else
                    {
                        if (activeGameBoard[xKoordinat, yKoordinat + (i * retning)] != ' ')
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                isTheDirectionValid = true;
            }
            return isTheDirectionValid;
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

        public void PlaceShip(int xKoordinat, int yKoordinat, int shipLength, int shipdirection)
        {
            //string xKoordinatstring = Console.ReadLine();
            //if (xKoordinatstring != "0" ||
            //    xKoordinatstring != "1" ||
            //    xKoordinatstring != "2" ||
            //    xKoordinatstring != "3" ||
            //    xKoordinatstring != "4" ||
            //    xKoordinatstring != "5" ||
            //    xKoordinatstring != "6" ||
            //    xKoordinatstring != "7" ||
            //    xKoordinatstring != "8" ||
            //    xKoordinatstring != "9")
            //{
            //    Console.WriteLine("Du må kun skrive et enkelt tal");
            //    Console.ReadKey();
            //}
            //else
            //{
            //    int xKoordinat = Convert.ToInt32(xKoordinatstring);
            //    string yKoordinatstring = Console.ReadLine();
            //    if (yKoordinatstring != "0" ||
            //        yKoordinatstring != "1" ||
            //        yKoordinatstring != "2" ||
            //        yKoordinatstring != "3" ||
            //        yKoordinatstring != "4" ||
            //        yKoordinatstring != "5" ||
            //        yKoordinatstring != "6" ||
            //        yKoordinatstring != "7" ||
            //        yKoordinatstring != "8" ||
            //        yKoordinatstring != "9")
            //    {
            //        Console.WriteLine("Du må kun skrive et enkelt tal");
            //        Console.ReadKey();
            //    }
            //    else
            //    {
            //        int yKoordinat = Convert.ToInt32(yKoordinatstring);
            bool isEastClear = ValidateShipDirection(xKoordinat, yKoordinat, shipLength, 'e');
            bool isWestClear = ValidateShipDirection(xKoordinat, yKoordinat, shipLength, 'w');
            bool isNorthClear = ValidateShipDirection(xKoordinat, yKoordinat, shipLength, 'n');
            bool isSouthClear = ValidateShipDirection(xKoordinat, yKoordinat, shipLength, 's');
            if (!isEastClear && !isWestClear && !isNorthClear && !isSouthClear)
            {
                Console.WriteLine("Der er ikke plads til skibet her!");
                Console.ReadKey();
            }
            else
            {
                if (isEastClear)
                {
                    Console.WriteLine("Tast 1 for at placerer skibet mod øst");
                    if (shipdirection == 1)
                    {
                        for (int i = 0; i <= shipLength; i++)
                        {
                            PlacePartOfBattleship(xKoordinat + i, yKoordinat);
                        }
                    }
                }
                if (isWestClear)
                {
                    Console.WriteLine("Tast 2 for at placerer skibet mod vest");
                    if (shipdirection == 2)
                    {
                        for (int i = 0; i <= shipLength; i++)
                        {
                            PlacePartOfBattleship(xKoordinat - i, yKoordinat);
                        }
                    }
                }
                if (isNorthClear)
                {
                    Console.WriteLine("Tast 3 for at placerer skibet mod nord");
                    if (shipdirection == 3)
                    {
                        for (int i = 0; i < shipLength; i++)
                        {
                            PlacePartOfBattleship(xKoordinat, yKoordinat + i);
                        }
                    }
                }
                if (isSouthClear)
                {
                    Console.WriteLine("Tast 4 for at placerer skibet mod syd");
                    if (shipdirection == 4)
                    {
                        for (int i = 0; i <= shipLength; i++)
                        {
                            PlacePartOfBattleship(xKoordinat, yKoordinat - i);
                        }
                    }
                }
            }
        }

        public void PlacePartOfBattleship(int xKoordinat, int yKoordinat)
        {
            activeGameBoard[xKoordinat, yKoordinat] = '#';
        }

        public int GetNumberFromPlayer()
        {
            char intToPrint;
            do
            {
                Console.WriteLine("Du skal skrive et tal.");
                intToPrint = Console.ReadKey().KeyChar;
            } while (!char.IsNumber(intToPrint));
            return Convert.ToInt32(intToPrint);
        }

        public bool FireShotsAtOppositePlayersBoardAndMarkMyShots(int xKoordinat, int yKoordinat)
        {
            bool isShotsSuccessful = false;
            char charOnGameBoard;
            charOnGameBoard = ValidatePlacement(xKoordinat, yKoordinat);
            if (BattleShipsPlayerTurn == 0)
            {
                if (charOnGameBoard != ' ' && charOnGameBoard != 'X' && charOnGameBoard != 'O')
                {
                    //checker shipChar array for position af skibs char. Så minusses der 1 fra shipLengths
                    int positionInArray = Array.IndexOf(player[1].shipChar, charOnGameBoard);
                    player[1].shipLengths[positionInArray] -= 1;
                    player[1].GameBoardMyShips[xKoordinat, yKoordinat] = 'X';
                    player[0].GameBoardMyShots[xKoordinat, yKoordinat] = 'X';
                    Console.WriteLine("BUM! \"Kaptajn, vi har ramt et skib\"");
                    Console.ReadKey();
                    isShotsSuccessful = true;
                }
                if (charOnGameBoard == ' ')
                {
                    player[1].GameBoardMyShips[xKoordinat, yKoordinat] = 'O';
                    player[0].GameBoardMyShots[xKoordinat, yKoordinat] = 'O';
                    Console.WriteLine("Plask!...\"Kaptajn, det var en misser\"");
                    Console.ReadKey();
                    isShotsSuccessful = true;
                }
                if (charOnGameBoard == 'X' || charOnGameBoard == 'O')
                {
                    Console.WriteLine("Du har allerede skudt der. Men det er godt at være sikker, i guess");
                    Console.ReadKey();
                    isShotsSuccessful = false;
                }
            }
            if (BattleShipsPlayerTurn == 1)
            {
                if (charOnGameBoard != ' ' && charOnGameBoard != 'X' && charOnGameBoard != 'O')
                {
                    //checker shipChar array for position af skibs char. Så minusses der 1 fra shipLengths
                    int positionInArray = Array.IndexOf(player[1].shipChar, charOnGameBoard);
                    player[0].shipLengths[positionInArray] -= 1;
                    player[0].GameBoardMyShips[xKoordinat, yKoordinat] = 'X';
                    player[1].GameBoardMyShots[xKoordinat, yKoordinat] = 'X';
                    Console.WriteLine("BUM! \"Kaptajn, vi har ramt et skib\"");
                    Console.ReadKey();
                    isShotsSuccessful = true;
                }
                if (charOnGameBoard == ' ')
                {
                    player[0].GameBoardMyShips[xKoordinat, yKoordinat] = 'O';
                    player[1].GameBoardMyShots[xKoordinat, yKoordinat] = 'O';
                    Console.WriteLine("Plask!...\"Kaptajn, det var en misser\"");
                    Console.ReadKey();
                    isShotsSuccessful = true;
                }
                if (charOnGameBoard == 'X' || charOnGameBoard == 'O')
                {
                    Console.WriteLine("Du har allerede skudt der. Men det er godt at være sikker, i guess");
                    Console.ReadKey();
                    isShotsSuccessful = false; 
                }
            }
            return isShotsSuccessful;
        }
    }
}