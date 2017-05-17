using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_game
{

    public class Stone
    {
        public int x, y, width, height;
        public Rectangle stoneRec;
        public SolidBrush brush; // ----------
        public Image stoneImage;

        private int stoneMax = 3;

        public Stone(Random randStone)
        {
            x = (int)((randStone.Next(1, 19) + 0.25) * 40);
            y = (int)((randStone.Next(1, 11) + 0.25) * 40);

            brush = new SolidBrush(Color.Green);
            stoneImage = Image.FromFile("Images\\stone.bmp");
            
            width = 40;
            height = 40;

            stoneRec = new Rectangle(x, y, width, height);
        }

        public void stoneLocation(Random randStone)
        {

            x = (int)((randStone.Next(1, 19) + 0.25) * 40);
            y = (int)((randStone.Next(1, 11) + 0.25) * 40);
        }

        public void drawStone(Graphics paper)
        {
            stoneRec.X = x;
            stoneRec.Y = y;

            paper.DrawImage(stoneImage, stoneRec);
        }

        public int StoneMax()
        {
            return stoneMax;
        }

    }
}
