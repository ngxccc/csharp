using System.Text;
using ExpenseTracker.ConsoleApp.Models;
using ExpenseTracker.ConsoleApp.Services;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

TransactionService service = new();

bool exit = false;
while (!exit)
{
  Console.Clear();
  Console.WriteLine("=== QUẢN LÝ CHI TIÊU ===");
  Console.WriteLine("1. Thêm khoản thu/chi");
  Console.WriteLine("2. Xem danh sách");
  Console.WriteLine("3. Xem số dư (Chưa làm)");
  Console.WriteLine("0. Thoát");
  Console.Write("Chọn chức năng: ");

  string? choice = Console.ReadLine();

  switch (choice)
  {
    case "1":
      AddTransactionUI(service);
      break;
    case "2":
      ShowListUI(service);
      break;
    case "3":
      Console.WriteLine("Tính năng này bạn tự code nhé!");
      Pause();
      break;
    case "0":
      exit = true;
      break;
    default:
      Console.WriteLine("Chọn sai rồi!");
      Pause();
      break;
  }
}

void AddTransactionUI(TransactionService svc)
{
  Console.WriteLine("\n--- THÊM MỚI ---");

  Console.Write("Nhập tiêu đề: ");
  string title = Console.ReadLine() ?? "Không tên";

  Console.Write("Nhập số tiền: ");
  if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
  {
    Console.WriteLine("Số tiền không hợp lệ!");
    Pause();
    return;
  }

  Console.Write("Loại (1=Thu, 2=Chi): ");
  string typeStr = Console.ReadLine() ?? "2";
  TransactionType type = typeStr == "1" ? TransactionType.Income : TransactionType.Expense;

  svc.AddTransaction(title, amount, type);
  Console.WriteLine("✅ Đã thêm thành công!");
  Pause();
}

void ShowListUI(TransactionService svc)
{
  Console.WriteLine("\n--- DANH SÁCH GIAO DỊCH ---");
  var list = svc.GetAll();

  if (list.Count == 0)
  {
    Console.WriteLine("Chưa có dữ liệu.");
  }
  else
  {
    foreach (var item in list)
    {
      Console.WriteLine(item);
    }
  }
  Pause();
}

void Pause()
{
  Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
  Console.ReadKey();
}
