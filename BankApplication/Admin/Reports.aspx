<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="BankApplication.Admin.Reports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box-table">
            <asp:Button ID="txtBack" CssClass="btn" runat="server" Text="Back" OnClick="txtBack_Click" />
            <h2>Bank Reports</h2>

            <table class="table">
                <tr>
                    <td>Total Customers</td>
                    <td><asp:Label ID="lblTotalCustommers" runat="server" ></asp:Label></td>
                </tr>
                <tr>
                    <td>Total Money In Bank</td>
                    <td><asp:Label ID="lblTotalMoney" runat="server" ></asp:Label></td>
                </tr>
                <tr>
                    <td>Total Transactions</td>
                    <td><asp:Label ID="lblTotalTransactions" runat="server" ></asp:Label></td>
                </tr>
                <tr>
                    <td>Total Credit</td>
                    <td><asp:Label ID="lblTotalCredit" runat="server" ></asp:Label></td>
                </tr>
                <tr>
                    <td>Total Debit</td>
                    <td><asp:Label ID="lblTotalDebit" runat="server" ></asp:Label></td>
                </tr>
                <tr>
                    <td>Tally </td>
                    <td><asp:Label ID="lblTally" runat="server" ></asp:Label></td>
                </tr>
            </table>

            <br />
            <asp:GridView ID="gvTransactions" runat="server" CssClass="table" AutoGenerateColumns="true">

            </asp:GridView>
        </div>
    </form>
</body>
</html>
