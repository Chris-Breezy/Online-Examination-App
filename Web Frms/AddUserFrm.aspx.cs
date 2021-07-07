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
    public partial class AddUserFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                GetStudID();
                DispStuds();
                tID.Focus();
            }
        }

        private void DispStudName() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select StudentID, LName + ', ' + FName + ' ' + MName as Student from tblStudent " + 
                         " where StudentID='"+ cbID.Text.Trim() +"' ";
 
            try 
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds,"Studs");
                con.Close();

                if (ds.Tables[0].Rows.Count > 0) 
                {
                    cbStuds.SelectedValue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }
            }
            catch (Exception ex) 
            {
                lError.Text = "Error...Studs..." + ex.Message;
                con.Close();
            }
            finally 
            {
                con.Close();
            }
        }

        private void DispStudID() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select StudentID, LName + ', ' + FName + ' ' + MName as Student from tblStudent " +
                         " where StudentID='" + cbStuds.SelectedValue.Trim() + "' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Studs");
                con.Close();
                cbID.SelectedValue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                lError.Text = "Error...sName..." + ex.Message;
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        private void GetStudID()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select StudentID from tblStudent ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "StudID");
                con.Close();
                //Do something Krazy here...
                cbID.DataSource = ds.Tables[0];
                cbID.DataValueField = "StudentID";
                cbID.DataTextField = "StudentID";
                cbID.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("Error...StudID..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        private void DispStuds()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select StudentID, LName + ', ' + FName + ' ' + MName as Student from tblStudent ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Student");
                con.Close();
                //Do something Krazy here...
                cbStuds.DataSource = ds.Tables[0];
                cbStuds.DataValueField = "StudentID";
                cbStuds.DataTextField = "Student";
                cbStuds.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error...Students..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        private void SaveNew() 
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " INSERT INTO tblUser(UserID,Username,Password,StudentID) " +
                              " VALUES('" + tID.Text.Trim() +"','" + tUser.Text.Trim() +
                              "','" + tPass.Text.Trim() +"','" + cbStuds.SelectedValue.Trim() +"') ";
            
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lError.Text = "Data Successfully Save";
                tID.Focus();
                tID.Text = string.Empty;
                cbStuds.SelectedIndex = 0;
                lStuds.Text = string.Empty;
                tUser.Text = string.Empty;
                tPass.Text = string.Empty;
                tConfirm.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lConfirm.Text = "Error...Save..." + ex.Message;
                con.Close();
            }
            finally 
            {
                con.Close();
            }
        }

        private bool CkDupID() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select * from tblUser " + " where UserID='"+ tID.Text.Trim() +"' ";

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

        private bool ckDupUser() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select * from tblUser " + " where Username='" + tUser.Text.Trim() + "' and Password='"+ tPass.Text.Trim() +"' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Users");
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
                Response.Write("Error...DupUsers..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return false;
        }

        private bool CkDupStud() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select * from tblUser " + " where StudentID='"+ cbStuds.SelectedValue.Trim() +"' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Studs");
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
                Response.Write("Error...DupStuds..." + ex.Message);
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
            if (tID.Text == string.Empty || cbStuds.SelectedIndex == -1 || tUser.Text == string.Empty ||
                tPass.Text == string.Empty || tConfirm.Text == string.Empty)
            {
                tID.Focus();
                lError.Text = "Please fill all details";
                return;
            }

            if (tPass.Text != tConfirm.Text)
            {
                lConfirm.Text = "! Password and Confirm Password must be match";
                tPass.Focus();
                return;
            }

            if (CkDupID() == true) 
            {
                lError.Text = "User already Exist";
                tUser.Focus();
                return;
            }

            if (ckDupUser() == true) 
            {
                lError.Text = "Username and Password already Exist";
                tUser.Focus();
                return;
            }

            if (CkDupStud() == true) 
            {
                lError.Text = "Student has Already have Account";
                cbStuds.Focus();
                return;
            }

            SaveNew();

        }

        protected void tID_TextChange(object sender, EventArgs e)
        {
            
        }

        protected void tFull_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void cbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispStudName();
        }

        protected void cbStuds_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispStudID();
        }
    }
}