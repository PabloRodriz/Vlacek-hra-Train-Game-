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

        int[] orientation; // 0 = left, 1 = up, 2 = right, 3 = down


        private Rectangle[] trainRec;
        public Image[] imageArray;


        private SolidBrush brush;
        private int x, y, width, height;
        private Level level;

        public Rectangle[] TrainRec
        {
            get { return trainRec; }
        }


        // The snake is made of Squares of 40x40 pixels (Rectangle class)

        public Train() // -- TRAIN --
        {
            int vagons = 1;

            trainRec = new Rectangle[vagons];
            imageArray = new Image[vagons];
            orientation = new int[vagons];
            brush = new SolidBrush(Color.Blue);
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


        

        // Painting each rectangle inside the snake
        // Painting the field also
        // !!! possile implementation of different eaten items here !!!
        public void drawSnake(Graphics paper)
        {
            for (int i = 0; i < level.getWallUp().Length; i++)
            {
                paper.DrawImage(level.getWallsImage(), level.getWallUp()[i]);
                paper.DrawImage(level.getWallsImage(), level.getWallDown()[i]);
            }

            for (int i = 0; i < level.getWallLeft().Length; i++)
            {
                paper.DrawImage(level.getWallsImage(), level.getWallLeft()[i]);
                paper.DrawImage(level.getWallsImage(), level.getWallRight()[i]);
            }

            for (int i = 0; i < trainRec.Length; i++)
            {
                paper.DrawImage(imageArray[i], trainRec[i]);
               
            }
            
           

        }

        public void drawSnake()
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
            drawSnake();
            trainRec[0].Y += 40;
            orientation[0] = 3;
            imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_down.gif");
            
            if (trainRec[0].IntersectsWith(level.getWalls()[3]) || hitItSelf(trainRec, trainRec[0]))
            {                
                imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                imageArray[1] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                crash = true;         

            }

            return crash;
        }
        public bool moveUp()
        {
            bool crash = false;
            drawSnake();
            trainRec[0].Y -= 40;
            orientation[0] = 1;
            imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_up.gif");
            if (trainRec[0].IntersectsWith(level.getWalls()[1]) || hitItSelf(trainRec, trainRec[0]))
            {
                crash = true;
                imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                imageArray[1] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                //MessageBox.Show("Collision", "Error", MessageBoxButtons.OKCancel);

            }
            return crash;
        }
        public bool moveRight()
        {
            bool crash = false;
            drawSnake();
            trainRec[0].X += 40;
            orientation[0] = 2;
            imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_right.gif");
            if (trainRec[0].IntersectsWith(level.getWalls()[2]) || hitItSelf(trainRec, trainRec[0]))
            {
                //MessageBox.Show("Collision", "Error", MessageBoxButtons.OKCancel);
                imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                imageArray[1] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                crash = true;
            }
            return crash;

        }
        public bool moveLeft()
        {
            bool crash = false;
            drawSnake();
            trainRec[0].X -= 40;
            orientation[0] = 0;
            imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_left.gif");
            if (trainRec[0].IntersectsWith(level.getWalls()[0]) || hitItSelf(trainRec, trainRec[0]))
            {
                //MessageBox.Show("Collision", "Error", MessageBoxButtons.OKCancel);
                imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                imageArray[1] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\crash.bmp");
                crash = true;

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
        }

    }
}
