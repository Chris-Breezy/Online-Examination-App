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
    public partial class UsersFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewDetails();
            //GridView1.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridView1.RowStyle.HorizontalAlign = HorizontalAlign.Left;
        }

        private void Delete()
        {
            DataSet ds;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " DELETE FROM tblUser WHERE UserID='' ";

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //Do Something Krazy...
            }
            catch (Exception ex)
            {
                Response.Write("Error...Delete..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }

        }

        private void ViewDetails() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select u.UserID, u.Username, u.[Password], u.StudentID, s.LName + ', ' + s.FName + ' ' + s.MName as Student " +
                         " from tblUser as u left join tblStudent as s on s.StudentID = u.StudentID ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Dets");
                con.Close();
                //Do something krazy
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error...Databind..." + ex.Message);
                con.Close();
            }
            finally 
            {
                con.Close();
            }

        }

        protected void lDelete_OnClick(object sender, EventArgs e)
        {
            string sSubID = (sender as LinkButton).CommandArgument;
            //lCreate.Text = sSubID.ToString();

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " DELETE FROM tblUser WHERE UserID='"+ sSubID +"'";

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ViewDetails();
            }
            catch (Exception ex)
            {
                Response.Write("Error...Delete..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }
    }
}