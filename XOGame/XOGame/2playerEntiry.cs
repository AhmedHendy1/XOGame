using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOGame
{
    public partial class _2playerEntiry : Form
    {
        public _2playerEntiry()
        {
            InitializeComponent();
        }
        
        private void btn_X_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (Name1.Text.Length > 7 || Name1.Text.Length > 7)
            {
                Name1.Text = Name1.Text.Substring(0, 7);
                Name2.Text = Name2.Text.Substring(0, 7);
            };
            _2Player Game = new _2Player(Name1.Text,Name2.Text);
            Game.Show();
            this.Hide();
        }
    }
}
