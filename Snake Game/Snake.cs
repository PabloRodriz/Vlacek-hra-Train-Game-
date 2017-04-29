using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    public class Snake
    {

        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;

        public Rectangle[] snakeRec;
        public Image[] imageArray;


        private SolidBrush brush;
        private int x, y, width, height;
        private Level level;

        // The snake is made of Squares of 10x10 pixels (Rectangle class)

        public Snake() // -- TRAIN --
        {
            
            snakeRec = new Rectangle[6];
            imageArray = new Image[6];
            brush = new SolidBrush(Color.Blue);
            level = new Level();

            x = 19; //wall.X(10) + wall.width(5) + 3 + clearance(1)
            y = 19; //wall.Y(10) + wall.height(5) + 3 + clearance(1) 
            width = 40;
            height = 40;


            /* Here we create and initialize each Square(Rectangle) starting from the first one drawn
             * which is in the position X, and x is decreased by 10, in order to adjust the positioning ,
             * cause each square is width = 10
             */
            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                imageArray[i] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_right.gif");
                x -= 40;
            }
        }

        

        // Painting each rectangle inside the snake
        // Painting the field also
        // !!! possile implementation of different eaten items here !!!
        public void drawSnake(Graphics paper)
        {
            
            for (int i = 0; i < snakeRec.Length; i++)
            {
                paper.DrawImage(imageArray[i], snakeRec[i]);
            }
            
            
            // loop
            paper.DrawRectangle(level.getPen(), level.getWalls()[0]);
            paper.DrawRectangle(level.getPen(), level.getWalls()[1]);
            paper.DrawRectangle(level.getPen(), level.getWalls()[2]);
            paper.DrawRectangle(level.getPen(), level.getWalls()[3]);

        }

        public void drawSnake()
        {
            /* Starting from the tail of the snake,
             * every position, but the first,
             * is exchanged with the next one, creating movement
             * The first position is changed in the moveUp/Down/Left/Right method.
             */
            for (int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
                imageArray[i] = imageArray[i - 1];
            }
        }

        public void moveDown()
        {
            drawSnake();
            snakeRec[0].Y += 40;
            imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_down.gif");
            if (snakeRec[0].IntersectsWith(level.getWalls()[3]) || hitItSelf(snakeRec, snakeRec[0]))
            {
                MessageBox.Show("Collision", "Error", MessageBoxButtons.OKCancel);
                
            }
        }
        public void moveUp()
        {
            drawSnake();
            snakeRec[0].Y -= 40;
            imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_up.gif");
            if (snakeRec[0].IntersectsWith(level.getWalls()[1]) || hitItSelf(snakeRec, snakeRec[0]))
            {
                MessageBox.Show("Collision", "Error", MessageBoxButtons.OKCancel);

            }
        }
        public void moveRight()
        {
            drawSnake();
            snakeRec[0].X += 40;
            imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_right.gif");
            if (snakeRec[0].IntersectsWith(level.getWalls()[2]) || hitItSelf(snakeRec, snakeRec[0]))
            {
                MessageBox.Show("Collision", "Error", MessageBoxButtons.OKCancel);

            }

        }
        public void moveLeft()
        {
            drawSnake();
            snakeRec[0].X -= 40;
            imageArray[0] = Image.FromFile(@"D:\ERASMUS\ZAZPE\Snake Game\Snake Game\Images\train_left.gif");
            if (snakeRec[0].IntersectsWith(level.getWalls()[0]) || hitItSelf(snakeRec, snakeRec[0]))
            {
                MessageBox.Show("Collision", "Error", MessageBoxButtons.OKCancel);
                

            }
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
    }
}
