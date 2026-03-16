<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="BankApplication.Transactions.Transfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transfer Money</title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>
    <script>
        function validateTransfer() {
            var receiver = document.getElementById("txtReceiver").value;
            var amount = document.getElementById("txtAmount").value;

            if (receiver == "") {
                alert("Enter Receiver's Acount");
                return false;
            }

            if (amount <= 0 || amount == "") {
                alert("Enter valid amount to transfer");
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="box">
            <h2>Transfer Money</h2><hr />
            <h3>Sender Account</h3>
            <asp:Label ID="lblSender" runat="server"> </asp:Label>
            <br /><br />
            <input type="text" id="txtReceiver" runat="server" placeholder="Receiver Account Number"/>
            <br />
            <input type="number" id="txtAmount" runat="server" placeholder="Amount"/>
            <br />

            <asp:Button  ID="btnGenerateOTP" runat="server" Text="Generate OTP" CssClass="btn" OnClick="btnGenerateOTP_Click" OnClientClick="return validateTransfer()" />
            <br /><br />
            <input type="text" id="txtOTP" runat="server" placeholder="Enter OTP" />

            <br />

            <asp:Button ID="btnTransfer" runat="server" Text="Transfer" CssClass="btn" OnClientClick="return validateTransfer()"
                OnClick="btnTransfer_Click"/>
            <br />

            <asp:Button ID="btnBack" runat="server" Text="Back to DashBoard" CssClass="btn" OnClick="btnBack_Click"/>
        </div>
    </form>
</body>
</html>
