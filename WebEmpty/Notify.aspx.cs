using WebEmpty.MasterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Notify : System.Web.UI.Page
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
                var result = tempClient.GetMessageByUserId(id);
                if (result.IsSuccess && result.Result != null)
                {
                    messagelist.DataSource = result.Result;
                    messagelist.DataBind();
                }
            }
        }
       
    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (messagelist.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.BindListView();
    }
}