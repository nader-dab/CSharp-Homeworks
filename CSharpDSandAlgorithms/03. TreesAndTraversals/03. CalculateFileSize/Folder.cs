namespace _03.CalculateFileSize
{
    using System;
    using System.Collections.Generic;

    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.ChildFolders = new List<Folder>();
            this.Files = new List<File>();
        }

        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }

        public void AddFile(string name, int size)
        {
            this.Files.Add(new File(name, size));
        }

        public void AddFolder(string name)
        {
            this.ChildFolders.Add(new Folder(name));
        }
    }
}
