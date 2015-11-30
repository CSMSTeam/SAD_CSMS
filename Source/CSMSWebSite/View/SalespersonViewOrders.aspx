<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalespersonViewOrders.aspx.cs" Inherits="SalespersonViewOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 33px;
        }
        .auto-style2 {
            height: 55px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbListOrder" runat="server" style="font-weight: 700" Text="List Of Orders"></asp:Label>
                </td>
                <td></td>
                <td>
                    <asp:Label ID="lblOrderDetail" runat="server" style="font-weight: 700"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvOrders" runat="server" OnSelectedIndexChanged="gvOrders_SelectedIndexChanged">
                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Detail" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td class="auto-style1">

                </td>
                <td colspan="2">

                    <asp:GridView ID="gvOrderDetail" runat="server">
                    </asp:GridView>
    
                    <br />
                    <asp:Label ID="lblTotalPrice" runat="server" style="font-weight: 700"></asp:Label>
                    <br />

                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="btnAccept" runat="server" OnClick="btnAccept_Click" Text="Accept" Visible="False" />
                </td>
                <td>
                    <asp:Button ID="btnDeny" runat="server" OnClick="btnDeny_Click" Text="Deny" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDeliveringOrder" runat="server" style="font-weight: 700" Text="List Of Delivering Orders" Visible="False"></asp:Label>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDeliveringOrder" runat="server" OnRowCommand="gvDeliveringOrder_RowCommand">
                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="Success" Text="Success" />
                            <asp:ButtonField ButtonType="Button" CommandName="Fail" Text="Fail" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:GridView ID="gvOrderDetailTemp" runat="server" Visible="False">
                    </asp:GridView>
                </td>
                <td></td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
