using ExpenseTracker.ConsoleApp.Models;

namespace ExpenseTracker.ConsoleApp.Services;

public class TransactionService
{
  private readonly List<Transaction> _transactions = [];

  public void AddTransaction(string title, decimal amount, TransactionType type)
  {
    var transaction = new Transaction
    {
      Title = title,
      Amount = amount,
      Type = type
    };
    _transactions.Add(transaction);
  }

  // Expression-bodied member
  public List<Transaction> GetAll() => _transactions;

  public decimal GetBalance()
  {
    decimal totalIncome = _transactions
    .Where(t => t.Type == TransactionType.Income)
    .Sum(t => t.Amount);

    decimal totalExpense = _transactions
    .Where(t => t.Type == TransactionType.Expense)
    .Sum(t => t.Amount);

    return totalIncome - totalExpense;
  }
}
