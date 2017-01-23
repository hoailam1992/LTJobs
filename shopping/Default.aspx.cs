using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterService;
using System.Collections.ObjectModel;
public partial class _Default : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterServiceClient();
    }

    // The return type can be changed to IEnumerable, however to support
    // paging and sorting, the following parameters must be added:
    //     int maximumRows
    //     int startRowIndex
    //     out int totalRowCount
    //     string sortByExpression
    public ObservableCollection<ProductItem> ProductList_GetData()
    {
        var result = new ObservableCollection<ProductItem>();
        foreach (var pro in tempClient.GetAllProduct().Result.Where(c=>c.IsActive))
        {
            ProductItem newItem = new ProductItem();
            newItem.Id = pro.Id;
            newItem.Code = pro.Code;
            newItem.Price = pro.Price;
            newItem.ProductDescription = pro.ProductDescription;
            var ItemPhoto = tempClient.GetPhotoByUserId(pro.UserId).Result.FirstOrDefault();
            newItem.DefaultImage = "data:image/png;base64,"+ Convert.ToBase64String(ItemPhoto.Image) ?? "img/love.jpg";
            result.Add(newItem);
        }       
        return result;
    }
}
