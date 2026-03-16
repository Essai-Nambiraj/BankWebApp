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
    public partial class Transfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountNumber"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            
            if (!IsPostBack)
            {
                lblSender.Text = Session["AccountNumber"].ToString();
            }
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            if (Session["OTP"] == null)
            {
                Response.Write("<script>alert('Generate OTP first')</script>");
                return;
            }

            int enteredOTP = Convert.ToInt32(txtOTP.Value);
            int realOTP = Convert.ToInt32(Session["OTP"]);

            if(enteredOTP != realOTP)
            {
                Response.Write("<script>alert('Invalid OTP')</script>");
                return;
            }

            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            string senders = Session["AccountNumber"].ToString();
            string receiver = txtReceiver.Value;
            decimal amount = Convert.ToDecimal(txtAmount.Value);

            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                //Check Sender Balance
                string query = "Select Balance from Customers where AccountNumber = @Acc";
                SqlCommand checkBalance = new SqlCommand(query, con, transaction);
                checkBalance.Parameters.AddWithValue("@Acc", senders);
                decimal balance = Convert.ToDecimal(checkBalance.ExecuteScalar());

                if(balance < amount)
                {
                    Response.Write("<script>alert('Insufficient Balance')</script>");
                    transaction.Rollback();
                    con.Close();
                    return;
                }

                //Deduct Sender Balance
                string query1 = "Update Customers Set Balance = Balance - @Amount where AccountNumber = @Sender";
                SqlCommand deduct = new SqlCommand(query1, con, transaction);

                deduct.Parameters.AddWithValue("@Amount", amount);
                deduct.Parameters.AddWithValue("@Sender", senders);

                deduct.ExecuteNonQuery();

                //Add Receivers Balance
                string query2 = "Update Customers Set Balance = Balance + @Amount where AccountNumber = @Receiver";
                SqlCommand add = new SqlCommand(query2, con, transaction);

                add.Parameters.AddWithValue("@Amount", amount);
                add.Parameters.AddWithValue("@Receiver", receiver);

                int rows = add.ExecuteNonQuery();

                if(rows == 0)
                {
                    Response.Write("<script>alert('Receiver Account Not Found!!!')</script>");
                    transaction.Rollback();
                    con.Close();
                    return;
                }

                //Insert Sender Tranaction
                string senderQuery = "Insert into Transactions(AccountNumber, Type, Amount, Description, Date) Values(@Acc, 'Transfer', @Amt, 'Transfer sent', GETDATE())";

                SqlCommand t1 = new SqlCommand(senderQuery, con, transaction);

                t1.Parameters.AddWithValue("@Acc", senders);
                t1.Parameters.AddWithValue("@Amt", amount);

                t1.ExecuteNonQuery();

                //Insert Receiver Tranaction
                string receiverQuery = "Insert into Transactions(AccountNumber, Type, Amount, Description, Date) Values(@Acc, 'Transfer', @Amt, 'Transfer Received', GETDATE())";
                SqlCommand t2 = new SqlCommand(receiverQuery, con, transaction);

                t2.Parameters.AddWithValue("@Acc", receiver);
                t2.Parameters.AddWithValue("@Amt", amount);

                t2.ExecuteNonQuery();

                transaction.Commit();

                Session["OTP"] = null;

                Response.Write("<script> alert('Transaction Successfull'); window.location='../Customer/Dashboard.aspx';</script>");

            }
            catch(Exception ex)
            {
                transaction.Rollback();
                Response.Write("<script> alert('Transaction Failed: " +ex.Message + "');</script>");
            }
            con.Close();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Customer/Dashboard.aspx");
        }

        protected void btnGenerateOTP_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int otp = rnd.Next(100000, 999999);
            Session["OTP"] = otp;

            Response.Write("<script>alert('Your OTP is: " + otp + "')</script>");
        }
    }
}