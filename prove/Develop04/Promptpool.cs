using System;
using System.Collections.Generic;

// Hands out prompts or questions in a random order without repeats.
// Once every item has been shown, it puts the full list back and starts over.
public class PromptPool
{
    private List<string> _items;
    private List<string> _unusedItems;
    private Random _random;

    public PromptPool(List<string> items)
    {
        _items = new List<string>(items);
        _unusedItems = new List<string>(items);
        _random = new Random();
    }

    public string GetNext()
    {
        if (_unusedItems.Count == 0)
        {
            _unusedItems = new List<string>(_items);
        }

        int index = _random.Next(_unusedItems.Count);
        string item = _unusedItems[index];
        _unusedItems.RemoveAt(index);
        return item;
    }
}