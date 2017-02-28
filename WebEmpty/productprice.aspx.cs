using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebEmpty.MasterService;
public partial class productprice : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long productid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
       
            if (Session["ProductId"] != null)
            {
                var flag = long.TryParse(Session["ProductId"].ToString(), out productid);
                if (!IsPostBack)
                {
                    showgrid();
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //DataRowView drv = e.Row.DataItem as DataRowView;
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        //    {
        //        DropDownList dp = (DropDownList)e.Row.FindControl("DropDownList1");
        //        var result = tempClient.GetAllProductType();
        //        foreach(var pd  in result.Result)
        //        {
        //            ListItem lt = new ListItem();
        //            lt.Text = pd.Code;
        //            lt.Value = pd.Id.ToString();
        //            dp.Items.Add(lt);
        //        }
        //    }
        //}
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ProductPrice pptemp = new ProductPrice();
        pptemp.ProductId = productid;
        pptemp.Id =Convert.ToInt64(((Label) GridView1.Rows[e.RowIndex].FindControl("Label6")).Text);
        Label ddl = (Label)GridView1.Rows[e.RowIndex].FindControl("lbl2");
        pptemp.ProductTypeId =Convert.ToInt64(ddl.Text);
        pptemp.Active = true;
        TextBox tx1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
        
        pptemp.Price =Convert.ToDecimal(tx1.Text);
        var result = tempClient.SaveProductPrice(pptemp);
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
        var source = tempClient.GetProductPriceByProductId(productid);
        if (source.IsSuccess)
        {
            GridView1.DataSource = source.Result;
            GridView1.DataBind();
        }
    }
}