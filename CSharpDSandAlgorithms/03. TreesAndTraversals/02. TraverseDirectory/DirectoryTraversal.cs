namespace _02.TraverseDirectory
{
    using System;
    using System.IO;

    public static class DirectoryTraversal
    {
        public static void TraverseDir(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            //directory.GetAccessControl(System.Security.AccessControl.AccessControlSections.Owner);
            TraverseDir(directory, string.Empty);
        }

        private static void TraverseDir(DirectoryInfo directory, string space)
        {
            try
            {
                foreach (var file in directory.GetFiles("*.exe"))
                {
                    Console.WriteLine(space + file.FullName);
                }

                var subDirectories = directory.GetDirectories();
                foreach (var dir in subDirectories)
                {
                    TraverseDir(dir, space + " ");
                }
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot acces directory {0}: {1}", directory.FullName, uae.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
