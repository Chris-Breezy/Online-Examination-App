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
    public partial class IndexFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //DateTime dt = DateTime.Now;
            //lblTime.Text = dt.ToString();
            lUser.Text = "Welcome: " + (string)Session["User"] + " / " + (string)Session["Nym"];

            if (!IsPostBack) 
            {
                DispSchoolYear();
                DispGrade();
                DispSection();
                DispSubject();
                GetExam();
                //SecExam();
            }
        }

        private bool GetExistingQuarter() 
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

            string s_ID = "";
            string sRevID = "";
            for (int x = lUser.Text.Length - 1; x >= 8; x--)
            {
                s_ID += lUser.Text[x].ToString();
            }
            for (int i = s_ID.Length - 1; i >= 15; i--)
            {
                sRevID += s_ID[i].ToString();
            }

            con.ConnectionString = myCon;

            string sql = " select * from tblExamResult " +
                         " where StudentID='" + sRevID.Trim() +
                         "' and SchoolYearID='" + cbSchoolYear.SelectedValue.Trim() +
                         "' and GradeID='" + cbGrade.SelectedValue.Trim() +
                         "' and SectionID='" + cbSec.SelectedValue.Trim() +
                         "' and SubjectID='" + cbSubject.SelectedValue.Trim() +
                         "' and QuarterID='" + sQuarter + "' ";

            try 
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "CkQuarter");
                con.Close();
                //Do Something Krazy Here...
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
                Response.Write("Error...CkQuarter..." + ex.Message);
                con.Close();
            }
            finally 
            {
                con.Close();
            }
            return false;
        }
        
        private void GetStudID() 
        {
            string sUser = "";
            string unsa = "";
            for (int x = 8; x < lUser.Text.Length; x++)
            {
                sUser += lUser.Text[x].ToString();
                for (int i = 0; i < sUser.Length; i++)
                {
                    if (sUser[i].ToString() == "/")
                    {
                        return;
                    }
                }
                //Tama 
                //Response.Write("" + sUser.ToString());
                lStudID.Text = "Student ID: " + "<b>" + sUser.ToString() + "</b>";
                //lItems.Text = sUser.ToString();
            }
        }

        private void SaveNew() 
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DateTime sGetDyt = DateTime.Now;

            string sTotScore = lTotScore.Text;
            string sCorrect = lCorrect.Text;
            string sIncorrect = lIncorrect.Text;
            string sRemarks = lRemarks.Text;
            string sID = lStudID.Text;

            string a = sCorrect;
            string b = string.Empty;
            int val;

            //For Loop
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                {
                    b += a[i];
                }
                //Response.Write(b);
            }
            val = int.Parse(b);

            string a1 = sIncorrect;
            string b1 = string.Empty;
            int val1;
            //For Loop
            for (int i = 0; i < a1.Length; i++)
            {
                if (Char.IsDigit(a1[i]))
                {
                    b1 += a1[i];
                }
                //Response.Write(b);
            }
            val1 = int.Parse(b1);

            string s_ID = sID.Substring(16);
            string u_ID = "";
            string sRevID = "";
            //Stud ID
            for (int x = s_ID.Length - 1; x >= 0; x--) 
            {
                u_ID += s_ID[x].ToString();
            }
            u_ID = u_ID.Substring(4);

            for (int x1 = u_ID.Length - 1; x1 >= 0; x1--)
            {
                sRevID += u_ID[x1].ToString();
            }

            string s_Remarks = sRemarks.Substring(12);
            string u_Remarks = "";
            string sRevMarks = "";
            //Remarks
            for (int i = s_Remarks.Length - 1; i >= 0; i--) 
            {
                u_Remarks += s_Remarks[i].ToString();
            }
            u_Remarks = u_Remarks.Substring(4);

            for (int i1 = u_Remarks.Length - 1; i1 >= 0; i1--)
            {
                sRevMarks += u_Remarks[i1].ToString();
            }

            string s_TotScore = sTotScore.Substring(16);
            string u_TotScore = "";
            string sRevScore = "";

            for (int t = s_TotScore.Length - 1; t >= 0; t--) 
            {
                u_TotScore += s_TotScore[t].ToString();
            }
            u_TotScore = u_TotScore.Substring(4);

            for (int t1 = u_TotScore.Length - 1; t1 >= 0; t1--) 
            {
                sRevScore += u_TotScore[t1].ToString();
            }

            string sQuarters = "";
            if (rd1.Checked) 
            {
                sQuarters = "QUARTER-01";
            }
            else if (rd2.Checked) 
            {
                sQuarters = "QUARTER-02";
            }
            else if (rd3.Checked) 
            {
                sQuarters = "QUARTER-03";
            }
            else if (rd4.Checked) 
            {
                sQuarters = "QUARTER-04";
            }

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = "INSERT INTO tblExamResult(StudentID, SchoolYearID, GradeID, SectionID, SubjectID, QuarterID, Score, Correct, Incorrect, Remarks, ExamDate)" +
                              "VALUES('" + sRevID.Trim() +"','" + cbSchoolYear.SelectedValue.Trim() + "','" + cbGrade.SelectedValue.Trim() + "','" + cbSec.SelectedValue.Trim() +
                              "','" + cbSubject.SelectedValue.Trim() + "','"+ sQuarters.Trim().ToString() +"','" + sRevScore.Trim() + "','" + val.ToString() + "','" + val1.ToString() + "','" + sRevMarks.Trim() + "','" + sGetDyt.ToString("MM/dd/yyyy") + "')";

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //Do Somthing Krazy Here Tommorrow...
                lSave.Text = "Exam successfully recorded";
            }
            catch (Exception ex)
            {
                lItems.Text = "Error...Save..." + ex.Message;
                con.Close();
            }
            finally 
            {
                con.Close();
            }
        }

        private void SecExam() 
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
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " SELECT q.QuestionNo, q.Question, q.Option1, q.Option2, q.Option3, q.Option4, q.Corrections, s.SubjectCode , s.[Description] " +
                         " FROM tblQuestion as q left join tblSubject as s on s.SubjectID = q.SubjectID " +
                         " WHERE q.SchoolYearID='" + cbSchoolYear.SelectedValue +
                         "' AND q.GradeID='" + cbGrade.SelectedValue +
                         "' AND q.SectionID='" + cbSec.SelectedValue +
                         "' AND q.SubjectID='" + cbSubject.SelectedValue +
                         "' AND q.QuarterID='" + sQuarter + "' ";

            try
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Secondary");
                con.Close();
                //Do Something Krazy Here...
                Repeater1.DataSource = ds.Tables[0];
                Repeater1.DataBind();
                bSubmit.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write("Error...Secondary..." + ex.Message);
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
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " SELECT q.QuestionNo, q.Question, q.Option1, q.Option2, q.Option3, q.Option4, q.Corrections, s.SubjectCode , s.[Description] " +
                         " FROM tblQuestion as q left join tblSubject as s on s.SubjectID = q.SubjectID " +
                         " WHERE q.SchoolYearID='" + cbSchoolYear.SelectedValue +
                         "' AND q.GradeID='" + cbGrade.SelectedValue +
                         "' AND q.SectionID='" + cbSec.SelectedValue +
                         "' AND q.SubjectID='" + cbSubject.SelectedValue +
                         "' AND q.QuarterID='" + sQuarter + "' ";

            try 
            {
                con.Open();
                da = new SqlDataAdapter(sql,con);
                da.Fill(ds, "Exam");
                con.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Repeater1.DataSource = ds.Tables[0];
                    //Repeater1.DataBind();
                    //bSubmit.Visible = true;
                    bTake.Visible = true;
                    lCode.Text = "Code: " + "<b>" + ds.Tables[0].Rows[0].ItemArray[7].ToString() +"</b>";
                    lDesc.Text = "Desciption: " + "<b>" + ds.Tables[0].Rows[0].ItemArray[8].ToString() + "</b>";
                    int totQuest;
                    //string myItems;
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {
                        //myItems = ds.Tables[0].Rows[x].ItemArray[0].ToString();
                        totQuest = x + 1;
                        //lItems.Text = "Total Questions: " + totQuest.ToString() + " / Would you like to take the exam?";
                        lItems.Text = "Total Questions: " + "<b>" + totQuest.ToString() + "</b>" + " / " + " Would you like to take the exam?";
                    }
                    //lItems.Text = "Total Questions: " + totQuest;
                    lTotScore.Visible = false;
                    lCorrect.Visible = false;
                    lIncorrect.Visible = false;
                    lRemarks.Visible = false;
                    lStudID.Visible = false;
                    lExamTaken.Visible = false;
                    bSubmit.Enabled = true;
                    bSubmit.Visible = false;
                    lSave.Text = string.Empty;
                    Repeater1.DataSource = string.Empty;
                    Repeater1.DataBind();
                }
                else 
                {
                    lItems.Text = "There's no Questionaire created yet.";
                    lCode.Text = string.Empty;
                    lDesc.Text = string.Empty;
                    bTake.Visible = false;
                    bSubmit.Visible = false;
                    Repeater1.DataSource = string.Empty;
                    Repeater1.DataBind();
                    //Modified
                    lSave.Text = string.Empty;
                    lTotScore.Visible = false;
                    lCorrect.Visible = false;
                    lIncorrect.Visible = false;
                    lRemarks.Visible = false;
                    lStudID.Visible = false;
                    lExamTaken.Visible = false;
                    bSubmit.Enabled = true;
                    bSubmit.Visible = false;
                }
            }
            catch(Exception ex) 
            {
                Response.Write("Error...Exam..." + ex.Message);
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
                da = new SqlDataAdapter(sql,con);
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
            catch(Exception ex) 
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

            string sql = " select SectionID, Section from tblSection where SchoolYearID='"+ cbSchoolYear.SelectedValue +"' and GradeID='"+ cbGrade.SelectedValue +"' ";

            try 
            {
                con.Open();
                da = new SqlDataAdapter(sql,con);
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
            catch(Exception ex) 
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
                da = new SqlDataAdapter(sql,con);
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
            catch(Exception ex) 
            {
                Response.Write("Error...Subs..." + ex.Message);
                con.Close();
            }
            finally 
            {
                con.Close();
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GetExam();
            //if (rd1.Checked) 
            //{
            //    GetExam();
            //    //Response.Write("1st Quarter has been checked");
            //    return;
            //}
        }

        protected void rd2_CheckedChanged(object sender, EventArgs e)
        {
            GetExam();
            //if (rd2.Checked)
            //{
                
            //    //Response.Write("2nd Quarter has been checked");
            //    return;
            //}            
        }

        protected void rd3_CheckedChanged(object sender, EventArgs e)
        {
            GetExam();
            //if (rd3.Checked)
            //{
                
            //    //Response.Write("3rd Quarter has been checked");
            //    return;
            //}
        }

        protected void rd4_CheckedChanged(object sender, EventArgs e)
        {
            GetExam();
            //if (rd4.Checked)
            //{
            //    GetExam();
            //    //Response.Write("4th Quarter has been checked");
            //    return;
            //}
        }

        protected void cbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispSection();
            GetExam();
            //Response.Write("" + cbSchoolYear.SelectedValue);
        }

        protected void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispSection();
            DispSubject();
            GetExam();
            //Response.Write("" + cbGrade.SelectedValue);
        }

        protected void cbSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetExam();
            //Response.Write("" + cbSec.SelectedValue);
        }

        protected void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Write("" + cbSubject.SelectedValue);
            GetExam();
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    //GetExam();
        //    //SecExam();
        //}

        private void UltimateFunc() 
        {
            //Some Additional Functions Here...
            bool naa = false;
            bool sAns = false;

            foreach (RepeaterItem ri in Repeater1.Items)
            {   
                RadioButton rb1 = (RadioButton)ri.FindControl("rOption1");
                RadioButton rb2 = (RadioButton)ri.FindControl("rOption2");
                RadioButton rb3 = (RadioButton)ri.FindControl("rOption3");
                RadioButton rb4 = (RadioButton)ri.FindControl("rOption4");
                //Label
                Label labCorrectans = (Label)ri.FindControl("lCorrectAns");
                Label Userselectedanswer = (Label)ri.FindControl("lUserSelectedOption");

                if (!rb1.Checked && !rb2.Checked && !rb3.Checked && !rb4.Checked)
                {
                    Label Wronganswer = (Label)ri.FindControl("lUserSelectedOption");
                    //Wronganswer.Text = "The Selected Answer <b>" + rb1.Text.ToString() + "</br> Is Wrong ";
                    Wronganswer.ForeColor = System.Drawing.Color.Red;
                    Wronganswer.Text = "Please select some answers";
                    naa = true;
                }
                else 
                {
                    Label Wronganswer = (Label)ri.FindControl("lUserSelectedOption");
                    //Wronganswer.Text = "The Selected Answer <b>" + rb1.Text.ToString() + "</br> Is Wrong ";
                    Wronganswer.ForeColor = System.Drawing.Color.Red;
                    Wronganswer.Text = "";
                    naa = false;
                    //return;
                    //getAns = true;
                    //ckAns();
                }

                if (naa == true)
                {
                    lItems.Text = "Please answer all the questions to proceed...";
                    //return;
                }
                
                if (naa == false) 
                {
                    lItems.Text = "Locked";
                    //Response.Write("Humana'g answer tanan");
                    //sAns = true;
                }
                //Response.Write(naa);
            }

            //if (lItems.Text == "Locked")
            //{
            //    ckAns();
            //    bSubmit.Enabled = false;
            //    bTake.Visible = true;
            //    bTake.Text = "Back";
            //}

        }

        private void ckAns() 
        {
            int sTots = 0;
            int sInCorrect = 0;
            int totQuest = 0;
            DateTime sGetDyt = DateTime.Now;

            for (int x = 0; x < Repeater1.Items.Count; x++)
            {
                totQuest = x + 1;
            }


            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb1 = (RadioButton)ri.FindControl("rOption1");
                RadioButton rb2 = (RadioButton)ri.FindControl("rOption2");
                RadioButton rb3 = (RadioButton)ri.FindControl("rOption3");
                RadioButton rb4 = (RadioButton)ri.FindControl("rOption4");
                Label labCorrectans = (Label)ri.FindControl("lCorrectAns");
                //labCorrectans.Visible = true;

                if (rb1.Checked == true)
                {
                    if (rb1.Text.Equals(labCorrectans.Text))
                    {
                        Label Userselectedanswer = (Label)ri.FindControl("lUserSelectedOption");
                        Userselectedanswer.Text = "The Selected Answer is <b>" + rb1.Text.ToString() + "</br>";
                        Userselectedanswer.ForeColor = System.Drawing.Color.Green;
                        rb1.Enabled = false;
                        rb2.Enabled = false;
                        rb3.Enabled = false;
                        rb4.Enabled = false;
                        sTots += 1;
                    }
                    else
                    {
                        Label Wronganswer = (Label)ri.FindControl("lUserSelectedOption");
                        Wronganswer.Text = "The Selected Answer <b>" + rb1.Text.ToString() + "</br> Is Wrong ";
                        Wronganswer.ForeColor = System.Drawing.Color.Red;
                        rb1.Enabled = false;
                        rb2.Enabled = false;
                        rb3.Enabled = false;
                        rb4.Enabled = false;
                        sInCorrect += 1;
                    }
                }
                //Response.Write("Result: " + sTots.ToString());
                //lItems.Text = "Total Correct Answer: " + sTots.ToString();
                lCorrect.Text = "Total Correct Answer: " + sTots.ToString();
                //lCorrect.Text = "Total Correct Answer: " + sTots.ToString();
                lIncorrect.Text = "Incorrect Answer: " + sInCorrect.ToString(); ;
                lTotScore.Text = "Total Score: " + sTots.ToString() + " / " + totQuest.ToString();
                lExamTaken.Text = "Exam Date: " + sGetDyt.ToString("MM/dd/yyyy");
            }

            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb1 = (RadioButton)ri.FindControl("rOption1");
                RadioButton rb2 = (RadioButton)ri.FindControl("rOption2");
                RadioButton rb3 = (RadioButton)ri.FindControl("rOption3");
                RadioButton rb4 = (RadioButton)ri.FindControl("rOption4");
                Label labCorrectans = (Label)ri.FindControl("lCorrectAns");
                //labCorrectans.Visible = true;
                if (rb2.Checked == true)
                {
                    if (rb2.Text.Equals(labCorrectans.Text))
                    {
                        Label Userselectedanswer = (Label)ri.FindControl("lUserSelectedOption");
                        Userselectedanswer.Text = "The Selected Answer is <b>" + rb2.Text.ToString() + "</br>";
                        Userselectedanswer.ForeColor = System.Drawing.Color.Green;
                        rb1.Enabled = false;
                        rb2.Enabled = false;
                        rb3.Enabled = false;
                        rb4.Enabled = false;
                        sTots += 1;
                        
                    }
                    else
                    {
                        Label Wronganswer = (Label)ri.FindControl("lUserSelectedOption");
                        Wronganswer.Text = "The Selected Answer <b>" + rb2.Text.ToString() + "</br> Is Wrong ";
                        Wronganswer.ForeColor = System.Drawing.Color.Red;
                        rb1.Enabled = false;
                        rb2.Enabled = false;
                        rb3.Enabled = false;
                        rb4.Enabled = false;
                        sInCorrect += 1;
                    }
                }
                //Response.Write("Result: " + sTots.ToString());
                //lItems.Text = "Total Correct Answer: " + sTots.ToString();
                lCorrect.Text = "Total Correct Answer: " + sTots.ToString();
                //lCorrect.Text = "Total Correct Answer: " + sTots.ToString();
                lIncorrect.Text = "Incorrect Answer: " + sInCorrect.ToString(); 
                lTotScore.Text = "Total Score: " + sTots.ToString() + " / " + totQuest.ToString();
                lExamTaken.Text = "Exam Date: " + sGetDyt.ToString("MM/dd/yyyy");
            }

            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb1 = (RadioButton)ri.FindControl("rOption1");
                RadioButton rb2 = (RadioButton)ri.FindControl("rOption2");
                RadioButton rb3 = (RadioButton)ri.FindControl("rOption3");
                RadioButton rb4 = (RadioButton)ri.FindControl("rOption4");
                Label labCorrectans = (Label)ri.FindControl("lCorrectAns");
                //labCorrectans.Visible = true;
                if (rb3.Checked == true)
                {
                    if (rb3.Text.Equals(labCorrectans.Text))
                    {
                        Label Userselectedanswer = (Label)ri.FindControl("lUserSelectedOption");
                        Userselectedanswer.Text = "The Selected Answer is <b>" + rb3.Text.ToString() + "</br>";
                        Userselectedanswer.ForeColor = System.Drawing.Color.Green;
                        rb1.Enabled = false;
                        rb2.Enabled = false;
                        rb3.Enabled = false;
                        rb4.Enabled = false;
                        sTots += 1;
                        
                    }
                    else
                    {
                        Label Wronganswer = (Label)ri.FindControl("lUserSelectedOption");
                        Wronganswer.Text = "The Selected Answer <b>" + rb3.Text.ToString() + "</br> Is Wrong ";
                        Wronganswer.ForeColor = System.Drawing.Color.Red;
                        rb1.Enabled = false;
                        rb2.Enabled = false;
                        rb3.Enabled = false;
                        rb4.Enabled = false;
                        sInCorrect += 1;
                    }
                }
                //Response.Write("Result: " + sTots.ToString());
                //lItems.Text = "Total Correct Answer: " + sTots.ToString();
                lCorrect.Text = "Total Correct Answer: " + sTots.ToString();
                //lCorrect.Text = "Total Correct Answer: " + sTots.ToString();
                lIncorrect.Text = "Incorrect Answer: " + sInCorrect.ToString(); ;
                lTotScore.Text = "Total Score: " + sTots.ToString() + " / " + totQuest.ToString();
                lExamTaken.Text = "Exam Date: " + sGetDyt.ToString("MM/dd/yyyy");
            }

            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb1 = (RadioButton)ri.FindControl("rOption1");
                RadioButton rb2 = (RadioButton)ri.FindControl("rOption2");
                RadioButton rb3 = (RadioButton)ri.FindControl("rOption3");
                RadioButton rb4 = (RadioButton)ri.FindControl("rOption4");
                Label labCorrectans = (Label)ri.FindControl("lCorrectAns");
                //labCorrectans.Visible = true;
                if (rb4.Checked == true)
                {
                    if (rb4.Text.Equals(labCorrectans.Text))
                    {
                        Label Userselectedanswer = (Label)ri.FindControl("lUserSelectedOption");
                        Userselectedanswer.Text = "The Selected Answer is <b>" + rb4.Text.ToString() + "</br>";
                        Userselectedanswer.ForeColor = System.Drawing.Color.Green;
                        rb1.Enabled = false;
                        rb2.Enabled = false;
                        rb3.Enabled = false;
                        rb4.Enabled = false;
                        sTots += 1;
                    }
                    else
                    {
                        Label Wronganswer = (Label)ri.FindControl("lUserSelectedOption");
                        Wronganswer.Text = "The Selected Answer <b>" + rb4.Text.ToString() + "</br> Is Wrong ";
                        Wronganswer.ForeColor = System.Drawing.Color.Red;
                        rb1.Enabled = false;
                        rb2.Enabled = false;
                        rb3.Enabled = false;
                        rb4.Enabled = false;
                        sInCorrect += 1;
                    }
                }
                //Response.Write("Result: " + sTots.ToString());
                //lItems.Text = "Total Correct Answer: " + sTots.ToString();
                lCorrect.Text = "Total Correct Answer: " + "<b>" + sTots.ToString() + "</b>";
                //lCorrect.Text = "Total Correct Answer: " + sTots.ToString();
                lIncorrect.Text = "Incorrect Answer: " + "<b>" + sInCorrect.ToString() + "</b>";
                lTotScore.Text = "Total Score: " + "<b>" + sTots.ToString() + " / " + totQuest.ToString() + "</b>";
                lExamTaken.Text = "Exam Date: " + "<b>" + sGetDyt.ToString("MM/dd/yyyy") + "</b>";

            }   
        }

        private void DispRemarks() 
        {
            string a = lCorrect.Text;
            string b = string.Empty;
            int val;

            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                {
                    b += a[i];
                }
                //Response.Write(b);
            }
            if (b.Length > 0)
            {
                val = int.Parse(b);
                //Response.Write(val);

                if (val >= 50)
                {
                    lRemarks.Text = "Remarks: " + "<b>" + "Passed" + "</b>";
                }
                else
                {
                    if (val >= 40)
                    {
                        lRemarks.Text = "Remarks: " + "<b>" + "Passed" + "</b>";
                    }
                    else
                    {
                        if (val >= 35)
                        {
                            lRemarks.Text = "Remarks: " + "<b>" + "Passed" + "</b>";
                        }
                        else
                        {
                            lRemarks.Text = "Remarks: " + "<b>" + "Failed" + "</b>";
                        }
                    }
                }


                if (val >= 20)
                {
                    lRemarks.Text = "Remarks: " + "<b>" + "Passed" + "</b>";
                }
                else 
                {
                    if (val >= 15)
                    {
                        lRemarks.Text = "Remarks: " + "<b>" + "Passed" + "</b>";
                    }
                    else 
                    {
                        if (val >= 10)
                        {
                            lRemarks.Text = "Remarks: " + "<b>" + "Passed" + "</b>";
                        }
                        else
                        {
                            lRemarks.Text = "Remarks: " + "<b>" + "Failed" + "</b>";
                        }
                    }
                }
                //if (val >= 50)
                //{
                //    lRemarks.Text = "Remarks: " + "<b>" + "Passed" + "</b>";
                //}
                //else
                //{
                //    lRemarks.Text = "Remarks: " + "<b>" + "Passed" + "</b>";
                //}

                //if (val >= 20)
                //{
                //    lRemarks.Text = "Remarks: " + "<b>" + "Passed" + "</b>";
                //}
                //else 
                //{
                //    lRemarks.Text = "Remarks: " + "<b>" + "Failed" + "</b>";
                //}

                //if (val >= 5)
                //{
                //    lRemarks.Text = "Remarks: " + "<b>" + "Passed" + "</b>";
                //}
                //else
                //{
                //    lRemarks.Text = "Remarks: " + "<b>" + "Failed" + "</b>";
                //}
                
            }
        }

        protected void bSubmit_Click(object sender, EventArgs e)
        {
            
            //Some Additional Functions Here...
            bool naa = false;
            bool sAns = false;
            int totQuest = 0;
            int totBool = 0;


            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb1 = (RadioButton)ri.FindControl("rOption1");
                RadioButton rb2 = (RadioButton)ri.FindControl("rOption2");
                RadioButton rb3 = (RadioButton)ri.FindControl("rOption3");
                RadioButton rb4 = (RadioButton)ri.FindControl("rOption4");
                //Label
                Label labCorrectans = (Label)ri.FindControl("lCorrectAns");
                Label Userselectedanswer = (Label)ri.FindControl("lUserSelectedOption");

                if (!rb1.Checked && !rb2.Checked && !rb3.Checked && !rb4.Checked)
                {
                    Label Wronganswer = (Label)ri.FindControl("lUserSelectedOption");
                    //Wronganswer.Text = "The Selected Answer <b>" + rb1.Text.ToString() + "</br> Is Wrong ";
                    Wronganswer.ForeColor = System.Drawing.Color.Red;
                    Wronganswer.Text = "Please select some answers";
                    naa = true;
                    totBool += 1;
                }
                else
                {
                    Label Wronganswer = (Label)ri.FindControl("lUserSelectedOption");
                    //Wronganswer.Text = "The Selected Answer <b>" + rb1.Text.ToString() + "</br> Is Wrong ";
                    Wronganswer.ForeColor = System.Drawing.Color.Red;
                    Wronganswer.Text = "";
                    naa = false;
                    //return;
                    //getAns = true;
                    //ckAns();
                }

                if (naa == false && totBool == 0)
                {
                    lItems.Text = "Locked";
                }
                else
                {
                    lItems.Text = "Please answer all Questions";
                }

                for (int x = 0; x < Repeater1.Items.Count; x++)
                {
                    totQuest = x + 1;
                }

                //Response.Write(totBool + "  " + naa);
            }

            if (lItems.Text == "Locked")
            {
                ckAns();
                GetStudID();
                DispRemarks();
                lItems.Text = "";
                SaveNew();
                lTotScore.Visible = true;
                lCorrect.Visible = true;
                lIncorrect.Visible = true;
                lRemarks.Visible = true;
                lStudID.Visible = true;
                lExamTaken.Visible = true;
                TakeBack();
                bSubmit.Enabled = false;
            }
        }

        private void TakeBack() 
        {
            cbSchoolYear.Enabled = true;
            cbGrade.Enabled = true;
            cbSec.Enabled = true;
            cbSubject.Enabled = true;
            rd1.Enabled = true;
            rd2.Enabled = true;
            rd3.Enabled = true;
            rd4.Enabled = true;
        }

        protected void bTake_Click(object sender, EventArgs e)
        {
            //GetStudID();
            //DateTime sGetDyt = DateTime.Now;
            //Response.Write("MyDate: " + sGetDyt.ToString("MM/dd/yyyy"));
            //string sUser = "";
            //string unsa = "";
            //string getUser = "";
            //for (int x = 8; x < lUser.Text.Length; x++)
            //{
            //    sUser += lUser.Text[x].ToString();
            //    for (int i = 0; i < sUser.Length; i++)
            //    {
            //        if (sUser[i].ToString() == "/")
            //        {
            //            return;
            //        }
            //    }
            //    //getUser = getUser + sUser.ToString();
            //    //Response.Write("" + lUser.Text[x].ToString());
            //    //Tama 
            //    //Response.Write("" + sUser.ToString());
            //    //lItems.Text = sUser.ToString();
            //}
            //Response.Write(getUser);

            if (GetExistingQuarter() == true)
            {
                Response.Write("Quarter is already taken");
                return;
            }
            else 
            {
                SecExam();
                cbSchoolYear.Enabled = false;
                cbGrade.Enabled = false;
                cbSec.Enabled = false;
                cbSubject.Enabled = false;
                rd1.Enabled = false;
                rd2.Enabled = false;
                rd3.Enabled = false;
                rd4.Enabled = false;

                lItems.Text = string.Empty;
                bTake.Visible = false;
                lCode.Text = string.Empty;
                lDesc.Text = string.Empty;
            }
            
            //if (bTake.Text == "Back")
            //{
            //    string sTotAns = lCorrect.Text;
            //    string sSubs;
            //    sSubs = sTotAns.Substring(22);
            //    Response.Write("" + sSubs);
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s_ID = "";
            string sRevID = "";
            for (int x = lUser.Text.Length - 1; x >= 8; x--)
            {
                s_ID += lUser.Text[x].ToString();
            }
            for (int i = s_ID.Length - 1; i >= 15; i--)
            {
                sRevID += s_ID[i].ToString();
            }
            Response.Write("" + sRevID.ToString());
            //string sScore = lCorrect.Text;

            //foreach (char c in sScore) 
            //{
            //    Response.Write("" + c);
            //}
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
            //foreach (RepeaterItem ri in Repeater1.Items)
            //{
            //    RadioButton rb1 = (RadioButton)ri.FindControl("rOption1");
            //    RadioButton rb2 = (RadioButton)ri.FindControl("rOption2");
            //    RadioButton rb3 = (RadioButton)ri.FindControl("rOption3");
            //    RadioButton rb4 = (RadioButton)ri.FindControl("rOption4");
            //    //Label
            //    Label labCorrectans = (Label)ri.FindControl("lCorrectAns");
            //    Label Userselectedanswer = (Label)ri.FindControl("lUserSelectedOption");

            //    if (!rb1.Checked && !rb2.Checked && !rb3.Checked && !rb4.Checked)
            //    {
            //        Label Wronganswer = (Label)ri.FindControl("lUserSelectedOption");
            //        //Wronganswer.Text = "The Selected Answer <b>" + rb1.Text.ToString() + "</br> Is Wrong ";
            //        Wronganswer.ForeColor = System.Drawing.Color.Red;
            //        Wronganswer.Text = "Please select some answers";
            //    }
            //    else
            //    {
            //        Label Wronganswer = (Label)ri.FindControl("lUserSelectedOption");
            //        //Wronganswer.Text = "The Selected Answer <b>" + rb1.Text.ToString() + "</br> Is Wrong ";
            //        Wronganswer.ForeColor = System.Drawing.Color.Red;
            //        Wronganswer.Text = "";
            //        //return;
            //        //getAns = true;
            //        //ckAns();
            //    }
            //}
        }
    }
}