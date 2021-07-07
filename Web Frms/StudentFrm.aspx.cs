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
    public partial class StudentFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            tID.Focus();
        }

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (tID.Text == string.Empty || tFName.Text == string.Empty || tMName.Text == string.Empty 
                || tLName.Text == string.Empty || tContact.Text == string.Empty || tAddress.Text == string.Empty || tEmail.Text == string.Empty) 
            {
                lError.Text = "Please fill all details";
                tID.Focus();
                return;
            }

            if (ckDup() == true) 
            {
                lError.Text = "Student ID is already Exist";
                tID.Focus();
                return;
            }

            Save();
        }

        private bool ckDup()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " Select * from tblStudent " +
                         " where StudentID='" + tID.Text.Trim() + "' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Dup");
                con.Close();
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
                lError.Text = "Error...DupID..." + ex.Message;
                con.Close();
            }
            finally
            {
                con.Close();

            }
            return false;
        }

        private void Save() 
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " INSERT INTO tblStudent(StudentID, FName, MName, LName, ContactNo, Address, Email) " +
                              " VALUES('" + tID.Text.Trim() + "','" + tFName.Text.Trim() + "','" + tMName.Text.Trim() +
                              "','" + tLName.Text.Trim() + "','" + tContact.Text.Trim() + "','" + tAddress.Text.Trim() +
                              "','" + tEmail.Text.Trim() + "') ";

            try 
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                tID.Text = string.Empty;
                tID.Focus();
                tFName.Text = string.Empty;
                tMName.Text = string.Empty;
                tLName.Text = string.Empty;
                tContact.Text = string.Empty;
                tAddress.Text = string.Empty;
                tEmail.Text = string.Empty;                
                lError.Text = "Data Save Successfully";
            }
            catch (Exception ex) 
            {
                lError.Text = "Error...Save..." + ex.Message;
                con.Close();
            }
            finally 
            {
                con.Close();
            }

        }
    }
}