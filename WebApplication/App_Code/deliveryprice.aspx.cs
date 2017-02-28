using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterService;
public partial class deliveryprice : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long productid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
        if (Session["DeliveryId"] != null)
        {
            var flag = long.TryParse(Session["DeliveryId"].ToString(), out productid);
            showgrid();
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DeliveryType pptemp = new DeliveryType();
        pptemp.DeliveryId = productid;
        pptemp.Id = Convert.ToInt64(((Label)GridView1.Rows[e.RowIndex].FindControl("Label6")).Text);
        Label ddl = (Label)GridView1.Rows[e.RowIndex].FindControl("DropDownList1");
        pptemp.Code = 0;
        pptemp.Active = true;
        TextBox tx2 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("tx2");
        pptemp.DeliveryDescription =tx2.Text;
        TextBox TextBox1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
        pptemp.ExtraFee = TextBox1.Text;
        TextBox TextBoxPrice = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxPrice");
        pptemp.Price =Convert.ToDecimal(TextBoxPrice.Text);
        var result = tempClient.SaveDeliveryType(pptemp);
        GridView1.EditIndex = -1;
        showgrid();
    }
    protected void GridView1_RowCancelingEdit
        (object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        showgrid();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        showgrid();
    }
    public void showgrid()
    {
        var source = tempClient.GetAllDeliveryTypeByDeliveryId(productid);
        if (source.IsSuccess)
        {
            GridView1.DataSource = source.Result;
            GridView1.DataBind();
        }
    }

    protected void btnBook_Click(object sender, EventArgs e)
    {
        try
        {
            DeliveryType tempDelivery = new DeliveryType();
            tempDelivery.Id = 0;
            tempDelivery.Code = Convert.ToInt64(inputProductCode.Value);
            tempDelivery.CreatedDate = DateTime.Now;
            tempDelivery.ModifiedDate = DateTime.Now;
            tempDelivery.DeliveryDescription = inputDescription.Value;
            tempDelivery.ExtraFee = inputExtraFee.Value;
            tempDelivery.DeliveryId = productid;
            tempDelivery.Price = Convert.ToDecimal(inputPrice.Value);
            var tempResult = tempClient.SaveDeliveryType(tempDelivery);
            if (tempResult.IsSuccess && tempResult.Result != null)
            {
                showgrid();
                inputDescription.Value = "";
                inputExtraFee.Value = "";
                inputPrice.Value = "";
                inputProductCode.Value = "";
            }
            else {
                this.Page.RegisterClientScriptBlock("Key", string.Format("<script>alert('{0}')</script>", tempResult.ErrorMessage));
            }
        }
        catch (Exception ex)
        {
            this.Page.RegisterClientScriptBlock("Key", string.Format("<script>alert('{0}')</script>", ex.Message));
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long id = Convert.ToInt64(((Label)GridView1.Rows[e.RowIndex].FindControl("Label6")).Text);
        tempClient.DeleteDeliveryTypeById(id);
        GridView1.EditIndex = -1;
        showgrid();
    }
}