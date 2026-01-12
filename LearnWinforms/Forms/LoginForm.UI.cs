using ReaLTaiizor.Controls;
using Panel = ReaLTaiizor.Controls.Panel;

namespace LearnWinforms.Forms;

public partial class LoginForm
{
    private MaterialTextBoxEdit? txtUsername;
    private MaterialTextBoxEdit? txtPassword;
    private HopeButton? btnLogin;
    private Label? lblTitle;
    private Panel? pnlLeft;

    private void InitializeControls()
    {
        // --- PANEL TRÁI ---
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

        // --- TITLE ---
        lblTitle = new()
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
            Font = new Font("Segoe UI", 12),
            Location = new Point(350, 130),
            Size = new Size(300, 40),
            ForeColor = Color.FromArgb(242, 246, 252),
        };
        Label lblUser = new()
        {
            Text = "Username",
            ForeColor = Color.Gray,
            Location = new Point(350, 105)
        };
        Controls.Add(txtUsername);
        Controls.Add(lblUser);

        // --- PASSWORD ---
        txtPassword = new()
        {
            Font = new Font("Segoe UI", 12),
            Location = new Point(350, 220),
            Size = new Size(300, 40),
            ForeColor = Color.FromArgb(242, 246, 252),
            PasswordChar = '●'
        };
        Label lblPass = new()
        {
            Text = "Password",
            ForeColor = Color.Gray,
            Location = new Point(350, 195)
        };
        Controls.Add(txtPassword);
        Controls.Add(lblPass);

        // --- BUTTON LOGIN ---
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

        // --- BUTTON EXIT ---
        Label btnExit = new()
        {
            Text = "X",
            Font = new Font("Arial", 15, FontStyle.Bold),
            ForeColor = Color.Gray,
            Location = new Point(710, 10),
            Cursor = Cursors.Hand
        };
        btnExit.Click += (s, e) => Application.Exit();
        Controls.Add(btnExit);
    }
}
