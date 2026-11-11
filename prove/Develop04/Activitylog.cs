using System;
using System.IO;

// Saves each finished activity to a text file, so you can look back at your
// history, even from earlier times you ran the program.
public class ActivityLog
{
    private string _fileName;

    public ActivityLog(string fileName)
    {
        _fileName = fileName;
    }

    public void AddEntry(string activityName, int seconds)
    {
        string line = $"{DateTime.Now:g} - {activityName} ({seconds} seconds)";
        File.AppendAllText(_fileName, line + Environment.NewLine);
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("Activity Log");
        Console.WriteLine("------------");

        if (File.Exists(_fileName))
        {
            string[] lines = File.ReadAllLines(_fileName);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();
            Console.WriteLine($"Total activities completed: {lines.Length}");
        }
        else
        {
            Console.WriteLine("You haven't completed any activities yet.");
        }

        Console.WriteLine();
        Console.Write("Press enter to go back to the menu.");
        Console.ReadLine();
    }
}