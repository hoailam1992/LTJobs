using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterService;
public partial class productupdate : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long id;
    ReturnTypeOfTracking result;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        id = Convert.ToInt64(Request["Id"]);
        if (!IsPostBack)
        {
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
                if (result.Result.DeliveryConfirm == "O")
                {
                    divRadio.Visible = false;
                    divRadio1.Visible = true;
                }
                else
                {
                    divRadio.Visible = true;
                    divRadio1.Visible = false;
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Tracking temp = new Tracking();
        temp.Id =Convert.ToInt64(idhidden.Value);
        temp.BookingId =Convert.ToInt64(idbooking.Value);
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
            temp.DeliveryConfirm = "Started";
        }
        else if (rdCancel.Checked)
        {
            temp.DeliveryConfirm = "Cancel";
            temp.RemarkDelivery = inputRemark.Value;
        }
        else 
        {
            temp.DeliveryConfirm = "Finished";
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