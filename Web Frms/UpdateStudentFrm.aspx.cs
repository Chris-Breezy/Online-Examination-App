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
    public partial class UpdateStudentFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tFName.Focus();
                //GetSplitNym();
                tID.Text = Request.QueryString["StudentID"];
                tContact.Text = Request.QueryString["ContactNo"];
                tAddress.Text = Request.QueryString["Address"];
                tEmail.Text = Request.QueryString["Email"];
                
                GetSplitNym();
            }
        }

        private void GetSplitNym()
        {
            string sRequest = Request.QueryString["FullName"];
            //tFName.Text = "Olmoguez, Cheza Mayer";
            tFName.Text = sRequest;
            string[] sSplit = tFName.Text.Split(null);
            tFName.Text = sSplit[1];
            tMName.Text = sSplit[2];
            tLName.Text = sSplit[0].TrimEnd(',');
        }

        private void SaveUpdate() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = myCon;
            cmd.Connection = con;

            cmd.CommandText = " UPDATE tblStudent SET FName='" + tFName.Text.Trim() + "', " + 
                              " MName='"+ tMName.Text.Trim() +"', " + 
                              " LName='"+ tLName.Text.Trim() +"', " + 
                              " ContactNo='"+ tContact.Text.Trim() +"', " + 
                              " Address='"+ tAddress.Text.Trim() +"', " + 
                              " Email='"+ tEmail.Text.Trim() +"' " + 
                              " WHERE StudentID='"+ tID.Text.Trim() +"' ";

            try 
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                tFName.Focus();
                tFName.Text = string.Empty;
                tMName.Text = string.Empty;
                tLName.Text = string.Empty;
                tContact.Text = string.Empty;
                tAddress.Text = string.Empty;
                tEmail.Text = string.Empty;
                lError.Text = "Data Updated Successfully";
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

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (tID.Text == string.Empty || tFName.Text == string.Empty || tMName.Text == string.Empty
                || tLName.Text == string.Empty || tContact.Text == string.Empty || tEmail.Text == string.Empty)
            {
                lError.Text = "Please fill all details";
                tFName.Focus();
                return;
            }

            SaveUpdate();
        }
    }
}