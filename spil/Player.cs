namespace spil
{
    //Player er klassen hvor vi definere spillernes brik
    internal class Player
    {
        //Metoden Player er en Constructer som kendetegnes ved 
        //1. at metoden hedder det samme som klassen 
        //2. at den ikke har nogen returtype
        //Metoden Player har et parameter som er en char værdi og hedder marking
        public Player(char marking)
        {
            //mark i Player.cs filen = marking
            this.mark = marking;
        }

        //mark er en Property i Player klassen.
        //get returnere værdien den indeholder. 
        //set tildeler en værdi til mark fx. værdien X eller O
        public char mark { get; internal set; }
    }
}