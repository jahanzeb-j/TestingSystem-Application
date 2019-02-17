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
    public partial class RegistrationF : Form
    {
        public RegistrationF()
        {
            InitializeComponent();
            //DatabaseConnection.getconnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check non empty
            if (name.Text == "" || email.Text == "" || pass.Text == "" || pass.Text != repass.Text)
            {
                if (pass.Text != repass.Text)
                {
                    label6.Text = "*";
                }
                else
                MessageBox.Show("plz Fill all Information");

            }
            else
            {

                DatabaseConnection.getconnection();
                string gander = "";
                if (radioButton1.Checked)
                    gander = "Male";
                if (radioButton2.Checked)
                    gander = "Female";

                string returnReg = DatabaseConnection.registereddata(name.Text, email.Text, gander, pass.Text);
                if (returnReg == "already")
                {
                    MessageBox.Show("Email ID must be unique , it already exist ..");

                }
                else if (returnReg == "inserted")
                {
                    MessageBox.Show("You are successfully Registered  ..");
                    this.Close();
                   // new testLogin().Show();

                }

            }
        }
    }
}
