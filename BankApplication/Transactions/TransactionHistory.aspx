<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="BankApplication.Transactions.TransactionHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box-table">
             <asp:Button ID="btnBack" runat="server" Text="Back to Dashboard" CssClass="btn" OnClick="btnBack_Click" />
            <h2>Transaction History</h2>
            <hr />
            <asp:GridView ID="gvTransactions" runat="server" CssClass="grid" AutoGenerateColumns="false" Width="100%" BorderStyle="Solid" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" />
                    <asp:BoundField DataField="Type" HeaderText="Type" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount (Rs.)" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                </Columns>
            </asp:GridView>
            <br />

           
            
        </div>
    </form>
</body>
</html>
