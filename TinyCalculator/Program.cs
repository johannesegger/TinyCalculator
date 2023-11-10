Console.WriteLine("== Tiny calculator ==");

int result = ReadNumber("Start value");
while (result > 1)
{
    ICalculation operation = ChooseOperator();
    int rightOperand = ReadNumber(operation.RightOperandName);
    if (operation.Calculate(result, rightOperand, out string? errorMessage) is int nextResult)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{result} {operation.Operator} {rightOperand} = {nextResult}");
        result = nextResult;
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.ResetColor();
    }
    if (result <= 1)
    {
        break;
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

ICalculation ChooseOperator()
{
    while (true)
    {
        Console.Write($"Operator [+ - * /]: ");
        string input = Console.ReadLine();
        if (input == "+") return new Addition();
        else if (input == "-") return new Subtraction();
        else if (input == "*") return new Multiplication();
        else if (input == "/") return new Division();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{input} is not a valid operator.");
        Console.ResetColor();
    }
}

interface ICalculation
{
    string Operator { get; }
    string RightOperandName { get; }
    int? Calculate(int a, int b, out string? errorMessage);
}

class Addition : ICalculation
{
    public string Operator => "+";
    public string RightOperandName => "Summand 2";
    public int? Calculate(int a, int b, out string? errorMessage)
    {
        errorMessage = null;
        return a + b;
    }
}

class Subtraction : ICalculation
{
    public string RightOperandName => "Subtrahend";
    public string Operator => "-";
    public int? Calculate(int a, int b, out string? errorMessage)
    {
        errorMessage = null;
        return a - b;
    }
}

class Division : ICalculation
{
    public string RightOperandName => "Divisor";
    public string Operator => "/";
    public int? Calculate(int a, int b, out string? errorMessage)
    {
        if (b == 0)
        {
            errorMessage = "Divisor darf nicht 0 sein.";
            return null;
        }
        errorMessage = null;
        return a / b;
    }
}

class Multiplication : ICalculation
{
    public string RightOperandName => "Factor 2";
    public string Operator => "*";
    public int? Calculate(int a, int b, out string? errorMessage)
    {
        errorMessage = null;
        return a * b;
    }
}
