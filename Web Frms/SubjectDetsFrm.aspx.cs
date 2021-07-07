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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DispData();
        }

        private void DispData() 
        {
            SqlDataAdapter da;
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();

            con.ConnectionString = myCon;

            string sql = " select s.SubjectID, s.SubjectCode, s.[Description], g.Grade " +
                         " from tblSubject as s left join tblGrade as g on g.GradeID = s.GradeID ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Disp");
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string sID = GridView1.SelectedRow.Cells[0].Text;
            //string sCode = GridView1.SelectedRow.Cells[1].Text;
            //lCreate.Text = sID.ToString();
        }

        protected void lDelete_OnClick(object sender, EventArgs e) 
        {
            string sSubID = (sender as LinkButton).CommandArgument;
            //lCreate.Text = sSubID.ToString();

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " DELETE FROM tblSubject " + " WHERE SubjectID='"+ sSubID +"'";

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DispData();
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

    }
}