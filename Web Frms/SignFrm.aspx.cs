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
    public partial class SignFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            tUser.Focus();
            if (IsPostBack) 
            {
                string Password = tPass.Text;
                tPass.Attributes.Add("value", Password);
            }
        }
        private bool ckLog() 
        {
            SqlDataAdapter da;
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " select * from tblUser " + " where Username='" + tUser.Text.Trim() +
                              "' and Password='"+ tPass.Text.Trim() +"'";

            try
            {
                con.Open();
                da = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                da.Fill(ds, "Log");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["User"] = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error...Log..." + ex.Message);
                con.Close();
            }
            finally 
            {
                con.Close();
                
            }
            return false;
        }

        protected void bEnter_Click(object sender, EventArgs e)
        {
            Session["Nym"] = tUser.Text;

            if ((tUser.Text == "admin" && tPass.Text == "cute") || tUser.Text == "admin" && tPass.Text == "admin")
            {
                Response.Redirect("AdminMenuFrm.aspx");
            }

            if (tUser.Text == string.Empty) 
            {
                lError.Text = "Please put Username";
                tUser.Focus();
                return;
            }
            else if (tPass.Text == string.Empty) 
            {
                lError.Text = "Please put Password";
                tPass.Focus();
                return;
            }

            if (ckLog() == true)
            {
                Response.Redirect("IndexFrm.aspx");
            }
            else 
            {
                lError.Text = "Incorrect Username or Password";
                return;
            }

            
        }

        protected void ckShow_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShow.Checked == false)
            {
                tPass.TextMode = TextBoxMode.Password;
            }

            if (ckShow.Checked == true)
            {
                tPass.TextMode = TextBoxMode.SingleLine;
            }
        }
    }
}