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
    public partial class UpdateSubjectsFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            tCode.Focus();
            if (!IsPostBack) 
            {
                DispGrade();
                tID.Text = Request.QueryString["SubjectID"];
                tCode.Text = Request.QueryString["SubjectCode"];
                tDesc.Text = Request.QueryString["Description"];
                //cbGrade.SelectedItem.Text = Request.QueryString["GradeID"];
                //cbGrade.SelectedValue = Request.QueryString["GradeID"];
            }
        }
        private void SaveUpdate() 
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " UPDATE tblSubject SET SubjectCode='"+ tCode.Text.Trim() +"'," + 
                              " Description='"+ tDesc.Text.Trim() +"', " + 
                              " GradeID='"+ cbGrade.SelectedValue.Trim() +"'" + 
                              " WHERE SubjectID='"+ tID.Text.Trim() +"'";

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                tCode.Text = string.Empty;
                tDesc.Text = string.Empty;
                cbGrade.SelectedIndex = 0;
                lError.Text = "Data Successfully Updated";
            }
            catch (Exception ex)
            {
                lError.Text = "Error...Update..." + ex.Message;
                con.Close();
            }
            finally 
            {
                con.Close();
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

                    string sGrd = Request.QueryString["GradeID"];
                    string sRequest;
                    for (int x = 0; x < cbGrade.Items.Count; x++)
                    {
                        sRequest = cbGrade.Items[x].Text;
                        if (sGrd == sRequest)
                        {
                            cbGrade.SelectedIndex = x;
                        }
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

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (tID.Text == string.Empty || tCode.Text == string.Empty || tDesc.Text == string.Empty || cbGrade.SelectedIndex == -1)
            {
                lError.Text = "Please fill all details";
                tCode.Focus();
                return;
            }
            SaveUpdate();
        }

        protected void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}