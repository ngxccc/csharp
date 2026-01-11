using System;
using System.Drawing;
using System.Windows.Forms;
using ReaLTaiizor.Controls; // Thư viện UI xịn
using ReaLTaiizor.Forms;
using Panel = ReaLTaiizor.Controls.Panel;

namespace LearnWinforms;

public class LoginForm : Form
{
    private MaterialTextBoxEdit? txtUsername;
    private MaterialTextBoxEdit? txtPassword;
    private HopeButton? btnLogin;
    private Label? lblTitle;
    private Panel? pnlLeft;

    public LoginForm()
    {
        FormBorderStyle = FormBorderStyle.None;
        Size = new Size(750, 450);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.White;

        InitializeControls();
    }

    private void InitializeControls()
    {
        pnlLeft = new()
        {
            Dock = DockStyle.Left,
            Width = 300,
            BackColor = Color.FromArgb(31, 30, 68),
        };

        Label lblWelcome = new()
        {
            Text = "WELCOME\nBACK",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 24, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(50, 150)
        };

        pnlLeft.Controls.Add(lblWelcome);

        Controls.Add(pnlLeft);

        lblTitle = new()
        {
            Text = "USER LOGIN",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            ForeColor = Color.FromArgb(31, 30, 68),
            AutoSize = true,
            Location = new Point(350, 50),
        };
        Controls.Add(lblTitle);

        txtUsername = new()
        {
            Text = "Admin",
            // BaseColor = Color.FromArgb(242, 246, 252),
            ForeColor = Color.FromArgb(31, 30, 68),
            // BorderColorA = Color.FromArgb(31, 30, 68),
            // BorderColorB = Color.Silver,
            Font = new Font("Segoe UI", 12),
            Size = new Size(300, 40),
            Location = new Point(350, 130)
        };
        Controls.Add(txtUsername);

        Label lblUser = new()
        {
            Text = "Username",
            ForeColor = Color.Gray,
            Location = new Point(350, 105)
        };
        Controls.Add(lblUser);


        // 2.3 Ô nhập Password
        txtPassword = new()
        {
            // BaseColor = Color.FromArgb(242, 246, 252),
            // BorderColorA = Color.FromArgb(31, 30, 68),
            Location = new Point(350, 220),
            Size = new Size(300, 40),
        };
        Controls.Add(txtPassword);

        Label lblPass = new()
        {
            Text = "Password",
            ForeColor = Color.Gray,
            Location = new Point(350, 195)
        };
        Controls.Add(lblPass);


        btnLogin = new()
        {
            Text = "LOGIN",
            Size = new Size(120, 45),
            Location = new Point(350, 300),
            PrimaryColor = Color.FromArgb(31, 30, 68),
            HoverTextColor = Color.FromArgb(50, 49, 100),
            TextColor = Color.White,
        };

        btnLogin.Click += BtnLogin_Click;

        Controls.Add(btnLogin);


        Label btnExit = new Label();
        btnExit.Text = "X";
        btnExit.Font = new Font("Arial", 15, FontStyle.Bold);
        btnExit.ForeColor = Color.Gray;
        btnExit.Location = new Point(710, 10);
        btnExit.Cursor = Cursors.Hand;
        btnExit.Click += (s, e) => Application.Exit();
        Controls.Add(btnExit);
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        // Logic đăng nhập giả lập
        if (txtUsername?.Text == "Admin") // Password bỏ qua cho nhanh
        {
            MessageBox.Show("Đăng nhập thành công!");

            // Mở Form Dashboard (Form1 cũ của bạn)
            Form1 dashboard = new Form1();
            dashboard.Show();

            // Ẩn Form Login đi
            Hide();
        }
        else
        {
            MessageBox.Show("Sai tài khoản rồi đại ca!");
        }
    }
}
