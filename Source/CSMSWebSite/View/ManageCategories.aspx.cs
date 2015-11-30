using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCategories();
        }
    }

    public void LoadCategories()
    {
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        grvCategories.DataSource = CSMSService.ManagerViewCategories();
        grvCategories.DataBind();
    }

    public void Clear()
    {
        txtCategoryID.Text = null;
        txtCategoryName.Text = null;
        txtCategoryDescription.Text = null;
    }

    public void AddCategory()
    {
        int categoryid = int.Parse(txtCategoryID.Text);
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        CSMSService.ManagerAddCategories(categoryid, txtCategoryName.Text, txtCategoryDescription.Text);
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
    protected void grvCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = grvCategories.SelectedRow;
        txtCategoryID.Text = Server.HtmlDecode(r.Cells[1].Text);
        txtCategoryName.Text = Server.HtmlDecode(r.Cells[2].Text);
        txtCategoryDescription.Text = Server.HtmlDecode(r.Cells[3].Text);
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddCategory();
        LoadCategories();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateCategory();
        LoadCategories();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DelteCategory();
        LoadCategories();
    }
}