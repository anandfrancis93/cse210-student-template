using System;
using System.Collections.Generic;
using System.IO;

// Holds the list of entries and handles display, saving, and loading.
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    private string _csvHeader = "Date,Prompt,Entry,Mood";

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            Console.WriteLine();
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public bool SaveToFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return false;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_csvHeader);
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.ToCsv());
                }
            }
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException)
        {
            Console.WriteLine($"Could not save to {filename}: {ex.Message}");
            return false;
        }

        Console.WriteLine($"Saved {_entries.Count} entries to {filename}.");
        return true;
    }

    public bool LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File not found: {filename}");
            return false;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line == _csvHeader)
            {
                continue;
            }

            Entry entry = Entry.FromCsv(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Loaded {_entries.Count} entries from {filename}.");
        return true;
    }
}
