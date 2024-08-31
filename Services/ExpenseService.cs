using ExpenseTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        public List<string> GetHelpCommandsList()
        {
            return new List<string>
            {
                "expense-tracker add --Description \"description\" --amount $amount --category \"CategoryName\"",
                "expense-tracker list",
                "expense-tracker summary",
                "expense-tracker summary --month monthNumber",
                "expense-tracker delete --id id",
                "exit",
                "clear"
            };
        }
    }
}
