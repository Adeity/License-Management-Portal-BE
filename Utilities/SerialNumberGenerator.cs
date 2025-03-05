using System;
using System.Text;

namespace DP_BE_LicensePortal.Utilities;
public class SerialNumberGenerator
{
    private static Random random = new Random();

    public static string GenerateSerialNumber(string prefix)
    {
        if (prefix.Length != 3)
        {
            throw new ArgumentException("Prefix must be exactly 3 characters long.");
        }

        StringBuilder serialNumber = new StringBuilder();
        serialNumber.Append(prefix.ToUpper());

        for (int i = 0; i < 6; i++)
        {
            serialNumber.Append('-');
            serialNumber.Append(GenerateRandomSegment(5));
        }

        return serialNumber.ToString();
    }

    private static string GenerateRandomSegment(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] segment = new char[length];

        for (int i = 0; i < length; i++)
        {
            segment[i] = chars[random.Next(chars.Length)];
        }

        return new string(segment);
    }

    public static void Main()
    {
        string prefix = "RPR";
        string serialNumber = GenerateSerialNumber(prefix);
        Console.WriteLine(serialNumber);
    }
}
