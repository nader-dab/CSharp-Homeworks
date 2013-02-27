using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiantBombsApplication
{
    class GiantBombsApplicaition
    {
        static int[,] gameField = new int[101, 101];
        static int totalUnits = 0;
        static string htmlTop;
        static string htmlBottom;
        static int fileNumber = 1;
        static List<string> Attacks = new List<string>();
        static int result = 0;
        static int enemyUnitsAtTheBeggining;

        static void Main(string[] args)
        {
            try
            {
                InitializeHtmlStrings();
                DefenseMessege();
                ReadingDefenseFromConsole();
                GenerateDefenseHtml();
                enemyUnitsAtTheBeggining = CountEnemy();
                AttackMessege();
                ReadingAttackFromConsole();
            }
            catch (ArgumentException ae)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ae.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot locate the html directory.");
            }
            catch (FileNotFoundException fnfe)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot locate the index.html file.");
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You do not have the permission to access file or directory.");
            }

            catch (FormatException fe) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
            }
            finally 
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }

        private static void DefenseMessege()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Application program for Giant Bombs");
            Console.WriteLine("Requires defense strategy and attack commands to generate html files.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter Defense strategy: ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void AttackMessege()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Please enter Attack commands and type ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("start ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("to open in browser");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static int CountEnemy()
        {
            int units = 0;
            for (int row = 0; row < gameField.GetLength(0); row++)
            {
                for (int col = 0; col < gameField.GetLength(0); col++)
                {
                    units += Math.Abs(gameField[row, col]);
                }
            }

            return units;
        }
        private static void CheckResult()
        {
            int mineCount = 0;
            for (int row = 0; row < gameField.GetLength(0); row++)
            {
                for (int col = 0; col < gameField.GetLength(0); col++)
                {
                    if (gameField[row, col] < 0)
                    {
                        mineCount++;
                    }
                }
            }

            if (mineCount == 0)
            {
                result = result * 2;
            }
        }

        private static void InitializeHtmlStrings()
        {
            htmlTop = @"<!DOCTYPE html>

<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <meta charset=""utf-8"" />
    <link href=""Scss1.css"" rel=""stylesheet"" />
    <title>Giant Bombs</title>
</head>
<body>
    <div id=""wrapper"">
         <header>
            <img src=""images/logo.png"" width=""850px"" alt=""logo""/>
             <nav>
                 <ul>
                     <li><a href=""index.html"">Home</a></li>
                     <li><a href=""playfield1.html"">Play Field</a></li>
                     <li><a href=""about.html"">About</a></li>
                 </ul>
             </nav>
        </header>
       <section id=""controls"">";

            htmlBottom = @"</table>
            </article>
        </section>
     </div>
</body>
</html>";
        }

        private static void GenerateAttackHtml(string attackClass)
        {

            string classBird = "<td class=\"bird\">";
            string classMine = "<td class=\"mine\">";
            string fileName = "html\\playfield" + fileNumber + ".html";

            StreamWriter writer = new StreamWriter(fileName);
            StringBuilder sb = new StringBuilder();
            using (writer)
            {
                writer.WriteLine(htmlTop);
                sb.Append("<div id=\"prev-button\"><a href=\"playfield" + (fileNumber - 1) + ".html\">Prev</a></div>");
                sb.Append("<div id=\"move-field\""+attackClass+" ><p>" + Attacks[fileNumber - 2] + "</p></div>");
                sb.Append("<div id=\"next-button\"><a href=\"playfield" + (fileNumber + 1) + ".html\">Next</a></div>");
               
                sb.Append(@" </section>
        <section id=""play-field"">
           
            <article >");

                sb.Append("<table>");
                for (int row = 0; row < gameField.GetLength(0); row++)
                {
                    sb.Append("<tr><th><p>" + (gameField.GetLength(0) - row - 1) + "</p></th>");

                    for (int col = 0; col < gameField.GetLength(1); col++)
                    {
                        if (gameField[row, col] > 0)
                        {
                            sb.Append(classBird + "<p>" + gameField[row, col] + "</p></td>");
                        }
                        else if (gameField[row, col] < 0)
                        {
                            sb.Append(classMine + "<p>" + 1 + "</p></td>");
                        }
                        else
                        {
                            sb.Append("<td><p>0</p></td>");
                        }
                    }
                    sb.Append("</tr>");
                    writer.WriteLine(sb);
                    sb.Clear();
                }

                sb.Append("<tfoot>");
                sb.Append("<tr><th><p>0</p></th>");
                for (int i = 0; i < gameField.GetLength(1); i++)
                {
                    sb.Append("<th><p>" + i + "</p></th>");
                }
                sb.Append(@"</tr>
	</tfoot>");
                writer.WriteLine(sb);
                writer.WriteLine(htmlBottom);
                sb.Clear();
            }
            fileNumber++;
        }

        private static void GenerateDefenseHtml() 
        {
            string classChicken = "<td class=\"bird\">";
            string classMine = "<td class=\"mine\">";

            string fileName = "html\\playfield" +fileNumber + ".html";
            StreamWriter writer = new StreamWriter(fileName);
            StringBuilder sb = new StringBuilder();
            using (writer)
            {
                writer.WriteLine(htmlTop);
                sb.Append("<div id=\"prev-button\"><a href=\"playfield" + 1 + ".html\">Prev</a></div>");
                sb.Append("<div id=\"move-field\" class=\"bird mine\"><p>Defense</p></div>");
                sb.Append("<div id=\"next-button\"><a href=\"playfield" + 2 + ".html\">Next</a></div>");
                sb.Append(@" </section>
        <section id=""play-field"">
           
            <article >");
                sb.Append("<table>");
                for (int row = 0; row < gameField.GetLength(0); row++)
                {
                    sb.Append("<tr><th><p>" + (gameField.GetLength(0) - row - 1) + "</p></th>");

                    for (int col = 0; col < gameField.GetLength(1); col++)
                    {
                        if (gameField[row, col] < 0)
                        {
                            sb.Append(classMine + "<p>1</p></td>");
                        }
                        else if (gameField[row, col] > 0)
                        {
                            sb.Append(classChicken + "<p>" + gameField[row, col] + "</p></td>");
                        }
                        else
                        {
                            sb.Append("<td><p>0</p></td>");
                        }
                    }
                    sb.Append("</tr>");
                    writer.WriteLine(sb);
                    sb.Clear();
                }

                sb.Append("<tfoot>");
                sb.Append("<tr><th><p>0</p></th>");
                for (int i = 0; i < gameField.GetLength(1); i++)
                {
                    sb.Append("<th><p>"+i+"</p></th>");
                }
                sb.Append(@"</tr>
	</tfoot>");
                writer.WriteLine(sb);
                writer.WriteLine(htmlBottom);
                sb.Clear();
            }
            fileNumber++;

        }

        private static void GenerateResultHtml(string attackClass)
        {

            string classBird = "<td class=\"bird\">";
            string classMine = "<td class=\"mine\">";
            string fileName = "html\\playfield" + fileNumber + ".html";

            StreamWriter writer = new StreamWriter(fileName);
            StringBuilder sb = new StringBuilder();
            using (writer)
            {
                writer.WriteLine(htmlTop);
                sb.Append("<div id=\"prev-button\"><a href=\"playfield" + (fileNumber - 1) + ".html\">Prev</a></div>");
                sb.Append("<div id=\"move-field\"" + attackClass + " ><p>Result: " + result + "</p></div>");
                sb.Append("<div id=\"next-button\"><a href=\"playfield" + fileNumber + ".html\">Next</a></div>");

                sb.Append(@" </section>
        <section id=""play-field"">
           
            <article >");

                sb.Append("<table>");
                for (int row = 0; row < gameField.GetLength(0); row++)
                {
                    sb.Append("<tr><th><p>" + (gameField.GetLength(0) - row - 1) + "</p></th>");

                    for (int col = 0; col < gameField.GetLength(1); col++)
                    {
                        if (gameField[row, col] > 0)
                        {
                            sb.Append(classBird + "<p>" + gameField[row, col] + "</p></td>");
                        }
                        else if (gameField[row, col] < 0)
                        {
                            sb.Append(classMine + "<p>" + 1 + "</p></td>");
                        }
                        else
                        {
                            sb.Append("<td><p>0</p></td>");
                        }
                    }
                    sb.Append("</tr>");
                    writer.WriteLine(sb);
                    sb.Clear();
                }

                sb.Append("<tfoot>");
                sb.Append("<tr><th><p>0</p></th>");
                for (int i = 0; i < gameField.GetLength(1); i++)
                {
                    sb.Append("<th><p>" + i + "</p></th>");
                }
                sb.Append(@"</tr>
	</tfoot>");
                writer.WriteLine(sb);
                writer.WriteLine(htmlBottom);
                sb.Clear();
            }
            fileNumber++;
        }

        private static void ReadingDefenseFromConsole()
        {
            totalUnits = int.Parse(Console.ReadLine());
            char[] separators = { ' ' };
            for (int i = 0; i < totalUnits; i++)
            {
                string rowData = Console.ReadLine();
                string[] rowCell = rowData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if (rowCell[0] == "chickens")
                {
                    int value = int.Parse(rowCell[1]);
                    int row = gameField.GetLength(0) - int.Parse(rowCell[3]) - 1;
                    var col = int.Parse(rowCell[2]);
                    if (gameField[row, col] == -6 || gameField[row, col] > 0)
                    {
                        throw new ArgumentException("Cannot stack defense units");
                    }
                    gameField[row, col] = value;

                }
                else if (rowCell[0] == "mine")
                {
                    int row = gameField.GetLength(0) - int.Parse(rowCell[2]) - 1;
                    int col = int.Parse(rowCell[1]);
                    if (gameField[row, col] == -6 || gameField[row, col] > 0)
                    {
                        throw new ArgumentException("Cannot stack defense units");
                    }
                    gameField[row, col] = -6;
                }
            }
        }

        private static void ReadingAttackFromConsole()
        {
            char[] separators = { ' ' };
            bool bombUsed = false;
            bool generateResult = false;
            for (string rowData = Console.ReadLine(); rowData !=string.Empty; rowData = Console.ReadLine())
            {
                Attacks.Add(rowData);
                string[] rowCell = rowData.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                
                if (rowCell[0] == "pigs")
                {
                    int value = int.Parse(rowCell[1]);
                    int row = gameField.GetLength(0) - int.Parse(rowCell[3]) - 1;
                    int col = int.Parse(rowCell[2]);
                    // TODO: not ready
                    // some magic to calculate pig - chicken slaughter
                    if (value*2 + 1 > CountChickens(col, row, 2))
                    {
                        ClearAfterDetonation(col, row, 2);
                    }
                    GenerateAttackHtml("class=\"pig\"");
                }

                else if (rowCell[0] == "bomb")
                {
                    if (bombUsed == true)
                    {
                        throw new ArgumentException("Only one bomb per combat can be used!");
                    }
                    int radius = int.Parse(rowCell[1]);
                    int row = gameField.GetLength(0) - int.Parse(rowCell[3]) - 1;
                    int col = int.Parse(rowCell[2]);
                    
                    ClearAfterDetonation(col,row, radius*radius);

                    GenerateAttackHtml("class=\"bomb\"");
                    bombUsed = true;
                }
                else if (rowCell[0] == "start")
                {
                    AddResulstToOutput();
                    generateResult = true;
                    result = enemyUnitsAtTheBeggining - CountEnemy();
                    CheckResult();
                    GenerateResultHtml("class=\"pig\"");
                    string curDir = Directory.GetCurrentDirectory();
                    System.Diagnostics.Process.Start(curDir + @"\html\index.html");
                    return;
                }
                else
                {
                    throw new ArgumentException("Invalid input");
                }
            }

            if (generateResult == false)
            {
                AddResulstToOutput();
                result = enemyUnitsAtTheBeggining - CountEnemy();
                CheckResult();
                GenerateResultHtml("class=\"pig\"");
            }
        }

        private static void ClearAfterDetonation(int possitionCol, int positionRow, int radius)
        {
            if (radius== 0)
            {
                gameField[positionRow, possitionCol] = 0;
                return;
            }
            int startCol = possitionCol - radius - 1;
            int startRow = gameField.GetLength(1) - positionRow - radius - 1;
            int endCol = possitionCol + radius + 1;
            int endRow = gameField.GetLength(1) - positionRow + radius + 1;
            if (startCol < 0) startCol = 0;
            if (endCol > 100) endCol = 100;
            if (startRow < 0) startRow = 0;
            if (endRow > 100) endRow = 100;

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    int sideA = Math.Abs(gameField.GetLength(1) - positionRow - row);
                    int sideB = Math.Abs(possitionCol - col);
                    if (((sideA * sideA) + (sideB * sideB)) <= radius)
                    {
                        gameField[gameField.GetLength(1) - row, col] = 0;
                    }
                }
            }
        }

        private static int CountChickens(int possitionCol, int positionRow, int radius)
        {
            int chickens = 0;
            int startCol = possitionCol - radius - 1;
            int startRow = gameField.GetLength(1) - positionRow - radius - 1;
            int endCol = possitionCol + radius + 1;
            int endRow = gameField.GetLength(1) - positionRow + radius + 1;
            if (startCol < 0) startCol = 0;
            if (endCol > 100) endCol = 100;
            if (startRow < 0) startRow = 0;
            if (endRow > 100) endRow = 100;

            for (int row = startRow; row < endRow; row++)
            {
                for (int col = startCol; col < endCol; col++)
                {
                    int sideA = Math.Abs(gameField.GetLength(1) - positionRow - row);
                    int sideB = Math.Abs(possitionCol - col);
                    if (((sideA * sideA) + (sideB * sideB)) <= ((radius) * (radius)))
                    {
                        if (gameField[gameField.GetLength(1) - row, col] > 0)
                        {
                            chickens += gameField[gameField.GetLength(1) - row, col];
                        }
                    }
                }
            }

            return chickens;
        }

        private static void AddResulstToOutput()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("If you would like to save your name press [Y] else [N]");
            Console.ForegroundColor = ConsoleColor.White;
            string answer = Console.ReadLine().ToLowerInvariant();
            if (answer == "y")
            {
                string filePath = "scoreboard.txt";
                StreamWriter writer = new StreamWriter(filePath, true);
                using (writer)
                {
                    Console.WriteLine("Your name:");
                    string name = Console.ReadLine();
                    string entry = name + " Score: "+ result;
                    writer.WriteLine(entry);
                }
            }
        }
    }
}