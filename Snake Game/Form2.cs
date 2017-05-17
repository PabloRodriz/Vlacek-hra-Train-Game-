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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void saveStones_Click(object sender, EventArgs e)
        {
            Program.maxStones = Convert.ToInt32(Math.Round(stoneNumber.Value, 0));
            Program.playerName = playerName.Text;
            this.Close();
        }
    }
}
