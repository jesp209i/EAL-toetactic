using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spil;

namespace Test
{
    [TestClass]
    public class BattleShipsTest
    {
        [TestMethod]
        public void GameBoardSquareIsNotEmpty()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.activeGameBoard = new char[10, 10]
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
            Assert.AreEqual(false, battleShipsTest.ValidatePlacement(3, 2));
        }
        [TestMethod]
        public void GameBoardSquareIsEmpty()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.activeGameBoard = new char[10, 10]
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
            Assert.AreEqual(true, battleShipsTest.ValidatePlacement(3, 2));
        }
        //[TestMethod]
        //public void CanVerifyThatShipCanBePlacedOnGameBoard()
        //{
        //    BattleShips battleShipsTest = new BattleShips();
        //    /*battleShipsTest.GameBoard = new char[10, 10]
        //    {
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //    }*/
        //    Assert.AreEqual(true, battleShipsTest.IsShipPlacementValid(3, 2,5,'n'));
        //}
        //public void VerifyInvalidShipPlacementOnOnGameBoard()
        //{
        //    BattleShips battleShipsTest = new BattleShips();
        //    battleShipsTest.GameBoard = new char[10, 10]
        //    {
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', 'x', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //    };
        //    Assert.AreEqual(false, battleShipsTest.IsShipPlacementValid(3, 2, 5, 'n'));
        //    Assert.AreEqual(false, battleShipsTest.IsShipPlacementValid(0, 0, 2, 's'));
        //    Assert.AreEqual(false, battleShipsTest.IsShipPlacementValid(0, 9, 3, 'w'));
        //    Assert.AreEqual(false, battleShipsTest.IsShipPlacementValid(9, 9, 3, 'e'));
        //}
        //public void SuccesfullyPlacedShip()
        //{
        //    BattleShips battleShipsTest = new BattleShips();
        //    char[,] expected = new char[10, 10]
        //    {
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', 'x', 'x', 'x', 'x', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //    };
        //    //PlaceShip(xKoordinat, yKoordinat, længde, retning)
        //    battleShipsTest.PlaceShip(3, 3, 4, 'w');
        //    Assert.AreEqual(expected, battleShipsTest.GameBoard);

        //}
        [TestMethod]
        public void CanPlacePartOfBattleship()
        {
            BattleShips battleShipsTest = new BattleShips();
            battleShipsTest.activeGameBoard = battleShipsTest.GameBoardOfPlayerA;
            battleShipsTest.PlacePartOfBattleship(3, 2);
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
            CollectionAssert.AreEqual(expected, battleShipsTest.activeGameBoard);
        }
    }
}
