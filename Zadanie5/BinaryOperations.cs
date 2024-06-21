using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = @"C:\Users\User\Desktop\labor2\duży_plik.txt";
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine("1. Zapisz dane do pliku");
        Console.WriteLine("2. Odczytaj dane z pliku");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                SaveData(path);
                break;
            case "2":
                ReadData(path);
                break;
            default:
                Console.WriteLine("Nieznana opcja.");
                break;
        }
    }

    static void SaveData(string path)
    {
        Console.Write("Podaj imię: ");
        string name = Console.ReadLine();
        Console.Write("Podaj wiek: ");
        int.TryParse(Console.ReadLine(), out int age); // Use TryParse to avoid exception
        Console.Write("Podaj adres: ");
        string address = Console.ReadLine();

        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            writer.Write(name?.ToString()); // Use null-conditional operator
            writer.Write(age);
            writer.Write(address?.ToString());
        }
        Console.WriteLine("Dane zostały zapisane.");
    }

    static void ReadData(string path)
    {
        try
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                string name = reader.ReadString();
                int age = reader.ReadInt32();
                string address = reader.ReadString();
                Console.WriteLine($"Imię: {name}, Wiek: {age}, Adres: {address}");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
        }
    }
}
