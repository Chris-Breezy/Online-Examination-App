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
    public partial class UpdateUserFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                GetStudID();
                GetStudents();
                tPass.Focus();
                DispStudID();
                DispStudName();
                tID.Text = Request.QueryString["UserID"];
                tUser.Text = Request.QueryString["Username"];
            }
            
            //tConfirm.Text = Request.QueryString["Student"]; 
        }

        private void DispStudName()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select StudentID, LName + ', ' + FName + ' ' + MName as Student from tblStudent " +
                         " where StudentID='" + cbID.Text.Trim() + "' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Studs");
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

        private void GetStudents() 
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

                string sRequest = Request.QueryString["Student"];
                string sStuds;
                for (int x = 0; x < cbStuds.Items.Count; x++) 
                {
                    sStuds = cbStuds.Items[x].Text;
                    if (sRequest == sStuds) 
                    {
                        cbStuds.SelectedIndex = x;
                    }
                }
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
        private void SaveUpdate() 
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " UPDATE tblUser SET Username='"+ tUser.Text.Trim() +"', " + 
                              " Password='"+ tPass.Text.Trim() +"', " + 
                              " StudentID='"+ cbStuds.SelectedValue.Trim() +"'" + 
                              " WHERE UserID='"+ tID.Text.Trim() +"' ";

            try 
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                tID.Text = string.Empty;
                cbStuds.SelectedIndex = 0;
                tUser.Text = string.Empty;
                tPass.Text = string.Empty;
                tConfirm.Text = string.Empty;
                lError.Text = "Data Updated Successfully";
            }
            catch (Exception ex) 
            {
                lError.Text = "Error...Save..." + ex.Message;
            }
            finally 
            {
                con.Close();
            }
        }

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (tID.Text == string.Empty || cbStuds.SelectedIndex == -1 || tUser.Text == string.Empty ||
                tPass.Text == string.Empty || tConfirm.Text == string.Empty) 
            {
                tPass.Focus();
                lError.Text = "Please fill all details";
                return;
            }

            if (tPass.Text != tConfirm.Text) 
            {
                tPass.Focus();
                lError.Text = "New Password and Confirm Password must Match";
                return;
            }
            SaveUpdate();
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