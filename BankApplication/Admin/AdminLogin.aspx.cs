using BankApplication.Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            string query = "Select * from Admins where Username=@u AND Password=@p";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@u", txtUser.Value);
            cmd.Parameters.AddWithValue("@p", txtPass.Value);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["Admin"] = txtUser.Value;
                Response.Redirect("AdminDashboard.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Write("<script>alert('Invalid Login')</script>");
            }

            con.Close();

        }

        protected void txtBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Customer/Register.aspx");
        }
    }
}