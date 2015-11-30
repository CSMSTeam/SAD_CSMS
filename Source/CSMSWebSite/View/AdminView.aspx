<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminView.aspx.cs" Inherits="AdminView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnManageAccount" runat="server" OnClick="btnManageAccount_Click" Text="Manage Account" />
        <asp:Button ID="btnAdminReport" runat="server" Text="View Report" />
    
    </div>
    </form>
</body>
</html>
