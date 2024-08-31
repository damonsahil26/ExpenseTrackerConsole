using ExpenseTracker.Models;
using ExpenseTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExpenseTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private static string fileName = "myExpenses.json";
        private static string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        public int AddExpense(string description, double amount, string category)
        {
            try
            {
                List<Expense> expenses = new List<Expense>();
                var newExpense = new Expense
                {
                    Id = GetId(),
                    Description = description,
                    Amount = amount,
                    CreatedAt = DateTime.Now,
                    Type = category
                };

                var fileExists = CheckAndCreateFile();

                if (fileExists)
                {
                    expenses = GetAllExpensesFromFile();

                    expenses?.Add(newExpense);

                    var updatedExpenses = JsonSerializer.Serialize<List<Expense>>(expenses);
                    File.WriteAllText(filePath, updatedExpenses);
                    return newExpense.Id;
                }

                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static List<Expense> GetAllExpensesFromFile()
        {
            List<Expense> fileExpenses = new List<Expense>();
            var jsonData = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(jsonData))
            {
                fileExpenses = JsonSerializer.Deserialize<List<Expense>>(jsonData);
            }

            return fileExpenses ?? new List<Expense>();
        }

        private int GetId()
        {
            if (!CheckIfFileExists())
            {
                return 1;
            }

            var expenses = GetAllExpensesFromFile();
            if(expenses?.Count > 0)
            {
                expenses.OrderBy(x => x.Id);
                var lastId = expenses.Last().Id;
                return lastId + 1;
            }

            return 0;
        }

        private bool CheckAndCreateFile()
        {
            try
            {
                var fileExits = CheckIfFileExists();
                if (!fileExits)
                {
                    using (FileStream fs = File.Create(filePath))
                    {
                        Console.WriteLine($"File {fileName} created successfully.");
                    }
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private bool CheckIfFileExists()
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            return true;
        }

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
