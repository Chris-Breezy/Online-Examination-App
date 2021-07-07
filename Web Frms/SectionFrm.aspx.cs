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
    public partial class SectionFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                DispYear();
                DispGrade();
                tID.Focus();
            }
            
        }
        private void Save() 
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " insert into tblSection(SectionID,Section,SchoolYearID,GradeID) " +
                              " values('" + tID.Text.Trim() +"','" + tSection.Text.Trim() +
                              "','" + cbYear.SelectedValue.Trim() +"','" + cbGrade.SelectedValue.Trim() +"') ";
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lSave.Text = "Data Successfully Save";
                tID.Focus();
                tID.Text = string.Empty;
                tSection.Text = string.Empty;
                cbYear.SelectedIndex = 0;
                cbGrade.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lSave.Text = "Error...Save..." + ex.Message;
                con.Close();
            }
            finally 
            {
                con.Close();
            }

        }
        private bool ckDupID() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select * from  tblSection " + " where SectionID='"+ tID.Text.Trim() +"' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Dup");
                con.Close();

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
                Response.Write("Error...DUpID..." + ex);
                con.Close();
                return false;
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

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (tID.Text == string.Empty || tSection.Text == string.Empty || cbGrade.SelectedIndex == -1 || cbYear.SelectedIndex == -1)
            {
                lSave.Text = "Please fill all details...";
                tID.Focus();
                return;
            }

            if (ckDupID() == true) 
            {
                lSave.Text = "Section ID is already exist";
                tID.Focus();
                return;
            }
            Save();
        }
    } 
}