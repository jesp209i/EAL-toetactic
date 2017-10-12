using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spil;

namespace Test
{
    [TestClass]
    public class BattleShipsTest
    {
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
        public void BSOpponentGameBoardSquareIsEmpty()
        {
            BattleShips battleShipsTest = new BattleShips();
            Assert.AreEqual(' ', battleShipsTest.ValidatePlacement(3, 2));
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
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', '#', '#', '#', '#', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            };
            //PlaceShip(xKoordinat, yKoordinat, længde, shipdirection)
            battleShipsTest.PlaceShip(3, 3, 4, 3, '#');
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
        public void BSChangeFromPlayerOneToPlayerTwo()
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
    }
}