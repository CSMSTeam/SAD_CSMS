<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageProduct.aspx.cs" Inherits="ManageProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblProductID" runat="server" Text="ID: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProductID" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Label ID="lblProductImportPrice" runat="server" Text="Import Price: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProductImportPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProductName" runat="server" Text="Name: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Label ID="lblProductUnitPrice" runat="server" Text="Unit Price: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProductUnitPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProductCategory" runat="server" Text="Category ID: "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCategories" runat="server" Height="22px" Width="131px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Label ID="lblProductQuantity" runat="server" Text="Quantity: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProductQuantity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProductSatus" runat="server" Text="Status: "></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rdoProductStatus" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                     <asp:ListItem Value="True">Active</asp:ListItem><asp:ListItem Value="False">Deactive</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style1"></td>
                <td></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" Text="New" />
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvProducts" runat="server" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
