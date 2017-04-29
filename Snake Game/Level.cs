using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public class Level
    {
        private Rectangle[] walls;
        // 0- left; 1- up; 2- right; 3- down
        private Pen fieldPen;
        private int x, y, width;

        public Level()
        {
            x = 10; // x coordinate of the start
            y = 10; // x coordinate of the point of start
            width = 400; // 10 x 10
            
            walls = new Rectangle[4];
            fieldPen = new Pen(System.Drawing.Color.Black, 5);
            walls[0] = new Rectangle(10, 10, 5, width + 15); // left
            walls[1] = new Rectangle(10, 10, 320 + width + 15, 5); // up
            walls[2] = new Rectangle(width + 22 + 320, 10, 5, width + 15); // right
            walls[3] = new Rectangle(10, width + 22, 320 + width + 15, 5); // down
            
        }

        
        public Rectangle[] getWalls()
        {
            return walls;
        }

        public Pen getPen()
        {
            return fieldPen;
        }


    }
}
