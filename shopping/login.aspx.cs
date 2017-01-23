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
            switch (result.Result.AccountType)
            {
                case "1":
                    Session["ClientId"] = result.Result.Id;
                    var Client = tempClient.GetClientByUserId(result.Result.Id);
                    if (Client.IsSuccess && Client.Result != null)
                        Session["UserClient"] = Client.Result;
                    break;
                case "2":
                    Session["ProductId"] = result.Result.Id;
                    var Product = tempClient.GetProductByUserId(result.Result.Id);
                    if (Product.IsSuccess && Product.Result != null)
                        Session["UserProduct"] = Product.Result;                    
                    break;
                case "3":
                    Session["DeliveryId"] = result.Result.Id;
                    var Delivery = tempClient.GetDeliveryByUserId(result.Result.Id);
                    if (Delivery.IsSuccess && Delivery.Result != null)
                        Session["UserDelivery"] = Delivery.Result;                  
                    break;
            }
            Session["UserId"] = result.Result.Id;
            Response.Redirect("Default.aspx");
        }
        else {
            lblMessage.InnerText = "Log In Fails";
            Session.Clear();
            Session.RemoveAll();
        }
    }
}