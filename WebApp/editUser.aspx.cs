using MasterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class editUser : System.Web.UI.Page
{
    MasterServiceClient tempClient;
    long userid;
    User currentUser;
    protected void Page_Load(object sender, EventArgs e)
    {      
        tempClient = new MasterServiceClient();
        if (!IsPostBack)
        { 
            long id;
            if (Session["UserType"] != null)
            {
                if (Session["UserId"] != null && long.TryParse(Session["UserId"].ToString(), out userid))
                {
                    var current = tempClient.GetUserById(userid);
                    if (!current.IsSuccess || current.Result == null)
                    {
                        return;
                    }
                    currentUser = current.Result;
                    //inputBirthDay.Value = currentUser.DateOfBirth.Day + "/" + currentUser.DateOfBirth.Month + "/" + currentUser.DateOfBirth.Year;
                    inputBirthDay.Value = currentUser.DateOfBirth.ToShortDateString();
                    inputDisplay.Value = currentUser.FullName;
                    inputPhoneNumber.Value = currentUser.Phone;
                    inputEmail.Value = currentUser.Email;
                    inputUserType.Value = currentUser.AccountType == "1" ? "Client" : currentUser.AccountType == "2" ? "Product" : "Delivery";
                    switch (Session["UserType"].ToString())
                    {
                        case "1":
                            if (Session["ClientId"] != null && long.TryParse(Session["ClientId"].ToString(), out id))
                            {
                                var tempProductBook = tempClient.GetClientById(id);
                                if (tempProductBook.IsSuccess && tempProductBook.Result != null)
                                {
                                    clientdiv.Visible = true;
                                    deliverydiv.Visible = false;
                                    productdiv.Visible = false;
                                    inputMonth.Value = tempProductBook.Result.CCExpiredMonth.Value.ToString();
                                    inputYear.Value = tempProductBook.Result.CCExpiredYear.Value.ToString();
                                    inputCreditCard.Value = tempProductBook.Result.CCHolder;
                                    inputCreditCardNumber.Value = tempProductBook.Result.CCNumber;
                                    inputSecPin.Value = tempProductBook.Result.CCPin;
                                    rdCash.Checked = tempProductBook.Result.PaymentMode == 1;
                                    rdCCard.Checked = tempProductBook.Result.PaymentMode == 2;
                                }
                            }
                            break;
                        case "2":
                            if (Session["ProductId"] != null && long.TryParse(Session["ProductId"].ToString(), out id))
                            {
                                var tempProductBook = tempClient.GetProductById(id);
                                if (tempProductBook.IsSuccess && tempProductBook.Result != null)
                                {
                                    clientdiv.Visible = false;
                                    deliverydiv.Visible = false;
                                    productdiv.Visible = true;
                                    inputPrdDes.Value = tempProductBook.Result.ProductDescription;
                                    inputPriceMember.Value = String.Format("{0}", tempProductBook.Result.Price);
                                    inputBankAccount.Value = tempProductBook.Result.BankAccNumber;
                                    inputAccountName.Value = tempProductBook.Result.BankAccount;
                                    selectBankName.Value = tempProductBook.Result.BankName;
                                    selectLanguage1.Value = tempProductBook.Result.Language1;
                                    selectLanguage2.Value = tempProductBook.Result.Language2;
                                    selectPreferrableArea.Value = tempProductBook.Result.PreferrableLocation;
                                    selectPrTypeMember.Value = tempProductBook.Result.Group;
                                }
                            }
                            break;
                        case "3":
                            if (Session["DeliveryId"] != null && long.TryParse(Session["DeliveryId"].ToString(), out id))
                            {
                                var tempDelivery = tempClient.GetDeliveryById(id);
                                if (tempDelivery.IsSuccess && tempDelivery.Result != null)
                                {
                                    clientdiv.Visible = false;
                                    deliverydiv.Visible = true;
                                    productdiv.Visible = false;
                                    inputAddress.Value = tempDelivery.Result.Address;
                                    inputDistrict.Value = tempDelivery.Result.Disctrict;
                                    inputHighest.Value = String.Format("{0}", tempDelivery.Result.HighestPrice);
                                    inputLowest.Value = String.Format("{0}", tempDelivery.Result.LowestPrice);
                                    inputHotelName.Value = tempDelivery.Result.Name;
                                    inputHotelPhoneNumber.Value = tempDelivery.Result.Phone;
                                    inputHotelEmail.Value = tempDelivery.Result.Email;
                                    inputCity.Value = tempDelivery.Result.City;
                                }
                            }
                            break;
                    }
                }
            }
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            long id;
            if (Session["UserId"] != null && long.TryParse(Session["UserId"].ToString(), out userid))
            {
                var current = tempClient.GetUserById(userid);
                if (!current.IsSuccess || current.Result == null)
                {
                    return;
                }
                currentUser = current.Result;
                currentUser.FullName = inputDisplay.Value;
                currentUser.Email = inputEmail.Value;
                currentUser.Phone = inputPhoneNumber.Value;
                currentUser.SecurityQuestionId = (short)selectQuestion.SelectedIndex;
                currentUser.SecurityAnswer = inputAnswer.Value;
                if (!string.IsNullOrEmpty(inputBirthDay.Value))
                    currentUser.DateOfBirth = Convert.ToDateTime(inputBirthDay.Value);
                currentUser.Clients = null;
                currentUser.Products = null;
                currentUser.Deliveries = null;
                currentUser.Photos = null;
                currentUser.MoneyTransactions = null;
                currentUser.MoneyTransactions1 = null;
                currentUser.Messages = null;
                switch (Session["UserType"].ToString())
                {
                    case "1":
                        if (Session["ClientId"] != null && long.TryParse(Session["ClientId"].ToString(), out id))
                        {
                            var tempClientUser = tempClient.GetClientById(id);
                            //clientregister.Id = id;
                            if (tempClientUser.IsSuccess && tempClientUser.Result != null)
                            {
                                tempClientUser.Result.CCExpiredMonth = Convert.ToInt16(inputMonth.Value);
                                tempClientUser.Result.CCExpiredYear = Convert.ToInt16(inputYear.Value);
                                tempClientUser.Result.CCHolder = inputCreditCard.Value;
                                tempClientUser.Result.CCNumber = inputCreditCardNumber.Value;
                                tempClientUser.Result.CCPin = inputSecPin.Value;
                                tempClientUser.Result.PaymentMode = rdCash.Checked ? 1 : rdCCard.Checked ? 2 : 0;
                                tempClientUser.Result.User = null;
                                tempClientUser.Result.Bookings = null;
                                tempClientUser.Result.ClientComments = null;
                                tempClient.SaveClient(tempClientUser.Result);
                            }
                        }
                        break;
                    case "2":
                        if (Session["ProductId"] != null && long.TryParse(Session["ProductId"].ToString(), out id))
                        {
                            var ProductTemp = tempClient.GetProductById(id);
                            //clientregister.Id = id;
                            if (ProductTemp.IsSuccess && ProductTemp.Result != null)
                            {
                                ProductTemp.Result.Language1 = selectLanguage1.Value;
                                ProductTemp.Result.Language2 = selectLanguage2.Value;
                                ProductTemp.Result.PreferrableLocation = selectPreferrableArea.Value;
                                ProductTemp.Result.Price = Convert.ToDecimal(inputPriceMember.Value);
                                ProductTemp.Result.ProductDescription = inputPrdDes.Value;
                                ProductTemp.Result.Group = selectPrTypeMember.Value;
                                ProductTemp.Result.BankName = selectBankName.Value;
                                ProductTemp.Result.BankAccNumber = inputBankAccount.Value;
                                ProductTemp.Result.BankAccount = inputAccountName.Value;
                                ProductTemp.Result.Bookings = null;
                                ProductTemp.Result.ClientComments = null;
                                ProductTemp.Result.ProductPrices = null;
                                ProductTemp.Result.Videos = null;
                                tempClient.SaveProduct(ProductTemp.Result);
                            }
                        }
                        break;
                    case "3":
                        if (Session["DeliveryId"] != null && long.TryParse(Session["DeliveryId"].ToString(), out id))
                        {
                            var DeliveryTemp = tempClient.GetDeliveryById(id);
                            //clientregister.Id = id;
                            if (DeliveryTemp.IsSuccess && DeliveryTemp.Result != null)
                            {
                                DeliveryTemp.Result.Name = inputHotelName.Value;
                                DeliveryTemp.Result.Phone = inputHotelPhoneNumber.Value;
                                DeliveryTemp.Result.Email = inputEmail.Value;
                                DeliveryTemp.Result.Quality = Convert.ToInt32(inputQuality.Value);
                                DeliveryTemp.Result.Address = inputAddress.Value;
                                DeliveryTemp.Result.City = inputCity.Value;
                                DeliveryTemp.Result.Disctrict = inputDistrict.Value;
                                DeliveryTemp.Result.LowestPrice = Convert.ToDecimal(inputLowest.Value);
                                DeliveryTemp.Result.HighestPrice = Convert.ToDecimal(inputHighest.Value);
                                DeliveryTemp.Result.User = null;
                                DeliveryTemp.Result.DeliveryTypes = null;
                                DeliveryTemp.Result.ClientComments = null;
                                DeliveryTemp.Result.Bookings = null;
                                tempClient.SaveDelivery(DeliveryTemp.Result);
                            }
                        }
                        break;
                }
                var Result = tempClient.SaveUser(currentUser);
                if (Result.IsSuccess)
                {
                    this.Page.RegisterClientScriptBlock("Key", string.Format("<script>alert('{0}')</script>", "Update Successful"));
                }
                else
                {
                    this.Page.RegisterClientScriptBlock("Key", string.Format("<script>alert('{0}')</script>", Result.ErrorMessage));
                }
            }
        }
        catch (Exception ex)
        {
            this.Page.RegisterClientScriptBlock("Key", string.Format("<script>alert('{0}')</script>", ex.Message));
        }
    }
}