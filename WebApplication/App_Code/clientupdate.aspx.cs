using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterService;
using System.Collections.ObjectModel;
using System.Text;

public partial class clientupdate : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long id;
    ReturnTypeOfTracking result;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        id = Convert.ToInt64(Request["Id"]);
        result = tempClient.GetTrackingById(id);
        if (result.IsSuccess && result.Result != null)
        {
            inputCode.Value = result.Result.DateTime.ToShortDateString() + result.Result.DateTime.ToShortTimeString();
            idhidden.Value = result.Result.Id.ToString();
            idbooking.Value = result.Result.BookingId.ToString();
            clconfirm.Value = result.Result.ClientConfirm;
            proconfirm.Value = result.Result.ProductConfirm;
            deliveryconfirm.Value = result.Result.DeliveryConfirm;
            clremark.Value = result.Result.RemarkClient;
            proremark.Value = result.Result.RemarkProduct;
            deliremark.Value = result.Result.RemarkDelivery;
            createddate.Value = result.Result.CreatedDate.ToBinary().ToString();
            modifieddate.Value = result.Result.ModifiedDate.ToBinary().ToString();
            datetime.Value = result.Result.DateTime.ToBinary().ToString();
            if (result.Result.ClientConfirm=="O")
            {
                divRadio.Visible = false;
                divRadio1.Visible = true;
            }
            else {
                divRadio.Visible = true;
                divRadio1.Visible = false;
            }
            var UserProduct = tempClient.GetProductById(result.Result.Booking.ProductId);
            if (UserProduct.IsSuccess && UserProduct.Result != null)
            {
                var resultPhoto = new ObservableCollection<Photo>(tempClient.GetPhotoByUserId(UserProduct.Result.UserId).Result ?? new List<Photo>());
                if (resultPhoto.Count > 0)
                {
                    var carouselInnerHtml = new StringBuilder();
                    //loop through and build up the html for indicators + images
                    for (int i = 0; i < resultPhoto.Count; i++)
                    {
                        var fileName = resultPhoto[i];
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Tracking temp = new Tracking();
        temp.Id = Convert.ToInt64(idhidden.Value);
        temp.BookingId = Convert.ToInt64(idbooking.Value);
        temp.ClientConfirm = clconfirm.Value;
        temp.ProductConfirm = proconfirm.Value;
        temp.DeliveryConfirm = deliveryconfirm.Value;
        temp.RemarkClient = clremark.Value;
        temp.RemarkProduct = proremark.Value;
        temp.RemarkDelivery = deliremark.Value;
        long date = Convert.ToInt64(createddate.Value);
        temp.CreatedDate = DateTime.FromBinary(date);
        date = Convert.ToInt64(modifieddate.Value);
        temp.ModifiedDate = DateTime.FromBinary(date);
        date = Convert.ToInt64(datetime.Value);
        temp.DateTime = DateTime.FromBinary(date);
        if (rdStart.Checked)
        {
            temp.ClientConfirm = "Started";
        }
        else if (rdCancel.Checked)
        {
            temp.ClientConfirm = "Cancel";
            temp.RemarkClient = inputRemark.Value;
        }
        else
        {
            temp.ClientConfirm = "Finished";
        }
        var ReturnResult = tempClient.SaveTracking(temp);
        if (ReturnResult.IsSuccess && ReturnResult.Result != null)
        {
            Page.RegisterClientScriptBlock("myalert", string.Format("<script>alert('{0}');</script>", "Tracking Successfully Saved"));
            Response.Redirect("bookingstatus.aspx");
        }
        else {
            Page.RegisterClientScriptBlock("myalert", string.Format("<script>alert('{0}');</script>", "Failed To Update Tracking"));
        }
    }
}