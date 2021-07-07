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
    public partial class UpdateSchoolYear : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                tID.Text = Request.QueryString["SchoolYearID"];
                tYear.Text = Request.QueryString["SchoolYear"];
            }
        }

        private void SaveUpdate() 
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " UPDATE tblSchoolYear SET SchoolYear='"+ tYear.Text.Trim() +"' " + 
                              " WHERE SchoolYearID='"+ tID.Text.Trim() +"' ";

            try 
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                tID.Text = string.Empty;
                tYear.Text = string.Empty;
                tYear.Focus();
                lYear.Text = "Data Updated Successfully";
                return;
            }
            catch (Exception ex) 
            {
                lYear.Text = "Error...Update" + ex.Message;
                con.Close();
            }
            finally 
            {
                con.Close();
            }
        }

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (tID.Text == string.Empty || tYear.Text == string.Empty) 
            {
                lYear.Text = "Please fill all details";
                tYear.Focus();
                return;
            }
            SaveUpdate();
        }
    }
}