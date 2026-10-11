using System;
using System.Collections.Generic;
using System.Text;

// Represents a single journal entry.
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;

    public Entry(string date, string promptText, string entryText, string mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine();
    }

    // Converts the entry to one CSV line (Excel-compatible).
    public string ToCsv()
    {
        return $"{CsvEscape(_date)},{CsvEscape(_promptText)},{CsvEscape(_entryText)},{CsvEscape(_mood)}";
    }

    // Builds an Entry from one CSV line. Returns null if the line is malformed.
    public static Entry FromCsv(string line)
    {
        List<string> fields = CsvSplit(line);
        if (fields.Count < 4)
        {
            return null;
        }
        return new Entry(fields[0], fields[1], fields[2], fields[3]);
    }

    // Wraps a field in quotes and doubles any quotes inside it.
    private static string CsvEscape(string value)
    {
        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }

    // Splits a CSV line into fields, respecting quoted commas and doubled quotes.
    private static List<string> CsvSplit(string line)
    {
        List<string> fields = new List<string>();
        StringBuilder current = new StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (inQuotes)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    current.Append(c);
                }
            }
            else
            {
                if (c == '"')
                {
                    inQuotes = true;
                }
                else if (c == ',')
                {
                    fields.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }
        }

        fields.Add(current.ToString());
        return fields;
    }
}
