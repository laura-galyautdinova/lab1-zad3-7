using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceFilePath = "duzy_plik.txt";
        string destinationFilePath = "duzy_copy.txt";

        // Generowanie dużego pliku
        int fileSizeInMB = 300;
        GenerateLargeFile(sourceFilePath, fileSizeInMB);

        // Test File.Copy method
        MeasureCopyTime(() => File.Copy(sourceFilePath, destinationFilePath, true), "File.Copy");

        // Test FileStream method
        MeasureCopyTime(() =>
        {
            using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open))
            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create))
            {
                sourceStream.CopyTo(destinationStream);
            }
        }, "FileStream.CopyTo");

        // Test BufferedStream method
        MeasureCopyTime(() =>
        {
            using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open))
            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create))
            using (BufferedStream bufferedSource = new BufferedStream(sourceStream))
            using (BufferedStream bufferedDestination = new BufferedStream(destinationStream))
            {
                bufferedSource.CopyTo(bufferedDestination);
            }
        }, "BufferedStream.CopyTo");
    }

    static void GenerateLargeFile(string filePath, int fileSizeInMB)
    {
        byte[] data = new byte[1024 * 1024]; // 1 MB buffer
        Random rng = new Random();
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            for (int i = 0; i < fileSizeInMB; i++)
            {
                rng.NextBytes(data);
                fs.Write(data, 0, data.Length);
            }
        }
        Console.WriteLine($"Generated file {filePath} with size {fileSizeInMB} MB");
    }

    static void MeasureCopyTime(Action copyAction, string methodName)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        copyAction();
        stopwatch.Stop();
        Console.WriteLine($"{methodName} took {stopwatch.ElapsedMilliseconds} ms");
    }
}
