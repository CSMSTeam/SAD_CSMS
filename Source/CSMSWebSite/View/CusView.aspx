<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CusView.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvCusProduct" runat="server" AllowPaging="True" OnSelectedIndexChanged="gvCusProduct_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Add To Cart" />
            </Columns>
        </asp:GridView>
        <br />
        
        <%Order order = (Order)Session["Order"];
          if (order != null)
          {
              Response.Write("<h1>" + order.CustOrderCode + "</h1>");
              if (order.Products.Count == 0)
              {
                  Response.Write("<h1>Empty Cart ! Please buy more ^_^ </h1>");
              }
              else
              { 
         %>  
            <table border="1">
                <tr>
                    <td><b>ID</b></td>
                    <td><b>Name</b></td>
                    <td><b>Quantity</b></td>
                    <td><b>Price</b></td>
                </tr>               
                <%
                  foreach (Product p in order.Products)
                  {
                      Response.Write("<tr><td>" + p.ProductID + "</td>");
                      Response.Write("<td>" + p.ProductName + "</td>");
                      Response.Write("<td>" + p.ProductQuantity + "</td>");
                      Response.Write("<td>" + p.ProductPrice + "</td></tr>");
                  }
                  Response.Write("<tr><td colspan=\"3\" style=\"font-weight: 700\">Total: </td><td style=\"font-weight: 700\">" + order.getTotal() + "</td></tr>"); 
                %>
                <tr>
                    <td>
                        <asp:Label ID="lblCusAddress" runat="server" Text="Adress"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCusAddress" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblCusPhone" runat="server" Text="Phone: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCusPhone" runat="server"></asp:TextBox>
                    </td>
                </tr>                
                <tr>
                    <td colspan="2">
                        
                        <asp:Button ID="btnOrder" runat="server" OnClick="btnOrder_Click" Text="Order" />
                        
                    </td>
                    <td>
                                                
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                                                
                    </td>
                   <td>
                       
                    </td>
                </tr>  
                <%}  } %>                      
            </table>
    </div>
    </form>
</body>
</html>
