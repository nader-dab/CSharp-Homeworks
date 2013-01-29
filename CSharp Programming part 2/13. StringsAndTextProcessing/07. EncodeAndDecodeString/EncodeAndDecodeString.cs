using System;

class EncodeAndDecodeString
{
    static void Main()
    {
        Console.WriteLine("Please enter a string:");
        string inputString = Console.ReadLine();
        Console.WriteLine("Please enter an encryption key:");
        string cipher = Console.ReadLine();
        string encodedString = Encode(inputString, cipher);
        Console.WriteLine("Encoded string: {0}",encodedString);
        string decodedString = Decode(encodedString, cipher);
        Console.WriteLine("Decoded string: {0}", decodedString);
    }

    private static string Decode(string encodedString, string cipher)
    {  
        char[] decodeArray = encodedString.ToCharArray();
        int key = 0;
        for (int index = 0; index < encodedString.Length; index++)
        {
            decodeArray[index] = (char)(decodeArray[index] ^ cipher[key]);
            if (key == cipher.Length - 1)
            {
                key = 0;
            }
            else
            {
                key++;
            }
        }
        string decodedString = new string(decodeArray);
        return decodedString;
    }
  
    private static string Encode(string decodedString, string cipher)
    {
        char[] encodeArray = decodedString.ToCharArray();
        int key = 0;
        for (int index = 0; index < decodedString.Length; index++)
        {
            encodeArray[index] = (char)(encodeArray[index] ^ cipher[key]);
            if (key == cipher.Length - 1)
            {
                key = 0;
            }
            else
            {
                key++;
            }
        }

        string encodedString = new string(encodeArray);
        return encodedString;
    }
}