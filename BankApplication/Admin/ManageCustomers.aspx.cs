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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }

            if (!IsPostBack)
            {
                LoadCustomers();
            }
        }

        //Load All Customers
        void LoadCustomers()
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            string query = "Select AccountNumber, Username, Balance from Customers";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            gvCustomers.DataSource = dt;
            gvCustomers.DataBind();

        }

        protected void txtBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }

        //Search Customers
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            string query = "SELECT AccountNumber, Username, Balance FROM Customers WHERE Username LIKE @Search OR AccountNumber LIKE @Search";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            da.SelectCommand.Parameters.AddWithValue("@Search", "%"+txtSearch.Value+"%");

            DataTable dt = new DataTable();

            da.Fill(dt);

            gvCustomers.DataSource = dt;
            gvCustomers.DataBind();
            
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        //Edit Button
        protected void gvCustomers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCustomers.EditIndex = e.NewEditIndex;
            LoadCustomers();
        }

        protected void gvCustomers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCustomers.EditIndex = -1;
            LoadCustomers();
        }

        protected void gvCustomers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string acc = gvCustomers.DataKeys[e.RowIndex].Value.ToString();
            string username = ((TextBox)gvCustomers.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            decimal balace = Convert.ToDecimal(((TextBox)gvCustomers.Rows[e.RowIndex].Cells[2].Controls[0]).Text);


            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();

            con.Open();

            string query = "UPDATE Customers SET Username=@User, Balance=@Bal WHERE AccountNumber=@Acc";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@User", username);
            cmd.Parameters.AddWithValue("@Bal", balace);
            cmd.Parameters.AddWithValue("@Acc", acc);

            cmd.ExecuteNonQuery();

            con.Close();

            gvCustomers.EditIndex = -1;
            LoadCustomers();
        }

        protected void gvCustomers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string acc = gvCustomers.DataKeys[e.RowIndex].Value.ToString();

            DBConnection db = new DBConnection();
            SqlConnection con = db.GetConnection();
            con.Open();

            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                string query1 = "DELETE FROM Customers WHERE AccountNumber=@Acc";
                SqlCommand cmd1 = new SqlCommand(query1, con, transaction);

                cmd1.Parameters.AddWithValue("@Acc", acc);
                cmd1.ExecuteNonQuery();


                string query2 = "DELETE FROM Transactions WHERE AccountNumber=@Acc";
                SqlCommand cmd2 = new SqlCommand(query2, con, transaction);

                cmd2.Parameters.AddWithValue("@Acc", acc);

                cmd2.ExecuteNonQuery();

                transaction.Commit();

                Response.Write("<script>alert('Customer Removed Successfully')</script>");

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Response.Write("<script>alert('Delete Failed:" + ex.Message + "')</script>");
            }

            con.Close();
            LoadCustomers();
        }
    }
}