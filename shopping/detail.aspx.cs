using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterService;
public partial class detail : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        long id = Convert.ToInt64(Request["Id"]);
        var Item = tempClient.GetProductById(id);
        if (Item.IsSuccess && Item.Result != null)
        {
            var UserInfo = tempClient.GetUserById(Item.Result.UserId);
            if (UserInfo.IsSuccess && UserInfo.Result != null)
            {
                lblName.InnerText = UserInfo.Result.FullName;
                lblPhoneNumber.InnerText =  UserInfo.Result.Phone.Replace(UserInfo.Result.Phone.Substring(UserInfo.Result.Phone.Length-5,5), "*****");
                lblPreferarea.InnerText = Item.Result.PreferrableLocation;
                lblPrice.InnerText =String.Format("{0:c}",Item.Result.Price.ToString());
                lblDescription.InnerText = Item.Result.ProductDescription;
                lblAge.InnerText = (DateTime.Now.Year - UserInfo.Result.DateOfBirth.Year).ToString();
                lblProductType.InnerText = Item.Result.Group;
            }
        }
    }
}