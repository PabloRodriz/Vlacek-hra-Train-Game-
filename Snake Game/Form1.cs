﻿using System;
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
        public static Train train;
        Stone stone;

        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;

        public static bool hp = true;

        public Form1()
        {
            init();
            InitializeComponent();
        }

        public void init()
        {
            
            stone = new Stone(randStone);
            train = new Train();
        }

        // event PaintEventHandler
        private void startDrawing(object sender, PaintEventArgs e)
        {
            
            paper = e.Graphics;
            if(train.stoneCounter == train.StoneMax)
            {
                if(train.win == true)
                {
                    train.drawWin(paper);
                    timer1.Stop();
                }
            }else
            {
                
                stone.drawStone(paper);
            }

            train.drawResult(paper);
            train.drawTrain(paper);
            
            
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
           
            if (e.KeyData == Keys.F2)
            {
                init();
                timer1.Start();
                Program.gv = true;
                this.Close();
            }
            if (e.KeyData == Keys.Escape)
            {
                Program.gv = false;
                this.Close();
                timer1.Stop();

            }
           

        }

        public void timer1_Tick(object sender, EventArgs e)
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
