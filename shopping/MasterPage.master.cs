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

                tempClient = new MasterServiceClient();
                var result = new ObservableCollection<Product>(tempClient.GetAllProduct().Result ?? new List<Product>());
                if (result.Count > 0)
                {
                    var carouselInnerHtml = new StringBuilder();
                    //loop through and build up the html for indicators + images
                    for (int i = 0; i < result.Count; i++)
                    {
                        var fileName = result[i];
                        carouselInnerHtml.AppendLine(i == 0 ? "<div class='item' style='display:none;'>" : "<div class='item'>");
                        carouselInnerHtml.AppendLine("<a href='detail_product.aspx?Id=" + fileName.Id + "'>");
                        carouselInnerHtml.AppendLine(" <img data-u='image' class='fill' src='/img/love.jpg' alt=''></img>");
                        carouselInnerHtml.AppendLine(" <h2> <span>" + fileName.Code + "<span class='spacer'></span><br/> "+fileName.Price+"</h2>");
                        carouselInnerHtml.AppendLine("<</a></div>");
                    }
                    ltlCarouselImages.Text = carouselInnerHtml.ToString();
                }
            }
            catch (Exception)
            {
                //something is dodgy so flush the cache
                if (cache["CarouselInnerHtml"] != null)
                {
                    Cache.Remove("CarouselInnerHtml");
                }
                if (cache["CarouselIndicatorsHtml"] != null)
                {
                    Cache.Remove("CarouselIndicatorsHtml");
                }
            }
        }
    } 

    protected void btnLog_Load(object sender, EventArgs e)
    {     
        if (Session["UserName"] == null)
        {
            lblLog.Text = "Log In";
            lblLog.NavigateUrl = "login.aspx";
        }
        else {
            lblLog.Text = "Log Out";
            lblLog.NavigateUrl = "login.aspx?logout=" + true;        
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
