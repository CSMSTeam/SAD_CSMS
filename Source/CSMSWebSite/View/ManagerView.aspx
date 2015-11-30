<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerView.aspx.cs" Inherits="ManagerView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnManageProduct" runat="server" OnClick="btnManageProduct_Click" Text="Manage Product" />
        <asp:Button ID="btnViewReport" runat="server" Text="View Report" />
    
    </div>
    </form>
</body>
</html>
