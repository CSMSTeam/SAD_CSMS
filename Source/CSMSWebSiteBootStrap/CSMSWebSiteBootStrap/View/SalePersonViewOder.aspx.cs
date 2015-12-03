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
            string role = (string)Session["USERROLE"];
            if (role != null && (role.Equals("Admin") || role.Equals("Saleperson")))
            {
                LoadOrders();
                lblUsername.Text = (string)Session["USERNAME"];

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void LoadOrders()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            grvOrderPending.DataSource = CSMSService.SalespersionViewOrders();
            grvOrderPending.DataBind();

            grvOderDelevering.DataSource = CSMSService.SalespersionViewDeliveringOrders();
            grvOderDelevering.DataBind();
            lblUsername.Text = (string)Session["USERNAME"];
        }

        protected void grvOrderPending_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow r = grvOrderPending.SelectedRow;
            string orderid = Server.HtmlDecode(r.Cells[0].Text);
            lblOderID.Text = orderid;
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
            lblOderID.Text = orderid;
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
            string orderid = lblOderID.Text;
            string s_empid = (string)Session["USERID"];
            int i_emid;
            if(s_empid!=null)
            {
                if(!s_empid.Equals(""))
                {
                    i_emid = int.Parse(s_empid);
                    CSMSService.SalespersionAcceptOrders(orderid, i_emid);
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
            }           
        }

        protected void btnDeny_Click(object sender, EventArgs e)
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            string orderid = lblOderID.Text;
            string s_empid = (string)Session["USERID"];
            int i_emid;
            if (s_empid != null)
            {
                if (!s_empid.Equals(""))
                {
                    i_emid = int.Parse(s_empid);
                    CSMSService.SalespersionDenyOrders(orderid, i_emid);
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
            }
        }

        protected void btnSucess_Click(object sender, EventArgs e)
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            string orderid = lblOderID.Text;
            string s_empid = (string)Session["USERID"];
            int i_emid;
            if (s_empid != null)
            {
                if (!s_empid.Equals(""))
                {
                    i_emid = int.Parse(s_empid);
                    CSMSService.SalespersionConfrimSuccessOrders(orderid, i_emid);
                    LoadOrders();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#myModal1').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SucessHideModalScript", sb.ToString(), false);
                    Response.Redirect(Request.RawUrl);
                }
            }
        }

        protected void btnFail_Click(object sender, EventArgs e)
        {
            string orderid = lblOderID.Text;
            string s_empid = (string)Session["USERID"];
            int i_emid;
            if (s_empid != null)
            {
                if (!s_empid.Equals(""))
                {
                    i_emid = int.Parse(s_empid);
                    CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
                    CSMSService.SalespersionConfrimFailOrders(tmpOrderID.Text,i_emid);
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}