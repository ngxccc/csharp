using LearnWinforms.Forms;

namespace LearnWinforms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        LoginForm login = new();

        if (login.ShowDialog() == DialogResult.OK)
        {
            Application.Run(new Form1());
        }
        else
        {
            Application.Exit();
        }

    }
}
