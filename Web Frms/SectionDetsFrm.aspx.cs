using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineExamSys
{
    public partial class SectionDetsFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DispGrid();
        }

        private void DispGrid() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select s.SectionID, s.Section, sy.SchoolYear, g.Grade " + 
                         " from tblSection as s left join tblSchoolYear as sy on sy.SchoolYearID = s.SchoolYearID left join tblGrade as g on g.GradeID = s.GradeID ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Sec");
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

        protected void lDelete_OnClick(object sender, EventArgs e)
        {
            string sSubID = (sender as LinkButton).CommandArgument;
            //lCreate.Text = sSubID.ToString();

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " DELETE FROM tblSection " + " WHERE SectionID='" + sSubID + "'";

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DispGrid();
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