using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spil
{

    public class TicTacToe
    {
        public char[,] GameBoard { get; set; }

        // De to spillere som skal bruges i spillet.
        Player playerA;
        Player playerB;

        // bruges til at afgøre hvilken spillers tur det er - se nede i metode PlaceMark()
        public bool isItAsturn = true;

        // Denne bool bruges til, at tjekke om det er det klassiske spil eller variationen
        public bool isVariation = true;

        // bruges til at sætte en brik på spillebrættet - se nede i metode PlaceMark()
        char mark;

        //Variablen CountNumberOfMarks skal tælle hvor mange brikker der er på brættet
        public int CountNumberOfMarks = 1;
        public void CountMarks()
        //public er for at gøre metoden tilgængelig alle steder.
        // void gør at metoden ikke returnere nogen. Man kan ikke kalde resultatet af metoden.
        {
            // CountNumberOfMarks++; er det samme som CountNumberOfMarks = CountNumberOfMarks + 1;
            CountNumberOfMarks++;
            //returnere værdien af CountNumberOfMarks
        }

        public TicTacToe()
        {
            GameBoard = new char[3, 3] {
                {' ', ' ', ' '},
                {' ', ' ', ' '},
                {' ', ' ', ' '} };
        }

        public string GetGameBoardView()
        {
            string resultat = "";
            resultat = resultat + "Y\n";
            resultat = resultat + "   _________________ \n";
            resultat = resultat + "  |     |     |     |\n";
            resultat = resultat + "3 |  " + GameBoard[0, 2] + "  |  " + GameBoard[1, 2] + "  |  " + GameBoard[2, 2] + "  |\n";
            resultat = resultat + "  |     |     |     |\n";
            resultat = resultat + "  |_____|_____|_____|\n";
            resultat = resultat + "  |     |     |     |\n";
            resultat = resultat + "2 |  " + GameBoard[0, 1] + "  |  " + GameBoard[1, 1] + "  |  " + GameBoard[2, 1] + "  |\n";
            resultat = resultat + "  |     |     |     |\n";
            resultat = resultat + "  |_____|_____|_____|\n";
            resultat = resultat + "  |     |     |     |\n";
            resultat = resultat + "1 |  " + GameBoard[0, 0] + "  |  " + GameBoard[1, 0] + "  |  " + GameBoard[2, 0] + "  |\n";
            resultat = resultat + "  |     |     |     |\n";
            resultat = resultat + "  |_____|_____|_____|\n";
            resultat = resultat + "     1     2     3    X\n";

            return resultat;
        }

        public char Validate() //Validate metoden undersøger hver linje for 3 på stribe
        {
            //Vi definerer resultatet som en char der inderholder mellemrum.
            //Hvis ingen har vundet returnere vi denne char i bunden af metoden
            char resultatet = ' '; 

            // GameBoard[0, 0] != ' ' tjkker om 0,0 er et mellemrum i GameBoard arrayet
            //&& GameBoard[0, 0] == GameBoard[1, 0] && GameBoard[1, 0] == GameBoard[2, 0])
            //tjekker om rækken er ens i arrayet
            //nederste række og første kolonne
            if (
                (GameBoard[0, 0] != ' ' && GameBoard[0, 0] == GameBoard[1, 0] && GameBoard[1, 0] == GameBoard[2, 0]) ||
                (GameBoard[0, 0] != ' ' && GameBoard[0, 0] == GameBoard[0, 1] && GameBoard[0, 1] == GameBoard[0, 2]))
            {
                //Hvis rækken er ens bliver char resultatet sat til det tegn der er i første felt vi tjekker i arrayet
                resultatet = GameBoard[0, 0];
            }
            //midterste kolonne og række
            if (
                (GameBoard[0, 1] != ' ' && GameBoard[0, 1] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[2, 1]) ||
                (GameBoard[1, 0] != ' ' && GameBoard[1, 0] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[1, 2]))
            {
                resultatet = GameBoard[1, 1];
            }
            //øverste række og sidste kolonne
            if (
                (GameBoard[0, 2] != ' ' && GameBoard[0, 2] == GameBoard[1, 2] && GameBoard[1, 2] == GameBoard[2, 2]) ||
                (GameBoard[2, 0] != ' ' && GameBoard[2, 0] == GameBoard[2, 1] && GameBoard[2, 1] == GameBoard[2, 2]))
            {
                resultatet = GameBoard[2,2];
            }
            // begge diagonaler
            if (
                (GameBoard[0, 2] != ' ' && GameBoard[0, 2] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[2, 0]) ||
                (GameBoard[0, 0] != ' ' && GameBoard[0, 0] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[2, 2]))
            {
                resultatet = GameBoard[1, 1];
            }
            
            return resultatet;
        }

        // Tilføjer 2 spillere og lader dem vælge hvilket tegn de vil bruge!
        internal void AddPlayers()
        {
            Console.WriteLine("Hvilket tegn bruger den første spiller?");

            // Console.ReadKey().KeyChar;
            // ReadKey() returnerer et keyinfo objekt
            // .KeyChar laver objektet om til en char
            char playerAMark = Console.ReadKey().KeyChar;

            // laver en ny instans af klassen player
            // og placerer brugerens valgte tegn i playerA.mark
            playerA = new Player(playerAMark);

            Console.WriteLine();
            Console.WriteLine("Hvilket tegn bruger den anden spiller?");
            char playerBMark = Console.ReadKey().KeyChar;
            playerB = new Player(playerBMark);

            //// er de forskellige?
            // sammenligner om de to spillerere har samme tegn.
            // hvis de har, bliver if-blokken startet
            if (playerA.mark == playerB.mark)
            {
                Console.WriteLine();
                Console.WriteLine("Du skal vælge noget andet end første spiller");
                playerBMark = Console.ReadKey().KeyChar;
                playerB.mark = playerBMark;
            }
        }

        // denne metoder placerer din brik
        internal void PlaceMark()
        {
            // hviken spillers tur er det?
            // tildeler brikken til den spiller hvis tur det er
            // ticTacToe bliver brugt til at refererer til TicTacToe.cs 
            //Bool variablen som vi definere i TicTacToe.cs skal være true.
            // og CountNumberOfMarks altså antallet af brikker skal være under 7
            if (isVariation == true && CountNumberOfMarks > 6)
            {
                Console.WriteLine("Du kan ikke sætte flere brikker. Du skal flytte en brik. Tryk på en tast for, at komme tilbage til menuen");
                Console.ReadKey();
            }
            else
            {
                if (isItAsturn) mark = playerA.mark;
                else mark = playerB.mark;

                Console.WriteLine("Hvor vil du placere din brik?");

                //indlæser streng fra brugeren
                string placering = Console.ReadLine();
                if (placering.Length < 2 || placering.Length > 2)
                {
                    Console.WriteLine("Venligst skriv et gyldigt koordinat. Tryk på en knap for, at gå tilbage");
                    Console.ReadKey();
                }
                else
                {
                    // undersøger om den før indtastede værdi er et tal - hvis ikke går spillet tilbage til menu
                    // int.TryParse undersøger om strengens "placering" kan fortolkes som et tal
                    if (int.TryParse(placering, out int s))
                    {

                        // laver streng om til en int
                        // int.Parse laver placering som til tal.
                        // .SubString() vælger den del af strengen jeg vil bruge. 
                        // Det første tal i Substringen forklarer hvor i stringen vi starter
                        // Det andet tal i substringen forklarer length
                        int xKoordinat = int.Parse(placering.Substring(0, 1));
                        int yKoordinat = int.Parse(placering.Substring(1, 1));

                        // undersøger om koordinaterne er mellem 1 og 3
                        if (IsInputOK(xKoordinat) && IsInputOK(yKoordinat))
                        {
                            // trækker 1 fra hver koordinat så det passer til arrayet
                            xKoordinat--;
                            yKoordinat--;

                            // kalder metoden der chekker om koordinaterne er frie
                            if (IsSquareEmpty(xKoordinat, yKoordinat))
                            {
                                // placerer brikken. 
                                this.GameBoard[xKoordinat, yKoordinat] = mark;
                                //CountMarks metoden tæller int CuntNumberOfMarks variablen en gang op
                                CountMarks();


                                // skifter spillerens tur.
                                if (isItAsturn) isItAsturn = false;
                                else isItAsturn = true;
                            }
                            else
                            {
                                // hvis metoden IsSquareEmpty() returnerer FALSE kommer denne frem
                                Console.WriteLine("Det felt er allerede taget");
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
        }

        //IsInputOK metoden undersøger om de indputtede tal er mellem 1 og 3 
        // bool typen kan kun returnere enten true eller false
        //IsInputOK kræver et int parameter som vi kalder for testNumber
        private bool IsInputOK(int testNumber)
        {
            //Hvis int parameteret er mindre end 1 eller større end 3
            if (testNumber < 1 || testNumber > 3)
            {
                //så returneres false
                return false;
            }
            //ellers returneres true
            //Der er ingen grund til at skrive else fordi  
            //hvis testNumber < 1 || testNumber > 3 foroven ikke gør sig gældende
            //så går IsInputOK metoden videre og returner true
            return true;

        }

        // IsSquareEmpty metoden undersøger om feltet i GameBoard arrayet er tomt
        // bool typen kan kun returnere enten true eller false
        private bool IsSquareEmpty(int x, int y)
        {
            //Hvis feltet med koordinaterne x,y i gameboarded indeholder ' '
            //så returnere metoden true
            if (this.GameBoard[x, y] == ' ') return true;
            //ellers returnere den false
            else return false;
        }

        // Her har vi implementeret metoden til, at flytte en en brik
        public void MoveMark()
        {
            //Vi laveren string som hedder userInput
            string userInput;
            Console.WriteLine("Hvilken brik vil du flytte");
            // vi sætter vores string userInput = Console.Readline
            //dvs. vi spørger om brugerinput
            userInput = Console.ReadLine();

            // såfremt brugerindputet er større eller mindre end to så aktiveres denne if statement
            if (userInput.Length < 2 || userInput.Length > 2)
            {
                Console.WriteLine("Du skal angive et x og et y koordinat.");
                Console.WriteLine("Fx. \"22\" for at rykke din brik fra midten af brættet.");
                Console.ReadKey();
            }
            else
            {
                // undersøger om den før indtastede værdi er et tal - hvis ikke går spillet tilbage til menu
                // int.TryParse undersøger om strengens "userInput" kan fortolkes som et tal
                //Hvis userInput er et tal får du en ny int variabel s som vi dog ikke bruger her
                if (int.TryParse(userInput, out int s))
                {

                    // laver streng om til en int
                    // int.Parse laver placering som til tal.
                    // .SubString() vælger den del af strengen jeg vil bruge. 
                    // Det første tal i Substringen forklarer hvor i stringen vi starter
                    // Det andet tal i substringen forklarer length
                    int xKoordinat = int.Parse(userInput.Substring(0, 1));
                    int yKoordinat = int.Parse(userInput.Substring(1, 1));

                    // undersøger om koordinaterne er mellem 1 og 3
                    if (IsInputOK(xKoordinat) && IsInputOK(yKoordinat))
                    {
                        // trækker 1 fra hver koordinat så det passer til arrayet
                        xKoordinat--;
                        yKoordinat--;

                    }
                    // Vi definere char ChosenBlock som = Gameboardet i this fane som vi er i, altså TicTacToe.cs
                    //GameBoard[xKoordinat, yKoordinat] refererer til et felt i vores GameBoard array. Et array har []
                    char chosenBlock = this.GameBoard[xKoordinat, yKoordinat];
                    //playerMark er en variabel hvor man kan sætte spillerens brik ind i som fx. X eller O.
                    char playerMark;
                    //I denne if statement sætter man spillerens brik ind i
                    if (isItAsturn)
                    {
                        //char playerMark variablen bliver sat = henter propertien mark fra playerA
                        playerMark = playerA.mark;
                    }
                    else
                    {
                        // Se ovenstående kommentar
                        playerMark = playerB.mark;
                    }
                    //såfremt det chosenBlock altså det valgte felt i vores GameBoard array
                    //er fyldt ud af spillerens egen brik så aktiveres if statementen
                    if (chosenBlock == playerMark)
                    {
                        // vi definere chosenBlock som værende ' '
                        chosenBlock = ' ';
                        //vi sætter det valgte felt i arrayet til at være chosenBlock som vi lige definerede som ' '
                        this.GameBoard[xKoordinat, yKoordinat] = chosenBlock;
                        // antallet af Marks altså brikker bliver talt en ned.
                        CountNumberOfMarks--;
                        //Vi kalder metoden PlaceMark
                        PlaceMark();
                    }
                    else
                    {
                        //Hvis du har valgt et forkert felt får du denne fejlmeddelelse 
                        Console.WriteLine("Du må kun flytte din egen brik! Tryk på en tast for at komme tilbage");
                        // Console.ReadKey sørger for at billedet på consolen ikke bare går videre efter
                        // "Du må kun flytte din egen brik! Tryk på en tast for at komme tilbage" meddelelsen
                        // Console.ReadKey afventer et tastetryk fra brugeren
                        Console.ReadKey();
                    }
                }
                else
                {   
                    //Denne fejlmeddelelse bliver aktiveret hvis du ikke har indtastet to tal
                    Console.WriteLine("Du skal angive x og y koordinaterne i tal. Tryk på en tast for at komme tiilbage");
                    // Console.ReadKey afventer et tastetryk fra brugeren
                    Console.ReadKey();
                }
            }
        }
    }
}
