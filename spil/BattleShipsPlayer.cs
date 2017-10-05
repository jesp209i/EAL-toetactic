namespace spil
{
    internal class BattleShipsPlayer
    {
        public string[] hangar = new string[5];
        public string[] slagSkib1 = new string[4];
        public string[] slagSkib2 = new string[4];
        public string[] destroyer1 = new string[3];
        public string[] destroyer2 = new string[3];
        public string[] ubaad = new string[3];
        public string[] patruljebåd1 = new string[2];
        public string[] patruljebåd2 = new string[2];
        public string[] patruljebåd3 = new string[2];
        public string name;
        public string Name 
            { 
            get { return this.name; }
            set { this.name = value; }
            }

    }
}