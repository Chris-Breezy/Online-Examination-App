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
    public partial class GradeDetsFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                DispGrade();
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

            cmd.CommandText = " DELETE FROM tblGrade " + " WHERE GradeID='" + sSubID + "'";

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DispGrade();
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
        
        private void DispGrade() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select GradeID, Grade from tblGrade ";

            try 
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds,"DispGrd");
                con.Close();
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex) 
            {
                Response.Write("Error...Disp..." + ex.Message);
                con.Close();
            }
            finally 
            {
                con.Close();
            }
        }
    }
}