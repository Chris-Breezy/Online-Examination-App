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
    public partial class QuestionaireDetsFrm : System.Web.UI.Page
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
                GetExam();
                //DispGV();
            }
            gvDisp.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        private void GetID(string myID) 
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " DELETE FROM tblQuestion " + " WHERE QuestionID='" + myID + "'";

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DispGV();
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

        
        protected void lDelete_OnClick(object sender, EventArgs e)
        {
            string sSubID = (sender as LinkButton).CommandArgument;
            string s1stRow;
            //lCreate.Text = sSubID.ToString();

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select * from tblQuestion " + 
                         " where Question='"+ sSubID.ToString() +"' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Del");
                con.Close();
                s1stRow = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                GetID(s1stRow.ToString());
                //Response.Write(sSubID + " - " + s1stRow);

            }
            catch (Exception ex)
            {
                Response.Write("Error...Del..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }

            //SqlConnection con = new SqlConnection();
            //SqlCommand cmd = new SqlCommand();

            //con.ConnectionString = myCon;
            //cmd.Connection = con;

            //cmd.CommandText = " DELETE FROM tblQuestion " + " WHERE QuestionID='" + sSubID + "'";

            //try
            //{
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    DispGV();
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("Error...Delete..." + ex.Message);
            //    con.Close();
            //}
            //finally
            //{
            //    con.Close();
            //}
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
                    rdAll.Focus();
                    rdAll.Enabled = true;
                    rd1.Enabled = true;
                    rd2.Enabled = true;
                    rd3.Enabled = true;
                    rd4.Enabled = true;
                }
                else
                {
                    cbSec.Items.Clear();
                    cbSec.Enabled = false;
                    rdAll.Enabled = false;
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

        private void DispGV() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select QuestionNo, Question, Option1, Option2, Option3, Option4, Corrections, SchoolYearID, GradeID, SectionID, SubjectID, QuarterID, QuestionID from tblQuestion ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Disp");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0) 
                {
                    gvDisp.DataSource = ds.Tables[0];
                    gvDisp.DataBind();
                }
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

        private void GetExam()
        {
            string sQuarter = string.Empty;

            if (rd1.Checked)
            {
                sQuarter = "and QuarterID='QUARTER-01'";
            }

            else if (rd2.Checked)
            {
                sQuarter = "and QuarterID='QUARTER-02'";
            }

            else if (rd3.Checked)
            {
                sQuarter = "and QuarterID='QUARTER-03'";
            }

            else if (rd4.Checked)
            {
                sQuarter = "and QuarterID='QUARTER-04'";
            }

            else if (rd4.Checked) 
            {
                sQuarter = "";
            }

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " SELECT QuestionNo, Question, Option1, Option2, Option3, Option4, Corrections, SchoolYearID, GradeID, SectionID, SubjectID, QuarterID, QuestionID " +
                         " FROM tblQuestion " +
                         " WHERE SchoolYearID='" + cbSchoolYear.SelectedValue +
                         "' and GradeID='" + cbGrade.SelectedValue +
                         "' and SectionID='" + cbSec.SelectedValue +
                         "' and SubjectID='" + cbSubj.SelectedValue + "' " + sQuarter;

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Exam");
                con.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDisp.DataSource = ds.Tables[0];
                    gvDisp.DataBind();
                }
                else
                {
                    //lItems.Text = "There's no Questionaire created yet.";
                    //bTake.Visible = false;
                    //bSubmit.Visible = false;
                    gvDisp.DataSource = string.Empty;
                    gvDisp.DataBind();
                    
                }


            }
            catch (Exception ex)
            {
                Response.Write("Error...Exam..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        protected void cbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispSection();
            GetExam();
        }

        protected void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispSection();
            DispSubject();
            GetExam();
        }

        protected void cbSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetExam();
        }

        protected void cbSubj_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetExam();
        }

        protected void rd1_CheckedChanged(object sender, EventArgs e)
        {
            GetExam();
        }

        protected void rd2_CheckedChanged(object sender, EventArgs e)
        {
            GetExam();
        }

        protected void rd3_CheckedChanged(object sender, EventArgs e)
        {
            GetExam();
        }

        protected void rd4_CheckedChanged(object sender, EventArgs e)
        {
            GetExam();
        }

        protected void rdAll_CheckedChanged(object sender, EventArgs e)
        {
            GetExam();
        }
    }
}