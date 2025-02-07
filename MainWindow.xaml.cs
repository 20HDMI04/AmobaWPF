using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmobaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int XTEAM = 0;
        public int OTEAM = 0;
        public int[,] table = new int[3, 3];
        public enum WhoseTurn { X, O };
        public WhoseTurn turn = WhoseTurn.X;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        public void StartGame()
        {
            XScore.Text = "X csapat: " + XTEAM.ToString();
            OScore.Text = "O csapat: " + OTEAM.ToString();
            table = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    table[i, j] = 0;
                }
            }
            InitTable();
        }
        public void InitTable() {
            PlayBoard.Children.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button obj = new Button()
                    {
                        Tag = "btn" + i + j,
                        Content = "X/O",
                        Width = 100,
                        Height = 100,
                        FontSize = 30,
                        Margin = new Thickness(5),
                        ClickMode = ClickMode.Press,
                    };
                    obj.Click += OnButtonPressed;
                    PlayBoard.Children.Add(obj);
                }
            }
        }

        public void OnButtonPressed(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            
            if (turn == WhoseTurn.X)
            {
                btn.Content = "X";
                btn.IsEnabled = false;
                table[Convert.ToInt32(btn.Tag.ToString()[3].ToString()), Convert.ToInt32(btn.Tag.ToString()[4].ToString())] = 1;
                CurrentTeam.Text = "O";
                turn = WhoseTurn.O;
            }
            else
            {
                btn.Content = "O";
                btn.IsEnabled = false;
                table[Convert.ToInt32(btn.Tag.ToString()[3].ToString()), Convert.ToInt32(btn.Tag.ToString()[4].ToString())] = -1;
                CurrentTeam.Text = "X";
                turn = WhoseTurn.X;
            }
            CheckWinner();
        }

        public void CheckWinner()
        {
            WhoseTurn winner = turn==WhoseTurn.X?WhoseTurn.O:WhoseTurn.X;
            if (table[0, 0] == table[0, 1] && table[0, 0] == table[0, 2] && table[0, 0] != 0) {
                //first row
                MessageBox.Show("Winner is: " + winner);
                if (winner == WhoseTurn.X)
                {
                    XTEAM+=1;
                }
                else
                {
                    OTEAM += 1;
                }
                StartGame();
            }
            else if (table[1, 0] == table[1, 1] && table[1, 0] == table[1, 2] && table[1, 0] != 0) {
                // second row
                MessageBox.Show("Winner is: " + winner);
                if (winner == WhoseTurn.X)
                {
                    XTEAM += 1;
                }
                else
                {
                    OTEAM += 1;
                }
                StartGame();
            }
            else if (table[2, 0] == table[2, 1] && table[2, 0] == table[2, 2] && table[2, 0] != 0) {
                // third row
                MessageBox.Show("Winner is: " + winner);
                if (winner == WhoseTurn.X)
                {
                    XTEAM += 1;
                }
                else
                {
                    OTEAM += 1;
                }
                StartGame();
            }
            else if (table[0, 0] == table[0, 1] && table[0, 0] == table[0, 2] && table[0, 0] != 0) {
                // first column
                MessageBox.Show("Winner is: " + winner);
                if (winner == WhoseTurn.X)
                {
                    XTEAM += 1;
                }
                else
                {
                    OTEAM += 1;
                }
                StartGame();
            }
            else if (table[0, 1] == table[1, 1] && table[0, 1] == table[2, 1] && table[0, 1] != 0) {
                // second column
                MessageBox.Show("Winner is: " + winner);
                if (winner == WhoseTurn.X)
                {
                    XTEAM += 1;
                }
                else
                {
                    OTEAM += 1;
                }
                StartGame();
            }
            else if (table[0, 2] == table[1, 2] && table[0, 2] == table[2, 2] && table[0, 2] != 0) {
                // third column
                MessageBox.Show("Winner is: " + winner);
                if (winner == WhoseTurn.X)
                {
                    XTEAM += 1;
                }
                else
                {
                    OTEAM += 1;
                }
                StartGame();
            }
            else if (table[0, 0] == table[1, 1] && table[0, 0] == table[2, 2] && table[0, 0] != 0) {
                // first diagonal
                MessageBox.Show("Winner is: " + winner);
                if (winner == WhoseTurn.X)
                {
                    XTEAM += 1;
                }
                else
                {
                    OTEAM += 1;
                }
                StartGame();
            }
            else if (table[0, 2] == table[1, 1] && table[0, 2] == table[2, 0] && table[0, 2] != 0)
            {
                // second diagonal
                MessageBox.Show("Winner is: " + winner);
                if (winner == WhoseTurn.X)
                {
                    XTEAM += 1;
                }
                else
                {
                    OTEAM += 1;
                }
                StartGame();
            }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (table[i, j] == 0)
                        { return; }
                    }
                }
                MessageBox.Show("Draw");
                StartGame();
        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
            XTEAM = 0;
            OTEAM = 0;
            XScore.Text = "X csapat: " + XTEAM.ToString();
            OScore.Text = "O csapat: " + OTEAM.ToString();
        }
    }
}
