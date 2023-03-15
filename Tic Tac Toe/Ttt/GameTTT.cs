using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ttt
{
    public partial class GameTTT : Form
    {
        Graphics G;
        Pen BoardPen;
        Color BoardColor = Color.Black;
        int[][] arr;
        bool turn = true;
        bool win = false;
        public GameTTT()
        {
            InitializeComponent();
            BoardPen = new Pen(BoardColor,5);
            arr = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                arr[i] = new int[3];
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Start();

        }

        protected void Start()
        {
            G = this.CreateGraphics();
            for (int i = 0; i < 3; i++) {
                for (int j = 1; j < 3; j++) {

                    Point P = new Point(this.Width - j*(this.Width / 3), 0);
                    Point p = new Point(this.Width - j*(this.Width / 3), this.Height);
                    G.DrawLine(BoardPen,P,p);
                    P = new Point(0, this.Height - j*(this.Height / 3));
                    p = new Point(this.Width, this.Height - j*(this.Height/3));
                    G.DrawLine(BoardPen, P, p);

                }
            }
        }

        protected void DrawX(int x, int y)
        {
            if (arr[x][y] == 0)
            {
                G = this.CreateGraphics();
                BoardColor = Color.Red;
                BoardPen = new Pen(BoardColor, 10);
                arr[x][y] = 1;
                x = 2 * x + 1;
                y = 2 * y + 1;
                Point P1 = new Point(this.Width * x / 6 - 120, this.Height * y / 6 - 120);
                Point P2 = new Point(this.Width * x / 6 + 120, this.Height * y / 6 + 120);
                G.DrawLine(BoardPen, P1, P2);
                P1 = new Point(this.Width * x / 6 + 120, this.Height * y / 6 - 120);
                P2 = new Point(this.Width * x / 6 - 120, this.Height * y / 6 + 120);
                G.DrawLine(BoardPen, P1, P2);
                turn = false;
            }
        }
        protected void DrawO(int x, int y)
        {
            if (arr[x][y] == 0)
            {
                G = this.CreateGraphics();
                BoardColor = Color.Blue;
                BoardPen = new Pen(BoardColor, 10);
                arr[x][y] = 2;
                x = 3 * x + 1;
                y = 6 * y + 1;
                G.DrawEllipse(BoardPen, this.Width * x / 9 - 15, this.Height * y / 18, 240, 240);
                turn = true;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            int x= 0;
            int y= 0;

                for (int i = 0; i < 3; i++)
                {

                    if ((i+1) * (this.Width / 3) > e.X && i * (this.Width / 3) < e.X)
                    {
                        x = i;
                        break;
                    }
                }

                for (int i = 0; i < 3; i++)
                {

                    if ((i+1) * (this.Height / 3) > e.Y && i * (this.Height / 3) < e.Y)
                    {
                        y = i;
                        break;  
                    }
                }

                if (turn == true)
                {
                    DrawX(x, y);
                }
                else
                {
                    DrawO(x, y);
                }

            CheckForWin();

            if (win == true) { 
                win = false;
                Invalidate();
                Restart(); 
            }
            
            
        }

        protected void CheckForWin() {

            bool check = false;
            for (int i = 0; i < 3; i++) {

                if (arr[i][0] == arr[i][1] && arr[i][1] == arr[i][2] && arr[i][0] != 0) 
                {
                    MessageBox.Show("You Won! ");
                    check = true;
                    break;
                }


                if (arr[0][i] == arr[1][i] && arr[1][i] == arr[2][i] && arr[0][i] != 0)
                {
                    MessageBox.Show("You Won! ");
                    check = true;
                    break;
                }

            }

            if (arr[0][0] == arr[1][1] && arr[1][1] == arr[2][2] && arr[0][0] != 0) 
            {
                MessageBox.Show("You Won! ");
                check = true;
            }
            if (arr[2][0] == arr[1][1] && arr[1][1] == arr[0][2] && arr[2][0] != 0)
            {
                MessageBox.Show("You Won! ");
                check = true;
            }

            
            if (arr[0].Contains(0) != true && arr[1].Contains(0) != true && arr[2].Contains(0) != true )
            {
                MessageBox.Show("Draw ");
                Invalidate();
                Restart();
            }
          

        }

        protected void Restart() {

            Color BoardColor = Color.Black;
            BoardPen = new Pen(BoardColor, 5);
            arr = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                arr[i] = new int[3];
            }
        }
    }
}
