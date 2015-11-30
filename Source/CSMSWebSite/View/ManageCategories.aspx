<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageCategories.aspx.cs" Inherits="ManageCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 58px;
        }
        #txtCategoryDescripton {
            height: 59px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblCategoryID" runat="server" Text="ID:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCategoryID" runat="server"></asp:TextBox>
                </td>
                <td></td>
                <td>
                    <asp:Label ID="lblCategoryDescription" runat="server" Text="Description: "></asp:Label>
                </td>
                <td rowspan="3">
                    <asp:TextBox ID="txtCategoryDescription" runat="server" Height="61px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCategoryName" runat="server" Text="Name: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
            </tr>
             <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" />
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="grvCategories" runat="server" OnSelectedIndexChanged="grvCategories_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
