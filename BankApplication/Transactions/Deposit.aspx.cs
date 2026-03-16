using BankApplication.Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication.Transactions
{
    public partial class Deposit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountNumber"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                lblAccount.Text = Session["AccountNumber"].ToString();
            }
        }

        protected void btnDeposit_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            string accNo = Session["AccountNumber"].ToString();
            decimal amount = Convert.ToDecimal(txtAmount.Value);

            con.Open();

            //Update Balance
            string query = "Update Customers set Balance = Balance + @Amount where AccountNumber = @AccNo";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.Parameters.AddWithValue("@AccNo", accNo);

            cmd.ExecuteNonQuery();

            //Insert transaction record
            string query2 = "Insert into Transactions(AccountNumber, Type, Amount, Description, Date) Values(@Acc, 'Deposit', @Amt, 'Cash Deposit', GETDATE())";
            SqlCommand cmd2 = new SqlCommand(query2, con);

            cmd2.Parameters.AddWithValue("@Acc", accNo);
            cmd2.Parameters.AddWithValue("@Amt", amount);

            cmd2.ExecuteNonQuery();

            con.Close();

            Response.Write("<script> alert('Deposit Successfull'); window.location='../Customer/Dashboard.aspx'; </script>");
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Customer/Dashboard.aspx");
        }
    }
}