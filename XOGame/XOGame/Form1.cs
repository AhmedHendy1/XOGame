namespace XOGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_2Player_Click(object sender, EventArgs e)
        {
            _2playerEntiry Game1 = new _2playerEntiry();
            Game1.Show();
            this.Hide();
        }

        private void btn_1Player_Click(object sender, EventArgs e)
        {
            _2Player game =new _2Player("Your Score","Computer");
            game.VSComputer=true;
            game.Show();
            this.Hide();
        }
    }
}
