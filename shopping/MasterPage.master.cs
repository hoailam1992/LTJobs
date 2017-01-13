using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    } 

    protected void btnLog_Load(object sender, EventArgs e)
    {     
        if (Session["UserName"] == null)
        {
            lblLog.Text = "Log In";
            lblLog.NavigateUrl = "login.aspx";
        }
        else {
            lblLog.Text = "Log Out";
            lblLog.NavigateUrl = "login.aspx?logout=" + true;        
        }
    }

    protected void lblRegister_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
        {
            lblRegister.Text = "Register";
            lblRegister.NavigateUrl = "register.aspx";
        }
        else
        {
            lblRegister.Text = Session["UserName"].ToString();
            lblRegister.NavigateUrl = "account.aspx";
        }
    }

    protected void lblRegister_Click(object sender, EventArgs e)
    {
        if (lblRegister.Text != "Register")
        {
            Response.Redirect("account.aspx");
        }
        else
        {
            Response.Redirect("register.aspx");
        }
    }
}
