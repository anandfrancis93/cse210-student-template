using System;
using System.Collections.Generic;

// Scripture Memorizer
//
// Exceeding requirements:
// 1. The program has a library of scriptures and picks one at random each time it runs.
// 2. HideRandomWords only picks words that are not already hidden (stretch challenge),
//    so every press of Enter hides new words.
// 3. Hidden words keep their punctuation (e.g. "_____,"), which gives a small hint.
// 4. A progress line shows how many words have been hidden so far.

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = new List<Scripture>();

        library.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));

        library.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));

        library.Add(new Scripture(
            new Reference("Moroni", 10, 4),
            "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost."));

        library.Add(new Scripture(
            new Reference("2 Nephi", 2, 25),
            "Adam fell that men might be; and men are, that they might have joy."));

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine($"Hidden: {scripture.GetHiddenCount()} of {scripture.GetWordCount()} words");
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Great job!");
                break;
            }

            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string? input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}