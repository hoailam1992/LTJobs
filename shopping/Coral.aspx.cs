using MasterService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Coral : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    protected void Page_Load(object sender, EventArgs e)
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
                carouselInnerHtml.AppendLine(i == 0 ? "<div class='item' style='display:none;'>" : "<div class='item'>");
                carouselInnerHtml.AppendLine("<a href='detail_product.aspx?Id=" + fileName.Id + "'>");
                carouselInnerHtml.AppendLine(" <img data-u='image'  class='fill' src='/img/love.jpg' " + "></img>");
                carouselInnerHtml.AppendLine(" <div><h1> " + fileName.Code + "<br/></h1></div> ");
                carouselInnerHtml.AppendLine("</a></div>");
            }
            //stick the html in the literal tags and the cache
            ltlCarouselImages.Text = carouselInnerHtml.ToString();          
        }
    }
}