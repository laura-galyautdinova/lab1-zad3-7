using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourcePath = @"C:\Users\User\Desktop\labor2\duży_plik.txt";
        string destPath = @"C:\Users\User\Desktop\labor2\maly_plik.txt";

        try
        {
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream destStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
            {
                sourceStream.CopyTo(destStream);
            }
            Console.WriteLine("Plik został skopiowany.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
        }
    }
}
