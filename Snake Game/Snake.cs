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
        public Rectangle[] snakeRec;
        
        private SolidBrush brush;
        private int x, y, width, height;
        private Level level;

        // The snake is made of Squares of 10x10 pixels (Rectangle class)

        public Snake()
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Blue);
            level = new Level();

            x = 19; //wall.X(10) + wall.width(5) + 3 + clearance(1)
            y = 19; //wall.Y(10) + wall.height(5) + 3 + clearance(1) 
            width = 10;
            height = 10;


            /* Here we create and initialize each Square(Rectangle) starting from the first one drawn
             * which is in the position 20, and x is decreased by 10, in order to adjust the positioning ,
             * cause each square is width = 10
             */
            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }

        // Painting each rectangle inside the snake
        // Painting the field also
        // !!! possile implementation of different eaten items here !!!
        public void drawSnake(Graphics paper)
        {
            foreach (Rectangle rec in snakeRec)
            {
                paper.FillRectangle(brush, rec);
            }
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
            }
        }

        public void moveDown()
        {
            drawSnake();
            snakeRec[0].Y += 10;
            if (snakeRec[0].IntersectsWith(level.getWalls()[3]))
            {
                MessageBox.Show("Collision", "Error", MessageBoxButtons.OKCancel);
                
            }
        }
        public void moveUp()
        {
            drawSnake();
            snakeRec[0].Y -= 10;
        }
        public void moveRight()
        {
            drawSnake();
            snakeRec[0].X += 10;
        }
        public void moveLeft()
        {
            drawSnake();
            snakeRec[0].X -= 10;
            if (snakeRec[0].IntersectsWith(level.getWalls()[0]))
            {
                MessageBox.Show("Collision", "Error", MessageBoxButtons.OKCancel);

            }
        }
    }
}
