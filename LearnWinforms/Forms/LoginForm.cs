namespace LearnWinforms.Forms;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        FormBorderStyle = FormBorderStyle.None;
        Size = new Size(750, 450);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.White;

        InitializeControls();
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        if (txtUsername?.Text == "Admin")
        {
            MessageBox.Show("Đăng nhập thành công!");

            DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            MessageBox.Show("Sai tài khoản rồi đại ca!");
        }
    }
}
