using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Services.Interfaces
{
    public interface IExpenseService
    {
        List<string> GetHelpCommandsList();

        int AddExpense(string description, double amount, string category);

        bool DeleteExpense(int id);

        double GetExpenseSummary();

        double GetExpenseSummary(int month);
    }
}
