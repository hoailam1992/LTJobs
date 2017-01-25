using MasterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class deliveryrespond : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long bookingid;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        if (!long.TryParse(Request["BookingId"], out bookingid))
        { bookingid = 0; }
        if (!IsPostBack)
        {
            if (!long.TryParse(Request["BookingId"], out bookingid))
            { bookingid = 0; }
            var Item = tempClient.GetBookingById(bookingid);
            if (Item.IsSuccess && Item.Result != null)
            {
                inputClientCode.Value = Item.Result.Client.Code;
                inputDate.Value = Item.Result.DateTime.HasValue ? Item.Result.DateTime.Value.ToLongTimeString() : "Empty";
                inputOwnLocation.Value = Item.Result.Location;
                datingtype.Value = Item.Result.ProductType.ToString();
                deliveryId.Value = Item.Result.Delivery.Name;
                htView.NavigateUrl = "detail_delivery.aspx?DeliverId=" + Item.Result.DeliveryId;
                if (Item.Result.PaymentMode == "1")
                {
                    rdCash.Checked = false;
                }
                else
                {
                    rdCCard.Checked = true;
                }
                if ((Item.Result.ProductRespond != "O" && Session["UserType"].ToString() == "2") ||
                    (Item.Result.DeliveryRespond != "O" && Session["UserType"].ToString() == "3") || Item.Result.Status == "F")
                {
                    btnAccept.Enabled = false;
                    btnReject.Enabled = false;
                }
                else
                {
                    btnAccept.Enabled = true;
                    btnReject.Enabled = true;
                }
            }
            else
            {
                bookingid = 0;
            }

        }
    }
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        var tempBooking = tempClient.GetBookingById(bookingid);
        if (tempBooking.IsSuccess && tempBooking.Result != null)
        {
            if (Session["UserType"].ToString() == "2")
            {
                tempBooking.Result.ProductRespond = "A";
            }
            else if (Session["UserType"].ToString() == "3")
            {
                tempBooking.Result.DeliveryRespond = "A";
            }
            tempBooking.Result.Client = null;
            tempBooking.Result.Product = null;
            tempBooking.Result.Delivery = null;
            tempBooking.Result.ModifiedDate = DateTime.Now;
            var tempResult = tempClient.SaveBooking(tempBooking.Result);
            if (tempResult.IsSuccess)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Accepted');", true);
                Response.Redirect("bookingstatus.aspx");
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + tempResult.ErrorMessage + "');", true);
            }
        }
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        var tempBooking = tempClient.GetBookingById(bookingid);
        if (tempBooking.IsSuccess && tempBooking.Result != null)
        {
            if (Session["UserType"].ToString() == "2")
            {
                tempBooking.Result.ProductRespond = "R";

            }
            else if (Session["UserType"].ToString() == "3")
            {
                tempBooking.Result.DeliveryRespond = "R";
            }
            tempBooking.Result.Client = null;
            tempBooking.Result.Product = null;
            tempBooking.Result.Delivery = null;
            tempBooking.Result.Status = "F";
            tempBooking.Result.ModifiedDate = DateTime.Now;
            var tempResult = tempClient.SaveBooking(tempBooking.Result);
            if (tempResult.IsSuccess)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Rejected');", true);
                Response.Redirect("bookingstatus.aspx");
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + tempResult.ErrorMessage + "');", true);
            }
        }
    }
}