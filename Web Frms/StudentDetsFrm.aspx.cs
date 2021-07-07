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
    public partial class StudentDetsFrm : System.Web.UI.Page
    {
        string myCon = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DispGrid();
        }
        private void DispGrid() 
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = myCon;

            string sql = " select StudentID, LName + ', ' + FName + ' ' + MName as FullName, ContactNo, [Address], Email from tblStudent ";

            try 
            {
                con.Open();
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Studs");
                con.Close();
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex) 
            {
                Response.Write("Error...Studs..." + ex.Message);
                con.Close();
            }
            finally 
            {
                con.Close();
            }

        }
    }
}