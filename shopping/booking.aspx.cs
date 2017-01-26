using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterService;
public partial class booking : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long productid;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        if (!IsPostBack)
        {
            if (!long.TryParse(Request["ProductID"], out productid))
            { productid = 0; }
            var Item = tempClient.GetProductById(productid);
            if (Item.IsSuccess && Item.Result != null)
            {
                inputProductCode.Value = Item.Result.Code;
            }
            else
            {
                productid = 0;
            }
            var deliveries = tempClient.GetAllDelivery();
            if (deliveries.IsSuccess && deliveries.Result != null)
            {
                foreach (Delivery tDelivery in deliveries.Result)
                {
                    ListItem tempList = new ListItem();
                    tempList.Value = tDelivery.Id.ToString();
                    tempList.Text = tDelivery.Name;
                    SelectDelivery.Items.Add(tempList);
                }
            }
            var producttype = tempClient.GetAllProductType();
            if (producttype.IsSuccess && producttype.Result != null)
            {
                foreach (ProductType tDelivery in producttype.Result)
                {
                    ListItem tempList = new ListItem();
                    tempList.Value = tDelivery.Id.ToString();
                    tempList.Text = tDelivery.Code;
                    SelectType.Items.Add(tempList);
                }
            }
        }
    }  

    protected void btnBook_Click(object sender, EventArgs e)
    {
        long clientid, deliveryid,producttype;
        Client tempUserClient;
        try
        {
            if (productid == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Product Not Found !!\n Please Select Product Again" + "');", true);
                return;
            }
            if (!long.TryParse(Session["ClientId"].ToString(), out clientid))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please Log In Before Do Booking !!" + "');", true);
                return;
            }
            tempUserClient = (Client)Session["UserClient"];
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please Log In Before Do Booking !!" + "');", true);
            return;
        }
        Booking userBook = new Booking();
        userBook.ClientId = Convert.ToInt64(Session["ClientId"].ToString());
        userBook.ProductId = productid;
        if (long.TryParse(SelectDelivery.Value, out deliveryid))
        {
            userBook.DeliveryId = deliveryid;
        }
        userBook.Location = inputOwnLocation.Value;
        userBook.PaymentMode = tempUserClient.PaymentMode == 1 ? "1": "2" ;
        if (long.TryParse(SelectType.Value, out producttype))
        {
            userBook.ProductType = producttype;
            var Price = tempClient.GetProductPriceByProductAndTypeId(productid, producttype);
            if (Price.IsSuccess && Price.Result != null)
            {
                userBook.ProductPrice = Price.Result.FirstOrDefault().Price;
            }
        }
        userBook.TotalCost = 0;
        userBook.CreatedDate = DateTime.Now;
        userBook.ModifiedDate = DateTime.Now;
        userBook.DeliveryRespond = "O";
        userBook.ProductRespond = "O";
        userBook.Status = "O";
        var result = tempClient.SaveBooking(userBook);
        if (result.IsSuccess && result.Result != null)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Booking Success" + "');", true);
            Response.Redirect("booking_success.aspx");
        }
        else {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + result.ErrorMessage+ "');", true);
        }
       
    }



    protected void btnLinkView_Click(object sender, EventArgs e)
    {
        Response.Write("<script>");
        Response.Write("window.open('detail_delivery.aspx?DeliveryId=" + SelectDelivery.Value+"','_blank')");
        Response.Write("</script>");
        //Response.Redirect("detail_delivery.aspx?DeliveryId=" + SelectDelivery.Value);
    }
}