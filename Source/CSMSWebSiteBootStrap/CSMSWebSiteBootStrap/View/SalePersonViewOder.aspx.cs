using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSMSWebSiteBootStrap.View
{
    public partial class SalePersonViewOder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        public void LoadOrders()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            grvOrderPending.DataSource = CSMSService.SalespersionViewOrders();
            grvOrderPending.DataBind();

            grvOderDelevering.DataSource = CSMSService.SalespersionViewDeliveringOrders();
            grvOderDelevering.DataBind();
        }

        protected void grvOrderPending_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow r = grvOrderPending.SelectedRow;
            string orderid = Server.HtmlDecode(r.Cells[0].Text);
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            grvOrderDetail.DataSource = CSMSService.SalespersionViewOrderDetail(orderid);
            grvOrderDetail.DataBind();
            int numRowDetail = grvOrderDetail.Rows.Count;
            float totalPrice = 0;
            for (int i = 0; i < numRowDetail; i++)
            {
                totalPrice = totalPrice + (float.Parse(grvOrderDetail.Rows[i].Cells[3].Text)
                                        * float.Parse(grvOrderDetail.Rows[i].Cells[4].Text));
            }
            lblTotalPrice.Text = "Total: " + totalPrice.ToString();
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", false);
            //upModal.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            btnAccept.Visible = true;
            btnDeny.Visible = true;
            btnSucess.Visible = false;
            btnFail.Visible = false;
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
        }

        protected void grvOderDelevering_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow r = grvOderDelevering.SelectedRow;
            string orderid = Server.HtmlDecode(r.Cells[0].Text);
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            grvOrderDetail.DataSource = CSMSService.SalespersionViewOrderDetail(orderid);
            grvOrderDetail.DataBind();
            int numRowDetail = grvOrderDetail.Rows.Count;
            float totalPrice = 0;
            for (int i = 0; i < numRowDetail; i++)
            {
                totalPrice = totalPrice + (float.Parse(grvOrderDetail.Rows[i].Cells[3].Text)
                                        * float.Parse(grvOrderDetail.Rows[i].Cells[4].Text));
            }
            lblTotalPrice.Text = "Total: " + totalPrice.ToString();
            tmpOrderID.Text = orderid;
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", false);
            //upModal.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            btnAccept.Visible = false;
            btnDeny.Visible = false;
            btnSucess.Visible = true;
            btnFail.Visible = true;
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            string orderid = grvOrderDetail.Rows[0].Cells[0].Text;
            CSMSService.SalespersionAcceptOrders(orderid);
            int numRowDetail = grvOrderDetail.Rows.Count;
            for (int i = 0; i < numRowDetail; i++)
            {
                int productid = int.Parse(grvOrderDetail.Rows[i].Cells[1].Text);
                int productquantity = int.Parse(grvOrderDetail.Rows[i].Cells[3].Text);
                CSMSService.SalespersonMinusProduct(productid, productquantity);
            }
            grvOrderDetail.DataSource = null;
            grvOrderDetail.DataBind();
            lblTotalPrice.Text = null;
            LoadOrders();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal1').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AcceptHideModalScript", sb.ToString(), false);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnDeny_Click(object sender, EventArgs e)
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            CSMSService.SalespersionDenyOrders(grvOrderDetail.Rows[0].Cells[0].Text);
            grvOrderDetail.DataSource = null;
            grvOrderDetail.DataBind();
            lblTotalPrice.Text = null; 
            btnAccept.Visible = false;
            btnDeny.Visible = false;
            LoadOrders();                      
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal1').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DenyHideModalScript", sb.ToString(), false);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnSucess_Click(object sender, EventArgs e)
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            CSMSService.SalespersionConfrimSuccessOrders(grvOrderDetail.Rows[0].Cells[0].Text);
            LoadOrders();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal1').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SucessHideModalScript", sb.ToString(), false);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnFail_Click(object sender, EventArgs e)
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            CSMSService.SalespersionConfrimFailOrders(tmpOrderID.Text);
            int numRow = grvOrderDetail.Rows.Count;
            for (int i = 0; i < numRow; i++)
            {
                int productid = int.Parse(grvOrderDetail.Rows[i].Cells[1].Text);
                int productquantity = int.Parse(grvOrderDetail.Rows[i].Cells[3].Text);
                CSMSService.SalespersonAddProduct(productid, productquantity);
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal1').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SucessHideModalScript", sb.ToString(), false);
            Response.Redirect(Request.RawUrl);
        }
    }
}