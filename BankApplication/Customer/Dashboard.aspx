<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BankApplication.Customer.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer DashBoard</title>
    <style>
        
    </style>
    <link rel="stylesheet" href="../Styles/BankApp.css"/>
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="dashboard-box">
             <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn" OnClick="btnLogout_Click" />
            <div class="labels">
                 <h2>Bank Dashboard</h2>
                 <hr />
                 <h3>Account Number</h3>
                 <asp:Label ID="lblAccount" runat="server" CssClass="labels" ></asp:Label>
                 <h3>Account Type</h3>
                 <asp:Label ID="lblAccountType" runat="server" CssClass="labels"></asp:Label>
             </div>
             <div class="balance">
                <h3>Current Balance</h3>
                <asp:Label ID="lblBalance" runat="server"></asp:Label>
            </div>
            

            <br />
            <asp:Button ID="btnDeposit" runat="server" Text="Deposit Money" CssClass="btn" OnClick="btnDeposit_Click"/>
            <asp:Button ID="btnWithdraw" runat="server" Text="Withdraw Money" CssClass="btn"  OnClick="btnWithdraw_Click"/>
            <asp:Button ID="btnTransfer" runat="server" Text="Transfer Money" CssClass="btn"  OnClick="btnTransfer_Click"/>
            <asp:Button ID="btnHistory" runat="server" Text="Transaction History" CssClass="btn" OnClick="btnHistory_Click"/>
        </div>
    </form>
</body>
</html>
