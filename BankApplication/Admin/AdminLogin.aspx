<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="BankApplication.Admin.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <asp:Button ID="txtBack" runat="server" Text="Back" OnClick="txtBack_Click" CssClass="btn" CausesValidation="false"/>

            <h2>Admin Login</h2>
            <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">

                <input type="text" id="txtUser" runat="server" placeholder="Username" />
                <asp:RequiredFieldValidator ID="user" runat="server" ErrorMessage="Enter Username" ControlToValidate="txtUser" ForeColor="Red">  </asp:RequiredFieldValidator>

                <input  type="password" id="txtPass" runat="server" placeholder="Password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Password" ControlToValidate="txtPass" ForeColor="Red"> </asp:RequiredFieldValidator>

                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
            </asp:Panel>

        </div>
    </form>
</body>
</html>
