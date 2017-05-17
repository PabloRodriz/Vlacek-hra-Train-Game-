using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Train_game
{
     class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static bool gv = true;
        public static int maxStones;
        public static string playerName;
        

        [STAThread]       
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());

            do
            {
            
                Application.Run(new Form1());
               



            } while (gv);
            
            
        }

        
    }
}
