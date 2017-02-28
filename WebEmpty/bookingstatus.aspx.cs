using WebEmpty.MasterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class bookingstatus : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        if (!this.IsPostBack)
        {
            this.BindListView();
        }
    }
    private void BindListView()
    {
        long id;
        if (Session["ClientId"] != null)
        {
            if (long.TryParse(Session["ClientId"].ToString(), out id))
            {
                var result = tempClient.GetBookingByClientId(id);
                if (result.IsSuccess && result.Result != null)
                {
                    bookinglist.DataSource = result.Result;
                    bookinglist.DataBind();
                }
            }
        }
        if (Session["ProductId"] != null)
        {
            if (long.TryParse(Session["ProductId"].ToString(), out id))
            {
                var result = tempClient.GetBookingByProductId(id);
                if (result.IsSuccess && result.Result != null)
                {
                    bookinglist.DataSource = result.Result;
                    bookinglist.DataBind();
                }
            }
        }
        if (Session["DeliveryId"] != null)
        {
            if (long.TryParse(Session["DeliveryId"].ToString(), out id))
            {
                var result = tempClient.GetBookingByDeliveryId(id);
                if (result.IsSuccess && result.Result != null)
                {
                    bookinglist.DataSource = result.Result;
                    bookinglist.DataBind();
                }
            }
        }
    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (bookinglist.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.BindListView();
    }
}