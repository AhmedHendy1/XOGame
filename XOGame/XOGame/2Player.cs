using Guna.UI2.WinForms;
using System.Data;

namespace XOGame
{
    public partial class _2Player : Form
    {

        bool checker = false;
        int increment;
        public bool VSComputer = false;
        Random rand = new Random();
        async void ComputerMove()
        {
            await Task.Delay(500);
            var emptyButtons = this.Controls.OfType<Guna2GradientButton>().Where(btn => btn.Enabled==true).ToList();
            if (emptyButtons.Count > 0)
            {
                var button = emptyButtons[rand.Next(emptyButtons.Count)];

                Button(button);
            }
        }
        void Button(Guna2GradientButton b1)
        {
            if (b1.Enabled==true)
            {
                if (checker == false)
                {
                    checker = true;
                    b1.Enabled = false;
                    b1.Text = "X";
                    b1.DisabledState.ForeColor = Color.Blue;
                }
                else
                {
                    checker = false;
                    b1.Enabled = false;
                    b1.Text = "O";
                    b1.DisabledState.ForeColor=Color.Red;
                }
                score();

            }
        }
        void Disable()
        {
            btn_1.Enabled = false;
            btn_2.Enabled = false;
            btn_3.Enabled = false;
            btn_4.Enabled = false;
            btn_5.Enabled = false;
            btn_6.Enabled = false;
            btn_7.Enabled = false;
            btn_8.Enabled = false;
            btn_9.Enabled = false;
            
        }
        public bool CheckAndHighlight(Guna2GradientButton btn1, Guna2GradientButton btn2, Guna2GradientButton btn3)
        {

            if (btn1.Text != "" && btn1.Text == btn2.Text && btn2.Text == btn3.Text)
            {
                btn1.DisabledState.ForeColor = Color.Green;
                btn2.DisabledState.ForeColor = Color.Green;
                btn3.DisabledState.ForeColor = Color.Green;

                if (player1.ForeColor == Color.Blue)
                {
                    if (btn1.Text == "X")
                    {
                        increment = int.Parse(player1.Text) + 1;
                        player1.Text = Convert.ToString(increment);
                        if (VSComputer)
                            MessageBox.Show($"You won ❤️");
                        else
                            MessageBox.Show($"{lb_Player1.Text} is won ❤️");
                        Disable();
                        return true;
                    }
                    else if (btn1.Text == "O")
                    {
                        increment = int.Parse(player1.Text) + 1;
                        player2.Text = Convert.ToString(increment);
                        if (VSComputer)
                            MessageBox.Show($"Computer won ❤️");
                        else
                            MessageBox.Show($"{lb_Player2.Text} is won ❤️");
                        Disable();
                        return true;
                    }
                }
                else
                {
                    if (btn1.Text == "X")
                    {
                        increment = int.Parse(player2.Text) + 1;
                        player2.Text = Convert.ToString(increment);
                        if (VSComputer)
                            MessageBox.Show($"Computer won ❤️");
                        else
                            MessageBox.Show($"{lb_Player2.Text} is won");
                        Disable();
                        return true;
                    }
                    else if (btn1.Text == "O")
                    {
                        increment = int.Parse(player1.Text) + 1;
                        player1.Text = Convert.ToString(increment);
                        if (VSComputer)
                            MessageBox.Show($"You won ❤️");
                        else
                            MessageBox.Show($"{lb_Player1.Text} is won");
                        Disable();
                        return true;
                    }
                }
            }
            return false;
        }

