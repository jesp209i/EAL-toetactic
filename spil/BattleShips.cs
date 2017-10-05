using System;
namespace spil
{
    internal class BattleShips
    {
        public string GetBattleShipsGameBoardView()
        {

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