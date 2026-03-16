<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deposit.aspx.cs" Inherits="BankApplication.Transactions.Deposit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Money Deposit</title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>
    <style>
        button:hover{
            background: #218838;
        }
    </style>

    <script>
        function validateDeposit() {
            var amount = document.getElementById("txtAmount").value;
            if (amount == "" || amount <= 0) {
                alert("Enter valid Deposit Amount");
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="boc">
            <h2>Deposit Money</h2>
            <hr />
            <h3>Account Number</h3>
            <asp:Label ID="lblAccount" runat="server" ></asp:Label>
            <br /><br />
            <input type="number" id="txtAmount" runat="server" placeholder="Enter Amount to Deposit"/>
            <asp:RequiredFieldValidator ID="pass" runat="server" ControlToValidate="txtAmount" ErrorMessage="Please enter a Deposit Amount" ForeColor="Red" />

            <br />
            <asp:Button ID="btnDeposit" runat="server" Text="Deposit" CssClass="btn" OnClientClick="return validateDeposit()"
                OnClick="btnDeposit_Click"/>
            <br />

            <asp:Button ID="btnBack" runat="server" Text="Back to DashBoard" CssClass="btn" OnClick="btnBack_Click" CausesValidation="false"/>

        </div>
    </form>
</body>
</html>
