using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. " +
               "Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = GetEndTime();

        // Keep alternating between breathing in and out until time runs out.
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine();

            Console.Write("Breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}