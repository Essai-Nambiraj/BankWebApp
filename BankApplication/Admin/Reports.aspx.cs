using BankApplication.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication.Admin
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSummary();
                LoadTransactions();
            }
        }

        void LoadSummary()
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            con.Open();

            //Total Customer
            string q = "Select COUNT(*) From Customers";
            SqlCommand cmd = new SqlCommand(q, con);
            lblTotalCustommers.Text = cmd.ExecuteScalar().ToString();

            //Total Amount in Bank
            string q1 = "SELECT SUM(Balance) from Customers";
            SqlCommand cmd1 = new SqlCommand(q1, con);
            object totalBal = cmd1.ExecuteScalar();
            lblTotalMoney.Text = totalBal == DBNull.Value ? "0" : totalBal.ToString();

            //Total transactions
            string q2 = "Select COUNT(*) from Transactions";
            SqlCommand cmd2 = new SqlCommand(q2, con);
            lblTotalTransactions.Text = cmd2.ExecuteScalar().ToString();

            //Total credited amount
            string q3 = "SELECT SUM(Amount) FROM Transactions WHERE Description='Deposit' OR Description='Transfer Received'";
            SqlCommand cmd3 = new SqlCommand(q3, con);
            object credit = cmd3.ExecuteScalar();
            decimal totalCredit = credit == DBNull.Value ? 0 : Convert.ToDecimal(credit);
            lblTotalCredit.Text = totalCredit.ToString();

            //Total Debited amount
            string q4 = "SELECT SUM(Amount) FROM Transactions WHERE Description='Withdraw' OR Description='Transfer Sent'";
            SqlCommand cmd4 = new SqlCommand(q4, con);
            object debit = cmd4.ExecuteScalar();
            decimal totalDebit = debit == DBNull.Value ? 0 : Convert.ToDecimal(debit);
            lblTotalDebit.Text = totalDebit.ToString();

            //Tally
            decimal tally = totalCredit - totalDebit;
            lblTally.Text = tally.ToString();
            con.Close();
        }

        void LoadTransactions()
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            string q = "SELECT AccountNumber, Type, Amount, Description, Date FROM Transactions ORDER BY Date DESC";
            SqlDataAdapter da = new SqlDataAdapter(q, con);

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