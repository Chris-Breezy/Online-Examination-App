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
    public partial class SchoolYearFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                tID.Focus();
            }
        }

        private bool ckDupID()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select * from  tblSchoolYear " + " where SchoolYearID='" + tID.Text.Trim() + "' ";

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

        private void SaveNew() 
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " INSERT INTO tblSchoolYear(SchoolYearID,SchoolYear) " + 
                              " VALUES('"+ tID.Text.Trim() +"','"+ tYear.Text.Trim() +"') ";

            try 
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                tID.Text = string.Empty;
                tYear.Text = string.Empty;
                tID.Focus();
                lYear.Text = "Data Successfully Save";
            }
            catch (Exception ex) 
            {
                lYear.Text = "Error...Save..." + ex.Message;
                con.Close();
            }
            finally 
            {
                con.Close();
            }
        }

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (tID.Text == string.Empty || tYear.Text == string.Empty) 
            {
                lYear.Text = "Please fill all details";
                tID.Focus();
                return;
            }

            if (ckDupID() == true) 
            {
                lYear.Text = "ID is Already Exist";
                tID.Focus();
                return;
            }

            SaveNew();
        }
    }
}