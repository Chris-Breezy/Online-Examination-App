using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace OnlineExamSys.Web_Frms
{
    public partial class QuestionaireFrm : System.Web.UI.Page
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
            }
            cbSchoolYear.Focus();
        }
        private void SaveNew() 
        {
            string sQuarter = string.Empty;

            if (rd1.Checked) 
            {
                sQuarter = "QUARTER-01";
            }

            if (rd2.Checked)
            {
                sQuarter = "QUARTER-02";
            }

            if (rd3.Checked)
            {
                sQuarter = "QUARTER-03";
            }

            if (rd4.Checked)
            {
                sQuarter = "QUARTER-04";
            }

            DataSet ds;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " insert into tblQuestion(QuestionNo, Question, Option1, Option2, Option3, Option4, Corrections, SchoolYearID, GradeID, SectionID, SubjectID, QuarterID) " +
                              " values('" + tID.Text.Trim() +"','" + tQuestion.Text.Trim() +"','" + tOp1.Text.Trim() +"','" + tOp2.Text.Trim() +
                              "','" + tOp3.Text.Trim() +"','" + tOp4.Text.Trim() +"','" + tCorrect.Text.Trim() +"','" + cbSchoolYear.SelectedValue.Trim() +
                              "','" + cbGrade.SelectedValue.Trim() +"','" + cbSec.SelectedValue.Trim() +
                              "','" + cbSubj.SelectedValue.Trim() +"','" + sQuarter +"') ";

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //Do Something Krazy here...
                lblSave.Text = "Data Successfully Save";
                bSave.Text = "New";
                tID.Text = string.Empty;
                tID.Focus();
                tQuestion.Text = string.Empty;
                tOp1.Text = string.Empty;
                tOp2.Text = string.Empty;
                tOp3.Text = string.Empty;
                tOp4.Text = string.Empty;
                tCorrect.Text = string.Empty;
                lCorrect.Text = string.Empty;
                bCancel.Visible = false;

                tID.Enabled = false;
                tQuestion.Enabled = false;
                tOp1.Enabled = false;
                tOp2.Enabled = false;
                tOp3.Enabled = false;
                tOp4.Enabled = false;
                tCorrect.Enabled = false;

                lQuestion.Enabled = true;

                cbSchoolYear.Enabled = true;
                cbGrade.Enabled = true;
                cbSec.Enabled = true;
                cbSubj.Enabled = true;
                rd1.Enabled = true;
                rd2.Enabled = true;
                rd3.Enabled = true;
                rd4.Enabled = true;


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
        

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (cbSchoolYear.Text == string.Empty || cbGrade.Text == string.Empty || cbSec.Text == string.Empty || cbSubj.Text == string.Empty)
            {
                lCorrect.Text = "Please select School Year and etc...";
                cbSchoolYear.Focus();
                return;
            }

            if (!rd1.Checked && !rd2.Checked && !rd3.Checked && !rd4.Checked)
            {
                lCorrect.Text = "Please select some Quarter to proceed...";
                return;
            }

            if (bSave.Text == "New")
            {
                bSave.Text = "Save";
                bCancel.Visible = true;
                lblSave.Text = string.Empty;
                cbSchoolYear.Enabled = false;
                cbGrade.Enabled = false;
                cbSec.Enabled = false;
                cbSubj.Enabled = false;
                rd1.Enabled = false;
                rd2.Enabled = false;
                rd3.Enabled = false;
                rd4.Enabled = false;

                tID.Enabled = true;
                tQuestion.Enabled = true;
                tOp1.Enabled = true;
                tOp2.Enabled = true;
                tOp3.Enabled = true;
                tOp4.Enabled = true;
                tCorrect.Enabled = true;
                lCorrect.Text = "";
                tID.Focus();
            }
            else if (bSave.Text == "Save")
            {
                //Do some traps in Questionaire Details
                if (tID.Text == string.Empty || tQuestion.Text == string.Empty || tOp1.Text == string.Empty
                    || tOp2.Text == string.Empty || tOp3.Text == string.Empty || tOp4.Text == string.Empty 
                    || tCorrect.Text == string.Empty)
                {
                    lCorrect.Text = "please fill all details to proceed...";
                    tID.Focus();
                    return;
                }

                if (tCorrect.Text != tOp1.Text && tCorrect.Text != tOp2.Text && tCorrect.Text != tOp3.Text && tCorrect.Text != tOp4.Text)
                {
                    lCorrect.Text = "Some Options must be match in Corrections...";
                    tCorrect.Focus();
                    return;
                }

                if (ckDupID() == true) 
                {
                    lCorrect.Text = "Question ID is already exist";
                    tID.Focus();
                    return;
                }

                SaveNew();
            }

        }

        private bool ckDupID() 
        {
            string sQuarter = string.Empty;

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

            SqlDataAdapter da;
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();

            con.ConnectionString = myCon;

            string sql = " select QuestionID, QuestionNo, Question, Option1, Option2, Option3, Option4, Corrections from tblQuestion " +
                         " where SchoolYearID='" + cbSchoolYear.SelectedValue.Trim() +
                         "' and GradeID='" + cbGrade.SelectedValue.Trim() +
                         "' and SectionID='" + cbSec.SelectedValue.Trim() +
                         "' and SubjectID='" + cbSubj.SelectedValue.Trim() +
                         "' and QuarterID='" + sQuarter +
                         "' and QuestionNo='"+ tID.Text.Trim() +"' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "CkDup");
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
                Response.Write("Error...Ck...." + ex.Message);
                con.Close();
                return false;
            }
            finally 
            {
                con.Close();
            }
            
        }

        protected void bCancel_Click(object sender, EventArgs e)
        {
            bCancel.Visible = false;
            bSave.Text = "New";

            cbSchoolYear.Enabled = true;
            cbGrade.Enabled = true;
            cbSec.Enabled = true;
            cbSubj.Enabled = true;
            rd1.Enabled = true;
            rd2.Enabled = true;
            rd3.Enabled = true;
            rd4.Enabled = true;

            lCorrect.Text = string.Empty;
            tID.Enabled = false;
            tQuestion.Enabled = false;
            tOp1.Enabled = false;
            tOp2.Enabled = false;
            tOp3.Enabled = false;
            tOp4.Enabled = false;
            tCorrect.Enabled = false;

            tID.Text = string.Empty;
            tQuestion.Text = string.Empty;
            tOp1.Text = string.Empty;
            tOp2.Text = string.Empty;
            tOp3.Text = string.Empty;
            tOp4.Text = string.Empty;
            tCorrect.Text = string.Empty;

        }

        protected void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispSection();
            DispSubject();
        }

        protected void cbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispSection();
        }

        
    }
}