using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
	public partial class Form1 : Form
	{
		Point[] p;
		Point apple;
		int len;
		int direction;	//1-left; 2-right; 3-top; 4-down
		public Form1()
		{
			InitializeComponent();
			len = 5;
			p = new Point[200];
			direction = 3;
			for (int i = 0; i < 5; i++)
			{
				p[i].X = 50;
				p[i].Y = 50 + i*10;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			for(int i=198;i>=0;i--)
            {
				p[i+1].X = p[i].X;
				p[i+1].Y = p[i].Y;
            }
			if(direction == 1)
            {
				p[0].X = p[1].X - 10;
				p[0].Y = p[1].Y;
            }
			if (direction == 2)
			{
				p[0].X = p[1].X + 10;
				p[0].Y = p[1].Y;
			}
			if (direction == 3)
			{
				p[0].X = p[1].X;
				p[0].Y = p[1].Y - 10;
			}
			if (direction == 4)
			{
				p[0].X = p[1].X;
				p[0].Y = p[1].Y + 10;
			}
			SolidBrush b = new SolidBrush(Color.Brown);
			for(int i=0;i<len;i++)
            {
				e.Graphics.FillEllipse(b,p[i].X, p[i].Y,10,10);
            }
			SolidBrush b1 = new SolidBrush(Color.Green);
			e.Graphics.FillEllipse(b1,apple.X, apple.Y, 10,10);
			if(p[0].X==apple.X & p[0].Y==apple.Y)
            {
				len++;
				Random R;
				R = new Random();
				apple.X = R.Next(0,20)*10;
				apple.Y = R.Next(0,20)*10;
				timer1.Interval--;
            }

		}

        private void timer1_Tick(object sender, EventArgs e)
        {
			panel1.Invalidate();	//перерисовка формы
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Left)
				direction = 1;
			if (e.KeyCode == Keys.Right)
				direction = 2;
			if (e.KeyCode == Keys.Up)
				direction = 3;
			if (e.KeyCode == Keys.Down)
				direction = 4;
		}
    }
}
