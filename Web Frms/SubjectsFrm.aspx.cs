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
    public partial class SubjectsFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            tID.Focus();
            if (!IsPostBack) 
            {
                DispGrade();
            }
        }

        private void DispGrade() 
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            try
            {
                string sql = " select * from tblGrade ";

                using (da = new SqlDataAdapter(sql, con))
                {
                    con.Open();
                    da.Fill(ds, "Chupapi");
                    con.Close();

                    cbGrade.DataSource = ds.Tables[0];
                    cbGrade.DataValueField = "GradeID";
                    cbGrade.DataTextField = "Grade";
                    cbGrade.DataBind();
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

        private void Save() 
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " INSERT INTO tblSubject(SubjectID, SubjectCode, Description, GradeID) " +
                              " VALUES('" + tID.Text.Trim() +"','" + tCode.Text.Trim()  +"','" + tDesc.Text.Trim() +
                              "','" + cbGrade.SelectedValue.Trim() +"') ";

            try 
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                tID.Text = string.Empty;
                tID.Focus();
                tCode.Text = string.Empty;
                tDesc.Text = string.Empty;
                cbGrade.SelectedIndex = 0;
                lError.Text = "Data Successfully Save";
            }
            catch (Exception ex) 
            {
                lError.Text = "Error...Save..." + ex.Message;
                con.Close();
            }
            finally 
            {
                con.Close();
            }
        }

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (tID.Text == string.Empty || tCode.Text == string.Empty || tDesc.Text == string.Empty || cbGrade.SelectedIndex == -1)
            {
                lError.Text = "Please fill all description to proceed";
                tID.Focus();
                return;
            }

            Save();

        }
    }
}