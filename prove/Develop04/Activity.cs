using System;
using System.Collections.Generic;
using System.Threading;

// This is the parent class for every activity. Anything the activities have in
// common (name, description, duration, the start/end messages, and the little
// animations) lives here so I don't have to write it three times.
public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    // Every activity runs a little differently, so each child class fills this in.
    public abstract void Run();

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = AskForDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }

    // Figures out when the activity should wrap up, based on the duration the user picked.
    protected DateTime GetEndTime()
    {
        return DateTime.Now.AddSeconds(_duration);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> frames = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % frames.Count;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string number = i.ToString();
            Console.Write(number);
            Thread.Sleep(1000);
            // Erase the whole number before showing the next one. This matters for
            // numbers like "10", which would otherwise leave a stray "0" behind.
            Console.Write(new string('\b', number.Length));
            Console.Write(new string(' ', number.Length));
            Console.Write(new string('\b', number.Length));
        }
    }

    private int AskForDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }

            Console.WriteLine("Please type a whole number that is more than 0.");
        }
    }
}