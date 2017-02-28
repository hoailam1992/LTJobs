using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebEmpty.MasterService;
public partial class transactions : System.Web.UI.Page
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
        if (Session["UserId"] != null)
        {
            if (long.TryParse(Session["UserId"].ToString(), out id))
            {
                var result = tempClient.GetMoneyTransactionByDestinationId(id);
                if (result.IsSuccess && result.Result != null)
                {
                    var result2 = tempClient.GetMoneyTransactionBySourceId(id);
                    if (result2.IsSuccess && result.Result != null)
                    {
                        foreach (var transaction in result.Result)
                        {
                            result2.Result.Add(transaction);
                        }
                        foreach (var input in result2.Result)
                        {
                            if (input.ReceiptPhoto!=null)
                            input.ImgSrc = "data:image/png;base64," + Convert.ToBase64String(input.ReceiptPhoto);
                        }
                        bookinglist.DataSource = result2.Result;
                        bookinglist.DataBind();
                    }
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