using System;

class PrintCardNames
{
    static void Main()
    {
        for (int suiteIndex = 1; suiteIndex <= 4; suiteIndex++)
        {
            for (int nameIndex = 1; nameIndex <= 13; nameIndex++)
            {
                string cardName;
                string cardSuite; 
                switch (nameIndex)
                {
                    case 1 : cardName = "Two of "; break;
                    case 2 : cardName = "Three of "; break;
                    case 3 : cardName = "Four of "; break;
                    case 4 : cardName = "Five of "; break;
                    case 5 : cardName = "Six of "; break;
                    case 6 : cardName = "Seven of "; break;
                    case 7 : cardName = "Eight of ";break;
                    case 8 : cardName = "Nine of "; break;
                    case 9 : cardName = "Ten of "; break;
                    case 10 : cardName = "Jack of "; break;
                    case 11 : cardName = "Queen of "; break;
                    case 12 : cardName = "King of "; break;
                    case 13 : cardName = "Ace of "; break;
                    default: cardName = " "; break;
                }
                switch (suiteIndex)
                {
                    case 1: cardSuite = "clubs"; break;
                    case 2: cardSuite = "diamonds"; break;
                    case 3: cardSuite = "hears"; break;
                    case 4: cardSuite = "spades"; break;
                    default: cardSuite = " "; break;
                }
                Console.WriteLine(cardName + cardSuite);
            }
        }
    }
}

