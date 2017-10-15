using Microsoft.VisualStudio.TestTools.UnitTesting;
using spil;

namespace Test
{
    [TestClass]
    public class BattleShipsTest
    {
        [TestMethod]
        public void BSCanPlaceAllShips()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.PlaceShip(0, 0, 2, 1, 'A');
            battleShipsTest.PlaceShip(0, 1, 2, 1, 'B');
            battleShipsTest.PlaceShip(0, 2, 2, 1, 'C');
            battleShipsTest.PlaceShip(0, 3, 3, 1, 'D');
            battleShipsTest.PlaceShip(0, 4, 3, 1, 'E');
            battleShipsTest.PlaceShip(0, 5, 3, 1, 'F');
            battleShipsTest.PlaceShip(0, 6, 4, 1, 'G');
            //battleShipsTest.PlaceShip(0, 7, 4, 1, 'H');
            //battleShipsTest.PlaceShip(0, 8, 5, 1, 'I');
            /*char[,] expected = new char[10,10]
                        {
                {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', ' '},
                {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', ' '},
                {' ', ' ', ' ', 'D', 'E', 'F', 'G', 'H', 'I', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'G', 'H', 'I', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'I', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
            };*/
            Assert.AreEqual(true, battleShipsTest.ValidateShipDirection(0, 7, 4, 'e'));
            Assert.AreEqual(false, battleShipsTest.ValidateShipDirection(0, 7, 4, 'n'));
            Assert.AreEqual(false, battleShipsTest.ValidateShipDirection(0, 7, 4, 's'));
            Assert.AreEqual(false, battleShipsTest.ValidateShipDirection(0, 7, 4, 'w'));
        }
        [TestMethod]
        public void BSOpponentGameBoardSquareIsNotEmpty()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.player[1].GameBoardMyShips = new char[10, 10]
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', 'x', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
            };
            Assert.AreEqual('x', battleShipsTest.ValidatePlacement(3, 2));
        }
        [TestMethod]
        public void BSOpponentGameBoardSquareIsEmpty()
        {
            BattleShips battleShipsTest = new BattleShips();
            Assert.AreEqual(' ', battleShipsTest.ValidatePlacement(3, 2));
        }
        [TestMethod]
        public void BSShipIsNotGone()
        {
            BattleShips battleShipsTest = new BattleShips();

            Assert.AreEqual(false, battleShipsTest.IsShipGone(3));
        }
        [TestMethod]
        public void BSShipIsGone()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.player[battleShipsTest.battleShipOppositePlayer].shipLengths[3] = 0;
            Assert.AreEqual(true, battleShipsTest.IsShipGone(3));
        }
        [TestMethod]
        public void BSCanVerifyThatShipCanBePlacedOnGameBoard()
        {
            BattleShips battleShipsTest = new BattleShips();
            Assert.AreEqual(true, battleShipsTest.ValidateShipDirection(3, 2, 5, 'n'));
        }
        [TestMethod]
        public void BSVerifyInvalidShipPlacementOnOnGameBoard()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.player[battleShipsTest.battleShipCurrentPlayer].GameBoardMyShips = new char[10, 10]
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', 'x', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            };
            Assert.AreEqual(false, battleShipsTest.ValidateShipDirection(3, 2, 5, 'n'));
            Assert.AreEqual(false, battleShipsTest.ValidateShipDirection(0, 0, 2, 's'));
            Assert.AreEqual(false, battleShipsTest.ValidateShipDirection(0, 9, 3, 'w'));
            Assert.AreEqual(false, battleShipsTest.ValidateShipDirection(9, 9, 3, 'e'));
        }
        [TestMethod]
        public void BSSuccesfullyPlacedShip()
        {
            BattleShips battleShipsTest = new BattleShips();
            char[,] expected = new char[10, 10]
            {
                {'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', 'C', 'C'},
                {'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {'A', ' ', ' ', '#', '#', '#', '#', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'B'},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'B'},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'B'},
            };
            //PlaceShip(xKoordinat, yKoordinat, længde, shipdirection)
            battleShipsTest.PlaceShip(3, 3, 4, 3, '#');
            battleShipsTest.PlaceShip(0, 0, 4, 1, 'A');
            battleShipsTest.PlaceShip(9, 9, 3, 2, 'B');
            battleShipsTest.PlaceShip(0, 9, 3, 4, 'C');
            CollectionAssert.AreEqual(expected, battleShipsTest.player[battleShipsTest.battleShipCurrentPlayer].GameBoardMyShips);

        }
        [TestMethod]
        public void BSCanPlacePartOfBattleship()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.PlacePartOfBattleship(3, 2, '#');
            char[,] expected = new char[10, 10]
        {
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
        };
            CollectionAssert.AreEqual(expected, battleShipsTest.player[battleShipsTest.battleShipCurrentPlayer].GameBoardMyShips);
        }
        [TestMethod]
        public void BSChangeFromPlayerOneToPlayerTwoAndBackAgain()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.EndTurn();
            Assert.AreEqual(1, battleShipsTest.battleShipCurrentPlayer);
            Assert.AreEqual(0, battleShipsTest.battleShipOppositePlayer);
            battleShipsTest.EndTurn();
            Assert.AreEqual(0, battleShipsTest.battleShipCurrentPlayer);
            Assert.AreEqual(1, battleShipsTest.battleShipOppositePlayer);
        }
        [TestMethod]
        public void BSWeHaveAWinner()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.player[battleShipsTest.battleShipOppositePlayer].shipLengths = new int[9] {0,0,0,0,0,0,0,0,0};
            Assert.AreEqual(true, battleShipsTest.HasAnyoneWonTheGame());
        }
        [TestMethod]
        public void BSWeDontHaveAWinner()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.player[battleShipsTest.battleShipOppositePlayer].shipLengths = new int[9] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            Assert.AreEqual(false, battleShipsTest.HasAnyoneWonTheGame());
        }
        [TestMethod]
        public void BSHasHitShip()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.player[battleShipsTest.battleShipOppositePlayer].GameBoardMyShips = new char[10,10]
                        {
                        {'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
                        };
            Assert.AreEqual(2, battleShipsTest.FireShotsAtOppositePlayersBoardAndMarkMyShots(0,0));
        }
        [TestMethod]
        public void BSHasNotHitShip()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.player[battleShipsTest.battleShipOppositePlayer].GameBoardMyShips = new char[10, 10]
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
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
                        };
            Assert.AreEqual(3, battleShipsTest.FireShotsAtOppositePlayersBoardAndMarkMyShots(0, 0));
        }
        [TestMethod]
        public void BSAlreadyShotAtThatPlace()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.player[battleShipsTest.battleShipOppositePlayer].GameBoardMyShips = new char[10, 10]
                        {
                        {'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
                        };
            Assert.AreEqual(4, battleShipsTest.FireShotsAtOppositePlayersBoardAndMarkMyShots(0, 0));
        }
        [TestMethod]
        public void BSSunkShip()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.player[battleShipsTest.battleShipOppositePlayer].shipLengths = new int[9] {1,2,2,3,3,4,4,5,9 };
            battleShipsTest.player[battleShipsTest.battleShipOppositePlayer].GameBoardMyShips = new char[10, 10]
                        {
                        {'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
                        };
            Assert.AreEqual(1, battleShipsTest.FireShotsAtOppositePlayersBoardAndMarkMyShots(0, 0));
        }

    }
}