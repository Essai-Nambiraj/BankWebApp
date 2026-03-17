<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveAccounts.aspx.cs" Inherits="BankApplication.Admin.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <asp:Button ID="txtBack" runat="server" Text="Back"  CssClass="btn"  OnClick="txtBack_Click" />
            <asp:GridView ID="gvPending" runat="server" AutoGenerateColumns="false" OnRowCommand="gvPending_RowCommand" >
                <Columns>
                    <asp:BoundField DataField="CustomerID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="AccountNumber" HeaderText="Account" />
                    <asp:ButtonField ButtonType="Button" CommandName="Approve" Text="Approve" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>