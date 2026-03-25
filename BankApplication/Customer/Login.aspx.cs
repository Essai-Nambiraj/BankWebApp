using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication.Customer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountNumber"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            con.Open();

            string q1 = "Select * from Customers where Username=@username";           

            SqlCommand cmd1 = new SqlCommand(q1, con);

            cmd1.Parameters.AddWithValue("@username", txtUser.Value);
          
            //Check username exist or not
            SqlDataReader sdr = cmd1.ExecuteReader();

            if (!sdr.HasRows)
            {
                lblUserError.Text = "Username dose not exist";
                con.Close();
                return;
            }
            sdr.Close();

            //Check Password
            string q = "Select * from Customers where Username=@u and Password=@p";

            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@u", txtUser.Value);
            cmd.Parameters.AddWithValue("@p", txtPass.Value);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                //Successful Login
                Session["AccountNumber"] = dr["AccountNumber"].ToString();
                Response.Redirect("Dashboard.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                lblPassError.Text = "Incorrect Password";
            }
            con.Close();
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnUpdatePwd_Click(object sender, EventArgs e)
        {
            string user = txtUser.Value;
            string current = txtCurrent.Text;
            string newPass = txtNew.Text;
            string confirm = txtConfirm.Text;

            if (newPass != confirm)
            {
                Response.Write("<script>alert('Password do not match.')</script>");
                return;
            }


            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            con.Open();

            //check current pwd
            string q = "Select Count(*) from Customers where Password=@pwd";
            SqlCommand check = new SqlCommand(q, con);

            check.Parameters.AddWithValue("@pwd", current);

            int count = (int)check.ExecuteScalar();

            if(count == 0)
            {
                Response.Write("<script>alert('Current Password incorrect')</script>");
                con.Close();
                return;
            }

            //update pwd
            string query = "Update Customers Set Password=@newPass where Password=@pwd AND Username=@user";
            SqlCommand update = new SqlCommand(query, con);

            update.Parameters.AddWithValue("@user", user);
            update.Parameters.AddWithValue("@pwd", current );
            update.Parameters.AddWithValue("@newPass", newPass);

            update.ExecuteNonQuery();

            con.Close();

            Response.Write("<script>alert('Password Updated Successfully')</script>");
        }
    }
}

