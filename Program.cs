
using ExpenseTracker.Services;
using ExpenseTracker.Services.Interfaces;
using ExpenseTracker.Utilities;
using Microsoft.Extensions.DependencyInjection;

ConsoleMessage.PrintInfoMessage("Hi, Welcome To Expense Tracker Application : ");

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);

var serviceProvider = serviceCollection.BuildServiceProvider();
var _expenseService = serviceProvider.GetService<IExpenseService>();

void ConfigureServices(ServiceCollection serviceCollection)
{
    serviceCollection.AddTransient<IExpenseService, ExpenseService>();
}
bool terminateProgram = false;
while (true && !terminateProgram)
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

    if (!commands[0].ToLower().Equals("expense-tracker")
        && !commands[0].ToLower().Equals("help")
        && !commands[0].ToLower().Equals("clear")
         && !commands[0].ToLower().Equals("exit")
        )
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
        else if (commands[0].Equals("clear"))
            ClearConsole();
        else if (commands[0].Equals("exit"))
            break;
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
        case "exit":
            TerminateProgram();
            break;
        default:
            DisplayWrongCommandMessage();
            break;
    }
}

void TerminateProgram()
{
    terminateProgram = true;
}

void ClearConsole()
{
    Console.Clear();
    ConsoleMessage.PrintInfoMessage("Hi, Welcome To Expense Tracker Application : ");
}

void ShowHelp()
{
    var helps = _expenseService?.GetHelpCommandsList();
    int count = 1;
    if (helps != null && helps.Count > 0)
    {
        foreach (var item in helps)
        {
            ConsoleMessage.PrintHelpMessage(item, count);
            count++;
        }
    }
}

void DeleteExpense(List<string> commands)
{
    if (!IsDeleteCommandCorrect(4, commands))
    {
        return;
    }

    Int32.TryParse(commands[3].Trim(), out int id);
    var result = _expenseService?.DeleteExpense(id);
    if (result != null && result.Value)
    {
        ConsoleMessage.PrintErrorMessage("Expense deleting failed for some reason! Please try again...");
    }
    else
    {
        ConsoleMessage.PrintInfoMessage($"Expense deleted successfully");
    }
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

    if (commands.Count == 2)
    {
        var result = _expenseService?.GetExpenseSummary();

        if (result != null)
        {
            ConsoleMessage.PrintInfoMessage($"Total expenses: ${result.Value}");
        }
        else
        {
            ConsoleMessage.PrintInfoMessage($"Total expenses: $0");
        }
    }
    else
    {
            Int32.TryParse(commands[3], out int month); 
            var result = _expenseService?.GetExpenseSummary(month);
            var monthName = new DateTime(1, month, 1).ToString("MMMM");
            if (result != null)
            {
                ConsoleMessage.PrintInfoMessage($"Total expenses for the {monthName} month : ${result.Value}");
            }
            else
            {
                ConsoleMessage.PrintInfoMessage($"Total expenses: $0");
            }
    }
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
    string description = commands[3];
    string category = commands[7];
    Double.TryParse(commands[5].Trim(), out double amount);


    var result = _expenseService?.AddExpense(description, amount, category);

    if (result == 0)
    {
        ConsoleMessage.PrintErrorMessage("Expense adding failed for some reason! Please try again...");
    }
    else
    {
        ConsoleMessage.PrintInfoMessage($"Expense added successfully (ID : {result})");
    }
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