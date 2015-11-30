<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageAccount.aspx.cs" Inherits="ManageAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 20px;
        }
        .auto-style2 {
            width: 125px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <strong>CSMS Manage Account</strong><br />
        <br />
        <table border="1">
            <tr>
                <td><asp:Label ID="lblEmpCode" runat="server" Text="Code: "></asp:Label></td>
                <td><asp:TextBox ID="txtEmpCode" runat="server"></asp:TextBox></td>
                <td class="auto-style1">&nbsp;</td>
                <td><asp:Label ID="lblEmpAddress" runat="server" Text="Address: "></asp:Label></td>
                <td class="auto-style2"><asp:TextBox ID="txtEmpAddress" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblEmpName" runat="server" Text="Name: "></asp:Label></td>
                <td><asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox></td>
                <td class="auto-style1"></td>
                <td>
                    <asp:Label ID="lblEmpPhone" runat="server" Text="Phone: "></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtEmpPhone" runat="server"></asp:TextBox>
                </td>
            </tr>            
            <tr>
                <td>
                    <asp:Label ID="lblEmpUsername" runat="server" Text="Username: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpUsername" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
                <td><asp:Label ID="lblEmpCity" runat="server" Text="City: "></asp:Label></td>
                <td class="auto-style2"><asp:TextBox ID="txtEmpCity" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmpPassword" runat="server" Text="Password: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpPassword" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
                <td>
                    <asp:Label ID="lblEmpCountry" runat="server" Text="Country: "></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtEmpCountry" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblEmpRole" runat="server" Text="Role: "></asp:Label></td>
                <td><asp:TextBox ID="txtEmpRole" runat="server"></asp:TextBox></td>
                <td class="auto-style1"></td>
                <td>
                    <asp:Label ID="lblEmpSalary" runat="server" Text="Salary: "></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtEmpSalary" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblEmpSex" runat="server" Text="Sex: "></asp:Label></td>
                <td><asp:TextBox ID="txtEmpSex" runat="server"></asp:TextBox></td>
                <td class="auto-style1"></td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Hours works: "></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtEmpHoursWork" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblEmpBrithdate" runat="server" Text="Brithdate: "></asp:Label></td>
                <td><asp:TextBox ID="txtEmpBrithdate" runat="server"></asp:TextBox></td>
                <td class="auto-style1"></td>
                <td>
                    <asp:Label ID="lblEmpMgrid" runat="server" Text="ManageID: "></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtEmpMgrID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblEmpHiredate" runat="server" Text="Hiredate: "></asp:Label></td>
                <td><asp:TextBox ID="txtEmpHiredate" runat="server"></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:Label ID="lblEmpStatus" runat="server" Text="Status: "></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rdoPriceRange" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                     <asp:ListItem Value="True">Active</asp:ListItem><asp:ListItem Value="False">Deactive</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" Text="New" />
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Save" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                </td>
            </tr>
            
        </table>
        
        <asp:GridView ID="gvEmployees" runat="server" OnSelectedIndexChanged="gvEmployees_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
