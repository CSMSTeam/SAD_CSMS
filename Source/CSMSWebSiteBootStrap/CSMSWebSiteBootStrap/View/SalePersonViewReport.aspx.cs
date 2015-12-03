using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSMSWebSiteBootStrap.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = (string)Session["USERROLE"];
            if (role != null && (role.Equals("Admin") || role.Equals("Saleperson")))
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
            string s_empid = (string)Session["USERID"];
            int i_emid;
            if (s_empid != null)
            {
                if (!s_empid.Equals(""))
                {
                    i_emid = int.Parse(s_empid);
                    CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
                    grvOrderReport.DataSource = CSMSService.SalePersonViewReport(i_emid, DateTime.Now.Date, DateTime.Now);
                    grvOrderReport.DataBind();
                    int numRowReport = grvOrderReport.Rows.Count;
                    float total = 0;
                    for (int i = 0; i < numRowReport; i++)
                    {
                        total += float.Parse(grvOrderReport.Rows[i].Cells[4].Text);
                    }
                    lblDayTotal.Text = " Total: " + total.ToString();
                    lblUsername.Text = (string)Session["USERNAME"];
                }
            }
        }

        protected void grvOrderReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow r = grvOrderReport.SelectedRow;
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