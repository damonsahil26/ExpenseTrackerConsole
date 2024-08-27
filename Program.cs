
using ExpenseTracker.Utilities;

ConsoleMessage.PrintInfoMessage("Hi, Welcome To Expense Tracker Application : ");

ConsoleMessage.PrintCommandMessage("Please enter command to continue or type help for more options : ");

while (true)
{
    string input = Console.ReadLine() ?? string.Empty;
    if (string.IsNullOrEmpty(input))
    {
        ConsoleMessage.PrintErrorMessage("No input given.");
        continue;
    }

    List<string> commands = Utility.ParseInput(input);

    if(commands.Count < 2)
    {
        ConsoleMessage.PrintErrorMessage("Wrong command entered!");
        continue;
    }

    if (!commands[0].ToLower().Equals("expense-tracker"))
    {
        ConsoleMessage.PrintErrorMessage("Wrong command entered!");
        continue;
    }

    HandleEnteredExpense(commands);

}

void HandleEnteredExpense(List<string> commands)
{
    switch (commands[1].ToLower())
    {
        case "add":
            AddExpense();
            break;
        case "list":
            DisplayAddedExpenses();
            break;
        case "summary":
            DisplaySummary();
            break;
        case "delete":
            DeleteExpense();
            break;
        default:
            break;
    }
}

void DeleteExpense()
{
    throw new NotImplementedException();
}

void DisplaySummary()
{
    throw new NotImplementedException();
}

void DisplayAddedExpenses()
{
    throw new NotImplementedException();
}

void AddExpense()
{
    throw new NotImplementedException();
}