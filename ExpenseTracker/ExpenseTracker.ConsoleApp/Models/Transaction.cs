namespace ExpenseTracker.ConsoleApp.Models;

public enum TransactionType { Income, Expense }

public class Transaction
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public required string Title { get; set; }
  public decimal Amount { get; set; }
  public TransactionType Type { get; set; }
  public DateTime Date { get; set; } = DateTime.Now;
  public override string ToString()
  {
    // Định dạng tiền tệ và ngày tháng
    return $"{Date:dd/MM/yyyy} | {Type,-7} | {Title,-20} | {Amount:N0} đ";
  }
}
