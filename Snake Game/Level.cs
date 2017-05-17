using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_game
{
    public class Level
    {
        private Rectangle[] walls;

        private Rectangle[] wallUp;
        private Rectangle[] wallDown;
        private Rectangle[] wallLeft;
        private Rectangle[] wallRight;
        
        private Image wallsImage;
        // 0- left; 1- up; 2- right; 3- down
        private Pen fieldPen;
        private int x, y, width;

        public Level()
        {
            x = 10; // x coordinate of the start
            y = 10; // x coordinate of the point of start
            width = 400; // 10 x 10
            
            walls = new Rectangle[4];
            wallUp = new Rectangle[20];
            wallDown = new Rectangle[20];
            wallLeft = new Rectangle[12];
            wallRight = new Rectangle[12];
            

            wallsImage = Image.FromFile("Images\\wall.gif");
            fieldPen = new Pen(System.Drawing.Color.Black, 5);

            walls[0] = new Rectangle(10, 10, 5, width + 15); // left
            walls[1] = new Rectangle(10, 10, 320 + width + 15, 5); // up
            walls[2] = new Rectangle(780, 10, 5, width + 15); // right
            walls[3] = new Rectangle(10, 450, 320 + width + 15, 5); // down


            
            for (int i = 0; i < wallUp.Length; i++)
            {
                wallUp[i] = new Rectangle(x, y, 40, 40);
                wallDown[i] = new Rectangle(x, 450, 40, 40);
                x += 40;
            }
            x = 10;
            for (int i = 0; i < wallLeft.Length; i++)
            {
                wallLeft[i] = new Rectangle(x , y, 40, 40);
                wallRight[i] = new Rectangle(x + 760, y, 40, 40);
                
                y += 40;
            }


        }

        public Rectangle[] getWallLeft()
        {
            return wallLeft;
        }

        public Rectangle[] getWallRight()
        {
            return wallRight;
        }


        public Rectangle[] getWallDown()
        {
            return wallDown;
        }

        public Rectangle[] getWallUp()
        {
            return wallUp;
        }

        public Rectangle[] getWalls()
        {
            return walls;
        }

        public Image getWallsImage()
        {
            return wallsImage;
        }

        public Pen getPen()
        {
            return fieldPen;
        }


    }
}
