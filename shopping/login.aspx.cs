using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    MasterService.MasterServiceClient tempClient = new MasterService.MasterServiceClient();
    bool flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnLogIn.Click += BtnLogIn_Click;
        flag =Convert.ToBoolean(Request["logout"]);
        if (flag)
        {
            Session.Clear();
            Session.RemoveAll();
            lblMessage.InnerText = "Log Out Success";
        }
    }

    private void BtnLogIn_Click(object sender, EventArgs e)
    {
        var result = tempClient.LoginUser(inputUserName.Value, inputPass.Value);
        if (result.IsSuccess && result.Result != null)
        {
            Session["UserName"] = inputUserName.Value;
            Session["FullName"] = result.Result.FullName;
           
            Response.Redirect("Default.aspx");
        }
        else {
            lblMessage.InnerText = "Log In Fails";
            Session.Clear();
            Session.RemoveAll();
        }
    }
}