using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterService;
public partial class CustomControl_ItemControl : System.Web.UI.UserControl
{
    MasterServiceClient tempClient;
    long ItemId;
    protected void Page_Load(object sender, EventArgs e)
    {
        urlDetail.NavigateUrl = "detail.aspx?id=" + ItemId;
        var ItemResult =  tempClient.GetProductById(ItemId);
        if (ItemResult.IsSuccess && ItemResult.Result != null)
        {
            lblPrice.InnerText = ItemResult.Result.Price.ToString();
            lblCode.InnerText = ItemResult.Result.Code;
        }
        tempClient.Close();
    }
    public CustomControl_ItemControl()
    {
    }
    public CustomControl_ItemControl(long id)
    {
        ItemId = id;
    }
}