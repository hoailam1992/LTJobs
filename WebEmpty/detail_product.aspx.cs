using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebEmpty.MasterService;
using System.Collections.ObjectModel;
using System.Text;

public partial class detail : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long id;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        id = Convert.ToInt64(Request["Id"]);
        var Item = tempClient.GetProductById(id);
        if (Item.IsSuccess && Item.Result != null)
        {
            var UserInfo = tempClient.GetUserById(Item.Result.UserId);
            if (UserInfo.IsSuccess && UserInfo.Result != null)
            {
                lblName.InnerText = UserInfo.Result.FullName;
                lblPhoneNumber.InnerText =  UserInfo.Result.Phone.Replace(UserInfo.Result.Phone.Substring(UserInfo.Result.Phone.Length-5,5), "*****");
                lblPreferarea.InnerText = Item.Result.PreferrableLocation;
                lblPrice.InnerText =String.Format("{0}",Item.Result.Price.ToString());
                lblDescription.InnerText = Item.Result.ProductDescription;
                lblAge.InnerText = (DateTime.Now.Year - UserInfo.Result.DateOfBirth.Year).ToString();
                lblProductType.InnerText = Item.Result.Group;               
                var result = new ObservableCollection<Photo>(tempClient.GetPhotoByUserId(Item.Result.UserId).Result?? new List<Photo>());
                if (result.Count > 0)
                {
                    var carouselInnerHtml = new StringBuilder();
                    //loop through and build up the html for indicators + images
                    for (int i = 0; i < result.Count; i++)
                    {
                        var fileName = result[i];
                        string imagesource = @"/img/love.jpg";                        
                        imagesource = "data:image/png;base64," + Convert.ToBase64String(fileName.Image);                        
                        carouselInnerHtml.AppendLine("<div>");
                        carouselInnerHtml.AppendLine("<img data-u='image' src='"+imagesource+"' />");
                        carouselInnerHtml.AppendLine("<img data-u='thumb' src='" + imagesource + "'></img>");
                        carouselInnerHtml.AppendLine("</div>");
                    }
                    ltlCarouselImages.Text = carouselInnerHtml.ToString();
                }
            }
        }
    }
       
    protected void btnBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("booking.aspx?ProductID=" + id);
    }
}