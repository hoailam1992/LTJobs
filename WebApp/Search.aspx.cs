using MasterService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    ObservableCollection<ProductItem> FullProduct = new ObservableCollection<ProductItem>();
    protected void Page_Load(object sender, EventArgs e)
    {               
            tempClient = new MasterServiceClient();
            FullProduct = new ObservableCollection<ProductItem>();
        foreach (var pro in tempClient.GetAllProductAndUser().Result.Where(c => c.IsActive && !c.IsBlocked))
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
            newItem.DefaultImage = Convert.ToBase64String(ItemPhoto.Image) != null? "data:image/png;base64," + Convert.ToBase64String(ItemPhoto.Image) : "img/love.jpg";
            FullProduct.Add(newItem);
        }   
    }
    public ObservableCollection<ProductItem> ProductList_GetData()
    {
        var result = new ObservableCollection<ProductItem>();  
        int maxage, minage;
        foreach (var pro in FullProduct)
        {
            if (!String.IsNullOrWhiteSpace(inputCode.Value) && !pro.Code.Contains(inputCode.Value))
                continue;
            if (int.TryParse(inputMaxAge.Value, out maxage))
            {
                if (!String.IsNullOrWhiteSpace(inputMaxAge.Value) && !(pro.Age <= Convert.ToInt32(inputMaxAge.Value)))
                    continue;
            }
            if (int.TryParse(inputMinAge.Value, out minage))
            {
                if (!String.IsNullOrWhiteSpace(inputMinAge.Value) && !(pro.Age >= Convert.ToInt32(inputMinAge.Value)))
                    continue;
            }
            if (int.TryParse(inputMinPrice.Value, out maxage))
            {
                if (!String.IsNullOrWhiteSpace(inputMinPrice.Value) && !(pro.Price >= Convert.ToInt32(inputMinPrice.Value)))
                    continue;
            }
            if (int.TryParse(inputMaxPrice.Value, out minage))
            {
                if (!String.IsNullOrWhiteSpace(inputMaxPrice.Value) && !(pro.Price <= Convert.ToInt32(inputMaxPrice.Value)))
                    continue;
            }
            if (!String.IsNullOrEmpty(selectLanguage1.Value))
            {
                if (selectLanguage1.Value != pro.Language1 && selectLanguage1.Value != pro.Language2)
                    continue;
            }
            if (!String.IsNullOrEmpty(selectLanguage2.Value))
            {
                if (selectLanguage2.Value != pro.Language1 && selectLanguage2.Value != pro.Language2)
                    continue;
            }
            if (!String.IsNullOrEmpty(selectPreferrableArea.Value))
            {
                if (selectPreferrableArea.Value != pro.PreferrableLocation)
                    continue;
            }
            if (!String.IsNullOrEmpty(selectPrTypeMember.Value))
            {
                if (selectPrTypeMember.Value != pro.Group)
                    continue;
            }
            result.Add(pro);
        }
        return result;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ProductList.DataBind();          
    }
}