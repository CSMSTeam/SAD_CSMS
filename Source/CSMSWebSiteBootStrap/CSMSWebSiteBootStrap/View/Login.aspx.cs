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
            role = GuestLogin.GuestLogin(username, password);
            if (role != null || !role.Equals(""))
            {
                Session.Timeout = 60;
                Session.Add("ROLE", role);
                Response.Redirect("MasterView.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}