using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSMSWebSiteBootStrap.View
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = (string)Session["USERROLE"];
            if (role != null && (role.Equals("Admin") || role.Equals("Manager")))
            {
                LoadProducts();
                lblUsername.Text = (string)Session["USERNAME"];
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        public void LoadProducts()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            grvProduct.DataSource = CSMSService.ManagerViewProducts();
            grvProduct.DataBind();

            for (int i = 0; i < grvProduct.Rows.Count; i++)
            {
                grvProduct.Rows[i].Cells[6].Text = grvProduct.Rows[i].Cells[6].Text.Trim().ToUpper() == "TRUE" ? "Available" : "Not Available";
            }


        }
        public void LoadDropDownList1()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            DropDownList1.DataSource = CSMSService.ManagerViewCategories();
            DropDownList1.DataValueField = "categoryid";
            DropDownList1.DataTextField = "categoryname";
            DropDownList1.DataBind();
        }
        public void Clear()
        {
            txtProductID.Text = null;
            txtProductName.Text = null;
            txtCategoryID.Text = null;
            txtImportPrice.Text = null;
            txtUnitPrice.Text = null;
            txtProductQuantity.Text = null;
            rbtStatus.ClearSelection();
        }
        public void AddProduct()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            bool status = rbtStatus_.SelectedValue == "Available" ? true : false;
            CSMSService.ManagerAddProduct(txtProductName_.Text,
                                            int.Parse(DropDownList1.SelectedValue),
                                            float.Parse(txtImportPrice_.Text),
                                            float.Parse(txtUnitPrice_.Text),
                                            int.Parse(txtProductQuantity_.Text),
                                            status);
        }
        public void UpdateProduct()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            bool status = rbtStatus.SelectedValue == "Available" ? true : false;
            CSMSService.ManagerUpdateProduct(int.Parse(txtProductID.Text),
                                                txtProductName.Text,
                                                int.Parse(txtCategoryID.Text),
                                                float.Parse(txtImportPrice.Text),
                                                float.Parse(txtUnitPrice.Text),
                                                int.Parse(txtProductQuantity.Text),
                                                status);
        }
        public void DeleteProduct()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            CSMSService.ManagerDeleteProduct(int.Parse(txtProductID.Text));
        }

        protected void grvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
            GridViewRow gv = grvProduct.SelectedRow;

            txtProductID.Text = Server.HtmlDecode(gv.Cells[0].Text);
            txtProductName.Text = Server.HtmlDecode(gv.Cells[1].Text);
            txtCategoryID.Text = Server.HtmlDecode(gv.Cells[2].Text);
            txtImportPrice.Text = Server.HtmlDecode(gv.Cells[3].Text);
            txtUnitPrice.Text = Server.HtmlDecode(gv.Cells[4].Text);
            txtProductQuantity.Text = Server.HtmlDecode(gv.Cells[5].Text);
            rbtStatus.SelectedValue = Server.HtmlDecode(gv.Cells[6].Text);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
        }

        protected void btnShowAddDialog_Click(object sender, EventArgs e)
        {
            Clear();
            LoadDropDownList1();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal1').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateProduct();
            LoadProducts();
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
            DeleteProduct();
            LoadProducts();
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
            AddProduct();
            LoadProducts();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Category Add New Successfully');");
            sb.Append("$('#myModal1').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        } 
    }
}