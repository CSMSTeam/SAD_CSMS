using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Order order;
    bool notYetOrder;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCusProduct();
            order = new Order();
            Session["Order"] = order;
        }
        order = (Order)Session["Order"];
    }

    public void LoadCusProduct() {
        CSMSService.CSMSWebservice CusViewProduct = new CSMSService.CSMSWebservice();
        gvCusProduct.DataSource = CusViewProduct.CustomerLoadProduct();
        gvCusProduct.DataBind();
        notYetOrder = true;
    }
    public void CusOrder()
    {
        order.OrderAddress = txtCusAddress.Text;
        order.CusPhone = txtCusPhone.Text;
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        CSMSService.CustomerAddOrder(order.CustOrderCode, order.OrderDate,
                                        order.OrderAddress, order.getTotal(), order.CusPhone);

        foreach (Product p in order.Products)
        {
            CSMSService.CustomerInsertOrderDetail(order.CustOrderCode, p.ProductID, p.ProductPrice, p.ProductQuantity);
        }
    }

    protected void gvCusProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (notYetOrder == true)
        {
            
            notYetOrder = false;
        }
        GridViewRow r = gvCusProduct.SelectedRow;
        int ID = int.Parse(Server.HtmlDecode(r.Cells[1].Text));
        string name = Server.HtmlDecode(r.Cells[2].Text);
        float price = float.Parse(Server.HtmlDecode(r.Cells[3].Text));
        Product cusSelePro = new Product(ID, name, price, 1);
        bool exitedinorder = false;
        if (order.Products != null)
        {
            foreach (Product p in order.Products)
            {
                if (cusSelePro.ProductID == p.ProductID)
                {
                    exitedinorder = true;
                    p.ProductQuantity++;
                    break;
                }
            }
        }        
        if (exitedinorder == false)
        {
            order.AddProductToOrder(cusSelePro);
        }
    }
    protected void btnOrder_Click(object sender, EventArgs e)
    {
        CusOrder();
        Response.Redirect("CusView.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        order.Products.Clear();
    }
}