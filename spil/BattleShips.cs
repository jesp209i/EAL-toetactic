using System;
namespace spil
{
    public class BattleShips
    {
        public BattleShipsPlayer[] player;
        public int battleShipsCurrentPlayer = 0;
        public int battleShipOppositePlayer = 1;

        //public char[,] GameBoardOfPlayerA { get; set; }
        //public char[,] GameBoardOfPlayerB { get; set; }

        //char array variabel
        //public char[,] activeGameBoard { get; set; }
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
                    if ( xKoordinat + (i * retning) < 0 || yKoordinat + (i * retning) > 9 ||player[battleShipsCurrentPlayer].GameBoardMyShips[xKoordinat + (i * retning), yKoordinat] != ' ')


                    {
                        return false;
                    }
                    else
                    {
                        if (player[battleShipsCurrentPlayer].GameBoardMyShips[xKoordinat + (i * retning), yKoordinat] != ' ')
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


                    if (yKoordinat + (i * retning) < 0 || yKoordinat + (i * retning) > 9|| player[battleShipsCurrentPlayer].GameBoardMyShips[xKoordinat, yKoordinat + (i * retning)] != ' ' )


                    {
                        return false;
                    }
                    else
                    {
                        if (player[battleShipsCurrentPlayer].GameBoardMyShips[xKoordinat, yKoordinat + (i * retning)] != ' ')
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
            resultat += "Y\n";
            resultat += "   _________________________________________       _________________________________________\n";
            for (int i = 0; i < 9; i++)
            {
                int inverseI = 9 - i;
            resultat += " " + inverseI +" | " + player[battleShipsCurrentPlayer].GameBoardMyShips[0, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShips[1, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShips[2, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShips[3, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShips[4, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShips[5, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShips[6, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShips[7, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShips[8, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShips[9, inverseI] + " |     " + inverseI +" | " + player[battleShipsCurrentPlayer].GameBoardMyShots[0, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShots[1, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShots[2, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShots[3, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShots[4, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShots[5, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShots[6, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShots[7, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShots[8, inverseI] + " | " + player[battleShipsCurrentPlayer].GameBoardMyShots[9, inverseI] + " | \n";
            resultat += "   |___|___|___|___|___|___|___|___|___|___|       |___|___|___|___|___|___|___|___|___|___|\n";
            }
            resultat += "    0   1   2   3   4   5   6   7   8   9    X       0   1   2   3   4   5   6   7   8   9   X";

            return resultat;

        }

        public string GetPlayerName()
        {
            Console.WriteLine("Indtast dit navn");
            string getPlayerName = Console.ReadLine();
            return getPlayerName;
        }

        public void PlaceShip(int xKoordinat, int yKoordinat, int shipLength, int shipdirection, char shipLetter)
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
                            PlacePartOfBattleship(xKoordinat + i, yKoordinat, shipLetter);
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
                            PlacePartOfBattleship(xKoordinat - i, yKoordinat, shipLetter);
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
                            PlacePartOfBattleship(xKoordinat, yKoordinat + i, shipLetter);
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
                            PlacePartOfBattleship(xKoordinat, yKoordinat - i, shipLetter);
                        }
                    }
                }
            }
        }

        public void PlacePartOfBattleship(int xKoordinat, int yKoordinat, char shipLetter)
        {
            player[battleShipsCurrentPlayer].GameBoardMyShips[xKoordinat, yKoordinat] = shipLetter;
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
            int currentPlayer = battleShipsCurrentPlayer;
            int opponentPlayer = battleShipOppositePlayer;

            /*if (BattleShipsPlayerTurn == 0)
            {
                currentPlayer = 0;
                opponentPlayer = 1;
            }
            else
            {
                currentPlayer = 1;
                opponentPlayer = 0;
            }*/
                if (charOnGameBoard != ' ' && charOnGameBoard != 'X' && charOnGameBoard != 'O')
                {
                    //checker shipChar array for position af skibs char. Så minusses der 1 fra shipLengths
                    int positionInArray = Array.IndexOf(player[1].shipChar, charOnGameBoard);
                    player[opponentPlayer].shipLengths[positionInArray] -= 1;
                    player[opponentPlayer].GameBoardMyShips[xKoordinat, yKoordinat] = 'X';
                    player[currentPlayer].GameBoardMyShots[xKoordinat, yKoordinat] = 'X';
                    if (IsShipGone(charOnGameBoard))
                    {
                        Console.WriteLine("Sunket \"Kaptajn, vi har sunket et skib!\"");
                        Console.ReadKey();
                        isShotsSuccessful = true;
                    }
                    else
                    {
                        Console.WriteLine("BUM! \"Kaptajn, vi har ramt et skib\"");
                        Console.ReadKey();
                        isShotsSuccessful = true;
                    }
                }
                if (charOnGameBoard == ' ')
                {
                    player[opponentPlayer].GameBoardMyShips[xKoordinat, yKoordinat] = 'O';
                    player[currentPlayer].GameBoardMyShots[xKoordinat, yKoordinat] = 'O';
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
            return isShotsSuccessful;
        }

        private bool IsShipGone(char charOnGameBoard)
        {
            throw new NotImplementedException();
        }

        public char ValidatePlacement(int xKordiant, int yKoordinat)
        { 
             return player[battleShipsCurrentPlayer].GameBoardMyShips[xKordiant, yKoordinat];

        }
    }
}
// TODO Needs to remove/refactor activeGameBoard, or find other solution, see line 293.
// TODO Needs to track currentPlayer and opponent (maybe 'int's in BattleShips-class scope?)
// TODO needs method to change player when turn is done. (maybe include a "smokescreen" here, when changing players?)
// TODO needs method to update gameBoardsScreen with relevant information (ship placement and bombings).
// TODO IsShipGone() method missing
// TODO refactor FireShotsAtOppositePlayersBoardAndMarkMyShots() method - how can we make tests for it? - Is it doing too much?
//               Can we reuse methods we've already made? (in short: almost!)
// TODO method to check if game is done, and show winner.
// 
// Is anything missing?
//
// How can we tie everything nicely together?
// Does everybody understand what's happening? (This is really Important!)
// Presentation - what, what?
//
// Bonus -----
// Refactor ValidateShipDirection() - method works, but can be much nicer!
// Refactor PlaceShip() - method works, but can be much nicer!
