using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebEmpty.MasterService;
public partial class booking : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long productid;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        
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
        if (!IsPostBack)
        {
            var deliveries = tempClient.GetAllDelivery();
            if (deliveries.IsSuccess && deliveries.Result != null)
            {
                //SelectDelivery.Items.Clear();
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
                SelectType.Items.Clear();
                foreach (ProductType tDelivery in producttype.Result)
                {
                    ListItem tempList = new ListItem();
                    tempList.Value = tDelivery.Id.ToString();
                    tempList.Text = tDelivery.Code;
                    SelectType.Items.Add(tempList);
                }
            }
            SelectDelivery.SelectedIndexChanged += SelectDelivery_SelectedIndexChanged1;
            SelectDeliveryType.SelectedIndexChanged += SelectDeliveryType_SelectedIndexChanged1;
            SelectType.SelectedIndexChanged += SelectType_SelectedIndexChanged1;
        }
    }

    private void SelectType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        long producttype;
        if (long.TryParse(SelectType.SelectedValue, out producttype))
        {
            var Price = tempClient.GetProductPriceByProductAndTypeId(productid, producttype);
            if (Price.IsSuccess && Price.Result != null && Price.Result.Count != 0)
            {
                inputProductPrice.Value = Price.Result.FirstOrDefault().Price.ToString();
            }
            else
            {
                var DefaultPrice = tempClient.GetProductById(productid);
                if (DefaultPrice.Result != null)
                    inputProductPrice.Value = DefaultPrice.Result.Price.ToString();
            }
            inputCost.Value = Convert.ToDecimal(String.IsNullOrEmpty(inputDeliveryPrice.Value) ? "0" : inputDeliveryPrice.Value) + Convert.ToDecimal(String.IsNullOrEmpty(inputProductPrice.Value) ? "0" : inputProductPrice.Value) + "$";
        }
    }

    private void SelectDeliveryType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            inputDeliveryPrice.Value = SelectDeliveryType.SelectedValue;
            inputCost.Value = Convert.ToDecimal(String.IsNullOrEmpty(inputDeliveryPrice.Value) ? "0" : inputDeliveryPrice.Value) + Convert.ToDecimal(String.IsNullOrEmpty(inputProductPrice.Value) ? "0" : inputProductPrice.Value) + "$";
        }
        catch { }
    }

    private void SelectDelivery_SelectedIndexChanged1(object sender, EventArgs e)
    {
        var result = tempClient.GetAllDeliveryTypeByDeliveryId(Convert.ToInt64(SelectDelivery.SelectedValue));
        if (result.IsSuccess && result.Result != null)
        {
            SelectDeliveryType.Items.Clear();
            foreach (var temp in result.Result)
            {
                ListItem tempList = new ListItem();
                tempList.Value = temp.Price.ToString();
                tempList.Text = temp.DeliveryDescription;
                SelectDeliveryType.Items.Add(tempList);
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
                Page.RegisterClientScriptBlock("myalert","<script>alert('" + "Product Not Found !!\\n Please Select Product Again" + "');</script>");
                return;
            }
            if (!long.TryParse(Session["ClientId"].ToString(), out clientid))
            {
                Page.RegisterClientScriptBlock("myalert", "<script>alert('" + "Please Log In Before Do Booking !!" + "');</script>");
                return;
            }
            tempUserClient = (Client)Session["UserClient"];
        }
        catch
        {
            Page.RegisterClientScriptBlock("myalert",string.Format("<script>alert('{0}');</script>","Please Log In Before Do Booking"));
            Response.Redirect("login.aspx");
            return;
        }
        Booking userBook = new Booking();
        if (string.IsNullOrEmpty(inputDate.Value))
        {
            Page.RegisterClientScriptBlock("myalert", string.Format("<script>alert('{0}');</script>", "Please Select Dating Time"));
            return;
        }
        DateTime dt =Convert.ToDateTime(inputDate.Value);
        if (!string.IsNullOrEmpty(selecthour.SelectedValue))
            dt = dt.AddHours(double.Parse(selecthour.SelectedValue));
        else
        {
            Page.RegisterClientScriptBlock("myalert", string.Format("<script>alert('{0}');</script>", "Please Select Time"));
            return;
        }
        if (!string.IsNullOrEmpty(selectmin.SelectedValue))
            dt = dt.AddMinutes(double.Parse(selectmin.SelectedValue));
        else
        {
            Page.RegisterClientScriptBlock("myalert", string.Format("<script>alert('{0}');</script>", "Please Select Time"));
            return;
        }
        userBook.DateTime = dt;
        userBook.ClientId = Convert.ToInt64(Session["ClientId"].ToString());
        userBook.ProductId = productid;
        if (long.TryParse(SelectDelivery.SelectedValue, out deliveryid))
        {
            userBook.DeliveryId = deliveryid;
            if (string.IsNullOrEmpty(SelectDeliveryType.SelectedValue))
            {
                Page.RegisterClientScriptBlock("myalert", string.Format("<script>alert('{0}');</script>", "Please Select Delivery  Type"));
                return;
            }
        }
        Calculate();
        userBook.ProductType =Convert.ToInt64(SelectType.SelectedValue);
        userBook.Location = inputOwnLocation.Value;
        userBook.PaymentMode = rdCash.Checked ? "1" : "2";
        //if (long.TryParse(SelectType.SelectedValue, out producttype))
        //{
        //    userBook.ProductType = producttype;
        //    var Price = tempClient.GetProductPriceByProductAndTypeId(productid, producttype);
        //    if (Price.IsSuccess && Price.Result != null && Price.Result.Count != 0)
        //    {
        //        userBook.ProductPrice = Price.Result.FirstOrDefault().Price;
        //        userBook.ProductValue = userBook.ProductPrice.Value;
        //    }
        //    else {
        //        var DefaultPrice = tempClient.GetProductById(productid);
        //        if (DefaultPrice.Result != null)
        //        {
        //            userBook.ProductPrice = DefaultPrice.Result.Price;
        //            userBook.ProductValue = userBook.ProductPrice.Value;
        //        }
        //    }
        //}
        userBook.ProductPrice = Convert.ToDecimal(String.IsNullOrEmpty(inputProductPrice.Value) ? "0" : inputProductPrice.Value);
        userBook.ProductValue = Convert.ToDecimal(String.IsNullOrEmpty(inputProductPrice.Value) ? "0": inputProductPrice.Value);
        userBook.DeliveryValue = Convert.ToDecimal(String.IsNullOrEmpty(inputDeliveryPrice.Value) ? "0" : inputDeliveryPrice.Value);
        userBook.TotalCost = Convert.ToDecimal(inputCost.Value);
        userBook.CreatedDate = DateTime.Now;
        userBook.ModifiedDate = DateTime.Now;
        userBook.DeliveryRespond = "O";
        userBook.ProductRespond = "O";
        userBook.Status = "O";
        var result = tempClient.SaveBooking(userBook);
        if (result.IsSuccess && result.Result != null)
        {
            Page.RegisterClientScriptBlock("myalert",string.Format("<script>alert('{0}');</script>","Booking Successfully"));
            Response.Redirect("booking_success.aspx");
        }
        else {
            Page.RegisterClientScriptBlock("myalert", string.Format("<script>alert('{0}');</script>", "Booking Fails"));
        }

    }



    protected void btnLinkView_Click(object sender, EventArgs e)
    {
        Response.Write("<script>");
        Response.Write("window.open('detail_delivery.aspx?DeliveryId=" + SelectDelivery.SelectedValue+"','_blank')");
        Response.Write("</script>");
        //Response.Redirect("detail_delivery.aspx?DeliveryId=" + SelectDelivery.Value);
    }

    protected void SelectDelivery_SelectedIndexChanged(object sender, EventArgs e)
    {
       var result = tempClient.GetAllDeliveryTypeByDeliveryId(Convert.ToInt64(SelectDelivery.SelectedValue));
        if (result.IsSuccess && result.Result != null)
        {
            SelectDeliveryType.Items.Clear();
            foreach (var temp in result.Result)
            {
                ListItem tempList = new ListItem();
                tempList.Value = temp.Price.ToString();
                tempList.Text = temp.DeliveryDescription;
                SelectDeliveryType.Items.Add(tempList);
            }
        }
    }

    protected void SelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        long producttype;
        if (long.TryParse(SelectType.SelectedValue, out producttype))
        {
            var Price = tempClient.GetProductPriceByProductAndTypeId(productid, producttype);
            if (Price.IsSuccess && Price.Result != null && Price.Result.Count != 0)
            {
               inputProductPrice.Value = Price.Result.FirstOrDefault().Price.ToString();
            }
            else
            {
                var DefaultPrice = tempClient.GetProductById(productid);
                if (DefaultPrice.Result != null)
                    inputProductPrice.Value = DefaultPrice.Result.Price.ToString();
            }
            inputCost.Value = Convert.ToDecimal( String.IsNullOrEmpty(inputDeliveryPrice.Value) ? "0": inputDeliveryPrice.Value) + Convert.ToDecimal(String.IsNullOrEmpty(inputProductPrice.Value) ? "0" : inputProductPrice.Value)+"";
        }
    }

    protected void SelectDeliveryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            inputCost.Value = Convert.ToDecimal(String.IsNullOrEmpty(inputDeliveryPrice.Value) ? "0" : inputDeliveryPrice.Value) + Convert.ToDecimal(String.IsNullOrEmpty(inputProductPrice.Value) ? "0" : inputProductPrice.Value)+"";
        }
        catch { }
    }

    protected void btnTake_Click(object sender, EventArgs e)
    {
        var result = tempClient.GetAllDeliveryTypeByDeliveryId(Convert.ToInt64(SelectDelivery.SelectedValue));
        if (result.IsSuccess && result.Result != null)
        {
            SelectDeliveryType.Items.Clear();
            foreach (var temp in result.Result)
            {
                ListItem tempList = new ListItem();
                tempList.Value = temp.Price.ToString();
                tempList.Text = temp.DeliveryDescription;
                SelectDeliveryType.Items.Add(tempList);
            }
        }
    }


    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        Calculate();
    }
    public void Calculate()
    {
        long producttype;
        if (long.TryParse(SelectType.SelectedValue, out producttype))
        {
            var Price = tempClient.GetProductPriceByProductAndTypeId(productid, producttype);
            if (Price.IsSuccess && Price.Result != null && Price.Result.Count != 0)
            {
                inputProductPrice.Value = Price.Result.FirstOrDefault().Price.ToString();
            }
            else
            {
                var DefaultPrice = tempClient.GetProductById(productid);
                if (DefaultPrice.Result != null)
                    inputProductPrice.Value = DefaultPrice.Result.Price.ToString();
            }
        }
        inputProductCost.Value = inputProductPrice.Value;
        inputDeliveryPrice.Value = SelectDeliveryType.SelectedValue;
        inputDeliveryCost.Value = inputDeliveryPrice.Value;
        inputCost.Value = Convert.ToDecimal(String.IsNullOrEmpty(inputDeliveryPrice.Value) ? "0" : inputDeliveryPrice.Value) + Convert.ToDecimal(String.IsNullOrEmpty(inputProductPrice.Value) ? "0" : inputProductPrice.Value) + "";
    }
}