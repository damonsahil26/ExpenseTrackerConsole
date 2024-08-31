
using ExpenseTracker.Utilities;

ConsoleMessage.PrintInfoMessage("Hi, Welcome To Expense Tracker Application : ");

while (true)
{
    ShowNewCommandText();
    string input = Console.ReadLine() ?? string.Empty;
    if (string.IsNullOrEmpty(input))
    {
        ConsoleMessage.PrintErrorMessage("No input given.");
        continue;
    }

    List<string> commands = Utility.ParseInput(input);

    if (commands.Count < 1)
    {
        ConsoleMessage.PrintErrorMessage("Wrong command entered!");
        continue;
    }

    if (!commands[0].ToLower().Equals("expense-tracker") && !commands[0].ToLower().Equals("help") && !commands[0].ToLower().Equals("clear"))
    {
        ConsoleMessage.PrintErrorMessage("Wrong command entered!");
        continue;
    }

    if (commands.Count > 1)
    {
        HandleEnteredExpense(commands);
    }

    else
    {
        if (commands[0].Equals("help"))
            ShowHelp();
        else
            ClearConsole();
    }

}

void HandleEnteredExpense(List<string> commands)
{
    switch (commands[1].ToLower())
    {
        case "add":
            AddExpense(commands);
            break;
        case "list":
            DisplayAddedExpenses(commands);
            break;
        case "summary":
            DisplaySummary(commands);
            break;
        case "delete":
            DeleteExpense(commands);
            break;
        case "help":
            ShowHelp();
            break;
        case "clear":
            ClearConsole();
            break;
        default:
            DisplayWrongCommandMessage();
            break;
    }
}

void ClearConsole()
{
    Console.Clear();
    ConsoleMessage.PrintInfoMessage("Hi, Welcome To Expense Tracker Application : ");
}

void ShowHelp()
{
    throw new NotImplementedException();
}

void DeleteExpense(List<string> commands)
{
    if (!IsDeleteCommandCorrect(4, commands))
    {
        return;
    }

    // TODO: Call delete service method
}

bool IsDeleteCommandCorrect(int parametersRequired, List<string> commands)
{
    if (commands.Count != parametersRequired)
    {
        DisplayWrongCommandMessage();
        return false;
    }

    if (commands.Count == 4)
    {
        if (!commands[2].Equals("--id"))
        {
            DisplayWrongCommandMessage();
            return false;
        }


        if (!Int32.TryParse(commands[3].Trim(), out int result))
        {
            DisplayWrongCommandMessage();
            return false;
        }
    }

    return true;
}

void DisplaySummary(List<string> commands)
{
    if (!IsSummaryCommandCorrect(4, commands))
    {
        return;
    }

    // TODO: Call summary service method
}

bool IsSummaryCommandCorrect(int parametersRequired, List<string> commands)
{
    if (commands.Count != parametersRequired && commands.Count != 2)
    {
        DisplayWrongCommandMessage();
        return false;
    }

    if (commands.Count == 4)
    {
        if (!commands[2].Equals("--month"))
        {
            DisplayWrongCommandMessage();
            return false;
        }


        if (!Int32.TryParse(commands[3].Trim(), out int result))
        {
            DisplayWrongCommandMessage();
            return false;
        }
    }

    return true;
}

void DisplayAddedExpenses(List<string> commands)
{
    if (!IsListCommandCorrect(2, commands))
    {
        return;
    }

    // TODO: Call List service method
}

bool IsListCommandCorrect(int parametersRequired, List<string> commands)
{
    if (commands.Count != parametersRequired)
    {
        DisplayWrongCommandMessage();
        return false;
    }

    return true;
}

void AddExpense(List<string> commands)
{
    if (!IsAddCommandCorrect(8, commands))
    {
        return;
    }

    Double.TryParse(commands[5].Trim(), out double amount);
    // TODO: Call Add service method
}

bool IsAddCommandCorrect(int parametersRequired, List<string> commands)
{
    if (commands.Count != parametersRequired)
    {
        DisplayWrongCommandMessage();
        return false;
    }

    if (!commands[2].Equals("--description") || !commands[4].Equals("--amount") || !commands[6].Equals("--category"))
    {
        DisplayWrongCommandMessage();
        return false;
    }

    if (!Double.TryParse(commands[5].Trim(), out double result))
    {
        DisplayWrongCommandMessage();
        return false;
    }

    return true;
}

void DisplayWrongCommandMessage()
{
    ConsoleMessage.PrintErrorMessage("Wrong Or Incomplete command entered!");
}

static void ShowNewCommandText()
{
    ConsoleMessage.PrintCommandMessage("Please enter command to continue or type help for more options : ");
}