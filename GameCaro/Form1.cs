namespace GameCaro;

public partial class Form1 : Form
{
    const int CHESS_WIDTH = 30;
    const int CHESS_HEIGHT = 30;
    const int BOARD_WIDTH = 20;
    const int BOARD_HEIGHT = 15;

    private Panel pnlChessBoard = new();
    private List<List<Button>> matrix = [];
    private int currentPlayer = 0;

    public Form1()
    {
        InitializeComponent();

        Text = "Game Caro - C# WinForms CLI";
        Size = new Size(800, 600);
        StartPosition = FormStartPosition.CenterScreen;

        CreateChessBoardPanel();
        DrawChessBoard();
    }

    void CreateChessBoardPanel()
    {
        pnlChessBoard = new Panel
        {
            Location = new Point(10, 10),
            Size = new Size(BOARD_WIDTH * CHESS_WIDTH, BOARD_HEIGHT * CHESS_HEIGHT)
        };
        Controls.Add(pnlChessBoard);
    }

    void DrawChessBoard()
    {
        matrix = [];
        Button oldButton = new() { Width = 0, Location = new Point(0, 0) };

        for (int i = 0; i < BOARD_HEIGHT; ++i)
        {
            matrix.Add([]);

            for (int j = 0; j < BOARD_WIDTH; ++j)
            {
                Button btn = new()
                {
                    Width = CHESS_WIDTH,
                    Height = CHESS_HEIGHT,
                    Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                    Tag = new Point(j, i),
                    BackColor = Color.White
                };

                btn.Click += Btn_Click;

                pnlChessBoard.Controls.Add(btn);
                matrix[i].Add(btn);

                oldButton = btn;
            }

            oldButton.Location = new Point(0, oldButton.Location.Y + CHESS_HEIGHT);
            oldButton.Width = 0;
            oldButton.Height = 0;
        }
    }

    void Btn_Click(object? sender, EventArgs e)
    {
        if (sender is not Button btn) return;

        if (!string.IsNullOrEmpty(btn.Text)) return;

        if (currentPlayer == 0)
        {
            btn.Text = "X";
            btn.ForeColor = Color.Red;
        }
        else
        {
            btn.Text = "O";
            btn.ForeColor = Color.Blue;
        }

        if (IsEndGame(btn))
        {
            string winner = (currentPlayer == 0) ? "Người chơi X" : "Người chơi O";
            MessageBox.Show($"{winner} đã chiến thắng!", "Kết thúc game");

            return;
        }

        currentPlayer = (currentPlayer == 0) ? 1 : 0;
    }

    private bool IsEndGame(Button btn)
    {
        if (btn.Tag is not Point point) return false;

        return IsEndHorizontal(point) ||
           IsEndVertical(point) ||
           IsEndPrimaryDiagonal(point) ||
           IsEndSubDiagonal(point);
    }

    private bool IsEndHorizontal(Point point)
    {
        int count = 1;
        int x = point.X;
        int y = point.Y;

        // Duyệt sang Trái
        for (int i = x - 1; i >= 0; i--)
        {
            if (matrix[y][i].Text == matrix[y][x].Text)
                count++;
            else
                break;
        }

        // Duyệt sang Phải
        for (int i = x + 1; i < BOARD_WIDTH; i++)
        {
            if (matrix[y][i].Text == matrix[y][x].Text)
                count++;
            else
                break;
        }

        return count >= 5;
    }

    private bool IsEndVertical(Point point)
    {
        int count = 1;
        int x = point.X;
        int y = point.Y;

        // Duyệt lên Trên
        for (int i = y - 1; i >= 0; i--)
        {
            if (matrix[i][x].Text == matrix[y][x].Text)
                count++;
            else
                break;
        }

        // Duyệt xuống Dưới
        for (int i = y + 1; i < BOARD_HEIGHT; i++)
        {
            if (matrix[i][x].Text == matrix[y][x].Text)
                count++;
            else
                break;
        }

        return count >= 5;
    }

    // 3. Kiểm tra chéo CHÍNH (Huyền: \ ) -> Tăng X thì Tăng Y
    private bool IsEndPrimaryDiagonal(Point point)
    {
        int count = 1;
        int x = point.X;
        int y = point.Y;

        // Duyệt lên góc Trên-Trái (X giảm, Y giảm)
        for (int i = 1; x - i >= 0 && y - i >= 0; i++)
        {
            if (matrix[y - i][x - i].Text == matrix[y][x].Text)
                count++;
            else
                break;
        }

        // Duyệt xuống góc Dưới-Phải (X tăng, Y tăng)
        for (int i = 1; x + i < BOARD_WIDTH && y + i < BOARD_HEIGHT; i++)
        {
            if (matrix[y + i][x + i].Text == matrix[y][x].Text)
                count++;
            else
                break;
        }

        return count >= 5;
    }

    // 4. Kiểm tra chéo PHỤ (Sắc: / ) -> Tăng X thì Giảm Y
    private bool IsEndSubDiagonal(Point point)
    {
        int count = 1;
        int x = point.X;
        int y = point.Y;

        // Duyệt lên góc Trên-Phải (X tăng, Y giảm)
        for (int i = 1; x + i < BOARD_WIDTH && y - i >= 0; i++)
        {
            if (matrix[y - i][x + i].Text == matrix[y][x].Text)
                count++;
            else
                break;
        }

        // Duyệt xuống góc Dưới-Trái (X giảm, Y tăng)
        for (int i = 1; x - i >= 0 && y + i < BOARD_HEIGHT; i++)
        {
            if (matrix[y + i][x - i].Text == matrix[y][x].Text)
                count++;
            else
                break;
        }

        return count >= 5;
    }
}
