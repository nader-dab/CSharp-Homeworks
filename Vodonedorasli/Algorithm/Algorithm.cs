using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Algorithm
{
    static int t;   //number of periods
    static int v;   //number of seaweeds to put
    static int n;   //size of the gamefield
    static int remainingSeaweeds;
    static char[,] startingArray;
    static List<Coordinates> foodLocation = new List<Coordinates>();
    static List<Pattern> elementsToPlay = new List<Pattern>();
    struct Coordinates
    {
        public bool taken; //wheather a field is free or not
        public bool food;
        public int x; //corresponds to row
        public int y; //corresponds to col
    }
    struct Pattern
    {
        public int count;
        public int width;
        public int height;
        public string form;
        public int horizontalOffset;
        public int verticalOffset;
        public int minSizeOfN;
    }
    static Pattern beakon;
    static Pattern beahive;
    static Pattern lineOfSeven;
    static Pattern spaceFiller;
    static Pattern rabitOne;
    static Pattern pufferTrain;
    static Pattern sacrifice;
    static Pattern cross;

    static void Main()
    {
        Stopwatch st = new Stopwatch();
        st.Start();
        ReadInputFromConsole();
        InitializeAllPatterns();
        remainingSeaweeds = v;
        GameLogic();
        PrintFieldToConsole();
        st.Stop();
    }
    static void GameLogic()
    {
        //if the number of seaweeds that we must place v is larger 
        //than the max amount ofsustanable elements of pattern type beahive (with some tollerance)
        if (n >= 9 && (((n / 4) * (n / 5) * 6) * 0.9) <= v)
        {
            CheckForSustanability();
        }
        else
        {
            PlayDefault();
        }

    }
    static void PlayDefault()
    {
        List<Pattern> possibleElements = new List<Pattern>();
        for (int index = 0; index < elementsToPlay.Count; index++)
        {
            //Possible elements are only those that require count equal or less that the remainingSeaweeds and can fit on the gamefield and are suitable to play
            if (elementsToPlay[index].count <= remainingSeaweeds
                && Math.Max(elementsToPlay[index].width, elementsToPlay[index].height) <= startingArray.GetLength(0)
                && elementsToPlay[index].minSizeOfN <= startingArray.GetLength(0))
            {
                possibleElements.Add(elementsToPlay[index]);
            }
        }
        elementsToPlay = possibleElements.ToList();
        //placing patters depending on their type
        //Spacefiller
        bool betterPattern = false;
        if (elementsToPlay.Count > 0 && elementsToPlay[0].Equals(spaceFiller))
        {
            PlaceInCenter(spaceFiller);
            betterPattern = true;
            elementsToPlay.Remove(spaceFiller);
        }
        if (elementsToPlay.Count > 0 && elementsToPlay[0].Equals(pufferTrain))
        {
            PlacePatternLeft(pufferTrain);
            betterPattern = true;
            elementsToPlay.Remove(pufferTrain);
        }
        if (elementsToPlay.Count > 0 && elementsToPlay[0].Equals(rabitOne))
        {
            if (betterPattern == false)
            {
                PlaceInCenter(rabitOne);
                betterPattern = true;
            }
            elementsToPlay.Remove(rabitOne);
        }
        if (elementsToPlay.Count > 0 && elementsToPlay[0].Equals(lineOfSeven))
        {
            if (betterPattern == false)
            {
                PlaceInCenter(lineOfSeven);
            }
            elementsToPlay.Remove(lineOfSeven);
        }
        if (elementsToPlay.Count > 0 && elementsToPlay[0].Equals(beahive))
        {
            PlacePatternLeft(beahive);
            elementsToPlay.Remove(beahive);
        }
        if (elementsToPlay.Count > 0 && elementsToPlay[0].Equals(cross))
        {
            PlacePatternLeft(cross);
            elementsToPlay.Remove(cross);
        }
        if (elementsToPlay.Count > 0 && elementsToPlay[0].Equals(beakon))
        {
            PlacePatternLeft(beakon);
            elementsToPlay.Remove(beakon);
        }
        if (remainingSeaweeds > 0)
        {
            SacrificeSeaweeds();
        }
    }

    static bool CheckIfSpaceIsFree(Pattern currentPattern, int rowPosition, int colPosition)
    {
        bool free = true;
        for (int row = rowPosition; row < rowPosition + currentPattern.height && row < startingArray.GetLength(0) && free == true; row++)
        {
            for (int col = colPosition; col < colPosition + currentPattern.width && col < startingArray.GetLength(1) && free == true; col++)
            {
                if (startingArray[row, col] == '+')
                {
                    free = false;
                }
            }
        }
        return free;
    }

    static void PlaceInCenter(Pattern currentPattern)
    {
        bool canItFit = true;
        for (int numberOfFillers = 0; numberOfFillers < 5 && canItFit == true && currentPattern.count <= remainingSeaweeds; numberOfFillers++)
        {
            //place currentPattern in center
            if (numberOfFillers == 0)
            {
                int centerRow = startingArray.GetLength(0) / 2 - currentPattern.height / 2;
                int centerCol = startingArray.GetLength(1) / 2 - currentPattern.width / 2;

                if ((centerRow >= 0 && centerCol >= 0)
                    && (centerRow + currentPattern.height - 1) < startingArray.GetLength(0)
                    && (centerCol + currentPattern.width - 1) < startingArray.GetLength(1))
                {
                    PlacePatternOnField(currentPattern, centerRow, centerCol);
                }
                else
                {
                    canItFit = false;
                }
            }
            //place in top right
            else if (numberOfFillers == 1)
            {
                int topRow = startingArray.GetLength(0) / 2 - currentPattern.height - currentPattern.verticalOffset;
                int topCol = startingArray.GetLength(1) / 2 + currentPattern.width + currentPattern.horizontalOffset;
                if ((topRow >= 0 && topCol >= 0)
                    && (topRow + currentPattern.height) < startingArray.GetLength(0)
                    && (topCol + currentPattern.width) < startingArray.GetLength(1))
                {
                    PlacePatternOnField(currentPattern, topRow, topCol);
                }
                else
                {
                    canItFit = false;
                }
            }
            //place in bottom right
            else if (numberOfFillers == 2)
            {
                int topRow = startingArray.GetLength(0) / 2 + currentPattern.verticalOffset;
                int topCol = startingArray.GetLength(1) / 2 + currentPattern.width + currentPattern.horizontalOffset;
                if ((topRow >= 0 && topCol >= 0)
                    && (topRow + currentPattern.height) < startingArray.GetLength(0)
                    && (topCol + currentPattern.width) < startingArray.GetLength(1))
                {
                    PlacePatternOnField(currentPattern, topRow, topCol);
                }
                else
                {
                    canItFit = false;
                }
            }
            //place in bottom left
            else if (numberOfFillers == 3)
            {
                int topRow = startingArray.GetLength(0) / 2 + currentPattern.verticalOffset;
                int topCol = startingArray.GetLength(1) / 2 - 2 * currentPattern.width - currentPattern.horizontalOffset;
                if ((topRow >= 0 && topCol >= 0)
                    && (topRow + currentPattern.height) < startingArray.GetLength(0)
                    && (topCol + currentPattern.width) < startingArray.GetLength(1))
                {
                    PlacePatternOnField(currentPattern, topRow, topCol);
                }
                else
                {
                    canItFit = false;
                }
            }
            //place in top left
            else if (numberOfFillers == 4)
            {
                int topRow = startingArray.GetLength(0) / 2 - currentPattern.height - currentPattern.verticalOffset;
                int topCol = startingArray.GetLength(1) / 2 - 2 * currentPattern.width - currentPattern.horizontalOffset;
                if ((topRow >= 0 && topCol >= 0)
                    && (topRow + currentPattern.height) < startingArray.GetLength(0)
                    && (topCol + currentPattern.width) < startingArray.GetLength(1))
                {
                    PlacePatternOnField(currentPattern, topRow, topCol);
                }
                else
                {
                    canItFit = false;
                }
            }
        }
    }

    static int lastUsedPositionR = 0;
    static int lastUsedPositionC = 0;
    static void PlacePatternLeft(Pattern currentPattern)
    {
        if (currentPattern.count <= remainingSeaweeds)
        {
            int initialRow = lastUsedPositionR;
            int intialCol = lastUsedPositionC;
            for (int col = intialCol; col < startingArray.GetLength(1) && remainingSeaweeds >= currentPattern.count; col++)
            {
                for (int row = initialRow; row < startingArray.GetLength(0) && remainingSeaweeds >= currentPattern.count; row++)
                {
                    if (row + currentPattern.height - 1 < startingArray.GetLength(0) && col + currentPattern.width - 1 < startingArray.GetLength(1) && CheckIfSpaceIsFree(currentPattern, row, col))
                    {
                        PlacePatternOnField(currentPattern, row, col);
                        row = row + currentPattern.height - 1 + currentPattern.verticalOffset;
                        lastUsedPositionR = row + currentPattern.verticalOffset + 1;
                        lastUsedPositionC = col;
                    }
                }
                col = col + currentPattern.width + currentPattern.horizontalOffset;
                initialRow = 0;
            }
            lastUsedPositionC = lastUsedPositionC + currentPattern.horizontalOffset;
        }
    }
    static void CheckForSustanability()
    {
        //place beahives on the entire field so that they don't interfier with each other
        for (int row = 0; row < startingArray.GetLength(0) && remainingSeaweeds >= beahive.count; row++)
        {
            for (int col = 0; col < startingArray.GetLength(1) && remainingSeaweeds >= beahive.count; col++)
            {
                if ((row + beahive.height - 1) < startingArray.GetLength(0)
                    && (col + beahive.width - 1) < startingArray.GetLength(1)
                    && remainingSeaweeds >= beahive.count)
                {
                    PlacePatternOnField(beahive, row, col);
                    col = col + beahive.width - 1 + beahive.horizontalOffset;
                }
            }
            row = row + beahive.height - 1 + beahive.verticalOffset;
        }
        SacrificeSeaweeds();

    }
    //Placing Patterns
    static void PlacePatternOnField(Pattern currentPattern, int rowPosition, int colPosition)
    {
        //rowPosition and colPosition are the coordinates where the pattern will be placed on the field
        //currentPattern.form is one dimensional string array where each new line coresponds to a new row on the field
        for (int row = rowPosition, patternFormIndex = 0; row < currentPattern.height + rowPosition; row++)
        {
            for (int col = colPosition; col < currentPattern.width + colPosition; col++, patternFormIndex++)
            {
                if (currentPattern.form[patternFormIndex] == '+')
                {
                    //remove food if placed ontop
                    if (startingArray[row, col] == 'F')
                    {
                        Coordinates removeFood = new Coordinates();
                        removeFood.x = row;
                        removeFood.y = col;
                        removeFood.food = true;
                        removeFood.taken = false;
                        foodLocation.Remove(removeFood);
                    }
                    if (startingArray[row, col] != '+')
                    {
                        remainingSeaweeds--;
                    }
                    //place life
                    startingArray[row, col] = '+';
                }
            }
            //After reaching the end of the current line we add 2 to the form index to compensate for \n
            patternFormIndex += 2;
        }
    }
    static void SacrificeSeaweeds()
    {
        //put sacrifice on food withouth interfering with surrounding sustanable neighbours
        if (remainingSeaweeds > 0)
        {
            for (int index = foodLocation.Count - 1; index >= 0; index--)
            {
                if (CheckForAreaEffects(foodLocation[index].x, foodLocation[index].y) == 0)
                {
                    PlacePatternOnField(sacrifice, foodLocation[index].x, foodLocation[index].y);
                }
            }
        }
        //put sacrifice without interfeereing
        if (remainingSeaweeds > 0)
        {
            PutSacrificeWithouthInterfering();
        }
        //put sacrifice in the bottom corner
        if (remainingSeaweeds > 0)
        {
            LastResort();
        }
    }


    static void PutSacrificeWithouthInterfering()
    {
        for (int radius = 0; radius < (n * 2) - 1 && remainingSeaweeds > 0; radius++)
        {
            int row = n - 1 - radius;
            if (row < 0)
            {
                row = 0;
            }
            int col = n - 1;
            if (radius >= n)
            {
                col = 2 * n - radius - 2;
            }
            while ((row < n) && (col > -1) && remainingSeaweeds > 0)
            {
                if (startingArray[row, col] != '+' && CheckForAreaEffects(row, col) == 0)
                {
                    startingArray[row, col] = '+';
                    remainingSeaweeds--;
                }
                row++;
                col--;
            }
        }
    }
    static void LastResort()
    {
        for (int radius = 0; radius < (n * 2) - 1 && remainingSeaweeds > 0; radius++)
        {
            int row = n - 1 - radius;
            if (row < 0)
            {
                row = 0;
            }
            int col = n - 1;
            if (radius >= n)
            {
                col = 2 * n - radius - 2;
            }
            while ((row < n) && (col > -1) && remainingSeaweeds > 0)
            {
                if (startingArray[row, col] != '+')
                {
                    startingArray[row, col] = '+';
                    remainingSeaweeds--;
                }
                row++;
                col--;
            }
        }
    }
    static int CheckForAreaEffects(int row, int col)
    {
        int life = 0;
        //left
        if (col > 1)
        {
            life += CheckForSuroundingLife(row, col - 1);
        }
        //top left
        if (row > 1 && col > 1)
        {
            life += CheckForSuroundingLife(row - 1, col - 1);
        }
        //top
        if (row > 1)
        {
            life += CheckForSuroundingLife(row - 1, col);
        }
        //top right
        if (row > 1 && col < startingArray.GetLength(1) - 1)
        {
            life += CheckForSuroundingLife(row - 1, col + 1);
        }
        //right
        if (col < startingArray.GetLength(1) - 1)
        {
            life += CheckForSuroundingLife(row, col + 1);
        }
        //bottom right
        if (row < startingArray.GetLength(0) - 1 && col < startingArray.GetLength(1) - 1)
        {
            life += CheckForSuroundingLife(row + 1, col + 1);
        }
        //bottom
        if (row < startingArray.GetLength(0) - 1)
        {
            life += CheckForSuroundingLife(row + 1, col);
        }
        //bottom left
        if (row < startingArray.GetLength(0) - 1 && col > 1)
        {
            life += CheckForSuroundingLife(row + 1, col - 1);
        }

        return life;
    }
    static int CheckForSuroundingLife(int row, int col)
    {
        int life = 0;

        //left
        if (col > 0 && startingArray[row, col - 1] == '+')
        {
            life++;
        }
        //top left
        if (col > 0 && row > 0 && startingArray[row - 1, col - 1] == '+')
        {
            life++;
        }
        //top
        if (row > 0 && startingArray[row - 1, col] == '+')
        {
            life++;
        }
        //top right
        if (col < n - 1 && row > 0 && startingArray[row - 1, col + 1] == '+')
        {
            life++;
        }
        //right
        if (col < n - 1 && startingArray[row, col + 1] == '+')
        {
            life++;
        }
        //bottom right
        if (col < n - 1 && row < n - 1 && startingArray[row + 1, col + 1] == '+')
        {
            life++;
        }
        //bottom
        if (row < n - 1 && startingArray[row + 1, col] == '+')
        {
            life++;
        }
        //bottom left
        if (col > 0 && row < n - 1 && startingArray[row + 1, col - 1] == '+')
        {
            life++;
        }
        return life;
    } //TODO: May proove ineffecient
    static void InitializeAllPatterns()
    {
        elementsToPlay.Add(InitializeSpaceFiller());
        elementsToPlay.Add(InitializeInfinitePufferTrain());
        elementsToPlay.Add(InitializeInfiniteRabitOne());
        elementsToPlay.Add(InitializeLineOfSeven());
        elementsToPlay.Add(InitializeBeahive());
        elementsToPlay.Add(InitializeCross());
        elementsToPlay.Add(InitializeBeakon());
        InitializeSacrifice(); // just needs to be initialized withouth adding it to the elements
    }
    //Pattern Initialization
    static Pattern InitializeSacrifice()
    {
        sacrifice = new Pattern();
        sacrifice.count = 1;
        sacrifice.height = 1;
        sacrifice.width = 1;
        sacrifice.horizontalOffset = 0;
        sacrifice.verticalOffset = 0;
        sacrifice.minSizeOfN = 3;
        sacrifice.form = "+";
        return sacrifice;
    }
    static Pattern InitializeCross()
    {
        cross = new Pattern();
        cross.count = 4;
        cross.height = 3;
        cross.width = 3;
        cross.horizontalOffset = 1;
        cross.verticalOffset = 1;
        cross.minSizeOfN = 3;
        cross.form = @"0+0
+0+
0+0";
        return cross;
    }
    static Pattern InitializeBeakon()
    {
        beakon = new Pattern();
        beakon.count = 3;
        beakon.height = 2;
        beakon.width = 2;
        beakon.horizontalOffset = 2;
        beakon.verticalOffset = 2;
        beakon.minSizeOfN = 3;
        beakon.form = @"++
+0";
        return beakon;
    }
    static Pattern InitializeBeahive()
    {
        beahive = new Pattern();
        beahive.count = 6;
        beahive.height = 3;
        beahive.width = 4;
        beahive.horizontalOffset = 1;
        beahive.verticalOffset = 1;
        beahive.minSizeOfN = 4;
        beahive.form = @"0++0
+00+
0++0";
        return beahive;
    }
    static Pattern InitializeLineOfSeven()
    {
        lineOfSeven = new Pattern();
        lineOfSeven.count = 7;
        lineOfSeven.height = 1;
        lineOfSeven.width = 7;
        lineOfSeven.horizontalOffset = 15;
        lineOfSeven.verticalOffset = 15;
        lineOfSeven.minSizeOfN = 14;
        lineOfSeven.form = @"+++++++";
        return lineOfSeven;
    }               //wierd behaviour can grown to a pulsar when stacking 2
    static Pattern InitializeSpaceFiller()
    {
        spaceFiller = new Pattern();
        spaceFiller.count = 200;
        spaceFiller.height = 26;
        spaceFiller.width = 49;
        spaceFiller.horizontalOffset = (int)(t / 1.75);
        spaceFiller.verticalOffset = (int)(t / 1.75);
        spaceFiller.minSizeOfN = 60;
        spaceFiller.form = @"00000000000000000000+++000+++00000000000000000000
0000000000000000000+00+000+00+0000000000000000000
++++000000000000000000+000+000000000000000000++++
+000+00000000000000000+000+00000000000000000+000+
+00000000+000000000000+000+000000000000+00000000+
0+00+00++00+0000000000000000000000000+00++00+00+0
000000+00000+0000000+++000+++0000000+00000+000000
000000+00000+00000000+00000+00000000+00000+000000
000000+00000+00000000+++++++00000000+00000+000000
0+00+00++00+00++0000+0000000+0000++00+00++00+00+0
+00000000+000++0000+++++++++++0000++000+00000000+
+000+000000000++00000000000000000++000000000+000+
++++00000000000+++++++++++++++++++00000000000++++
0000000000000000+0+00000000000+0+0000000000000000
0000000000000000000+++++++++++0000000000000000000
0000000000000000000+000000000+0000000000000000000
00000000000000000000+++++++++00000000000000000000
000000000000000000000000+000000000000000000000000
00000000000000000000+++000+++00000000000000000000
0000000000000000000000+000+0000000000000000000000
0000000000000000000000000000000000000000000000000
000000000000000000000+++0+++000000000000000000000
000000000000000000000+++0+++000000000000000000000
00000000000000000000+0++0++0+00000000000000000000
00000000000000000000+++000+++00000000000000000000
000000000000000000000+00000+000000000000000000000";
        return spaceFiller;

    }               //Expands equaly in all directions
    static Pattern InitializeInfiniteRabitOne()
    {
        rabitOne = new Pattern();
        rabitOne.count = 10;
        rabitOne.height = 6;
        rabitOne.width = 6;
        rabitOne.horizontalOffset = 50;
        rabitOne.verticalOffset = 50;
        rabitOne.minSizeOfN = 20;
        rabitOne.form = @"0+0000
++0+00
0000++
+00+00
+00000
+00000";
        return rabitOne;
    }
    static Pattern InitializeInfinitePufferTrain()
    {

        pufferTrain = new Pattern();
        pufferTrain.count = 22;
        pufferTrain.height = 18;
        pufferTrain.width = 5;
        pufferTrain.horizontalOffset = (int)(t / 1.5);
        pufferTrain.verticalOffset = 4;
        pufferTrain.minSizeOfN = 20;
        pufferTrain.form = @"000+0
0000+
+000+
0++++
00000
00000
00000
+0000
0++00
00+00
00+00
0+000
00000
00000
000+0
0000+
+000+
0++++";
        return pufferTrain;

    }       //Goes right and breads along the way
    //Reading
    static void ReadInputFromConsole()
    {
        t = int.Parse(Console.ReadLine());
        v = int.Parse(Console.ReadLine());
        remainingSeaweeds = v;
        n = int.Parse(Console.ReadLine());
        startingArray = new char[n, n];
        for (int row = 0; row < n; row++)
        {
            string inputRow = Console.ReadLine();
            for (int col = 0; col < n; col++)
            {
                startingArray[row, col] = inputRow[col];
                if (startingArray[row, col] == 'F')
                {
                    Coordinates foodCoordinates = new Coordinates();
                    foodCoordinates.food = true;
                    foodCoordinates.taken = false;
                    foodCoordinates.x = row;
                    foodCoordinates.y = col;
                    foodLocation.Add(foodCoordinates);
                }
            }
        }
    }
    //Printing
    static void PrintFieldToConsole()
    {
        StringBuilder sb = new StringBuilder();
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                sb.Append(startingArray[row, col]);
            }
            sb.Append("\n");
        }
        Console.Write(sb.ToString());
    }
}