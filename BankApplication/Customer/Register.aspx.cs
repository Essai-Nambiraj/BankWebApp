using System;
using System.Data.SqlClient;
using BankApplication;
using Microsoft.AspNet.FriendlyUrls;

namespace BankApplication.Customer
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            //string accountType = ddlAccountType.SelectedValue;

            con.Open();
            string q = "Select * from Customers where Username=@usern";

            SqlCommand cmd1 = new SqlCommand(q, con);
            cmd1.Parameters.AddWithValue("@usern", txtUserName.Text);

            SqlDataReader sdr = cmd1.ExecuteReader();
            if (sdr.HasRows)
            {
                lblExist.Text = "Username or Account already exist";
                con.Close();
                return;
            }
            else
            {
                sdr.Close();
                string accNo = "ACC" + new Random().Next(10000, 99999);

                string query = "Insert into Customers(Name, Email, Phone, Address, Username, Password, AccountNumber, AccountType, Balance, Status) " +
                    "Values(@Name, @Email, @Phone, @Address, @Username, @Password, @AccNo, @AccType,0, 'Pending')";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);             
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@AccNo", accNo);
                cmd.Parameters.AddWithValue("@AccType", ddlAccountType.SelectedItem.Text);


                cmd.ExecuteNonQuery();
            }

            con.Close();

            Response.Redirect("Login.aspx");

        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Admin/AdminLogin.aspx");
        }

        protected void btnCustLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}