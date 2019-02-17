using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;

namespace Test_Record_Project
{
    public partial class QuestionsAns : Form
    {
        public QuestionsAns()
        {
            InitializeComponent();
        }

        static int n = 1;
        static ArrayList v;
        static string qOpANS = "";
        bool b = true;
        static int totalm=0;
        static int totalq=0;
        static int correctq=0;


        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseConnection.getconnection();
           
            //check options 
            radioButtoncheck();
            //
            b = true;
            RecordQuestion r = DatabaseConnection.getquestions();
               DatabaseConnection.n++;
            labelID.Text = ""+ r.questionId;
                labelName.Text = r.questions;
                labelOa.Text =  r.qOpa;
                labelOb.Text =  r.qOpb;
               LabelOc.Text =  r.qOpc;
               qOpANS = r.qOpANS;

               label5.Text = DatabaseConnection.stnameG;
           
            if(DatabaseConnection.testcomplete)
            {

                panel1.Visible = true;
                button1.Enabled = false;

                totalm = totalq * 10;
                int per = (Int32.Parse(obmarks.Text) * 100) / totalm;
                int incq = totalq - correctq;
                DateTime d = DateTime.Now;
                string date = d.ToString();
                
               DatabaseConnection.insertResult(DatabaseConnection.stnameG,DatabaseConnection.emailadressG,(totalm).ToString(),obmarks.Text,(per).ToString(),(totalq).ToString(),(correctq).ToString(),(incq).ToString(),date);

            }
            
        }

        private void radioButtoncheck()
        {
            if (radioButton1.Checked)
            {
                if (labelOa.Text == qOpANS)
                {
                    correctq++;
                    obmarks.Text = (Int32.Parse(obmarks.Text) + 10) + "";
                }
            }

            if (radioButton2.Checked)
            {
                if (labelOb.Text == qOpANS)
                {
                    correctq++;
                    obmarks.Text = (Int32.Parse(obmarks.Text) + 10) + "";
                }
            }
            if (radioButton3.Checked)
            {
                if (LabelOc.Text == qOpANS)
                {
                    correctq++;
                    obmarks.Text = (Int32.Parse(obmarks.Text) + 10) + "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            totalq++;
            Form1_Load(null,null);
           // obmarks.Text = (Int32.Parse(obmarks.Text) + 1) + "";
          
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new result().Show();
        }

       
       

        
    }
         
}
