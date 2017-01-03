using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    TextBox txtUsername;
    TextBox txtFullname;
    TextBox txtPassword;
    TextBox txtRePassword;
    TextBox txtAnswers;
    TextBox txtBirthday;
    TextBox txtPhone;
    TextBox txtEmail;
    RadioButton rdClient;
    RadioButton rdProduct;
    RadioButton rdDelivery;
    DropDownList drdQuestion;
    protected void Page_Load(object sender, EventArgs e)
    {
        MasterService.MasterServiceClient tempClient = new MasterService.MasterServiceClient();
        txtUsername = FindControl("inputUsername") as TextBox;
    }
}