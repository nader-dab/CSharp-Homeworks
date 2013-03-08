namespace GenericListProgram
{
    using System;
    using GenericListLibrary;

    public class GenericListProgram
    {
        // Tasks 5,6,7
        public static void Main(string[] args)
        {
            // Creating an instance of the generic class
            GenericList<string> myList = new GenericList<string>();

            // Adding elements
            myList.Add("0");
            myList.Add("1");
            myList.Add("2");
            myList.Add("3");
            myList.Add("4");
            myList.Add("6");
            myList.Add("7");
            myList.Add("7");
            myList.Add("8");

            // Inserting and removing elements
            myList.InsertAt(5, "5");
            myList.RemoveAt(7);
            myList.InsertAt(9, "9");
            
            // Printing elements using the indexer of the class
            for (int index = 0; index < myList.Count; index++)
            {
                Console.WriteLine("Element[{0}] = {1}", index, myList[index]);
            }

            // Min, Max, IndexOf, Capacity, Count, ToString demonstration
            Console.WriteLine("Min element: {0}", myList.Min());
            Console.WriteLine("Max element: {0}", myList.Max());
            Console.WriteLine("Index Of 4 = {0}", myList.IndexOf("4"));
            Console.WriteLine("List capacity: {0}", myList.Capacity);
            Console.WriteLine("Element count: {0}", myList.Count);
            Console.WriteLine(myList.ToString());
        }
    }
}