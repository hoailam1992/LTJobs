using MasterService;
using System;
using System.Collections.Generic;
using System.Linq;
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
            lblQuality.InnerText = Item.Result.Quality.HasValue ? Item.Result.Quality.Value.ToString() + " Star(s)":"0 Star(s)";            
        }
    }
}