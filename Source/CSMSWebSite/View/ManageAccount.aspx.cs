using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEmployees();
        }
    }

    public void LoadEmployees() {
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        gvEmployees.DataSource = CSMSService.AdminViewAccount();
        gvEmployees.DataBind();
    }
    public void clear() {
        txtEmpCode.Text = null;
        txtEmpName.Text = null;
        txtEmpUsername.Text = null;
        txtEmpPassword.Text = null;
        txtEmpRole.Text = null;
        txtEmpSex.Text = null;
        txtEmpBrithdate.Text = null;
        txtEmpHiredate.Text = null;
        txtEmpAddress.Text = null;
        txtEmpPhone.Text = null;
        txtEmpCity.Text = null;        
        txtEmpCountry.Text = null;
        txtEmpSalary.Text = null;
        txtEmpHoursWork.Text = null;
        txtEmpMgrID.Text = null;
        rdoPriceRange.SelectedValue = null;
    }
    public void addAccount() 
    {
        float salary = float.Parse(txtEmpSalary.Text);
        int hourswork = int.Parse(txtEmpHoursWork.Text);
        int mgrid = int.Parse(txtEmpMgrID.Text);
        int id = int.Parse(txtEmpCode.Text);
        bool status = false;
        if(rdoPriceRange.SelectedValue.Equals("True")){
            status = true;
        }else
        {
            status = false;
        }
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        CSMSService.AdminAddNewAccount(id, txtEmpName.Text, txtEmpUsername.Text, txtEmpPassword.Text,
            txtEmpRole.Text, txtEmpSex.Text, txtEmpBrithdate.Text, txtEmpHiredate.Text, txtEmpAddress.Text,
            txtEmpPhone.Text, txtEmpCity.Text, txtEmpCountry.Text, salary, hourswork, mgrid, status);
        
    }
    public void updateAcount()
    {
        float salary = float.Parse(txtEmpSalary.Text);
        int hourswork = int.Parse(txtEmpHoursWork.Text);
        int mgrid = int.Parse(txtEmpMgrID.Text);
        int id = int.Parse(txtEmpCode.Text);
        bool status = false;
        if (rdoPriceRange.SelectedValue.Equals("True"))
        {
            status = true;
        }
        else
        {
            status = false;
        }
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        CSMSService.AdminUpdateAccount(id, txtEmpName.Text, txtEmpUsername.Text, txtEmpPassword.Text,
            txtEmpRole.Text, txtEmpSex.Text, txtEmpBrithdate.Text, txtEmpHiredate.Text, txtEmpAddress.Text,
            txtEmpPhone.Text, txtEmpCity.Text, txtEmpCountry.Text, salary, hourswork, mgrid, status);
    }
    public void deleteAccount()
    {
        int id = int.Parse(txtEmpCode.Text);
        CSMSService.CSMSWebservice CSMSService = new CSMSService.CSMSWebservice();
        CSMSService.AdminDeleteAccount(id);
    }
    protected void gvEmployees_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = gvEmployees.SelectedRow;
        txtEmpCode.Text = Server.HtmlDecode(r.Cells[1].Text);
        txtEmpName.Text = Server.HtmlDecode(r.Cells[2].Text);
        txtEmpUsername.Text = Server.HtmlDecode(r.Cells[3].Text);
        txtEmpPassword.Text = Server.HtmlDecode(r.Cells[4].Text);
        txtEmpRole.Text = Server.HtmlDecode(r.Cells[5].Text);
        txtEmpSex.Text = Server.HtmlDecode(r.Cells[6].Text);
        txtEmpBrithdate.Text = Server.HtmlDecode(r.Cells[7].Text);
        txtEmpHiredate.Text = Server.HtmlDecode(r.Cells[8].Text);
        txtEmpAddress.Text = Server.HtmlDecode(r.Cells[9].Text);
        txtEmpPhone.Text = Server.HtmlDecode(r.Cells[10].Text);
        txtEmpCity.Text = Server.HtmlDecode(r.Cells[11].Text);
        txtEmpCountry.Text = Server.HtmlDecode(r.Cells[12].Text);
        txtEmpSalary.Text = Server.HtmlDecode(r.Cells[13].Text);
        txtEmpHoursWork.Text = Server.HtmlDecode(r.Cells[14].Text);
        txtEmpMgrID.Text = Server.HtmlDecode(r.Cells[15].Text);
        CheckBox status = (CheckBox)r.Cells[16].Controls[0];
        if (status.Checked)
        {
            rdoPriceRange.SelectedValue = "True";
        }
        else 
        {
            rdoPriceRange.SelectedValue = "False";    
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        addAccount();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateAcount();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        deleteAccount();
    }
}