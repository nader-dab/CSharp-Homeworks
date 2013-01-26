using System;
using System.Net;

class DownloadFileFromInternet
{
    static void Main()
    {
        Console.WriteLine("Please enter url path fo file image: ");
        string urlPath = Console.ReadLine();
        Console.WriteLine("Save file as: ");
        string saveAs = Console.ReadLine();
        WebClient webClient = new WebClient(); 
        using (webClient)
        {
            try
            {
                webClient.DownloadFile(urlPath, saveAs);
            }
            catch (WebException)
            {
                Console.WriteLine("Invalid address!");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The method has been called simultaneously on multiple threads.");
            }
        }
    }
}