using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Island
{
    public partial class Form1 : Form
    {
        Game game = null;
        Random rnd;

        public Form1()
        {
            InitializeComponent();

            Random rnd = new Random();
            game = new Game(rnd);
        }

        private void btnLiveWeek_Click(object sender, EventArgs e)
        {
                game.NextWeek();
        }
    }
}
