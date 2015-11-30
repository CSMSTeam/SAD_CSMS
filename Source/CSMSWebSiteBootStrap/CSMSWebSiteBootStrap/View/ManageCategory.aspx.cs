using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSMSWebSiteBootStrap.View
{
    public partial class ManageCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                LoadCategories();            
        }

        public void LoadCategories()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            grvCategory.DataSource = CSMSService.ManagerViewCategories();
            grvCategory.DataBind();
        }
        public void Clear()
        {
            txtCategoryID.Text = null;
            txtCategoryName.Text = null;
            txtCategoryDescription.Text = null;
            txtCategoryName1.Text = null;
            txtCategoryDescription1.Text = null;
        }

        public void AddCategory()
        {
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            CSMSService.ManagerAddCategories(txtCategoryName1.Text, txtCategoryDescription1.Text);
        }

        public void UpdateCategory()
        {
            int categoryid = int.Parse(txtCategoryID.Text);
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            CSMSService.ManagerUpdateCategories(categoryid, txtCategoryName.Text, txtCategoryDescription.Text);
        }

        public void DelteCategory()
        {
            int categoryid = int.Parse(txtCategoryID.Text);
            CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
            CSMSService.ManagerDeleteCategories(categoryid);
        }
        protected void grvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
            GridViewRow r = grvCategory.SelectedRow;
            txtCategoryID.Text = Server.HtmlDecode(r.Cells[0].Text);
            txtCategoryName.Text = Server.HtmlDecode(r.Cells[1].Text);
            txtCategoryDescription.Text = Server.HtmlDecode(r.Cells[2].Text);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", false);
            //upModal.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
        }
        protected void btnShowAddDialog_Click(object sender, EventArgs e)
        {
            Clear();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal1').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddCategory();
            LoadCategories();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Category Add New Successfully');");
            sb.Append("$('#myModal1').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateCategory();            
            LoadCategories();
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
            DelteCategory();
            LoadCategories();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Category Deleted Successfully');");
            sb.Append("$('#myModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteHideModalScript", sb.ToString(), false);
            Response.Redirect(Request.RawUrl);
        }
    }
}