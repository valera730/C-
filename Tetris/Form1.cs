using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Controllers;

namespace Tetris
{
    public partial class Form1 : Form
    {
        string playerName;

        public Form1()
        {
            InitializeComponent();
            try
            {
                if (!File.Exists(RecordsController.recordPath))
                    File.Create(RecordsController.recordPath);
            } catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            playerName = Microsoft.VisualBasic.Interaction.InputBox("Enter player name","Enter your name","New game");
            if(playerName == "")
            {
                playerName = "New player";
            }
            this.KeyDown += new KeyEventHandler(keyFunc);
            Init();
        }

        public void Init()
        {
            RecordsController.ShowRecords(labelRecord);
            this.Text = "Tetris: Current player - " + playerName;
            MapController.size = 25;
            MapController.score = 0;
            MapController.linesRemoved = 0;
            MapController.currentShape = new Shape(3, 0);
            MapController.Interval = 1000;
            label1.Text = "Score: " + MapController.score;
            label2.Text = "Lines: " + MapController.linesRemoved;
            label3.Text = "Speed: 0";

            timer1.Interval = MapController.Interval;
            timer1.Tick += new EventHandler(update);
            timer1.Start();            

            Invalidate();
        }

        private void keyFunc(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (!MapController.IsIntersects())
                    {
                        MapController.ResetArea();
                        MapController.currentShape.RotateShape();
                        MapController.Merge();
                        Invalidate();
                    }
                    break;
                case Keys.Space:
                    timer1.Interval = 10;
                    break;
                case Keys.Right:
                    if (!MapController.CollideHor(1))
                    {
                        MapController.ResetArea();
                        MapController.currentShape.MoveRight();
                        MapController.Merge();
                        Invalidate();
                    }
                    break;
                case Keys.Left:
                    if (!MapController.CollideHor(-1))
                    {
                        MapController.ResetArea();
                        MapController.currentShape.MoveLeft();
                        MapController.Merge();
                        Invalidate();
                    }
                    break;

                case Keys.P:
                       if (timer1.Enabled)
                       {
                           //pressedButton.Text = "Continue";
                           timer1.Stop();
                        }
                        else
                        {
                            //pressedButton.Text = "Pause";
                            timer1.Start();
                        }
                    break;
                    case Keys.F2:
                        timer1.Tick -= new EventHandler(update);
                        timer1.Stop();
                        MapController.ClearMap();
                        Init();
                    break;

                case Keys.Escape:
                case Keys.F10:
                    this.Close();
                    break;
            }
        }
                
        private void update(object sender, EventArgs e)
        {
            MapController.ResetArea();
            if (!MapController.Collide())
            {
                MapController.currentShape.MoveDown();
            }
            else
            {
                MapController.Merge();
                MapController.SliceMap(label1, label2, label3);
                timer1.Interval = MapController.Interval;
                MapController.currentShape.ResetShape(3,0);
                if (MapController.Collide())
                {
                    RecordsController.SaveRecords(playerName);
                    MapController.ClearMap();
                    timer1.Tick -= new EventHandler(update);
                    timer1.Stop();
                    MessageBox.Show("Your score: " + MapController.score);
                    Init();
                }
            }
            MapController.Merge();
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            MapController.DrawGrid(e.Graphics);
            MapController.DrawMap(e.Graphics);
            MapController.ShowNextShape(e.Graphics);
        }

        private void OnPauseButtonClick(object sender, EventArgs e)
        {
            var pressedButton = sender as ToolStripMenuItem;
            if (timer1.Enabled)
            {
                pressedButton.Text = "Continue";
                timer1.Stop();
                labelPause.Visible = true;
                MapController.ShowPause();
            }
            else
            {
                pressedButton.Text = "Pause";
                timer1.Start();
                labelPause.Visible = false;
            }
        }

        private void OnAgainButtonClick(object sender, EventArgs e)
        {
            timer1.Tick -= new EventHandler(update);
            timer1.Stop();
            MapController.ClearMap();
            Init();
        }
        private void OnInfoPressed(object sender, EventArgs e)
        {
            string infoString = "";
            infoString = "Left/right keys arrow to control shapes.\n";
            infoString += "Spacebar to drop the shape .\n";
            infoString += "Key up to rotate the shape.\n";
            MessageBox.Show(infoString,"Help");
        }
        private void OnExitPressed()
        {
            this.Close();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void OnExitPressed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}