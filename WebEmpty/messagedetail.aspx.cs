using WebEmpty.MasterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class messagedetail : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long id;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        id = Convert.ToInt64(Request["Id"]);
        var Item = tempClient.GetMessageById(id);
        if (Item.IsSuccess && Item.Result != null)
        {
            inputFrom.Value = Item.Result.From;
            inputSubject.Value = Item.Result.Subject;
            inputBody.Value = Item.Result.Body;
            Item.Result.Status = true;
            tempClient.SaveMessage(Item.Result);
        }
    }
}