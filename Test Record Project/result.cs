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
    public partial class result : Form
    {
        public result()
        {
            InitializeComponent();
        }

   

       
        public void result_Load(object sender, EventArgs e)
        {

            DatabaseConnection.getconnection();
        //  DatabaseConnection.insertResult(Lstname.Text,Remail.Text,Rtoalm.Text,)
            ResultData re = DatabaseConnection.showresult();

            Lstname.Text = re.name;
            Remail.Text = re.email;
            Rtoalm.Text = re.totalmarks;
            Robtainm.Text = re.obtainmarks;
            Rperce.Text = re.percentage;
            Rtalq.Text = re.totalquestions;
            Rcorrect.Text = re.correctq;
            Rincorrect.Text = re.incorrectq;
            Rdate.Text = re.date;


        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            new testLogin().Close();
            this.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            new testLogin().Show();
            this.Close();


        }

    }
}
