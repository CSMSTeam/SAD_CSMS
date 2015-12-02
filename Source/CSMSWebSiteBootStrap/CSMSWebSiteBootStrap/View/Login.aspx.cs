using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSMSWebSiteBootStrap.View
{
    public partial class Login : System.Web.UI.Page
    {
        string role;
        protected void Page_Load(object sender, EventArgs e)
        {
            role = (string)Session["ROLE"];
            if (role != null && !role.Equals(""))
            {
                Response.Redirect("MasterView.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            CSMSService.CSMSWebservice GuestLogin = new CSMSService.CSMSWebservice();
            string []info =  GuestLogin.GuestLogin(username,password);
            if (info!=null)
            {
                Session.Timeout = 60;
                Session.Add("USERID", info[0]);
                Session.Add("USERNAME", info[1]);
                Session.Add("USERROLE", info[2]);
                switch(info[2])
                {
                    case "Admin":
                        Response.Redirect("MasterView.aspx");
                        break;
                    case "Saleperson":
                        Response.Redirect("SalePersonViewOder.aspx");
                        break;
                    case "Manager":
                        Response.Redirect("ManageProduct.aspx");
                        break;
                    default:
                        Response.Redirect("Login.aspx");
                        break;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}