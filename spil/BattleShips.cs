using System;
namespace spil
{
    public class BattleShips
    {
        public BattleShipsPlayer[] player;

        public int battleShipCurrentPlayer = 0;
        public int battleShipOppositePlayer = 1;

        public BattleShips()
        {
            player = new BattleShipsPlayer[2] { new BattleShipsPlayer(), new BattleShipsPlayer() };
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

                    if (xKoordinat + (i * retning) < 0 || yKoordinat + (i * retning) > 9 || player[battleShipCurrentPlayer].GameBoardMyShips[xKoordinat + (i * retning), yKoordinat] != ' ')
                    {
                        return false;
                    }
                    else
                    {
                        if (player[battleShipCurrentPlayer].GameBoardMyShips[xKoordinat + (i * retning), yKoordinat] != ' ')
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


                    if (yKoordinat + (i * retning) < 0 || yKoordinat + (i * retning) > 9 || player[battleShipCurrentPlayer].GameBoardMyShips[xKoordinat, yKoordinat + (i * retning)] != ' ')



                    {
                        return false;
                    }
                    else
                    {
                        if (player[battleShipCurrentPlayer].GameBoardMyShips[xKoordinat, yKoordinat + (i * retning)] != ' ')
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
            resultat += "Y   Dine skibe                                      Skyd efter din modstander\n";
            resultat += "   _________________________________________       _________________________________________\n";
            for (int i = 0; i < 9; i++)
            {
                int inverseI = 9 - i;
                resultat += " " + inverseI + " | " + player[battleShipCurrentPlayer].GameBoardMyShips[0, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShips[1, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShips[2, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShips[3, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShips[4, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShips[5, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShips[6, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShips[7, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShips[8, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShips[9, inverseI] + " |     " + inverseI + " | " + player[battleShipCurrentPlayer].GameBoardMyShots[0, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShots[1, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShots[2, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShots[3, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShots[4, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShots[5, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShots[6, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShots[7, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShots[8, inverseI] + " | " + player[battleShipCurrentPlayer].GameBoardMyShots[9, inverseI] + " | \n";
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
            player[battleShipCurrentPlayer].GameBoardMyShips[xKoordinat, yKoordinat] = shipLetter;
        }

        public int GetNumberFromPlayer()
        {
            bool numberIsNotOk = true;
            do
            {
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int numberFromPlayer) && userInput.Length == 1 && numberFromPlayer > -1)
            {
                numberIsNotOk = false;
                return numberFromPlayer;
            }
            else
            {
                Console.WriteLine("Du skal skrive et tal");
                Console.ReadKey();
            }
            } while (numberIsNotOk);
        }


        public int FireShotsAtOppositePlayersBoardAndMarkMyShots(int xKoordinat, int yKoordinat)
        {
            int shotReport = 0;
            char charOnGameBoard;
            charOnGameBoard = ValidatePlacement(xKoordinat, yKoordinat);

            if (charOnGameBoard != ' ' && charOnGameBoard != 'X' && charOnGameBoard != 'O')
            {
                //checker shipChar array for position af skibs char. Så minusses der 1 fra shipLengths
                int positionInArray = Array.IndexOf(player[battleShipOppositePlayer].shipChar, charOnGameBoard);
                player[battleShipOppositePlayer].shipLengths[positionInArray] -= 1;
                player[battleShipOppositePlayer].GameBoardMyShips[xKoordinat, yKoordinat] = 'X';
                player[battleShipCurrentPlayer].GameBoardMyShots[xKoordinat, yKoordinat] = 'X';
                if (IsShipGone(positionInArray))
                {
                    shotReport = 1; //sunket
                }
                else
                {
                    shotReport = 2; //ramt
                }
            }
            if (charOnGameBoard == ' ')
            {
                player[battleShipOppositePlayer].GameBoardMyShips[xKoordinat, yKoordinat] = 'O';
                player[battleShipCurrentPlayer].GameBoardMyShots[xKoordinat, yKoordinat] = 'O';
                shotReport = 3; //plask
            }
            if (charOnGameBoard == 'X' || charOnGameBoard == 'O')
            {
                shotReport = 4; //skudt to gange det samme sted
            }
            return shotReport;
        }

        public char ValidatePlacement(int xKordiant, int yKoordinat)
        {
            return player[battleShipCurrentPlayer].GameBoardMyShips[xKordiant, yKoordinat];

        }

        public bool HasAnyoneWonTheGame()
        {
            foreach (int oneShipLength in player[battleShipOppositePlayer].shipLengths)
            {
                if (oneShipLength > 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsShipGone(int positionInArray)
        {
            bool returnValue;
            if (player[battleShipOppositePlayer].shipLengths[positionInArray] < 1)
            {
                returnValue = true;
            }
            else
            {
                returnValue = false;
            }
            return returnValue;
        }


        public void EndTurn()
        {
            if (battleShipCurrentPlayer == 0)
            {
                battleShipCurrentPlayer = 1;
                battleShipOppositePlayer = 0;
            }
            else
            {
                battleShipCurrentPlayer = 0;
                battleShipOppositePlayer = 1;

            }
        }

        public void SmokeScreen()
        {
            string oppositePlayerName;
            if (this.player[battleShipOppositePlayer].name == "")
            {
                oppositePlayerName = "spiller 2";
            }
            else
            {
                oppositePlayerName = this.player[battleShipOppositePlayer].name;
            }
            Console.Clear();
            Console.WriteLine("     _______  _______  _______  _______  ___      _______  _______  __   __  ___   _______  _______ ");
            Console.WriteLine("    |  _    ||   _   ||       ||       ||   |    |       ||       ||  | |  ||   | |       ||       |");
            Console.WriteLine("    | |_|   ||  |_|  ||_     _||_     _||   |    |    ___||  _____||  |_|  ||   | |    _  ||  _____|");
            Console.WriteLine("    |       ||       |  |   |    |   |  |   |    |   |___ | |_____ |       ||   | |   |_| || |_____ ");
            Console.WriteLine("    |  _   | |       |  |   |    |   |  |   |___ |    ___||_____  ||       ||   | |    ___||_____  |");
            Console.WriteLine("    | |_|   ||   _   |  |   |    |   |  |       ||   |___  _____| ||   _   ||   | |   |     _____| |");
            Console.WriteLine("    |_______||__| |__|  |___|    |___|  |_______||_______||_______||__| |__||___| |___|    |_______|");
            Console.WriteLine();
            Console.WriteLine(" _______  ___   _  ___   _______  _______    _______  _______  ___   ___      ___      _______  ______   ");
            Console.WriteLine("|       ||   | | ||   | |       ||       |  |       ||       ||   | |   |    |   |    |       ||    _ |  ");
            Console.WriteLine("|  _____||   |_| ||   | |    ___||_     _|  |  _____||    _  ||   | |   |    |   |    |    ___||   | ||  ");
            Console.WriteLine("| |_____ |      _||   | |   |___   |   |    | |_____ |   |_| ||   | |   |    |   |    |   |___ |   |_||_ ");
            Console.WriteLine("|_____  ||     |_ |   | |    ___|  |   |    |_____  ||    ___||   | |   |___ |   |___ |    ___||    __  |");
            Console.WriteLine(" _____| ||    _  ||   | |   |      |   |     _____| ||   |    |   | |       ||       ||   |___ |   |  | |");
            Console.WriteLine("|_______||___| |_||___| |___|      |___|    |_______||___|    |___| |_______||_______||_______||___|  |_|");
            Console.WriteLine("Skift spiller, tryk på en tast når " + oppositePlayerName + " er klar");
            Console.ReadKey();
        }
    }
}
// TODO refactor FireShotsAtOppositePlayersBoardAndMarkMyShots() method - how can we make tests for it? - Is it doing too much?
//               Can we reuse methods we've already made? (in short: almost!)
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
