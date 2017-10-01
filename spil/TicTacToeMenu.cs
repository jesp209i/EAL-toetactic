using System;

namespace spil
{

    public class TicTacToeMenu
    {
        TicTacToe ticTacToe {get; set; }
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
                    case "1": DoActionFor1(); break;
                    case "2": DoActionFor2(); break;
                    case "3": DoActionFor3(); break;
                    case "0": running = false; break;
                    default : ShowMenuSelectionErroe(); break;
                }
            } while (running);
        }

        private void ShowGameChoose()
        {
            bool lol = true;
            string choice = "";
            do
            {
                ChooseGame();
                choice = GetUserChoise();
                switch (choice)
                {
                    case "1": DoActionStartNormalGame();
                        lol = false;
                    break;
                    case "2": DoActionStartVariationGame();
                        lol = false;
                    break;
                    case "0": lol = false; break;
                    default: ShowMenuSelectionErroe(); break;
                }
            } while (lol);
        }

        private void DoActionStartVariationGame()
        {
            ticTacToe = new TicTacToe();
            ticTacToe.isVariation = true;
            ticTacToe.AddPlayers();
        }

        private void DoActionStartNormalGame()
        {
             ticTacToe = new TicTacToe();
            ticTacToe.isVariation = false;
            ticTacToe.AddPlayers();
        }

        private void ShowMenu()
        {
            Console.Clear();
            if (ticTacToe != null)
            {
                Console.WriteLine(ticTacToe.GetGameBoardView());
            }
            Console.WriteLine("tic tac toe");
            Console.WriteLine();
            Console.WriteLine("1. Opret nyt spil");
            Console.WriteLine("2. Sæt en brik");
            Console.WriteLine("3. Flyt en brik");
            Console.WriteLine();
            Console.WriteLine("0. exit");
        }

        private void ChooseGame()
        {
            Console.Clear();
            Console.WriteLine("Vil du starte almindeligt eller variation?");
            Console.WriteLine();
            Console.WriteLine("1. Almindeligt");
            Console.WriteLine("2. Variation");
            Console.WriteLine();
            Console.WriteLine("0. Tilbage");
        }


        private string GetUserChoise()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }

        private void ShowMenuSelectionErroe()
        {
            Console.WriteLine("Ugyldigt valg.");
            Console.ReadLine();
        }

        private void DoActionFor1()
        {
            ShowGameChoose();
        }
        private void DoActionFor2()
        {
            //Vi kalder kalder PlaceMark metoden som ligger i TicTacToe.cs filen
            ticTacToe.PlaceMark();
            // Hvis Validate metoden som ligger i TicTacToe.cs filen ikke = ' '
            //Så aktiveres denne if statement
            if (ticTacToe.Validate()!=' ')
            {
                //Vi definere resultatet som en string der indeholder en tom string
                string resultatet = "";
                // Vi tilføger Tillykke ! og ticTacToe.Validate() og " har vundet! til stringen resultatet
                // ticTacToe.Validate() metoden returnere vinderens brik fx. X eller O
                // Kan også skrives som  resultatet = resultatet + ("Tillykke! " + ticTacToe.Validate() + " har vundet!"); 
                resultatet += ("Tillykke! " + ticTacToe.Validate() + " har vundet!");

                Console.Clear();
                Console.WriteLine(ticTacToe.GetGameBoardView());
                Console.WriteLine(resultatet);
                Console.ReadKey();
                //Når ticTacToe = null så sletter vi vores instans af spillet som er tictactoe objektet.
                ticTacToe = null;
            }
            // Hvis ticTacToe ikke = null så kører vores nuværende instans af spillet
            //Såfremt CountNumberOfMarks metoden i TicTacToe.cs filen når 10
            //Så aktiveres denne if statement
            if (ticTacToe != null && ticTacToe.CountNumberOfMarks == 10)
            {
                // NoWinner metoden i TicTacToeMenu.cs bliver kaldt
                this.NoWinner();
            }
        }
        private void DoActionFor3()
        {
            ticTacToe.MoveMark();
        }
        private void NoWinner()
        {
            Console.Clear();
            Console.WriteLine(ticTacToe.GetGameBoardView());
            Console.WriteLine("It is a Draw. Tryk på en tast for at komme tilbage til menuen.");
            Console.ReadKey();
            ticTacToe = null;
        }

    }
}