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
    public partial class UpdateSectionFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                DispYear();
                DispGrade();
                tID.Text = Request.QueryString["SectionID"];
                tSection.Text = Request.QueryString["Section"];
            }
            
            //cbYear.DataTextField = Request.QueryString["SchoolYear"];
            //cbYear.SelectedItem.Text = Request.QueryString["SchoolYear"];
            //cbYear.Text = Request.QueryString["SchoolYear"];
            //cbGrade.SelectedItem.Text = Request.QueryString["Grade"];
        }

        private void DispGrade()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select * from  tblGrade ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Grades");
                con.Close();
                cbGrade.DataSource = ds.Tables[0];
                cbGrade.DataValueField = "GradeID";
                cbGrade.DataTextField = "Grade";
                cbGrade.DataBind();

                string sRequest = Request.QueryString["Grade"];
                string sGrade;

                for (int x = 0; x < cbGrade.Items.Count; x++) 
                {
                    sGrade = cbGrade.Items[x].Text;
                    if (sGrade == sRequest) 
                    {
                        cbGrade.SelectedIndex = x;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error...Grade..." + ex);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }
        private void DispYear()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select * from  tblSchoolYear ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Year");
                con.Close();

                cbYear.DataSource = ds.Tables[0];
                cbYear.DataValueField = "SchoolYearID";
                cbYear.DataTextField = "SchoolYear";
                cbYear.DataBind();

                string sRequest = Request.QueryString["SchoolYear"];
                string sYear;
                for (int x = 0; x < cbYear.Items.Count; x++) 
                {
                    sYear = cbYear.Items[x].Text;
                    if (sYear == sRequest) 
                    {
                        cbYear.SelectedIndex = x;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error...Year..." + ex);
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

            cmd.CommandText = " UPDATE tblSection SET Section='"+ tSection.Text.Trim() +"'," + 
                              " SchoolYearID='"+ cbYear.SelectedValue.Trim() +"', " + 
                              " GradeID='"+ cbGrade.SelectedValue.Trim() +"' " + 
                              " WHERE SectionID='"+ tID.Text.Trim() +"' ";
            
            try 
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                tSection.Text = string.Empty;
                tSection.Focus();
                cbYear.SelectedIndex = 0;
                cbGrade.SelectedIndex = 0;
                lSave.Text = "Data Successfully Updated";
            }
            catch (Exception ex) {
                lSave.Text = "Error...Update..." + ex.Message;
                con.Close();
            }
            finally 
            {
                con.Close();
            }
        }

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (tID.Text == string.Empty || tSection.Text == string.Empty || cbYear.SelectedIndex == -1 || cbGrade.SelectedIndex == -1) 
            {
                lSave.Text = "Please fill all details";
                tSection.Focus();
                return;
            }
            SaveUpdate();
        }
    }
}