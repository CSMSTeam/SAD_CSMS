using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ManageProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadProducts();
        }
        
    }

    public void LoadProducts() 
    {
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        gvProducts.DataSource = CSMSService.ManagerViewProducts();
        gvProducts.DataBind();

        DataTable dt = CSMSService.ManagerLoadCategories();
        ddlCategories.DataSource = dt;
        ddlCategories.DataTextField = "categoryname";
        ddlCategories.DataValueField = "categoryid";
        ddlCategories.DataBind();
    }
    public void AddProduct()
    {
        int productid = int.Parse(txtProductID.Text);
        int categoryid = int.Parse(ddlCategories.SelectedValue);
        float importpirce = float.Parse(txtProductImportPrice.Text);
        float unitprice = float.Parse(txtProductUnitPrice.Text);
        int quantity = int.Parse(txtProductQuantity.Text);
        bool status = false;
        if (rdoProductStatus.SelectedValue.Equals("True"))
        {
            status = true;
        }
        else
        {
            status = false;
        }

        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        CSMSService.ManagerAddProduct(productid, txtProductName.Text, categoryid,
                                      importpirce, unitprice, quantity, status);
    }
    public void UpdateProduct()
    {
        int productid = int.Parse(txtProductID.Text);
        int categoryid = int.Parse(ddlCategories.SelectedValue);
        float importpirce = float.Parse(txtProductImportPrice.Text);
        float unitprice = float.Parse(txtProductUnitPrice.Text);
        int quantity = int.Parse(txtProductQuantity.Text);
        bool status = false;
        if (rdoProductStatus.SelectedValue.Equals("True"))
        {
            status = true;
        }
        else
        {
            status = false;
        }

        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        CSMSService.ManagerUpdateProduct(productid, txtProductName.Text, categoryid,
                                      importpirce, unitprice, quantity, status);
    }
    public void DeleteProduct()
    {
        int productid = int.Parse(txtProductID.Text);
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        CSMSService.ManagerDeleteProduct(productid);
    }
    public void Clear()
    {
        txtProductID.Text = null;
        txtProductName.Text = null;
        ddlCategories.SelectedIndex = -1;
        txtProductImportPrice.Text = null;
        txtProductUnitPrice.Text = null;
        txtProductQuantity.Text = null;
        rdoProductStatus.SelectedValue = null;
    }
    protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = gvProducts.SelectedRow;
        txtProductID.Text = Server.HtmlDecode(r.Cells[1].Text);
        txtProductName.Text = Server.HtmlDecode(r.Cells[2].Text);
        ddlCategories.SelectedValue = Server.HtmlDecode(r.Cells[3].Text);
        txtProductImportPrice.Text = Server.HtmlDecode(r.Cells[4].Text);
        txtProductUnitPrice.Text = Server.HtmlDecode(r.Cells[5].Text);
        txtProductQuantity.Text = Server.HtmlDecode(r.Cells[6].Text);
        CheckBox status = (CheckBox)r.Cells[7].Controls[0];
        if (status.Checked)
        {
            rdoProductStatus.SelectedValue = "True";
        }
        else
        {
            rdoProductStatus.SelectedValue = "False";
        }

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddProduct();
        LoadProducts();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateProduct();
        LoadProducts();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DeleteProduct();
        LoadProducts();
    }
}