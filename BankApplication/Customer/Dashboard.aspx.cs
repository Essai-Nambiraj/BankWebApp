using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication.Customer
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            if (Session["AccountNumber"] == null)
            {
                Response.Redirect("Login.aspx");
            }

           
            if (Session["AccountNumber"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadAccountDetails();
            }
        }

        void LoadAccountDetails()
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            string accNo = Session["AccountNumber"].ToString();
           
            string query = "Select AccountNumber, AccountType, Balance from Customers where AccountNumber=@acc";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@acc", Session["AccountNumber"].ToString());

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lblAccount.Text = dr["AccountNumber"].ToString();
                lblAccountType.Text = dr["AccountType"].ToString();
                lblBalance.Text = dr["Balance"].ToString();
            }
            dr.Close();
            con.Close();

        }

        protected void btnDeposit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Transactions/Deposit.aspx");
        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Transactions/Withdraw.aspx");
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Transactions/Transfer.aspx");
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Transactions/TransactionHistory.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
           
            Response.Redirect("../Customer/Login.aspx");
        }
    }
}