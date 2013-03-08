namespace PointLibrary
{
    using System;
    using System.IO;
    using System.Text;

    public static class PathStorage
    {
        private static Encoding encoding = Encoding.UTF8;

        public static void Save(Path sequence, string file)
        {
            try
            {
                StreamWriter writer = new StreamWriter(file, false, encoding);
                using (writer)
                {
                    writer.WriteLine(sequence);
                }
            }
            catch (ArgumentNullException ane)
            {
                throw new ArgumentException("The file path is empty.", ane);
            }
            catch (DirectoryNotFoundException dnf)
            {
                throw new DirectoryNotFoundException(string.Format("Cannot find the directory to save file {0}", file), dnf);
            }
            catch (UnauthorizedAccessException uae)
            {
                throw new UnauthorizedAccessException(string.Format("Cannot save file to: {0} due to permission restriction", file), uae);
            }
        }

        public static void Load(string file, Path sequence)
        {
            try
            {
                StreamReader reader = new StreamReader(file, encoding);
                using (reader)
                {
                    for (string line = reader.ReadLine(); !string.IsNullOrEmpty(line); line = reader.ReadLine())
                    {
                        string[] points = line.Split(new char[] { ' ', '[', ']', 'X', 'Y', 'Z', ':' }, StringSplitOptions.RemoveEmptyEntries);
                        int x = int.Parse(points[0]);
                        int y = int.Parse(points[1]);
                        int z = int.Parse(points[2]);
                        sequence.AddPoint(new Point3D(x, y, z));
                    }
                }
            }
            catch (ArgumentNullException ane)
            {
                throw new ArgumentException("The file path is empty.", ane);
            }
            catch (FileNotFoundException fnfe)
            {
                throw new FileNotFoundException(string.Format("Cannot find the specified file {0}", file), fnfe);
            }
            catch (UnauthorizedAccessException uae)
            {
                throw new UnauthorizedAccessException(string.Format("Cannot load file {0} due to permission restriction", file), uae);
            } 
        }
    }
}