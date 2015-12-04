using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSMSWebSiteBootStrap.View
{
    public partial class AdminViewReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = (string) Session["USERROLE"];
            if (role != null && (role.Equals("Admin")))
            {
                loadReport();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void loadReport()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            grvReport.DataSource = CSMSService.AdminViewReport(DateTime.Now.Date, DateTime.Now, "Success");
            grvReport.DataBind();
            lblUsername.Text = (string) Session["USERNAME"];
        }

        protected void grvReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow r = grvReport.SelectedRow;
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
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}