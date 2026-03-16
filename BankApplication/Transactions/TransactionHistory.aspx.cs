using BankApplication.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication.Transactions
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountNumber"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadTransaction();
            }
        }

        void LoadTransaction()
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            string accNo = Session["AccountNumber"].ToString();

            string query = "Select * from Transactions where AccountNumber = @AccNo Order By Date DESC";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@AccNo", accNo);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            gvTransactions.DataSource = dt;
            gvTransactions.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Customer/Dashboard.aspx");
        }
    }
}