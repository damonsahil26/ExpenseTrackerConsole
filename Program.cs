
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

    if (!commands[0].ToLower().Equals("expense-tracker"))
    {
        ConsoleMessage.PrintErrorMessage("Wrong command entered!");
        continue;
    }
}



