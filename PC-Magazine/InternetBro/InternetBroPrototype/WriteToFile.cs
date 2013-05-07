namespace Crawler
{
    using System;
    using System.IO;
    using System.Text;

    public static class WriteToFile
    {
        public static void WriteTextToFile(string text, string file)
        {
            try
            {
                var writer = new StreamWriter(file, false, Encoding.GetEncoding("windows-1251"));

                using (writer)
                {
                    writer.Write(text);
                }
            }
            catch (ArgumentException ane)
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
    }
}