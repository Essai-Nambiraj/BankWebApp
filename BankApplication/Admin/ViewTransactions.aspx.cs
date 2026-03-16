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
    public partial class ViewTransactions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTransactions();
            }
        }

        void LoadTransactions()
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            string query = "Select * from Transactions Order By Date desc";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            gvTransactions.DataSource = dt;
            gvTransactions.DataBind();
        }

        protected void txtBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}