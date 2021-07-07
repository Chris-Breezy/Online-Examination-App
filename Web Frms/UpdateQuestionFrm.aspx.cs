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
    public partial class UpdateQuestionFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                DispSchoolYear();
                DispGrade();
                DispSection();
                DispSubject();
                tID.Text = Request.QueryString["QuestionNo"];
                tQuestion.Text = Request.QueryString["Question"];
                tOp1.Text = Request.QueryString["Option1"];
                tOp2.Text = Request.QueryString["Option2"];
                tOp3.Text = Request.QueryString["Option3"];
                tOp4.Text = Request.QueryString["Option4"];
                tCorrect.Text = Request.QueryString["Corrections"];
                DispSelectedRadio();
            }
        }

        private void DispSelectedRadio() 
        {
            string sQry = Request.QueryString["QuarterID"];

            if (sQry == "QUARTER-01") 
            {
                rd1.Checked = true;
            }
            else if (sQry == "QUARTER-02") 
            {
                rd2.Checked = true;
            }
            else if (sQry == "QUARTER-03")
            {
                rd3.Checked = true;
            }
            else if (sQry == "QUARTER-04")
            {
                rd4.Checked = true;
            }
        }

        private void DispGrade()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select * from tblGrade ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Grade");
                con.Close();

                cbGrade.DataSource = ds.Tables[0];
                cbGrade.DataValueField = "GradeID";
                cbGrade.DataTextField = "Grade";
                cbGrade.DataBind();
                
                string sRequest = Request.QueryString["GradeID"];
                string sItems;
                for (int x = 0; x < cbGrade.Items.Count; x++) 
                {
                    sItems = cbGrade.Items[x].Value;
                    if (sItems == sRequest) 
                    {
                        cbGrade.SelectedIndex = x;
                    }
                } 
                
            }
            catch (Exception ex)
            {
                Response.Write("Error...Grade..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        private void DispSchoolYear()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select SchoolYearID, SchoolYear from tblSchoolYear ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "SY");
                con.Close();

                cbSchoolYear.DataSource = ds.Tables[0];
                cbSchoolYear.DataValueField = "SchoolYearID";
                cbSchoolYear.DataTextField = "SchoolYear";
                cbSchoolYear.DataBind();

                string sRequest = Request.QueryString["SchoolYearID"];
                string sValue;
                for (int x = 0; x < cbSchoolYear.Items.Count; x++)
                {
                    sValue = cbSchoolYear.Items[x].Value;
                    if (sRequest == sValue)
                    {
                        cbSchoolYear.SelectedIndex = x;
                    }
                } 

            }
            catch (Exception ex)
            {
                Response.Write("Error...SY..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        private void DispSection()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select SectionID, Section from tblSection where SchoolYearID='" + cbSchoolYear.SelectedValue + "' and GradeID='" + cbGrade.SelectedValue + "' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Secs");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbSec.DataSource = ds.Tables[0];
                    cbSec.DataValueField = "SectionID";
                    cbSec.DataTextField = "Section";
                    cbSec.DataBind();
                    cbSec.Enabled = true;
                    rd1.Focus();
                    rd1.Enabled = true;
                    rd2.Enabled = true;
                    rd3.Enabled = true;
                    rd4.Enabled = true;

                    string sRequest = Request.QueryString["SectionID"];
                    string sItems;
                    for (int x = 0; x < cbSec.Items.Count; x++) 
                    {
                        sItems = cbSec.Items[x].Value;
                        if (sItems == sRequest) 
                        {
                            cbSec.SelectedIndex = x;
                        }
                    }
                }
                else
                {
                    cbSec.Items.Clear();
                    cbSec.Enabled = false;
                    rd1.Enabled = false;
                    rd2.Enabled = false;
                    rd3.Enabled = false;
                    rd4.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error...Secs..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }
        private void DispSubject()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select SubjectID, SubjectCode from tblSubject where GradeID='" + cbGrade.SelectedValue + "' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Subs");
                con.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbSubj.DataSource = ds.Tables[0];
                    cbSubj.DataValueField = "SubjectID";
                    cbSubj.DataTextField = "SubjectCode";
                    cbSubj.DataBind();
                    cbSubj.Enabled = true;

                    string sRequest = Request.QueryString["SubjectID"];
                    string sItems;
                    for (int x = 0; x < cbSubj.Items.Count; x++)
                    {
                        sItems = cbSubj.Items[x].Value;
                        if (sItems == sRequest)
                        {
                            cbSubj.SelectedIndex = x;
                        }
                    }

                }
                else
                {
                    cbSubj.Items.Clear();
                    cbSubj.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Error...Subs..." + ex.Message);
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

            string sRequest = Request.QueryString["QuestionID"];
            string sQuarter = "";

            if (rd1.Checked) 
            {
                sQuarter = "QUARTER-01";
            }
            else if (rd2.Checked) 
            {
                sQuarter = "QUARTER-02";
            }
            else if (rd3.Checked)
            {
                sQuarter = "QUARTER-03";
            }
            else if (rd4.Checked)
            {
                sQuarter = "QUARTER-04";
            }

            cmd.CommandText = " UPDATE tblQuestion SET QuestionNo='"+ tID.Text.Trim() +"'," + 
                              " Question='"+ tQuestion.Text.Trim() +"', " +
                              " Option1='" + tOp1.Text.Trim() + "', " +
                              " Option2='" + tOp2.Text.Trim() + "', " +
                              " Option3='" + tOp3.Text.Trim() + "', " +
                              " Option4='" + tOp4.Text.Trim() + "', " +
                              " Corrections='" + tCorrect.Text.Trim() + "', " +
                              " SchoolYearID='" + cbSchoolYear.SelectedValue.Trim() + "', " +
                              " GradeID='" + cbGrade.SelectedValue.Trim() + "', " +
                              " SectionID='" + cbSec.SelectedValue.Trim() + "', " +
                              " SubjectID='" + cbSubj.SelectedValue.Trim() + "', " +
                              " QuarterID='" + sQuarter + "' " + 
                              " WHERE QuestionID='"+ sRequest +"' ";

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblSave.Text = "Data Updated Successfully";
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
            if (tID.Text == string.Empty || tQuestion.Text == string.Empty || tOp1.Text == string.Empty
                    || tOp2.Text == string.Empty || tOp3.Text == string.Empty || tOp4.Text == string.Empty
                    || tCorrect.Text == string.Empty)
            {
                lCorrect.Text = "Please fill all details to proceed...";
                tID.Focus();
                return;
            }

            if (tCorrect.Text != tOp1.Text && tCorrect.Text != tOp2.Text && tCorrect.Text != tOp3.Text && tCorrect.Text != tOp4.Text)
            {
                lCorrect.Text = "Some Options must be match in Corrections...";
                tCorrect.Focus();
                return;
            }
            SaveUpdate();
        }

        protected void cbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispSection();
        }

        protected void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispSection();
            DispSubject();
        }
    }
}