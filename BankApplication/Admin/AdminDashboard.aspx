<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="BankApplication.Admin.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>

    <script>
        function confirmLogout() {
            confirm("Are you want to sure to Logout?");
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="box">

            <h2>Admin DashBoard</h2>
            <h3>Welcome,
                <asp:Label ID="lblAdminName" runat="server"></asp:Label>

            </h3>
            

            <br />
            <asp:Button runat="server" Text="Approve Accounts" CssClass="btn" PostBackUrl="~/Admin/ApproveAccounts.aspx" />
            <asp:Button runat="server" Text="Manage Customers" CssClass="btn" PostBackUrl="~/Admin/ManageCustomers.aspx" />
            <asp:Button runat="server" Text="View Transactions" CssClass="btn" PostBackUrl="~/Admin/ViewTransactions.aspx" />
            <asp:Button runat="server" Text="Reports" CssClass="btn" PostBackUrl="~/Admin/Reports.aspx" />
            <asp:Button runat="server" Text="View Loans" CssClass="btn" PostBackUrl="~/Admin/ApproveLoan.aspx" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" PostBackUrl="~/Admin/AdminLogin.aspx"  CssClass="btn" OnClick="btnLogout_Click" OnClientClick="return confirmLogout()" />
        </div>
    </form>
</body>
</html>
