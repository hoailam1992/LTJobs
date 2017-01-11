using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterService;
using System.Globalization;

public partial class register : System.Web.UI.Page
{
    MasterService.MasterServiceClient tempClient;
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterService.MasterServiceClient(); 
    }

    public void BtnRegister_Click(object sender, EventArgs e)
    {       
        User RegisterUser = new User();     
        RegisterUser.UserName = inputUsername.Value;
        RegisterUser.FullName = inputDisplay.Value;
        RegisterUser.Email = inputEmail.Value;
        RegisterUser.Id = 0;
        RegisterUser.IsBlocked = false;
        RegisterUser.Phone = inputPhoneNumber.Value;       
        RegisterUser.SecurityQuestionId = (short)selectQuestion.SelectedIndex;
        RegisterUser.SecurityAnswer = inputAnswer.Value;
        RegisterUser.AccountType = rdClient.Checked ? "1" : rdProduct.Checked ? "2" : "3";
        string strdate = inputBirthDay.Value;
        RegisterUser.DateOfBirth = new DateTime(Convert.ToInt32(strdate.Split('/')[2]), Convert.ToInt32(strdate.Split('/')[1]), Convert.ToInt32(strdate.Split('/')[0]));
        RegisterUser.Clients = null;
        RegisterUser.Products = null;
        RegisterUser.Deliveries = null;
        RegisterUser.Photos = null;
        RegisterUser.MoneyTransactions = null;
        RegisterUser.MoneyTransactions1 = null;
        RegisterUser.Messages = null;
        if (inputPass.Value == inputRetypePass.Value)
        {
            RegisterUser.Password = inputRetypePass.Value;        
            var resultuser = tempClient.SaveUser(RegisterUser);
            if (resultuser.IsSuccess && resultuser.Result != null)
            {
                if (rdClient.Checked)
                {
                    Client clientregister = new Client();
                    clientregister.Id = 0;
                    clientregister.IsValid = false;
                    clientregister.Balance = 0;
                    clientregister.CancelCount = 0;
                    clientregister.CCExpiredMonth = Convert.ToInt16(inputMonth.Value);
                    clientregister.CCExpiredYear = Convert.ToInt16(inputYear.Value);
                    clientregister.CCHolder = inputCreditCard.Value;
                    clientregister.CCNumber = inputCreditCardNumber.Value;
                    clientregister.CCPin = inputSecPin.Value;
                    clientregister.CreatedDate = DateTime.Now;
                    clientregister.PaymentMode = rdCash.Checked ? 1 : rdCCard.Checked ? 2 : 0;
                    clientregister.UserId = resultuser.Result.Id;
                    clientregister.Bookings = null;
                    clientregister.ClientComments = null;
                    clientregister.User = null;
                    
                    var ClientResult = tempClient.SaveClient(clientregister);
                }
                if (rdProduct.Checked)
                {
                    Product productregister = new Product();
                    productregister.Id = 0;
                    productregister.IsActive = false;
                    productregister.IsAvailable = false;
                    productregister.Language1 = selectLanguage1.Value;
                    productregister.Language2 = selectLanguage2.Value;
                    productregister.PreferrableLocation = selectPreferrableArea.Value;
                    productregister.Price = Convert.ToDecimal(inputPriceMember.Value);
                    productregister.ProductDescription = inputPrdDes.Value;
                    productregister.CancelCount = 0;
                    productregister.Balance = 0;
                    productregister.BankName = selectBankName.Value;
                    productregister.BankAccNumber = inputBankAccount.Value;
                    productregister.BankAccount = inputAccountName.Value;
                    productregister.Commission = 0;
                    productregister.UserId = resultuser.Result.Id;
                    productregister.Bookings = null;
                    productregister.ClientComments = null;
                    productregister.ProductPrices = null;
                    productregister.Videos = null;
                    var ProductResult = tempClient.SaveProduct(productregister);
                }
                if (rdDelivery.Checked)
                {
                    Delivery deliveryregister = new Delivery();
                    deliveryregister.Id = 0;
                    deliveryregister.Name = inputHotelName.Value;
                    deliveryregister.Phone = inputHotelPhoneNumber.Value;
                    deliveryregister.Quality = Convert.ToInt16(2);
                    deliveryregister.Email = inputEmail.Value;
                    deliveryregister.Address = inputAddress.Value;
                    deliveryregister.City = inputCity.Value;
                    deliveryregister.Disctrict = inputDistrict.Value;
                    deliveryregister.LowestPrice = Convert.ToDecimal(inputLowest.Value);
                    deliveryregister.HighestPrice = Convert.ToDecimal(inputHighest.Value);
                    deliveryregister.Commission = Convert.ToDecimal(0);
                    deliveryregister.UserId = resultuser.Result.Id;
                    deliveryregister.User = null;
                    deliveryregister.DeliveryTypes = null;
                    deliveryregister.ClientComments = null;
                    deliveryregister.Bookings = null;                    
                    var DeliveryRegister = tempClient.SaveDelivery(deliveryregister);

                }
            }
        }
    }
}