<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCustomers.aspx.cs" Inherits="BankApplication.Admin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Customers</title>
    <link href="../Styles/BankApp.css" rel="stylesheet"/>
    <script>
        function confirmDelete() {
            confirm("Are you want to sure to delete this Customer data and All the transaction, permanently?");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box-table">
            <asp:Button ID="txtBack" runat="server" CssClass="btn" Text="Back" OnClick="txtBack_Click" />

            <h2>Manage Customers</h2>
            <!-- Search Section -->
            Search Customer:
            <input type="text" id="txtSearch" runat="server" placeholder="Enter Account Number or Username" />

            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnSearch_Click" />

            <asp:Button ID="btnShowAll" runat="server" Text="Show All" CssClass="btn" OnClick="btnShowAll_Click" />
            <br /><br />

            <!-- Customer Grid -->

            <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" DataKeyNames="AccountNumber" OnRowEditing="gvCustomers_RowEditing" OnRowCancelingEdit="gvCustomers_RowCancelingEdit" 
                OnRowUpdating="gvCustomers_RowUpdating" OnRowDeleting="gvCustomers_RowDeleting" CssClass="table" >

                <Columns>
                    <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" ReadOnly="true" />
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Balance" HeaderText="Balance" />
                    <asp:CommandField HeaderText="Edit" ShowEditButton="true" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Remove Customer" CommandName="Delete" CssClass="btn-danger" OnClientClick="return confirmDelete()" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>


        </div>
    </form>
</body>
</html>
