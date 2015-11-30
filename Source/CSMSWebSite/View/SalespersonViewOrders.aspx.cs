using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalespersonViewOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadOrders();
    }

    public void LoadOrders()
    {
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        gvOrders.DataSource = CSMSService.SalespersionViewOrders();
        gvOrders.DataBind();

        gvDeliveringOrder.DataSource = CSMSService.SalespersionViewDeliveringOrders();
        gvDeliveringOrder.DataBind();
        if (gvDeliveringOrder.Rows.Count > 0)
        {
            lblDeliveringOrder.Visible = true;
        }
        else
        {
            lblDeliveringOrder.Visible = false;
        }
    }

    protected void gvOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = gvOrders.SelectedRow;
        string orderid = Server.HtmlDecode(r.Cells[1].Text);
        lblOrderDetail.Text = "Order" + orderid + "Detail";
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        gvOrderDetail.DataSource = CSMSService.SalespersionViewOrderDetail(orderid);
        gvOrderDetail.DataBind();
        int numRowDetail = gvOrderDetail.Rows.Count;
        float totalPrice = 0;
        for (int i = 0; i < numRowDetail; i++)
        {
            totalPrice = totalPrice + (float.Parse(gvOrderDetail.Rows[i].Cells[3].Text)
                                    * float.Parse(gvOrderDetail.Rows[i].Cells[4].Text));
        }
        lblTotalPrice.Text = "Total: " + totalPrice.ToString();
        btnAccept.Visible = true;
        btnDeny.Visible = true;
    }
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        string orderid = gvOrderDetail.Rows[0].Cells[0].Text;
        CSMSService.SalespersionAcceptOrders(orderid);
        int numRowDetail = gvOrderDetail.Rows.Count;
        for (int i = 0; i < numRowDetail; i++)
        {
            int productid = int.Parse(gvOrderDetail.Rows[i].Cells[1].Text);
            int productquantity = int.Parse(gvOrderDetail.Rows[i].Cells[3].Text);
            CSMSService.SalespersonMinusProduct(productid,productquantity);
        }
            gvOrderDetail.DataSource = null;
        gvOrderDetail.DataBind();        
        LoadOrders();
        lblTotalPrice.Text = null;
        lblOrderDetail.Text = null;
        btnAccept.Visible = false;
        btnDeny.Visible = false;
    }
    protected void btnDeny_Click(object sender, EventArgs e)
    {
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        CSMSService.SalespersionDenyOrders(gvOrderDetail.Rows[0].Cells[0].Text);
        gvOrderDetail.DataSource = null;
        gvOrderDetail.DataBind();
        btnAccept.Visible = false;
        btnDeny.Visible = false;
        LoadOrders();
        lblTotalPrice.Text = null;
        lblOrderDetail.Text = null;
    }

  

    protected void gvDeliveringOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string commandName = e.CommandName.ToString().Trim();
        GridViewRow row = gvDeliveringOrder.Rows[Convert.ToInt32(e.CommandArgument)];
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        switch (commandName)
        {
            case "Success":
                {
                    CSMSService.SalespersionConfrimSuccessOrders(Server.HtmlDecode(row.Cells[2].Text));
                    break;
                }               
            case "Fail":
                {
                    CSMSService.SalespersionConfrimFailOrders(Server.HtmlDecode(row.Cells[2].Text));
                    string orderid = row.Cells[2].Text;
                    gvOrderDetailTemp.DataSource = CSMSService.SalespersionViewOrderDetail(orderid);
                    gvOrderDetailTemp.DataBind();
                    int numRow = gvOrderDetailTemp.Rows.Count;
                    for (int i = 0; i < numRow; i++)
                    {
                        int productid = int.Parse(gvOrderDetailTemp.Rows[i].Cells[1].Text);
                        int productquantity = int.Parse(gvOrderDetailTemp.Rows[i].Cells[3].Text);
                        CSMSService.SalespersonAddProduct(productid,productquantity);
                    }
                        break;
                }                
            default: break;
        }
        LoadOrders();
    }
}