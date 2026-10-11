using System;

// Exceeding requirements:
// 1. Saves and loads the journal as a real .csv file that opens in Excel.
//    Every field is wrapped in quotes and inner quotes are doubled, so
//    commas and quotation marks in entries are handled correctly.
// 2. Each entry also records the user's mood (1-5), addressing the
//    "not sure what to write" barrier with a quick, low-effort input.
// 3. Prompts the user for confirmation before loading a file would
//    overwrite unsaved entries, and reports missing files or failed saves
//    instead of crashing.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool unsavedChanges = false;
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine() ?? "5";

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine() ?? "";

                string mood = "";
                while (mood != "1" && mood != "2" && mood != "3" && mood != "4" && mood != "5")
                {
                    Console.Write("Rate your mood today (1-5): ");
                    mood = (Console.ReadLine() ?? "5").Trim();
                }

                string date = DateTime.Now.ToShortDateString();
                journal.AddEntry(new Entry(date, prompt, response, mood));
                unsavedChanges = true;
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                if (unsavedChanges)
                {
                    Console.Write("You have unsaved entries that will be replaced. Continue? (y/n) ");
                    if ((Console.ReadLine() ?? "").Trim().ToLower() != "y")
                    {
                        continue;
                    }
                }
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine() ?? "";
                if (journal.LoadFromFile(filename))
                {
                    unsavedChanges = false;
                }
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine() ?? "";
                if (journal.SaveToFile(filename))
                {
                    unsavedChanges = false;
                }
            }
            else if (choice != "5")
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
            }
        }

        Console.WriteLine("Goodbye!");
    }
}
