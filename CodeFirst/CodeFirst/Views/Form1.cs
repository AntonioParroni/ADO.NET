using CodeFirst.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst
{
    public partial class Form1 : Form
    {
        public UserDatabaseAacademy dBContext = null;
        public Form2 f2 = null;
        public Form3 f3 = null;
        public Form1()
        {
            InitializeComponent();
            dBContext = new UserDatabaseAacademy();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f2 = new Form2();
            f2.f1 = this;
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // User loggedUsr = dBContext.Users.FirstOrDefault(x => x.Login == textBox1.Text && Password.VerifyHashedPassword( x.Password, textBox2.Text) == true);
            User loggedUsr = dBContext.Users.FirstOrDefault(x => x.Login == textBox1.Text);
            if (loggedUsr != null)
            {

                if (Password.VerifyHashedPassword(loggedUsr.Password, textBox2.Text))
                {
                    MessageBox.Show("Login Successfull!");
                    f3 = new Form3(loggedUsr);
                    f3.f1 = this;
                    this.Hide();
                    f3.Show();
                }
                else
                MessageBox.Show("Incorrect Password!");
            }
            else
            MessageBox.Show("No Such User");
        }
    }
}
