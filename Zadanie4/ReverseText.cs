using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = @"C:\Users\User\Desktop\labor2\duży_plik.txt";

        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    char[] charArray = line.ToCharArray();
                    Array.Reverse(charArray);
                    Console.WriteLine(new string(charArray));
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
        }
    }
}
