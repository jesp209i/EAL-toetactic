namespace spil
{
    //Player er klassen hvor vi definere spillernes brik
    internal class TicTacToePlayer
    {
        //Metoden Player er en Constructer som kendetegnes ved 
        //1. at metoden hedder det samme som klassen 
        //2. at den ikke har nogen returtype
        //Metoden Player har et parameter som er en char værdi og hedder marking
        public TicTacToePlayer(char marking)
        {
            //mark i Player.cs filen = marking
            this.Mark = marking;
        }

        //mark er en Property i Player klassen.
        //get returnere værdien den indeholder. 
        //set tildeler en værdi til mark fx. værdien X eller O
        public char Mark { get; internal set; }
    }
}