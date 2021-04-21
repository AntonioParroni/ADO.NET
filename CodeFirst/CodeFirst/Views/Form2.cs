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
    public partial class Form2 : Form
    {
        public Form1 f1 = null;
        public Form2()
        {
            InitializeComponent();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            newUser.Login = LoginBox.Text;

            string hasedPassword = Password.HashPassword(PasswordBox.Text);
            newUser.Password = hasedPassword;

            hasedPassword = "";

            newUser.FirstName = FirstNameBox.Text;
            newUser.LastName = LastNameBox.Text;
            newUser.Email = EmailBox.Text;

            f1.dBContext.Users.Add(newUser);

            UserBase userDb = new UserBase();
            userDb.User = newUser;
            f1.dBContext.MyDatabase.Add(userDb);

            f1.dBContext.SaveChanges();

            MessageBox.Show("Registration Successful!");
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.Show();
        }
    }
}
