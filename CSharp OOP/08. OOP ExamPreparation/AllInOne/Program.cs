namespace DocumentSystem
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
    public class AudioDocument : Multimedia
    {
        public long? SampleRate { get; protected set; }

        public void ChangeContent(string newContent)
        {
            throw new NotImplementedException();
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate")
            {
                this.SampleRate = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
            base.SaveAllProperties(output);
        }
    }
    public abstract class BinaryDocument : Document
    {
        public long? Size { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "size")
            {
                this.Size = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("size", this.Size));
            base.SaveAllProperties(output);
        }
    }
    public abstract class Document : IDocument
    {
        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }

            if (key == "content")
            {
                this.Content = value;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append("[");
            List<KeyValuePair<string, object>> attributes = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(attributes);
            attributes = attributes.OrderBy(x => x.Key).ToList();

            foreach (var item in attributes)
            {
                if (item.Value != null)
                {
                    sb.Append(item.Key);
                    sb.Append("=");
                    sb.Append(item.Value);
                    sb.Append(";");
                }
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }
    }
    public abstract class EncryptableDocument : BinaryDocument, IEncryptable
    {
        public bool IsEncrypted { get; private set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }

        public override string ToString()
        {
            if (this.IsEncrypted == true)
            {
                return this.GetType().Name + "[encrypted]";
            }
            else
            {
                return base.ToString();
            }
        }
    }
    public class ExcelDocument : OfficeDocument
    {
        public long? Rows { get; protected set; }
        public long? Cols { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.Rows = long.Parse(value);
            }
            else if (key == "cols")
            {
                this.Cols = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.Rows));
            output.Add(new KeyValuePair<string, object>("cols", this.Cols));
            base.SaveAllProperties(output);
        }
    }

    public abstract class Multimedia : BinaryDocument
    {
        public long? Length { get; protected set; }

        public void ChangeContent(string newContent)
        {
            throw new NotImplementedException();
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "length")
            {
                this.Length = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("length", this.Length));
            base.SaveAllProperties(output);
        }
    }

    public abstract class OfficeDocument : EncryptableDocument
    {
        public string Version { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "version")
            {
                this.Version = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("version", this.Version));
            base.SaveAllProperties(output);
        }
    }

    public class PDFDocument : EncryptableDocument
    {
        public long? Pages { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.Pages = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("pages", this.Pages));
            base.SaveAllProperties(output);
        }
    }

    public class TextDocument : Document, IEditable
    {
        public string Charset { get; protected set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "charset")
            {
                this.Charset = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("charset", this.Charset));
            base.SaveAllProperties(output);
        }
    }

    public class VideoDocument : Multimedia
    {
        public long? FrameRate { get; protected set; }

        public void ChangeContent(string newContent)
        {
            throw new NotImplementedException();
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "framerate")
            {
                this.FrameRate = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
            base.SaveAllProperties(output);
        }
    }

    public class WordDocument : OfficeDocument, IEditable
    {
        public long? Chars { get; protected set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "chars")
            {
                this.Chars = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("chars", this.Chars));
            base.SaveAllProperties(output);
        }
    }
}