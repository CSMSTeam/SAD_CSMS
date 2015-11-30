<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="View_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Resource/css/bootstrap.css" rel="stylesheet" />
    <link href="../Resource/LoginForm/css/style.css" rel="stylesheet" />
    <script src="../Resource/LoginForm/login.js"></script>
</head>
<body>
    <div class="login-form">    
    <div class="head">
			<img src="../Resource/image/me.jpg" />
    </div>  
    <form id="form1" runat="server">                  
        <table style="border-collapse: separate; border-spacing: 10px 10px;">
			<tr>
				<td><asp:TextBox ID="txtUsername" runat="server" placeholder="USERNAME" ></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ID="txtPassword" runat="server" placeholder="PASSWORD" TextMode="Password"></asp:TextBox> </td>
			</tr>            
		</table>
        <div class="p-container">		
                <asp:Button ID="btnLogin" runat="server" Text="Login" />
		    <div class="clear"></div>
		</div>
     </form>        
     </div>
</body>
</html>
