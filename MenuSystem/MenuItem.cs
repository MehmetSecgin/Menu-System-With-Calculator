using System;

namespace MenuSystem;

public class MenuItem
{
    // To run methods without any inputs.
    public MenuItem(string shortCut, string title, Func<string>? runMethod)
    {
        if (shortCut.Equals(""))
        {
            throw new ArgumentException("ShortCut cannot be empty or more than 1 letter!");
            
        }

        ShortCut = shortCut.Trim().ToUpper();
        Title = title ?? throw new ArgumentException("Title cannot be empty! ");
        RunMethod = runMethod;
    }

    public string ShortCut { get; private set; }
    public string Title { get; private set; }

    public Func<string>? RunMethod { get; private set; }


    public override string ToString()
    {
        return ShortCut + ") " + Title;
    }
}