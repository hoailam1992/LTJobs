using WebEmpty.MasterService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class detail_delivery : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long id;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        id = Convert.ToInt64(Request["DeliveryId"]);
        var Item = tempClient.GetDeliveryById(id);
        if (Item.IsSuccess && Item.Result != null)
        {
            lblName.InnerText = Item.Result.Name;
            lblAddress.InnerText = Item.Result.Address;
            lblLowestPrice.InnerText = String.Format("{0:c}", Item.Result.LowestPrice);
            lblHighestPrice.InnerText = String.Format("{0:c}", Item.Result.HighestPrice);
            lblQuality.InnerText = Item.Result.Quality.HasValue ? Item.Result.Quality.Value.ToString() + " Star(s)" : "0 Star(s)";
            var result = new ObservableCollection<Photo>(tempClient.GetPhotoByUserId(Item.Result.UserId).Result ?? new List<Photo>());
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
                    carouselInnerHtml.AppendLine("<img data-u='image' src='" + imagesource + "' />");
                    carouselInnerHtml.AppendLine("<img data-u='thumb' src='" + imagesource + "'></img>");
                    carouselInnerHtml.AppendLine("</div>");
                }
                ltlCarouselImages.Text = carouselInnerHtml.ToString();
            }
        }
    }
}