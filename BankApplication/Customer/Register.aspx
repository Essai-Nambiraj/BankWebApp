<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BankApplication.Customer.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Create Bank Account</h2>
            <asp:TextBox ID="txtName" runat="server" placeholder="Enter Full Name" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator0" runat="server" ErrorMessage="Enter Name" ControlToValidate="txtName" ForeColor="Red"> </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtPhone" runat="server" placeholder="Phone number" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Phone Number" ControlToValidate="txtPhone" ForeColor="Red"> </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtAddress" runat="server" placeholder="Address"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Full Address" ControlToValidate="txtAddress" ForeColor="Red"> </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email address"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Email" ControlToValidate="txtEmail" ForeColor="Red"> </asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="ddlAccountType" runat="server" >
                <asp:ListItem Text="Select Account Type" Value=""></asp:ListItem>
                <asp:ListItem Text="Savings Account" Value="Savings"></asp:ListItem>
                <asp:ListItem Text="Current Account" Value="Current"></asp:ListItem>
                <asp:ListItem Text="FIxed Depodit (FD)" Value="FD"></asp:ListItem>
            </asp:DropDownList>

            <asp:TextBox ID="txtUserName" runat="server" placeholder="Enter Username"></asp:TextBox>
            <asp:Label ID="lblExist" runat="server" ForeColor="Red" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Username" ControlToValidate="txtUserName" ForeColor="Red"> </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  placeholder="Enter Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Password" ControlToValidate="txtPassword" ForeColor="Red"> </asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"></asp:Button>
            <br />            
        </div>
        <asp:Label ID="lblAccount" runat="server" Text="Already have an acccount?" ></asp:Label>
        <asp:LinkButton ID="btnCustLogin" runat="server" Text="User Login"  OnClick="btnCustLogin_Click" CausesValidation="false" ></asp:LinkButton>
        <br />
        <asp:Button ID="btnAdmin" runat="server" Text="Admin Login" OnClick="btnAdmin_Click" CausesValidation="false"></asp:Button>
    </form>
</body>
</html>
