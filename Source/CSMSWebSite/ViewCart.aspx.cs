using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCart : System.Web.UI.Page
{
    Order order;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            order = (Order)Session["Order"];
        }       
        Session["Order"] = order;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        order = new Order();       
    }
    
}