using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Train_game
{
    public class Train
    {

        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;

        public bool win = false;

        int[] orientation; // 0 = left, 1 = up, 2 = right, 3 = down


        private Rectangle[] trainRec;
        public Image[] imageArray;


        private SolidBrush brush;
        private SolidBrush brushWinner;
        private Font resultFont = new Font("Arial", 12);
        private Font winnerFont = new Font("Arial", 25);
        private int x, y, width, height;
        private Level level;

        private int stoneMax = Program.maxStones;
        public int stoneCounter;

        public Image door = Image.FromFile("Images\\door.bmp");
        public Image doorOpen = Image.FromFile("Images\\opendoor.bmp");

        public Rectangle[] TrainRec
        {
            get { return trainRec; }
        }

        public int StoneMax
        {
            get { return stoneMax; }
            set { stoneMax = value; }

        }


        // The snake is made of Squares of 40x40 pixels (Rectangle class)

        public Train() // -- TRAIN --
        {
            int vagons = 1;

            trainRec = new Rectangle[vagons];
            imageArray = new Image[vagons];
            orientation = new int[vagons];
            brush = new SolidBrush(Color.Blue);
            brushWinner = new SolidBrush(Color.Red);
            level = new Level();

            x = 50; //wall.X(10) + wall.width(5) + 3 + clearance(1)
            y = 50; //wall.Y(10) + wall.height(5) + 3 + clearance(1) 
            width = 40;
            height = 40;


            /* Here we create and initialize each Square(Rectangle) starting from the first one drawn
             * which is in the position X, and x is decreased by 10, in order to adjust the positioning ,
             * cause each square is width = 10
             */
            trainRec[0] = new Rectangle(x, y, width, height);
            imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_right.gif");
            orientation[0] = 2; 
            x -= 40;
            for (int i = 1; i < trainRec.Length; i++)
            {
                trainRec[i] = new Rectangle(x, y, width, height);
                orientation[i] = 2;
                imageArray[i] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\vagonblue_right.bmp");
                x -= 40;
            }
        }


        
        public void drawWin(Graphics paper)
        {
            string[] lines = System.IO.File.ReadAllLines("winners.txt");
            string text;
            if (Int32.Parse(lines[1]) >= Program.maxStones) // Is >= so the first is remembered
                // winner still in database
            {
                text = "Winner!! But the best is " + lines[0] +  " score: " + lines[1];
            }else
            {
                text = "Winner!! You are the winner: " + Program.playerName + " score: " + Program.maxStones;
                string[] linesWrite = { Program.playerName, Program.maxStones.ToString() };
                
                System.IO.File.WriteAllLines("winners.txt", linesWrite);

            }

            paper.DrawString(text, winnerFont, brushWinner, 80, 200);

        }

        public void drawResult(Graphics paper)
        {
            string stones = "Stones left: " + (stoneMax - stoneCounter);
            paper.DrawString(stones, resultFont, brush, 10, 500);
            string keyF2 = "F2 restart";
            Brush green = new SolidBrush(Color.Green);
            paper.DrawString(keyF2, resultFont, green, 200, 500);

            string keyESC = "ESC finish";
            Brush orange = new SolidBrush(Color.OrangeRed);
            paper.DrawString(keyESC, resultFont, orange, 400, 500);

            string player = "Player: " + Program.playerName;
            Brush gold = new SolidBrush(Color.Gold);
            paper.DrawString(player, resultFont, gold, 700, 500);

        }


        // Painting each rectangle inside the snake
        // Painting the field also
        // !!! possile implementation of different eaten items here !!!
        public void drawTrain(Graphics paper)
        {
            for (int i = 0; i < level.getWallUp().Length; i++)
            {
                paper.DrawImage(level.getWallsImage(), level.getWallUp()[i]);
                paper.DrawImage(level.getWallsImage(), level.getWallDown()[i]);
            }

            for (int i = 0; i < level.getWallLeft().Length; i++)
            {
                paper.DrawImage(level.getWallsImage(), level.getWallLeft()[i]);
                if (i == 4)
                {
                    if (stoneCounter == stoneMax)
                    {
                        paper.DrawImage(doorOpen, level.getWallRight()[i]);
                    }else
                    {
                        paper.DrawImage(door, level.getWallRight()[i]);
                    }

                }else
                {
                    paper.DrawImage(level.getWallsImage(), level.getWallRight()[i]);
                }
               
            }
            

            for (int i = 0; i < trainRec.Length; i++)
            {
                if(trainRec.Length == 1)
                {
                    paper.DrawImage(imageArray[i], trainRec[i]);
                }
                else
                {
                    paper.DrawImage(imageArray[i], trainRec[i]);
                }
               
               
            }
            
           

        }

        public void drawTrain()
        {
            /* Starting from the tail of the snake,
             * every position, but the first,
             * is exchanged with the next one, creating movement
             * The first position is changed in the moveUp/Down/Left/Right method.
             */
            for (int i = trainRec.Length - 1; i > 0; i--)
            {
                trainRec[i] = trainRec[i - 1];
                orientation[i] = orientation[i - 1];
               
                    if(orientation[i] == 0)
                    {
                        imageArray[i] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\vagonblue_left.bmp");
                    }
                    else if (orientation[i] == 1)
                    {
                        imageArray[i] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\vagonblue_up.bmp");
                    }
                    else if (orientation[i] == 2)
                    {
                        imageArray[i] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\vagonblue_right.bmp");
                    }
                    else
                    {
                        imageArray[i] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\vagonblue_down.bmp");
                    }

                
                
            }
        }

        public bool moveDown()
        {
            bool crash = false;
            
            Rectangle helpRec = trainRec[0];
            helpRec.Y += 40;
            
           // ---- SOLUTION ---
            
            if (helpRec.IntersectsWith(level.getWalls()[3]) || hitItSelf(trainRec, helpRec))
            {                
                imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                //imageArray[1] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                crash = true;

            }else
            {
                drawTrain();
                trainRec[0].Y += 40;
                orientation[0] = 3;
                imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_down.gif");
            }

            return crash;
        }
        public bool moveUp()
        {
            bool crash = false;

            Rectangle helpRec = trainRec[0];
            helpRec.Y -= 40;


            
            if (helpRec.IntersectsWith(level.getWalls()[1]) || hitItSelf(trainRec, helpRec))
            {
                crash = true;
                imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                //imageArray[1] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                //MessageBox.Show("Collision", "Error", MessageBoxButtons.OKCancel);

            }else
            {
                drawTrain();
                trainRec[0].Y -= 40;
                orientation[0] = 1;
                imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_up.gif");
            }
            return crash;
        }
        public bool moveRight()
        {
            bool crash = false;

            Rectangle helpRec = trainRec[0];
            helpRec.X += 40;

            
            if (helpRec.IntersectsWith(level.getWalls()[2]) || hitItSelf(trainRec, helpRec))
            {
                if (helpRec.IntersectsWith(level.getWallRight()[4]) && stoneCounter == stoneMax)
                {
                    drawTrain();
                    trainRec[0].X += 40;
                    orientation[0] = 2;
                    imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_right.gif");
                    win = true;
                }else
                {
                    imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");

                    crash = true;
                }
               
            }else
            {
                
                drawTrain();
                trainRec[0].X += 40;
                orientation[0] = 2;
                imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_right.gif");
                
                
            }
            return crash;

        }
        public bool moveLeft()
        {
            bool crash = false;
            Rectangle helpRec = trainRec[0];
            helpRec.X -= 40;

           
            if (helpRec.IntersectsWith(level.getWalls()[0]) || hitItSelf(trainRec, helpRec))
            {
                
                imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");                
                crash = true;


            }else
            {
                drawTrain();
                trainRec[0].X -= 40;
                orientation[0] = 0;
                imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_left.gif");
            }
            return crash;
        }

        public bool hitItSelf(Rectangle[] body, Rectangle head)
        {
            bool hit = false;

            for (int i = 1; i < body.Length; i++)
            {
                if (head.IntersectsWith(body[i]))
                {
                    hit = true;
                    break;
                }
            }

            return hit;
        }


        public void growTrain()
        {
            List<Rectangle> rec = trainRec.ToList();
            rec.Add(new Rectangle(trainRec[trainRec.Length - 1].X, trainRec[trainRec.Length - 1].Y, width, height));
            trainRec = rec.ToArray();


            List<Image> imageList = imageArray.ToList();
            imageList.Add(imageArray[imageArray.Length - 1]);
            imageArray = imageList.ToArray();

            List<int> orientationList = orientation.ToList();
            orientationList.Add(orientation[orientation.Length - 1]);
            orientation = orientationList.ToArray();

            stoneCounter++;
        }

    }
}
