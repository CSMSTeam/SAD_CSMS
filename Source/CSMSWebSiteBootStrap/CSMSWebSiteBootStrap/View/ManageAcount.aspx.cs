using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSMSWebSiteBootStrap.View
{
    public partial class ManageAcount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        public void LoadAccounts()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            grvAccount.DataSource = CSMSService.AdminViewAccount();
            grvAccount.DataBind();

            for (int i = 0; i < grvAccount.Rows.Count; i++)
            {
                grvAccount.Rows[i].Cells[15].Text = grvAccount.Rows[i].Cells[15].Text.Trim().ToUpper() == "TRUE" ? "Available" : "Not Available";
            }
        }
        public void LoadDropList()
        {
            DropDownList1.Items.Add(new ListItem("Admin","Admin"));
            DropDownList1.Items.Add(new ListItem("Manager","Manager"));
            DropDownList1.Items.Add(new ListItem("Saleperson","Saleperson"));
            DropDownList1.DataBind();
            DropDownList2.DataSource = DropDownList1.Items;
            DropDownList2.DataTextField = "Text";
            DropDownList2.DataValueField = "Value";
            DropDownList2.DataBind();
        }

        public void Clear()
        {
            txtEmpID.Text = null;
            txtEmpName.Text = null;
            txtEmpUsername.Text = null;
            txtEmpPassword.Text = null;
            rbtSex.ClearSelection();
            txtEmpBirthdate.Text = null;
            txtEmpHiredate.Text = null;
            txtEmpAddress.Text = null;
            txtEmpPhone.Text = null;
            txtEmpCity.Text = null;
            txtEmpSalary.Text = null;
            txtEmpHourWork.Text = null;
            txtEmpMgrID.Text = null;
            rbtStatus.ClearSelection();
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
        }
        public void AddAccount()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            bool status = rbtStatus_.SelectedValue == "Available" ? true : false;

            CSMSService.AdminAddNewAccount(txtEmpName_.Text,
                                            txtEmpUsername_.Text,
                                            txtEmpPassword_.Text,
                                            DropDownList2.SelectedItem.ToString(),
                                            rbtSex_.SelectedValue,
                                            txtEmpBirthdate_.Text,
                                            txtEmpHiredate_.Text,
                                            txtEmpAddress_.Text,
                                            txtEmpPhone_.Text,
                                            txtEmpCity_.Text,
                                            txtEmpCountry_.Text,
                                            float.Parse(txtEmpSalary_.Text),
                                            int.Parse(txtEmpHourWork_.Text),
                                            int.Parse(txtEmpMgrID_.Text),
                                            status);
        }
        public void UpdateAccount()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            bool status = rbtStatus.SelectedValue == "Available" ? true : false;
            CSMSService.AdminUpdateAccount(int.Parse(txtEmpID.Text),
                                            txtEmpName.Text,
                                            txtEmpUsername.Text,
                                            txtEmpPassword.Text,
                                            DropDownList1.SelectedValue,
                                            rbtSex.SelectedValue,
                                            txtEmpBirthdate.Text,
                                            txtEmpHiredate.Text,
                                            txtEmpAddress.Text,
                                            txtEmpPhone.Text,
                                            txtEmpCity.Text,
                                            txtEmpCountry.Text,
                                            float.Parse(txtEmpSalary.Text),
                                            int.Parse(txtEmpHourWork.Text),
                                            int.Parse(txtEmpMgrID.Text),
                                            status);
        }
        public void DeleteAccount()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            CSMSService.AdminDeleteAccount(int.Parse(txtEmpID.Text));
        }

        protected void grvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
            LoadDropList();
            GridViewRow gv = grvAccount.SelectedRow;

            txtEmpID.Text = Server.HtmlDecode(gv.Cells[0].Text);
            txtEmpName.Text = Server.HtmlDecode(gv.Cells[1].Text);
            txtEmpUsername.Text = Server.HtmlDecode(gv.Cells[2].Text);
            txtEmpPassword.Text = Server.HtmlDecode(gv.Cells[3].Text);
            DropDownList1.SelectedValue = Server.HtmlDecode(gv.Cells[4].Text);
            rbtSex.SelectedValue = Server.HtmlDecode(gv.Cells[5].Text);
            txtEmpBirthdate.Text = Server.HtmlDecode(gv.Cells[6].Text);
            txtEmpHiredate.Text = Server.HtmlDecode(gv.Cells[7].Text);
            txtEmpAddress.Text = Server.HtmlDecode(gv.Cells[8].Text);
            txtEmpPhone.Text = Server.HtmlDecode(gv.Cells[9].Text);
            txtEmpCity.Text = Server.HtmlDecode(gv.Cells[10].Text);
            txtEmpCountry.Text = Server.HtmlDecode(gv.Cells[11].Text);
            txtEmpSalary.Text = Server.HtmlDecode(gv.Cells[12].Text);
            txtEmpHourWork.Text = Server.HtmlDecode(gv.Cells[13].Text);
            txtEmpMgrID.Text = Server.HtmlDecode(gv.Cells[14].Text);
            rbtStatus.SelectedValue = Server.HtmlDecode(gv.Cells[15].Text);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateAccount();
            LoadAccounts();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Category Updated Successfully');");
            sb.Append("$('#myModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAccount();
            LoadAccounts();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Category Deleted Successfully');");
            sb.Append("$('#myModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteHideModalScript", sb.ToString(), false);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddAccount();
            LoadAccounts();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Category Add New Successfully');");
            sb.Append("$('#myModal1').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnShowAddDialog_Click(object sender, EventArgs e)
        {
            Clear();
            LoadDropList();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal1').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
        }
    }
}