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
    public partial class UpdateGradeFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                tGrade.Focus();
                tID.Text = Request.QueryString["GradeID"];
                tGrade.Text = Request.QueryString["Grade"];
            }
        }

        private void SaveUpdate() 
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " UPDATE tblGrade SET Grade='"+ tGrade.Text.Trim() +"'" + 
                              " WHERE GradeID='"+ tID.Text.Trim() +"' ";

            try 
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lGrade.Text = "Data Updated Successfully";
                tGrade.Text = string.Empty;
                tGrade.Focus();
            }
            catch (Exception ex) 
            {
                Response.Write("Error...Update..." + ex.Message);
                con.Close();
            }
            finally 
            {
                con.Close();
            }
        }

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (tID.Text == string.Empty || tGrade.Text == string.Empty) 
            {
                lGrade.Text = "Please fill all details";
                tGrade.Focus();
                return;
            }
            SaveUpdate();
        }
    }
}