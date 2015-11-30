<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CSMSWebSiteBootStrap.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
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
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
		    <div class="clear"></div>
		</div>
     </form>        
     </div>
</body>
</html>
