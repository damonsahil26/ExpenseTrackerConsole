# Expense Tracker Console Application

.NET 8 Console app solution for tracking expenses. The Expense Tracker is a simple console-based application designed to help you manage and track your expenses. This application allows you to add, list, delete, and summarize your expenses, along with other utility features.

Project Task URL : [https://roadmap.sh/projects/expense-tracker](https://roadmap.sh/projects/expense-tracker)

.NET 8 Console app solution for the task-tracker [challenge](https://roadmap.sh/projects/expense-tracker) from [roadmap.sh](https://roadmap.sh/).
## Features

- **Add Expense**: Create a new expense with a description, amount, and category.
- **List Expenses**: Display all expenses added so far.
- **Delete Expense**: Remove an expense by its ID.
- **Summarize Expenses**: View a summary of total expenses, either overall or for a specific month.
- **Help Command**: Display a list of available commands.
- **Clear Console**: Clear the console and redisplay the welcome message.
- **Exit**: Exit the application.

## Installation

To run this application, follow these steps:

1. Clone this repository:
    ```bash
    git clone https://github.com/damonsahil26/ExpenseTrackerConsole.git
    ```

2. Navigate to the project directory:
    ```bash
    cd ExpenseTrackerConsole
    ```

3. Restore dependencies:
    ```bash
    dotnet restore
    ```

4. Build the project:
    ```bash
    dotnet build
    ```

5. Run the application:
    ```bash
    dotnet run
    ```

## Usage

After running the application, you will be greeted with a welcome message. You can then start entering commands.

### Available Commands

- **help**: Displays a list of all available commands.
- **expense-tracker add --description "Your description" --amount 100.50 --category "Food"**: Adds a new expense with the provided description, amount, and category.
- **expense-tracker list**: Lists all expenses.
- **expense-tracker delete --id 1**: Deletes the expense with the given ID.
- **expense-tracker summary**: Displays the total amount of all expenses.
- **expense-tracker summary --month 8**: Displays the total amount of expenses for a specified month (e.g., August).
- **clear**: Clears the console and redisplays the welcome message.
- **exit**: Exits the application.

### Example Usage

```bash
Enter command : expense-tracker add --description "Grocery shopping" --amount 150.75 --category "Food"
Expense added successfully with ID: 1

Enter command : expense-tracker list
Id   Description          Date         Amount   Category   
1    Grocery shopping     01-09-2024   150.75   Food

Enter command : expense-tracker summary
Total expenses: $150.75

Enter command : expense-tracker delete --id 1
Expense deleted successfully

Enter command : exit
