using System;

// HOW I WENT BEYOND THE CORE REQUIREMENTS:
// 1. No repeats: I made a PromptPool class so you won't see the same prompt or
//    question twice until you've gone through all of them in that session.
// 2. Activity log: every finished activity is saved to "mindfulness_log.txt" with
//    the date, the activity name and how long it lasted. Option 4 on the menu reads
//    the file back and shows your full history, even from earlier runs.
// 3. Input checking: if you type something that isn't a valid menu option or
//    duration, the program just asks again instead of crashing.

class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog("mindfulness_log.txt");

        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            // If the input stream closes (like pressing Ctrl+D), just exit instead of looping forever.
            if (choice == null)
            {
                break;
            }

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    log.Display();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("That is not a valid choice. Please try again.");
                    System.Threading.Thread.Sleep(1500);
                    break;
            }

            if (activity != null)
            {
                activity.Run();
                log.AddEntry(activity.GetName(), activity.GetDuration());
            }
        }
    }
}