        public void score()
        {
            // Horizontal win conditions
            if ((CheckAndHighlight(btn_1, btn_2, btn_3))) ;
            else if (CheckAndHighlight(btn_4, btn_5, btn_6)) ;
            else if (CheckAndHighlight(btn_7, btn_8, btn_9)) ;

            // Vertical win conditions
            else if (CheckAndHighlight(btn_1, btn_4, btn_7)) ;
            else if (CheckAndHighlight(btn_2, btn_5, btn_8)) ;
            else if (CheckAndHighlight(btn_3, btn_6, btn_9)) ;

            // Diagonal win conditions
            else if (CheckAndHighlight(btn_1, btn_5, btn_9)) ;
            else if (CheckAndHighlight(btn_3, btn_5, btn_7)) ;

            //Draw
            else if (btn_1.Text != "" && btn_2.Text != "" && btn_3.Text != ""
                && btn_4.Text != "" && btn_5.Text != "" && btn_6.Text != ""
                && btn_7.Text != "" && btn_8.Text != "" && btn_9.Text != "")
                MessageBox.Show("Draw");
        }
        string name1;
        string name2;
        public _2Player(string name1, string name2)
        {
            InitializeComponent();
            this.name1 = name1;
            this.name2 = name2;
            lb_Player1.Text = name1;
            lb_Player2.Text = name2;
        }

        private void Btn_NewGame_Click(object sender, EventArgs e)
        {
            this.btn_Reset_Click(sender, e);
            player1.Text = "0";
            player2.Text = "0";
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            if (checker == false)
            {
                player1.ForeColor = Color.Blue;
                player2.ForeColor = Color.Red;
            }
            else
            {
                player2.ForeColor = Color.Blue;
                player1.ForeColor = Color.Red;
            }

            btn_1.ForeColor = Color.White;
            btn_2.ForeColor = Color.White;
            btn_3.ForeColor = Color.White;
            btn_4.ForeColor = Color.White;
            btn_5.ForeColor = Color.White;
            btn_6.ForeColor = Color.White;
            btn_7.ForeColor = Color.White;
            btn_8.ForeColor = Color.White;
            btn_9.ForeColor = Color.White;
            btn_1.Enabled=true;
            btn_2.Enabled=true;
            btn_3.Enabled=true;
            btn_4.Enabled=true;
            btn_5.Enabled=true;
            btn_6.Enabled=true;
            btn_7.Enabled=true;
            btn_8.Enabled=true;
            btn_9.Enabled=true;
            btn_1.Text = "";
            btn_2.Text = "";
            btn_3.Text = "";
            btn_4.Text = "";
            btn_5.Text = "";
            btn_6.Text = "";
            btn_7.Text = "";
            btn_8.Text = "";
            btn_9.Text = "";  
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            Button(btn_9);
            if (VSComputer && !this.Controls.OfType<Guna2GradientButton>().All(btn => btn.Text != ""))
            {
                ComputerMove();
            }

        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            Button(btn_8);
            if (VSComputer && !this.Controls.OfType<Guna2GradientButton>().All(btn => btn.Text != ""))
            {
                ComputerMove();
            }

        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            Button(btn_7);
            if (VSComputer && !this.Controls.OfType<Guna2GradientButton>().All(btn => btn.Text != ""))
            {
                ComputerMove();
            }

        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            Button(btn_6);
            if (VSComputer && !this.Controls.OfType<Guna2GradientButton>().All(btn => btn.Text != ""))
            {
                ComputerMove();
            }

        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            Button(btn_5);
            if (VSComputer && !this.Controls.OfType<Guna2GradientButton>().All(btn => btn.Text != ""))
            {
                ComputerMove();
            }

        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            Button(btn_4);
            if (VSComputer && !this.Controls.OfType<Guna2GradientButton>().All(btn => btn.Text != ""))
            {
                ComputerMove();
            }

        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            Button(btn_3);
            if (VSComputer && !this.Controls.OfType<Guna2GradientButton>().All(btn => btn.Text != ""))
            {
                ComputerMove();
            }

        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            Button(btn_2);
            if (VSComputer && !this.Controls.OfType<Guna2GradientButton>().All(btn => btn.Text != ""))
            {
                ComputerMove();
            }

        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            Button(btn_1);
            if (VSComputer && !this.Controls.OfType<Guna2GradientButton>().All(btn => btn.Text != ""))
            {
                ComputerMove();
            }

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (!VSComputer)
            {
                this.Close();
                _2playerEntiry entiry = new _2playerEntiry();
                entiry.Show();
            }
            else
            {
                this.Close();
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        
    }
}

