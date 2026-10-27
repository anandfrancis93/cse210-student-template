using System;

// Represents a single word in the scripture, which can be shown or hidden.
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the word, or underscores of the same length if it is hidden.
    // Punctuation (like commas and periods) stays visible as a hint.
    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        string result = "";
        foreach (char c in _text)
        {
            if (char.IsLetter(c))
            {
                result += "_";
            }
            else
            {
                result += c;
            }
        }
        return result;
    }
}