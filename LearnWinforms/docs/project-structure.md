# Cấu trúc dự án

## 1. Cấu trúc cây thư mục (Folder Tree)

Plaintext

```txt
GameCaroProject/
│
├── 📁 Forms/               <-- Chứa toàn bộ giao diện (Form1, LoginForm...)
│   ├── Form1.cs
│   ├── Form1.UI.cs         <-- File tách UI bạn vừa làm
│   ├── LoginForm.cs
│   └── ...
│
├── 📁 Models/              <-- Chứa các class dữ liệu (Khuôn đúc)
│   ├── User.cs             (Chứa: Id, Username, Password)
│   ├── Match.cs            (Chứa: MatchId, Player1, Score)
│   └── ...
│
├── 📁 Repositories/        <-- (Database Layer) Chỉ chứa lệnh SQL/kết nối DB
│   ├── DatabaseHelper.cs   (Mở kết nối SQL Connection)
│   ├── UserRepository.cs   (Select, Insert, Update bảng User)
│   └── MatchRepository.cs
│
├── 📁 Services/            <-- (Logic Layer) Xử lý nghiệp vụ, tính toán
│   ├── AuthService.cs      (Kiểm tra đăng nhập, mã hóa pass)
│   ├── GameLogicService.cs (Kiểm tra thắng thua, nước đi)
│   └── ...
│
├── 📁 Helpers/             <-- Các hàm tiện ích dùng chung
│   ├── Constants.cs        (Lưu mã màu, font chữ mặc định)
│   └── ImageHelper.cs      (Xử lý ảnh avatar...)
│
└── Program.cs
```

---

## 2. Giải thích chi tiết & Code mẫu

Quy tắc vàng: **"Form gọi Service, Service gọi Repository, Repository gọi Database".**

### A. `Models` (Dữ liệu đơn thuần)

Chỉ chứa các Property, không chứa logic.

```c#
// File: Models/User.cs
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
}
```

#### B. `Repositories` (Thợ hồ - Làm việc vất vả với SQL)

Lớp này chỉ quan tâm làm sao lấy dữ liệu ra, không quan tâm dữ liệu đó dùng để làm gì.

```c#
// File: Repositories/UserRepository.cs
using System.Data.SqlClient;
using MyGame.Models;

public class UserRepository
{
    private string _connString = "Server=.;Database=GameCaro;Trusted_Connection=True;";

    public User GetUserByUsername(string username)
    {
        // Viết code SQL Select ở đây
        // Trả về đối tượng User hoặc null
        return null; // Demo
    }
}
```

#### C. `Services` (Bộ não - Xử lý nghiệp vụ)

Lớp này sẽ quyết định: Mật khẩu có đúng không? Có được phép đăng nhập không?

```c#
// File: Services/AuthService.cs
public class AuthService
{
    private UserRepository _userRepo = new UserRepository();

    public bool Login(string username, string password)
    {
        // 1. Gọi Repository lấy user
        var user = _userRepo.GetUserByUsername(username);

        // 2. Logic kiểm tra (Nghiệp vụ)
        if (user == null) return false; // Không tìm thấy

        if (user.Password == password) // (Thực tế phải check Hash)
        {
            return true; // Đúng pass
        }

        return false; // Sai pass
    }
}
```

#### D. `Forms` (Giao diện - Chỉ hiển thị)

Lúc này file `LoginForm.cs` của bạn sẽ cực kỳ sạch sẽ. Nó không cần biết SQL là gì, không cần biết check pass thế nào. Nó chỉ biết "Nhờ ông Service check hộ".

```c#
// File: Forms/LoginForm.cs
public partial class LoginForm : Form
{
    // Gọi Service
    private AuthService _authService = new AuthService();

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        string u = txtUsername.Text;
        string p = txtPassword.Text;

        // Form chỉ việc gọi hàm Login, không cần quan tâm bên trong làm gì
        bool ketQua = _authService.Login(u, p);

        if (ketQua)
        {
            MessageBox.Show("Welcome!");
        }
        else
        {
            MessageBox.Show("Sai rồi!");
        }
    }
}
```

### 3. Tại sao phải làm thế này? (Lợi ích)

1. **Dễ sửa lỗi (Debug):**

   - Nếu sai giao diện (nút bị lệch) -> Vào folder `Forms`.

   - Nếu sai logic (đúng pass mà báo sai) -> Vào folder `Services`.

   - Nếu lỗi kết nối SQL -> Vào folder `Repositories`.

2. **Tái sử dụng (Reusability):**

   - Sau này bạn làm thêm tính năng "Đổi mật khẩu" ở Form khác, bạn chỉ cần gọi lại `_authService.ChangePassword(...)` mà không cần viết lại code SQL.

3. **Làm việc nhóm:**

   - Bạn làm UI (Forms).

   - Bạn của bạn làm Database (Repositories).

   - Hai người không bị dẫm chân lên code của nhau.
