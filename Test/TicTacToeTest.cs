using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spil;

namespace Test
{
    [TestClass]
    public class TicTacToeTest
    {
        [TestMethod]
        public void NeitherPlayerHasThreeInARow()
        {
            TicTacToe ticTacToe = new TicTacToe();
            const char expectet = ' ';
            char actual = ticTacToe.Validate();
            Assert.AreEqual(expectet, actual); 
        }

        [TestMethod]
        public void ThreeInARow()
        {
            TicTacToe ticTacToe = new TicTacToe();
            const char expectet = 'x';
            ticTacToe.GameBoard = new char[3, 3]{
                { ' ', ' ', ' '},
                { 'x', 'x', 'x'},
                { ' ', ' ', ' '}
                };
            char actual = ticTacToe.Validate();
            Assert.AreEqual(expectet, actual);


        }
        [TestMethod]
        public void ThreeInAColumn()
        {
            TicTacToe ticTacToe = new TicTacToe();
            const char expectet = 'O';
            ticTacToe.GameBoard = new char[3, 3]{
                { ' ', ' ', 'O'},
                { ' ', ' ', 'O'},
                { ' ', ' ', 'O'}
                };
            char actual = ticTacToe.Validate();
            Assert.AreEqual(expectet, actual);
        }

        [TestMethod]
        public void ThreeDiagonaly()
        {
            TicTacToe ticTacToe = new TicTacToe();
            const char expectet = 'X';
            ticTacToe.GameBoard = new char[3, 3]{
                { 'X', ' ', ' '},
                { ' ', 'X', ' '},
                { ' ', ' ', 'X'}
                };
            char actual = ticTacToe.Validate();
            Assert.AreEqual(expectet, actual);
        }

        [TestMethod]
        public void PlayerDraw()
        {
            TicTacToe ticTacToe = new TicTacToe();
            const char expectet = ' ';
            ticTacToe.GameBoard = new char[3, 3]{
                { 'x', 'o', 'x'},
                { 'o', 'x', 'x'},
                { 'o', 'x', 'o'}
                };
            char actual = ticTacToe.Validate();
            Assert.AreEqual(expectet, actual);
        }
    }
}
