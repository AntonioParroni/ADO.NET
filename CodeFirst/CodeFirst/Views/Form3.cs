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
    public partial class Form3 : Form
    {
        public Form1 f1 = null;
        public User loggedUser;
        public Form3(User loggedUsr)
        {
            InitializeComponent();
            loggedUser = loggedUsr;
            FirstNameLabel.Text = loggedUser.FirstName;
            LastNameLabel.Text = loggedUser.LastName;
            EmailLabel.Text = loggedUser.Email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.Show();
        }
    }
}
