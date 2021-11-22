using CalculatorBrain;
using MenuSystem;

namespace ConsoleApp;

class Program
{

    private static readonly Brain Brain = new();

    static void Main()
    {
        Console.Clear();

        var mainMenu = new Menu(ShowCalculatorDisplay, "Calculator Main", EMenuLevel.Root);
        mainMenu.AddMenuItems(new List<MenuItem>()
        {
            new("B", "Binary operations", SubmenuBinary),
            new("U", "Unary operations", SubmenuUnary),
        });

        mainMenu.Run();
    }

    private static string ShowCalculatorDisplay()
    {
        return Brain.ToString();
    }

        
    private static string SubmenuBinary()
    {
        ShowCalculatorDisplay();
        var menu = new Menu(ShowCalculatorDisplay, "Binary", EMenuLevel.First);
        menu.AddMenuItems(new List<MenuItem>()
        {
            new("+", "+", Add),
            new("-", "-", Subtract),
            new("/", "/", Divide),
            new("*", "*", Multiply),
        });
        var res = menu.Run();
        return res!;
    }

    private static string SubmenuUnary()
    {
        ShowCalculatorDisplay();
        var menu = new Menu(ShowCalculatorDisplay, "Unary", EMenuLevel.First);
        menu.AddMenuItems(new List<MenuItem>()
        {
            new("Negate", "Negate", Negate),
            new("Sqrt", "Sqrt", Sqrt),
            new("Root", "Root", Root),
        });
        var res = menu.Run();
        return res!;
    }

    private static string Negate()
    {
        // _calculatorCurrentDisplay *= -1;
        return "";
    }

    private static string Sqrt()
    {
        // _calculatorCurrentDisplay = Math.Sqrt(_calculatorCurrentDisplay);
        return "";
    }

    public static string Root()
    {
        return "";
    }

    private static string Add()
    {
        Console.WriteLine("Input the amount you want to add to the value: ");
        var n = Console.ReadLine()?.Trim();
        double.TryParse(n, out var converted);

        Brain.Add(converted);
        return "";
    }

    private static string Subtract()
    {
        ShowCalculatorDisplay();
        Console.WriteLine("Input the amount you want to subtract from the value: ");
        var n = Console.ReadLine()?.Trim();
        double.TryParse(n, out var converted);

        Brain.Subtract(converted);

        return "";
    }

    private static string Divide()
    {
        ShowCalculatorDisplay();
        Console.WriteLine("Input the amount you want to divide the value with: ");
        var n = Console.ReadLine()?.Trim();
        double.TryParse(n, out var converted);
        Brain.Divide(converted);

        return "";
    }

    private static string Multiply()
    {
        Console.WriteLine("Input the amount you want to multiply the value with: ");
        var n = Console.ReadLine()?.Trim();
        double.TryParse(n, out var converted);

        Brain.ApplyCustomFunction(CustomMultiply, converted);

        // BattleShipBrain.ApplyCustomFunction((a, b) => a * b, converted);

        return "";
    }

    private static double CustomMultiply(double a, double b)
    {
        return a * b;
    }
}