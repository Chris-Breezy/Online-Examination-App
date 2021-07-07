using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineExamSys.Web_Frms
{
    public partial class GradeFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            tID.Focus();
        }

        private void SaveNew() 
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " INSERT INTO tblGrade(GradeID,Grade) " + 
                              " VALUES('"+ tID.Text.Trim() +"','"+ tGrade.Text.Trim() +"') ";

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lGrade.Text = "Data Successfully Save";
                tID.Text = string.Empty;
                tGrade.Text = string.Empty;
                tID.Focus();
            }
            catch (Exception ex)
            {
                Response.Write("Error...Save..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        private bool ckDupID() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select * from tblGrade " + " where GradeID='" + tID.Text.Trim() + "' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Dups");
                con.Close();
                //Do something Krazy here...
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error...Ck..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return false;
        }

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (tID.Text == string.Empty || tGrade.Text == string.Empty) 
            {
                lGrade.Text = "Please fill all details";
                tID.Focus();
                return;
            }

            if (ckDupID() == true) 
            {
                lGrade.Text = "ID is Already Exist";
                tID.Focus();
                return;
            }

            SaveNew();
        }
    }
}