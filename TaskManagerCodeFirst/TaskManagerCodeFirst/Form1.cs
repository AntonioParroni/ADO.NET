using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagerCodeFirst
{
    public partial class Form1 : Form
    {
        TaskManagerDB dB = null;
        Task selectedTask = null;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Hide();
            dataGridView1.MultiSelect = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dB = new TaskManagerDB();
            dB.Tasks.Load();
            
            MessageBox.Show("Connected!");
            dB.Tasks.Load();
            dataGridView1.DataSource = dB.Tasks.Local.ToBindingList();
            dataGridView1.Show();
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AllowUserToAddRows = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                Task updateTask = new Task();
                updateTask.Header = textBox1.Text;
                updateTask.Description = textBox2.Text;
                updateTask.Deadline = textBox3.Text;
                updateTask.Author = textBox4.Text;
                updateTask.Priority = textBox5.Text;

                Task toEdit = (Task)dataGridView1.CurrentRow.DataBoundItem;
                updateTask.Id = toEdit.Id;

                dB.Entry(toEdit).CurrentValues.SetValues(updateTask);
                dB.SaveChanges();
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Please Select a Record");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                Task newTask = new Task();
                newTask.Header = textBox1.Text;
                newTask.Description = textBox2.Text;
                newTask.Deadline = textBox3.Text;
                newTask.Author = textBox4.Text;
                newTask.Priority = textBox5.Text;

                dB.Tasks.Add(newTask);

                dB.SaveChanges();
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Please Enter Data!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dB.Tasks.Remove(selectedTask);
            selectedTask = null;
            dB.SaveChanges();
            dataGridView1.Refresh();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Task updateTask = dB.Tasks.FirstOrDefault(x => x.Id == e.RowIndex + 1);
            // Task updateTask = (Task)dataGridView1.CurrentRow.DataBoundItem;
            // Task updateTask = dB.Tasks.FirstOrDefault(x => x.Id == dataGridView1.SelectedRows) ;
            selectedTask = (Task)dataGridView1.CurrentRow.DataBoundItem;

            textBox1.Text = selectedTask.Header;
            textBox2.Text = selectedTask.Description;
            textBox3.Text = selectedTask.Deadline;
            textBox4.Text = selectedTask.Author;
            textBox5.Text = selectedTask.Priority;
        }
    }
}
