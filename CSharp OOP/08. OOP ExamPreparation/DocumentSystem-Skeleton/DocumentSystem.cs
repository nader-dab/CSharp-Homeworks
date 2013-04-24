namespace DocumentSystem
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IDocument
    {
        string Name { get; }
        string Content { get; }
        void LoadProperty(string key, string value);
        void SaveAllProperties(IList<KeyValuePair<string, object>> output);
        string ToString();
    }

    public interface IEditable
    {
        void ChangeContent(string newContent);
    }

    public interface IEncryptable
    {
        bool IsEncrypted { get; }
        void Encrypt();
        void Decrypt();
    }

    public class DocumentSystem
    {
        private static IList<IDocument> documents = new List<IDocument>();
        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                var trimmedParam = parameters.Split(' ');
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddDocument(string[] attributes, IDocument doc)
        {
            foreach (var item in attributes)
            {
                var keyValuePair = item.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                doc.LoadProperty(keyValuePair[0], keyValuePair[1]);
            }

            if (doc.Name != null)
            {
                documents.Add(doc);
                Console.WriteLine("Document added: " + doc.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            TextDocument doc = new TextDocument();
            AddDocument(attributes, doc);
        }
        private static void AddPdfDocument(string[] attributes)
        {
            PDFDocument doc = new PDFDocument();
            AddDocument(attributes, doc);  
        }

        private static void AddWordDocument(string[] attributes)
        {
            WordDocument doc = new WordDocument();
            AddDocument(attributes, doc);  
        }

        private static void AddExcelDocument(string[] attributes)
        {
            ExcelDocument doc = new ExcelDocument();
            AddDocument(attributes, doc);  
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AudioDocument doc = new AudioDocument();
            AddDocument(attributes, doc);  
        }

        private static void AddVideoDocument(string[] attributes)
        {
            VideoDocument doc = new VideoDocument();
            AddDocument(attributes, doc);  
        }

        private static void ListDocuments()
        {
            if (documents.Count == 0)
            {
                Console.WriteLine("No documents found");
            }
            else
            {
                foreach (var item in documents)
                {
                    Console.WriteLine(item);
                }
            }
            
        }

        private static void EncryptDocument(string name)
        {
            bool encryptable = false;
            foreach (var item in documents)
            {
                if (item.Name == name)
                {
                    encryptable = true;
                    if (item is IEncryptable)
                    {
                        (item as IEncryptable).Encrypt();
                        Console.WriteLine("Document encrypted: " + item.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: " + item.Name);
                    }
                }
            }

            if (!encryptable)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool foundEncryptable = false;
            foreach (var item in documents)
            {
                if (item.Name == name)
                {
                    foundEncryptable = true;
                    if (item is IEncryptable)
                    {
                        (item as IEncryptable).Decrypt();
                        Console.WriteLine("Document decrypted: " + item.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: " + item.Name);
                    }
                }
            }

            if (!foundEncryptable)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void EncryptAllDocuments()
        {
            bool foundEncryptable = false;
            foreach (var item in documents)
            {
                if (item is IEncryptable)
                {
                    (item as IEncryptable).Encrypt();
                    foundEncryptable = true;
                }
            }

            if (!foundEncryptable)
            {
                Console.WriteLine("No encryptable documents found");
            }
            else
            {
                Console.WriteLine("All documents encrypted");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            bool foundDocument = false;
            foreach (var item in documents)
            {
                if (item.Name == name)
                {
                    if (item is IEditable)
                    {
                        (item as IEditable).ChangeContent(content);
                        Console.WriteLine("Document content changed: " + item.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: " + item.Name);
                    }

                    foundDocument = true;
                }
            }

            if (!foundDocument)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }
    }
}