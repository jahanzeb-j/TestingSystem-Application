using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Collections;

namespace Test_Record_Project
{
    class DatabaseConnection
    {
        public static OleDbConnection con;
        public static int n=1;
        public static string emailadressG = "";
        public static string stnameG = "";
        public static bool testcomplete = false;
        
        public static void getconnection()
        {
            string driver = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=QuestionAns.mdb";
            con = new OleDbConnection(driver);
        }
        public static RecordQuestion getquestions()
        {
            
            string query = "select * from question where questionid="+n;
            con.Open();

            OleDbCommand com = new OleDbCommand(query, DatabaseConnection.con);
            OleDbDataReader read = com.ExecuteReader();
                RecordQuestion rec = new RecordQuestion();
                testcomplete = true;
                if (read.Read())
                {
                    rec.questionId = read.GetInt32(0);
                    rec.questions = read.GetString(1);
                    rec.qOpa = read.GetString(2);
                    rec.qOpb = read.GetString(3);
                    rec.qOpc = read.GetString(4);
                    rec.qOpANS = read.GetString(5);
                    testcomplete = false;
                }
                con.Close();

           
            
            return rec;
            
           
        }


        public static Boolean getLogin(string email, string pass)
        {
            con.Open();

                string query = "select * from registration where stemail='" + email + "' and stpassword='" + pass + "'";
                OleDbCommand com = new OleDbCommand(query, DatabaseConnection.con);
                OleDbDataReader read = com.ExecuteReader();

                if (read.Read())
                {
                    stnameG = read.GetString(1);
                    emailadressG = read.GetString(3);


                    return true;
                }
                con.Close();
                return false;
            
          
        }
        public static Boolean getResultcheck(string email)
        {
            con.Open();
            string Rquery = "select * from result where stemail='" + email + "'";
            OleDbCommand Rcom = new OleDbCommand(Rquery, DatabaseConnection.con);
            OleDbDataReader Rread = Rcom.ExecuteReader();
            if (Rread.Read())
            {
                emailadressG = Rread.GetString(1);
                return true;
            }
            con.Close();
            return false;

        }

        public static string registereddata(string stname,string email,string gender,string passwrod)
        {
            con.Open();

            string query = "select * from registration where stemail='" + email + "'";
            OleDbCommand com = new OleDbCommand(query, DatabaseConnection.con);
            OleDbDataReader read = com.ExecuteReader();

            if (read.Read())
            {
                con.Close();
                return "already";
            }
            else
            {
                string query1 = "insert into registration(stname,stgander,stemail,stpassword) values('" + stname + "','" + gender + "','" + email + "','" + passwrod + "')";
                OleDbCommand com1 = new OleDbCommand(query1, DatabaseConnection.con);
                int n = com1.ExecuteNonQuery();
                if (n > 0)
                {
                    con.Close();
                    return "inserted";
                }
                else
                {
                    con.Close();
                    return "error";
                }
            }
           
            //return "ok";
        }


        public static void insertResult(string stname,string stemail,string tmarks,string omarks,string perc,string tquest,string correcq,string incorre,string date)
        {
            con.Open();
            string queryr = "insert into result(stemail,stname,totalmarks,obtain,percentage,totalquestion,correctquestion,incorrectquestion,date_of_test) values('" + stemail + "','" + stname + "','" + tmarks + "','" + omarks + "','" + perc + "','" + tquest + "','" + correcq + "','" + incorre + "','"+date+"')";
            OleDbCommand comr = new OleDbCommand(queryr, DatabaseConnection.con);
            int n = comr.ExecuteNonQuery();

        }
        public static ResultData showresult()
        {
            

            string query = "select * from result where stemail='"+emailadressG+"'";
            con.Open();

            OleDbCommand com = new OleDbCommand(query, DatabaseConnection.con);
            OleDbDataReader read = com.ExecuteReader();
            ResultData r = new ResultData();
            //testcomplete = true;
            if (read.Read())
            {
                //r.questionId = read.GetInt32(0);
                r.email = read.GetString(1);
                r.name = read.GetString(2);
                r.totalmarks = read.GetString(3);
                r.obtainmarks = read.GetString(4);
                r.percentage = read.GetString(5);
                r.totalquestions = read.GetString(6);
                r.correctq = read.GetString(7);
                r.incorrectq = read.GetString(8);
                r.date = read.GetString(9);

                //testcomplete = false;
            }
            con.Close();

            return r;
        }
    } 
}
