using BankApplication.Customer;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication.Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPending();
            }
        }

        void LoadPending()
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            string query = "Select CustomerID, Name, AccountNumber from Customers where status='Pending'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            gvPending.DataSource = dt;
            gvPending.DataBind();
        }

        protected void gvPending_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string id = gvPending.Rows[index].Cells[0].Text;

                DBConnection db = new DBConnection();
                SqlConnection con = db.GetConnection();

                string query = "Update Customers set Status = 'Approved' where CustomerID=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                LoadPending();
            }

        }

        protected void txtBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}