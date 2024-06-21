using System;
using System.IO;
using System.Text;

class OpenFileProgram
{
    static void Main()
    {
        string path = @"C:\Users\User\Desktop\labor2\duży_plik.txt";

        try
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[fs.Length];
                int bytesRead = fs.Read(buffer, 0, buffer.Length);
                string content = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Zawartość pliku:");
                Console.WriteLine(content);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
        }
    }
}
