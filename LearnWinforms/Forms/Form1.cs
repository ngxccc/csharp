using FontAwesome.Sharp;

namespace LearnWinforms.Forms;

public partial class Form1 : Form
{
    private IconButton? currentBtn;

    public Form1()
    {
        InitializeComponent();

        Text = "Dashboard Application";
        ClientSize = new Size(1000, 600);
        MinimumSize = new Size(800, 500);
        StartPosition = FormStartPosition.CenterScreen;

        SidePanel();
        DesktopPanel();
    }

    private void MenuButton_Click(object? sender, EventArgs e)
    {
        if (sender is not IconButton btn) return;

        if (currentBtn != null)
        {
            currentBtn.BackColor = Color.FromArgb(31, 30, 68);
            currentBtn.IconColor = Color.Gainsboro;
            currentBtn.ForeColor = Color.Gainsboro;
        }

        currentBtn = btn;
        currentBtn.BackColor = Color.FromArgb(37, 36, 81);
        currentBtn.IconColor = Color.Red;
        currentBtn.ForeColor = Color.White;

        switch (btn.Name)
        {
            case "btnDashboard":
                // Mở form Dashboard
                MessageBox.Show("Mở Dashboard");
                break;
            case "btnOrders":
                // Mở form Orders
                MessageBox.Show("Mở Orders");
                break;
            case "btnSettings":
                // Mở form Settings
                break;
            default:
                break;
        }
    }

}
