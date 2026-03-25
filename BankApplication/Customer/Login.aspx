<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BankApplication.Customer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-box">
            <div class="dashboard-box-login">
                <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">
                <h2>Customer Login</h2>
                <input type="text" id="txtUser" runat="server" placeholder="UserName"/>
                <asp:RequiredFieldValidator ID="user" runat="server" ErrorMessage="Enter Username" ControlToValidate="txtUser" ForeColor="Red"> * </asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblUserError" runat="server" ForeColor="Red" ></asp:Label>
                <br />
                <input type="password" id="txtPass" runat="server" placeholder="Password"/> 
                <asp:RequiredFieldValidator ID="pass" runat="server" ControlToValidate="txtPass" ErrorMessage="Please enter a password" ForeColor="Red" > * </asp:RequiredFieldValidator>
                 <asp:Label ID="lblPassError" runat="server" ForeColor="Red" ></asp:Label>
                <br />
                <asp:LinkButton ID="btnForgot" runat="server" Text="Forgot Password?" CausesValidation="false" OnClientClick="openPopup(); return false;"></asp:LinkButton>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"  CssClass="btn" />        
                <asp:Button ID="btnNewUser" runat="server" Text="Create Account" OnClick="btnNewUser_Click" CausesValidation="false"  CssClass="btn" />
                </asp:Panel>
            </div>
          <asp:ValidationSummary ID="validate" runat="server" ForeColor="Red" />
            
        </div>
        
        <div class="overlay" id="popupOverlay">
            <div class="popup">
                <h3>Change Password</h3>
                Username: 
                <asp:TextBox ID="txtUsername" runat="server" />
                <br />
                Current Password
                <asp:TextBox ID="txtCurrent" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                New Password
                <asp:TextBox ID="txtNew" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                Confirm Password
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
                <br /><br />

                <asp:Button ID="btnUpdatePwd" runat="server" Text="Update" CssClass="btn" OnClick="btnUpdatePwd_Click" CausesValidation="false" />
                
                <asp:Button ID="btnCancel" runat="server" Text="Close" CssClass="btn" OnClientClick="closePopup(); return false;" CausesValidation="false" />

                <script>
                    function openPopup() {
                        document.getElementById("popupOverlay").style.display = "block";
                    }

                    function closePopup() {
                        document.getElementById("popupOverlay").style.display = "none";
                    }

                </script>
            </div>
        </div>
    </form>
    
</body>
</html>
