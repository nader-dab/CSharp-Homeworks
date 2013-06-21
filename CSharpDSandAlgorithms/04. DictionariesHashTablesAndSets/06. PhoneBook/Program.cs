namespace _06.PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Program
    {
        private const string PhoneFile = @"../../phones.txt";
        private const string CommandFile = @"../../commands.txt";
        private static Dictionary<string, List<string>> phonebook = new Dictionary<string, List<string>>();
        
        public static void Main(string[] args)
        {
            ReadPhoneBook();
            ProcessCommands();
        }

        private static void ProcessCommands()
        {
            string[] commands = File.ReadAllLines(CommandFile);
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == null)
                {
                    break;
                }

                string[] tokens = commands[i].Split(new string[]{"find(",",", ")"}, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string town = string.Empty;
                if (tokens.Length > 1)
                {
                    town = tokens[1];
                }
                string nameAndTown = name.ToLower() + " " + town.ToLower();
                PrintMatches(nameAndTown.Trim());
            }
        }

        private static void PrintMatches(string nameAndTown)
        {
            if (phonebook.ContainsKey(nameAndTown))
	        {
                foreach (var entry in phonebook[nameAndTown])
                {
                    Console.WriteLine(entry);
                }
	        }
        }

        private static void ReadPhoneBook()
        {
            string[] lines = File.ReadAllLines(PhoneFile);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == null)
                {
                    break;
                }

                string[] tokens = lines[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string[] names = tokens[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string town = tokens[1];

                foreach (var name in names)
                {
                    AddToPhonebook(name.Trim(), lines[i]);
                    string nameAndTown = name.ToLower() + " " + town.ToLower();
                    AddToPhonebook(nameAndTown.Trim(), lines[i].Trim());
                }
            }
        }

        public static void AddToPhonebook(string name, string line)
        {
            name = name.ToLower();
            List<string> entries;
            if (!phonebook.TryGetValue(name, out entries))
            {
                entries = new List<string>();
                phonebook.Add(name, entries);
            }

            entries.Add(line);
        }
    }
}
