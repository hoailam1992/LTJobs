using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterService;
using System.Text;
using System.Security.AccessControl;
using System.IO;
using System.Runtime.Caching;
public partial class MasterPage : System.Web.UI.MasterPage
{
    MasterServiceClient tempClient;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        if (!Page.IsPostBack)
        {
            ObjectCache cache = MemoryCache.Default;
            try
            {
                #region 
                //if (cache["CarouselInnerHtml"] != null && cache["CarouselIndicatorsHtml"] != null)
                //{
                //    //use the cached html
                //    ltlCarouselImages.Text = cache["CarouselInnerHtml"].ToString();
                //    ltlCarouselIndicators.Text = cache["CarouselIndicatorsHtml"].ToString();
                //}
                //else
                //{                    
                //filtering to jpgs, but ideally not required
                //var result = new ObservableCollection<Product>(tempClient.GetAllProduct().Result ?? new List<Product>());
                //if (result.Count > 0)
                //{
                //    var carouselInnerHtml = new StringBuilder();
                //    var indicatorsHtml = new StringBuilder(@"<ol class='carousel-indicators'>");
                //    //loop through and build up the html for indicators + images
                //    for (int i = 0; i < result.Count; i++)
                //    {
                //        var fileName = result[i];
                //        carouselInnerHtml.AppendLine(i == 0 ? "<div class='item active'>" : "<div class='item'>");
                //        //carouselInnerHtml.AppendLine(" <div class='fill' style='background-image: url('../img/silde.jpg');'></div>");
                //        carouselInnerHtml.AppendLine("<a href='detail_product.aspx?Id=" + fileName.Id + "'>");
                //        carouselInnerHtml.AppendLine(" <img class='fill' src='/img/love.jpg' " + "></img>");
                //        carouselInnerHtml.AppendLine(" <div class='carousel-caption'><h1> " + fileName.Code +"<br/></h1></div> ");
                //        //carouselInnerHtml.AppendLine("<label alt='Slide #" + (i + 1) + "'>"+ fileName.Code + " </label>");
                //        carouselInnerHtml.AppendLine("</a></div>");
                //        indicatorsHtml.AppendLine(i == 0 ? @"<li data-target='#myCarousel' data-slide-to='" + i + "' class='active'></li>" : @"<li data-target='#myCarousel' data-slide-to='" + i + "' class=''></li>");
                //    }
                //    //close tag
                //    indicatorsHtml.AppendLine("</ol>");
                //    //stick the html in the literal tags and the cache
                //    cache["CarouselInnerHtml"] = ltlCarouselImages.Text = carouselInnerHtml.ToString();
                //    cache["CarouselIndicatorsHtml"] = ltlCarouselIndicators.Text = indicatorsHtml.ToString();
                //}                    
                //}
                //if (cache["CarouselInnerHtmlNew"] != null && cache["CarouselIndicatorsHtmlNew"] != null)
                //{
                //    //use the cached html
                //    ltlCarouselImagesNew.Text = cache["CarouselInnerHtmlNew"].ToString();
                //    ltlCarouselIndicatorsNew.Text = cache["CarouselIndicatorsHtmlNew"].ToString();
                //}
                //else
                //{
                //    var result = new ObservableCollection<Product>(tempClient.GetAllProduct().Result ?? new List<Product>());
                //    if (result.Count > 0)
                //    {
                //        var carouselInnerHtml = new StringBuilder();
                //        var indicatorsHtml = new StringBuilder(@"<ol class='carousel-indicators'>");
                //        //loop through and build up the html for indicators + images
                //        for (int i = 0; i < result.Count; i++)
                //        {
                //            var fileName = result[i];
                //            carouselInnerHtml.AppendLine(i == 0 ? "<div class='item active'>" : "<div class='item'>");
                //            //carouselInnerHtml.AppendLine(" <div class='fill' style='background-image: url('../img/silde.jpg');'></div>");
                //            carouselInnerHtml.AppendLine("<a href='detail_product.aspx?Id=" + fileName.Id + "'>");
                //            carouselInnerHtml.AppendLine(" <img class='fill' src='/img/slide.jpg' " + "></img>");
                //            carouselInnerHtml.AppendLine(" <div class='carousel-caption'><h1> " + fileName.Code + "<br/></h1></div> ");
                //            //carouselInnerHtml.AppendLine("<label alt='Slide #" + (i + 1) + "'>"+ fileName.Code + " </label>");
                //            carouselInnerHtml.AppendLine("</a></div>");
                //            indicatorsHtml.AppendLine(i == 0 ? @"<li data-target='#myCarouselNew' data-slide-to='" + i + "' class='active'></li>" : @"<li data-target='#myCarouselNew' data-slide-to='" + i + "' class=''></li>");
                //        }
                //        //close tag
                //        indicatorsHtml.AppendLine("</ol>");
                //        //stick the html in the literal tags and the cache
                //        cache["CarouselInnerHtmlNew"] = ltlCarouselImagesNew.Text = carouselInnerHtml.ToString();
                //        cache["CarouselIndicatorsHtmlNew"] = ltlCarouselIndicatorsNew.Text = indicatorsHtml.ToString();
                //    }
                //}
                #endregion
                if (cache["CarouselInnerHtml"] != null)
                {
                    //use the cached html
                    ltlCarouselImages.Text = cache["CarouselInnerHtml"].ToString();                    
                }
                else
                {
                    tempClient = new MasterServiceClient();
                    var result = new ObservableCollection<Product>(tempClient.GetAllProduct().Result ?? new List<Product>());
                    if (result.Count > 0)
                    {
                        var carouselInnerHtml = new StringBuilder();
                        //loop through and build up the html for indicators + images
                        for (int i = 0; i < result.Count; i++)
                        {
                            var fileName = result[i];
                            var photoResult = tempClient.GetPhotoByUserId(fileName.UserId);
                            string imagesource = @"/img/love.jpg";
                            if (photoResult.IsSuccess && photoResult.Result != null && photoResult.Result.Count > 0)
                            {
                                imagesource = "data:image/png;base64," + Convert.ToBase64String(photoResult.Result.FirstOrDefault().Image);
                            }
                            else { continue; }
                            carouselInnerHtml.AppendLine("<div class='item'>");
                            carouselInnerHtml.AppendLine("<a href='detail_product.aspx?Id=" + fileName.Id + "' >");
                            //carouselInnerHtml.AppendLine("<asp:Panel ToolTip='"+ fileName.Code + "'>");
                            carouselInnerHtml.AppendLine(" <img data-u='image' class='fill' src='"+ imagesource + "' alt=''></img>");
                            //carouselInnerHtml.AppendLine("<span class='spacer'>" + fileName.Code + "</span><br/> " + fileName.Price + "");
                            //carouselInnerHtml.AppendLine("</asp:Panel >");
                            carouselInnerHtml.AppendLine("</a></div>");
                        }
                        ltlCarouselImages.Text = carouselInnerHtml.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //something is dodgy so flush the cache
                if (cache["CarouselInnerHtml"] != null)
                {
                    Cache.Remove("CarouselInnerHtml");
                }                
            }
        }
    } 

    protected void btnLog_Load(object sender, EventArgs e)
    {
        NodifyDiv.Visible = false;
        bookingdiv.Visible = false;
        if (Session["UserName"] == null)
        {
            lblLog.Text = "Log In";
            lblLog.NavigateUrl = "login.aspx";
            idAccountDetail.Visible = false;
            idBookingStatus.Visible = false;           
        }
        else {
            lblLog.Text = "Log Out";
            lblLog.NavigateUrl = "login.aspx?logout=" + true;
            idAccountDetail.Visible = true;
            idBookingStatus.Visible = true;
            long id,userid;
            
            if (Session["UserId"] != null && long.TryParse(Session["UserId"].ToString(), out userid))
            {
                var tempMess = tempClient.GetMessageByUserId(userid);
                if (tempMess.IsSuccess && tempMess.Result != null && tempMess.Result.FirstOrDefault(c=>c.Status==false)!=null)
                {
                    NodifyDiv.Visible = true;
                }
            }
            if (Session["UserType"] != null && Session["UserType"].ToString()!="1")
            {
                switch (Session["UserType"].ToString())
                {
                    case "2":
                        if (Session["ProductId"] != null && long.TryParse(Session["ProductId"].ToString(), out id))
                        {
                            var tempProductBook = tempClient.GetNewBookingByProductId(id);
                            if (tempProductBook.IsSuccess && tempProductBook.Result != null && tempProductBook.Result.Count > 0)
                            {
                                bookingdiv.Visible = true;
                            }
                        }
                        break;
                    case "3":
                        if (Session["DeliveryId"] != null && long.TryParse(Session["DeliveryId"].ToString(), out id))
                        {
                            var tempDeliveryBook = tempClient.GetNewBookingByDeliveryId(id);
                            if (tempDeliveryBook.IsSuccess && tempDeliveryBook.Result != null && tempDeliveryBook.Result.Count > 0)
                            {
                                bookingdiv.Visible = true;
                            }
                        }
                        break;
                }
            }
        }
    }

    protected void lblRegister_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
        {
            lblRegister.Text = "Register";
            lblRegister.NavigateUrl = "register.aspx";
        }
        else
        {
            lblRegister.Text = Session["UserName"].ToString();
            lblRegister.NavigateUrl = "account.aspx";
        }
    }

    protected void lblRegister_Click(object sender, EventArgs e)
    {
        if (lblRegister.Text != "Register")
        {
            Response.Redirect("account.aspx");
        }
        else
        {
            Response.Redirect("register.aspx");
        }
    }

    // The return type can be changed to IEnumerable, however to support
    // paging and sorting, the following parameters must be added:
    //     int maximumRows
    //     int startRowIndex
    //     out int totalRowCount
    //     string sortByExpression
    public ObservableCollection<MasterService.Product> ProductList_GetData()
    {
        var result = new ObservableCollection<Product>(tempClient.GetAllProduct().Result ?? new List<Product>());
        return result;
    }
}
