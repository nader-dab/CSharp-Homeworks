namespace _03.CalculateFileSize
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Program
    {
        private const string StartingPath = @"D:\Music";
        private static Folder myFolder = new Folder(StartingPath);
        public static void Main(string[] args)
        {
            TraverseDirectory(myFolder);
            Console.WriteLine("Total bytes: {0}", CalculateSum(myFolder));
        }

        private static long CalculateSum(Folder currentFolder)
        {

            long sum = 0;

            foreach (var file in currentFolder.Files)
            {
                sum += file.Size;
            }

            foreach (var child in currentFolder.ChildFolders)
            {
                sum+= CalculateSum(child);
            }

            return sum;
        }

        private static void TraverseDirectory(Folder currentFolder)
        {
            try
            {
                DirectoryInfo currentDirecotoryInfo = new DirectoryInfo(currentFolder.Name);
                DirectoryInfo[] subDirectories = currentDirecotoryInfo.GetDirectories();

                foreach (var file in currentDirecotoryInfo.GetFiles())
                {
                    currentFolder.AddFile(file.Name, (int)file.Length);
                }

                foreach (var dir in subDirectories)
                {
                    currentFolder.AddFolder(dir.FullName);
                }

                foreach (var child in currentFolder.ChildFolders)
                {
                    TraverseDirectory(child);
                }
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine("Cannot access directory: {0}", uae.Message);
            }
            catch(DirectoryNotFoundException dnf)
            {
                Console.WriteLine("Directory not found: {0}", dnf.Message);
            }
           
        }
    }
}
