using System;
using System.Text;
using System.Linq;

class CaesarCipher
{
    private static readonly string lowerCase = "abcdefghijklmnopqrstuvwxyząćęłńóśźż";
    private static readonly string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZĄĆĘŁŃÓŚŹŻ";

    public static string Encrypt(string input, int shift)
    {
        StringBuilder encrypted = new StringBuilder(input.Length);

        foreach (char c in input)
        {
            if (lowerCase.Contains(c))
            {
                int index = lowerCase.IndexOf(c);
                int newIndex = (index + shift) % lowerCase.Length;
                encrypted.Append(lowerCase[newIndex]);
            }
            else if (upperCase.Contains(c))
            {
                int index = upperCase.IndexOf(c);
                int newIndex = (index + shift) % upperCase.Length;
                encrypted.Append(upperCase[newIndex]);
            }
            else
            {                
                encrypted.Append(c);
            }
        }

        return encrypted.ToString();
    }

    public static string Decrypt(string input, int shift)
    {        
        return Encrypt(input, lowerCase.Length - shift);
    }
}

class Program
{
    static void Main(string[] args)
    {
        string original = "Zażółć gęślą jaźń!";
        int shift = 3;

        string encrypted = CaesarCipher.Encrypt(original, shift);
        string decrypted = CaesarCipher.Decrypt(encrypted, shift);

        Console.WriteLine($"Original: {original}");
        Console.WriteLine($"Encrypted: {encrypted}");
        Console.WriteLine($"Decrypted: {decrypted}");
    }
}
