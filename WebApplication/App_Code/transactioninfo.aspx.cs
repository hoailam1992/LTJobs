using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterService;
public partial class transactioninfo : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long id;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        id = Convert.ToInt64(Request["Id"]);
        var Item = tempClient.GetMoneyTransactionById(id);
        if (Item.IsSuccess && Item.Result != null)
        {
            inputCode.Value = Item.Result.Code;
            inputDate.Value = Item.Result.Trandate.ToShortDateString();
            inputFrom.Value = Item.Result.User.UserName;
            inputTo.Value = Item.Result.User1.UserName;
            inputValue.Value = Item.Result.Value.ToString();
            inputRemark.Value = Item.Result.Remark;
            inputStatus.Value = Item.Result.Status;
            inputPaymentDate.Value = Item.Result.PaymentDate.Value.ToShortDateString();
            inputPhoto.Value = "data:image/png;base64," + Convert.ToBase64String(Item.Result.ReceiptPhoto);            
        }
    }
}