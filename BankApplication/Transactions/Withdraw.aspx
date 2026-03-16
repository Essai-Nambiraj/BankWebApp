<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="BankApplication.Transactions.Withdraw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Withdraw Amount</title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>
    <style>
        button:hover{
            background: #218838;
        }
    </style>

    <script>
        function validateWithdraw() {
            var amount = document.getElementById("txtAmount").value;
            if (amount == null || amount <= 0) {
                alert("Enter valid amount to Withdraw");
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h2>Withdraw Amount</h2><hr />
            <h3>Account Number</h3>
            <br />
            <asp:Label ID="lblAccount" runat="server" ></asp:Label>
            <br /><br />
            <input type="number" id="txtAmount" runat="server" placeholder="Enter Amouht to Withdraw"/>
            <br />
            <asp:RequiredFieldValidator ID="pass" runat="server" ControlToValidate="txtAmount" ErrorMessage="Please enter a Withdraw Amount" ForeColor="Red" />
            <br />
            <asp:Button ID="btnWithdraw" runat="server" Text="Withdraw" CssClass="btn" OnClientClick="return validateWithdraw()"
                OnClick="btnWithdraw_Click"/>
            <br />

            <asp:Button ID="btnBack" runat="server" Text="Back to DashBoard" CssClass="btn" OnClick="btnBack_Click" CausesValidation="false" />
            

        </div>
    </form>
</body>
</html>
