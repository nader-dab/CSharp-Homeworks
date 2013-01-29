using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a url address:");
        string address = Console.ReadLine();
        string protocolDashes = "://";
        int indexOfProtocol = address.IndexOf(protocolDashes, 0);
        string protocol = address.Substring(0, indexOfProtocol);
        string choppedAddress = address.Substring(indexOfProtocol + protocolDashes.Length);
        int indexOfServer = choppedAddress.IndexOf('/', 0);
        string server = choppedAddress.Substring(0, indexOfServer);
        string resource = choppedAddress.Substring(indexOfServer);
        Console.WriteLine("[protocol] = \"{0}\"",protocol);
        Console.WriteLine("[server] = \"{0}\"", server);
        Console.WriteLine("[resource] = \"{0}\"", resource);
    }
}