<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTransactions.aspx.cs" Inherits="BankApplication.Admin.ViewTransactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <asp:Button ID="txtBack" runat="server" Text="Back" OnClick="txtBack_Click"/>
            <asp:GridView ID="gvTransactions" runat="server" ></asp:GridView>

        </div>
    </form>
</body>
</html>
