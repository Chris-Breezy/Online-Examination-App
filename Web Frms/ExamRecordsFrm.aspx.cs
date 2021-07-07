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
    public partial class ExamRecordsFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                //Put some krazy here...
                DispStudID();
                DispStudNym();
                DispSchoolYear();
                DispGrade();
                DispSection();
                DispSubject();
                DispRecords();
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

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbSchoolYear.DataSource = ds.Tables[0];
                    cbSchoolYear.DataValueField = "SchoolYearID";
                    cbSchoolYear.DataTextField = "SchoolYear";
                    cbSchoolYear.DataBind();
                }
                else
                {
                    cbSec.Text = string.Empty;
                    cbSec.Enabled = true;
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
                    cbSubject.Enabled = true;
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
                    cbSubject.DataSource = ds.Tables[0];
                    cbSubject.DataValueField = "SubjectID";
                    cbSubject.DataTextField = "SubjectCode";
                    cbSubject.DataBind();
                    cbSubject.Enabled = true;
                }
                else
                {
                    cbSubject.Items.Clear();
                    cbSubject.Enabled = false;
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

        private void DispStudNym() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select StudentID, LName + ', ' + FName + ' ' + MName as Student from tblStudent ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Student");
                con.Close();
                //Do Something Krazy Here
                cbNym.DataSource = ds.Tables[0];
                cbNym.DataTextField = "Student";
                cbNym.DataValueField = "StudentID";
                cbNym.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error...sNym..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        private void DispStudID() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select StudentID, LName + ', ' + FName + ' ' + MName as Student from tblStudent ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "StudID");
                con.Close();
                //Do Something Krazy Here
                cbID.DataSource = ds.Tables[0];
                cbID.DataTextField = "StudentID";
                cbID.DataValueField = "StudentID";
                cbID.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error...StudID..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        private void s_ID() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select StudentID, LName + ', ' + FName + ' ' + MName as Student from tblStudent " + 
                         " where StudentID='"+ cbNym.SelectedValue.Trim() +"' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Studs");
                con.Close();
                //Do Something Krazy Here
                cbID.SelectedValue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("Error...sID..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        private void s_Nym() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select StudentID, LName + ', ' + FName + ' ' + MName as Student from tblStudent " +
                         " where StudentID='" + cbID.Text.Trim() + "' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Studs");
                con.Close();
                //Do Something Krazy Here
                if (ds.Tables[0].Rows.Count > 0) 
                {
                    cbNym.SelectedValue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error...sNym..." + ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        
        
        private void DispRecords() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
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

            con.ConnectionString = myCon;

            string sql = " select e.ResultNo, s.LName + ', ' + s.FName + ' ' + s.MName as Student, e.Score, e.Correct, e.Incorrect, e.Remarks, e.ExamDate " +
                         " from tblExamResult as e left join tblStudent as s on s.StudentID = e.StudentID " +
                         " left join tblSubject as sub on sub.SubjectID = e.SubjectID " +
                         " where e.StudentID = '" + cbID.Text.Trim() +
                         "' and e.SchoolYearID='" + cbSchoolYear.SelectedValue.Trim() +
                         "' and e.GradeID='" + cbGrade.SelectedValue.Trim() +
                         "' and e.SectionID='" + cbSec.SelectedValue.Trim() +
                         "' and e.QuarterID='" + sQuarter.Trim() +"' and e.SubjectID='" + cbSubject.SelectedValue.Trim() +"' ";

            try 
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Recs");
                con.Close();
                //Do Something Krazy Here
                gvDisp.DataSource = ds.Tables[0];
                gvDisp.DataBind();
            }
            catch (Exception ex) 
            {
                Response.Write("Error...Recs..." + ex.Message);
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
            DispRecords();
        }

        protected void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispSection();
            DispSubject();
            DispRecords();
        }

        protected void cbSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispRecords();
        }

        protected void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispRecords();
        }

        protected void cbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_Nym();
            DispRecords();
        }

        protected void rd1_CheckedChanged(object sender, EventArgs e)
        {
            DispRecords();
        }

        protected void rd2_CheckedChanged(object sender, EventArgs e)
        {
            DispRecords();
        }

        protected void rd3_CheckedChanged(object sender, EventArgs e)
        {
            DispRecords();
        }

        protected void rd4_CheckedChanged(object sender, EventArgs e)
        {
            DispRecords();
        }

        protected void cbNym_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_ID();
        }
    }
}