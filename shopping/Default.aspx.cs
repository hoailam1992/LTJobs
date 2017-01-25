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
        tempClient = new MasterServiceClient();      
        foreach (var pro in tempClient.GetAllProductAndUser().Result.Where(c => c.IsActive && !c.IsBlocked).Take(10))
        {
            ProductItem newItem = new ProductItem();
            newItem.Age = DateTime.Now.Year - pro.User.DateOfBirth.Year;
            newItem.FullName = pro.User.FullName;
            newItem.Group = pro.Group;
            newItem.PreferrableLocation = pro.PreferrableLocation;
            newItem.Id = pro.Id;
            newItem.Code = pro.Code;
            newItem.Price = pro.Price;
            newItem.Language1 = pro.Language1;
            newItem.Language2 = pro.Language2;
            newItem.ProductDescription = pro.ProductDescription;
            var ItemPhoto = tempClient.GetDefaultPhotoByUserId(pro.UserId).Result;
            newItem.DefaultImage = "data:image/png;base64," + Convert.ToBase64String(ItemPhoto.Image) ?? "img/love.jpg";
            result.Add(newItem);
        }
        return result;
    }
}
