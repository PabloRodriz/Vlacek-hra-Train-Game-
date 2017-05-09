using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Train_game
{
    public partial class Form1 : Form
    {
        Random randStone = new Random();
        Graphics paper;
        Train train = new Train();
        Stone stone;

        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;

        public Form1()
        {
            InitializeComponent();
            stone = new Stone(randStone);
        }

        // event PaintEventHandler
        private void startDrawing(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            stone.drawStone(paper);
            train.drawSnake(paper);
            
            
        }

        private void game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Down)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Up)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Right)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }
            if (e.KeyData == Keys.Left)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }
            if (e.KeyData == Keys.P)
            {
                
                timer1.Stop();
            }
            if (e.KeyData == Keys.R)
            {

                timer1.Start();
            }
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
                timer1.Stop();
            }
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (down)
            {
                if (train.moveDown())
                {
                    timer1.Stop();                                        
                }
            }
            if (up)
            {
                if (train.moveUp())
                {
                    timer1.Stop();
                }
            }
            if (right)
            {
                if (train.moveRight())
                {
                    timer1.Stop();
                }
            }
            if (left)
            {
                if (train.moveLeft())
                {
                    timer1.Stop();
                }
            }


            if (train.TrainRec[0].IntersectsWith(stone.stoneRec))
            {
                train.growTrain();
                stone.stoneLocation(randStone);
            }


            this.Invalidate();
        }
        
        
    }
}
