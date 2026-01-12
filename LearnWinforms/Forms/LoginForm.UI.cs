using CuoreUI.Components;
using CuoreUI.Controls;

namespace LearnWinforms.Forms;

public partial class LoginForm
{
    private cuiTextBox? txtUsername;
    private cuiTextBox? txtPassword;
    private cuiButton? btnLogin;
    private cuiPanel? pnlLeft;
    private cuiFormRounder? formRounder;

    private void InitializeControls()
    {
        formRounder = new()
        {
            TargetForm = this,
            Rounding = 20,
        };

        // --- PANEL TRÁI ---
        pnlLeft = new()
        {
            Dock = DockStyle.Left,
            Width = 300,
        };

        Label lblWelcome = new()
        {
            Text = "WELCOME\nBACK",
            ForeColor = Color.Black,
            Font = new Font("Segoe UI", 24, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(50, 150)
        };
        pnlLeft.Controls.Add(lblWelcome);
        Controls.Add(pnlLeft);

        // --- TITLE ---
        Label lblTitle = new()
        {
            Text = "USER LOGIN",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            ForeColor = Color.FromArgb(31, 30, 68),
            AutoSize = true,
            Location = new Point(350, 50)
        };
        Controls.Add(lblTitle);

        // --- USERNAME ---
        txtUsername = new()
        {
            Location = new Point(350, 130),
            Size = new Size(300, 45),
            BackColor = Color.WhiteSmoke,
            ForeColor = Color.Black,
            OutlineColor = Color.FromArgb(31, 30, 68),
            FocusOutlineColor = Color.DeepPink,
            Rounding = new Padding(10),
            PlaceholderText = "Nhập tài khoản...",
            Font = new Font("Segoe UI", 11)
        };
        // Label lblUser = new()
        // {
        //     Text = "Username",
        //     ForeColor = Color.Gray,
        //     Location = new Point(350, 105)
        // };
        Controls.Add(txtUsername);
        // Controls.Add(lblUser);

        // --- PASSWORD ---
        txtPassword = new()
        {
            Location = new Point(350, 220),
            Size = new Size(300, 45),
            BackColor = Color.WhiteSmoke,
            ForeColor = Color.Black,
            OutlineColor = Color.FromArgb(31, 30, 68),
            FocusOutlineColor = Color.DeepPink,
            Rounding = new Padding(10),
            PlaceholderText = "Nhập mật khẩu...",
            PasswordChar = true,
            Font = new Font("Segoe UI", 11)
        };
        // Label lblPass = new()
        // {
        //     Text = "Password",
        //     ForeColor = Color.Gray,
        //     Location = new Point(350, 195)
        // };
        Controls.Add(txtPassword);
        // Controls.Add(lblPass);

        // --- BUTTON LOGIN ---
        btnLogin = new()
        {
            Content = "LOGIN",
            Size = new Size(150, 50),
            Location = new Point(350, 300),

            NormalBackground = Color.FromArgb(31, 30, 68),

            Rounding = new Padding(25),
            ForeColor = Color.White,
            NormalOutline = Color.Transparent,
            Font = new Font("Segoe UI", 12, FontStyle.Bold)
        };
        btnLogin.Click += BtnLogin_Click;
        Controls.Add(btnLogin);

        // --- BUTTON EXIT ---
        Label btnExit = new()
        {
            Text = "X",
            Font = new Font("Arial", 15, FontStyle.Bold),
            ForeColor = Color.Gray,
            Location = new Point(710, 10),
            Cursor = Cursors.Hand
        };
        btnExit.Click += (s, e) => Close();
        Controls.Add(btnExit);
    }
}
