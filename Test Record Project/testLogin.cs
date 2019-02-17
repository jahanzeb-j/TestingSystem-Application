using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Record_Project
{
    public partial class testLogin : Form
    {
        public testLogin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
             this.Close();
            //this.Scale(66);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new RegistrationF().Show();
            //this.Hide();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
        }

       

        private void login_Click(object sender, EventArgs e)
        {
            DatabaseConnection.getconnection();
            
            if(DatabaseConnection.getResultcheck(textBoxEmail.Text))
            {
                result a = new result();
                a.result_Load(null, null);
                a.Show();
                this.Hide();
            }
            else if (DatabaseConnection.getLogin(textBoxEmail.Text,textBoxPass.Text))
            {
                new QuestionsAns().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You are not registered yet or incorrect email or password .. ");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("hi" + MessageBoxIcon.
            //DialogResult d =KeyDown;
            MessageBox.Show("This project is created by Jahanzeb Adil \n Student of BE Computer System MUET", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           
        }
    }
}
