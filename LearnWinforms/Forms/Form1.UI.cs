using FontAwesome.Sharp;
using ReaLTaiizor.Controls;
using Panel = ReaLTaiizor.Controls.Panel;

namespace LearnWinforms.Forms;

public partial class Form1
{

    public void SidePanel()
    {
        Panel panelMenu = new()
        {
            Name = "panelMenu",
            Dock = DockStyle.Left,
            Width = 220,
            BackColor = Color.FromArgb(31, 30, 68),
        };

        Panel panelLogo = new()
        {
            Name = "panelLogo",
            Dock = DockStyle.Top,
            Height = 140,
            BackColor = Color.FromArgb(30, 30, 90)
        };

        var menuItems = new (string Name, IconChar Icon)[]
        {
            ("Dashboard", IconChar.ChartPie),
            ("Orders",    IconChar.ShoppingCart),
            ("Products",  IconChar.Tags),
            ("Customers", IconChar.UserFriends),
            ("Marketing", IconChar.Bullhorn),
            ("Settings",  IconChar.Cogs)
        };

        foreach (var item in menuItems.Reverse())
        {
            IconButton btn = new()
            {
                Name = "btn" + item.Name,
                Text = item.Name,
                IconChar = item.Icon,

                Dock = DockStyle.Top,
                Height = 60,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                IconColor = Color.Gainsboro,
                IconSize = 32,
                ForeColor = Color.Gainsboro,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Padding = new Padding(10, 0, 20, 0)
            };

            btn.Click += MenuButton_Click;

            panelMenu.Controls.Add(btn);
        }

        Controls.Add(panelMenu);
        panelMenu.Controls.Add(panelLogo);
        AddSaveButton(panelMenu);
    }


    public void DesktopPanel()
    {
        var panelDesktop = new LostBorderPanel()
        {
            Name = "panelDesktop",
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke,
            Font = new Font("Segoe UI", 12),
            ShowText = true,
            Text = "Khu vực làm việc chính",
            ForeColor = Color.Black,
        };

        Controls.Add(panelDesktop);
        panelDesktop.SendToBack();
    }

    public static void AddSaveButton(Panel parentPanel)
    {
        HopeButton btnSave = new()
        {
            Text = "LƯU DỮ LIỆU",
            Size = new Size(120, 40),
            Location = new Point(50, 50),

            PrimaryColor = Color.FromArgb(64, 158, 255),
            HoverTextColor = Color.FromArgb(102, 177, 255),

        };

        btnSave.Click += (s, e) => MessageBox.Show("Đã lưu!");

        parentPanel.Controls.Add(btnSave);
    }
}
