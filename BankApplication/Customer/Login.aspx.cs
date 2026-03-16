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
    }
}