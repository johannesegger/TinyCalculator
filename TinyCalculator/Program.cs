Console.WriteLine("== Tiny calculator ==");

int result = ReadNumber("Dividend");
while (true)
{
    int divisor = ReadNumber("Divisor");

    if (divisor == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Divisor darf nicht 0 sein.");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{result} / {divisor} = {result / divisor}");
        result = result / divisor;
        Console.ResetColor();
    }
}

static int ReadNumber(string name)
{
    while (true)
    {
        Console.Write($"{name}: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int dividend))
        {
            return dividend;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{input} is not a number.");
        Console.ResetColor();
    }
}