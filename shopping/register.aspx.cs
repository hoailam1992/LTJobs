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
        try
        {
            string errormessage = "";
            User RegisterUser = new User();
            decimal a;
            RegisterUser.UserName = inputUsername.Value;
            var check = tempClient.CheckUserName(RegisterUser.UserName);
            if (!check.Result)
            {
                errormessage += "User Name Already Exist\\n";
            }
            if (!string.IsNullOrEmpty(inputDisplay.Value))
            {
                RegisterUser.FullName = inputDisplay.Value;
            }
            else
            {
                errormessage += "Please Input Your Display Name\\n";
            }
            if (!string.IsNullOrEmpty(inputEmail.Value))
            {
                RegisterUser.Email = inputEmail.Value;
            }
            else
            {
                errormessage += "Please Input Your Email\\n";
            }            
            RegisterUser.Id = 0;
            RegisterUser.IsBlocked = false;
            if (!string.IsNullOrEmpty(inputPhoneNumber.Value))
            {
                RegisterUser.Phone = inputPhoneNumber.Value;
            }
            else
            {
                errormessage += "Please Input Your Phone Number\\n";
            }
            if ((short)selectQuestion.SelectedIndex != 0)
            {
                RegisterUser.SecurityQuestionId = (short)selectQuestion.SelectedIndex;
            }
            else {
                errormessage += "Please Select Your Security Question\\n";
            }
            if (!string.IsNullOrEmpty(inputAnswer.Value))
            {
                RegisterUser.SecurityAnswer = inputAnswer.Value;
            }
            else
            {
                errormessage += "Please Input Your Security Answer\\n";
            }
            RegisterUser.AccountType = rdClient.Checked ? "1" : rdProduct.Checked ? "2" : "3";
            if (!string.IsNullOrEmpty(inputBirthDay.Value))
            {
                RegisterUser.DateOfBirth = Convert.ToDateTime(inputBirthDay.Value);
            }
            else {
                errormessage += "Please Input Your Birthday\\n";
            }
            if (string.IsNullOrEmpty(inputPass.Value) || inputPass.Value.Length<=8)
            {             
                errormessage += "Password have to be more than 8 character \\n";
            }
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
                if (rdClient.Checked)
                {
                    Client clientregister = new Client();
                    clientregister.Id = 0;
                    clientregister.IsValid = false;
                    clientregister.Balance = 0;
                    clientregister.CancelCount = 0;
                    if (rdCCard.Checked)
                    {
                        try
                        {
                            clientregister.CCExpiredMonth = Convert.ToInt16(inputMonth.Value);
                            clientregister.CCExpiredYear = Convert.ToInt16(inputYear.Value);
                            clientregister.CCHolder = inputCreditCard.Value;
                            clientregister.CCNumber = inputCreditCardNumber.Value;
                            clientregister.CCPin = inputSecPin.Value;
                        }
                        catch (Exception ex)
                        {
                            errormessage += "Credit Card Info Not Valid\\n";
                        }
                    }
                    clientregister.CreatedDate = DateTime.Now;
                    clientregister.PaymentMode = rdCash.Checked ? 1 : rdCCard.Checked ? 2 : 0;
                    clientregister.UserId = 0;
                    clientregister.Bookings = null;
                    clientregister.ClientComments = null;
                    clientregister.User = null;
                    RegisterUser.Clients = new List<Client>();
                    RegisterUser.Clients.Add(clientregister);
                }
                if (rdProduct.Checked)
                {
                    Product productregister = new Product();
                    productregister.Id = 0;
                    productregister.IsActive = false;
                    productregister.IsAvailable = false;
                    productregister.Language1 = selectLanguage1.Value;
                    productregister.Language2 = selectLanguage2.Value;
                    if (selectPreferrableArea.Value != null)
                        productregister.PreferrableLocation = selectPreferrableArea.Value;
                    else
                        errormessage += "Please Select Preferrable Area\\n";
                    if (decimal.TryParse(inputPriceMember.Value, out a))
                    {
                        productregister.Price = Convert.ToDecimal(inputPriceMember.Value);
                    }
                    else {
                        errormessage += "Price is not valid\\n";
                    }
                    if (!string.IsNullOrEmpty(inputPrdDes.Value))
                    {
                        productregister.ProductDescription = inputPrdDes.Value;
                    }
                    else
                    {
                        errormessage += "Please Input Description\\n";
                    }
                    productregister.CancelCount = 0;
                    productregister.Balance = 0;
                    if (selectPrTypeMember.Value != null)
                        productregister.Group = selectPrTypeMember.Value;
                    else
                        errormessage += "Please Select Product Type\\n";
                    if (selectBankName.Value != null)
                        productregister.BankName = selectBankName.Value;
                    else
                        errormessage += "Please Select Bank Name\\n";

                    if (!string.IsNullOrEmpty(inputBankAccount.Value))
                        productregister.BankAccNumber = inputBankAccount.Value;
                    else
                        errormessage += "Please Input Account Number\\n";
                    if (!string.IsNullOrEmpty(inputAccountName.Value))
                        productregister.BankAccount = inputAccountName.Value;
                    else
                        errormessage += "Please Input Account Name\\n";
                    productregister.Commission = 0;
                    productregister.CreatedDate = DateTime.Now;
                    productregister.UserId = 0;
                    productregister.Bookings = null;
                    productregister.ClientComments = null;
                    productregister.ProductPrices = null;
                    productregister.Videos = null;
                    RegisterUser.Products = new List<Product>();
                    RegisterUser.Products.Add(productregister);
                }
                if (rdDelivery.Checked)
                {
                    Delivery deliveryregister = new Delivery();
                    deliveryregister.Id = 0;
                    if (!string.IsNullOrEmpty(inputHotelName.Value))
                        deliveryregister.Name = inputHotelName.Value;
                    else
                        errormessage += "Please Input Delivery Name\\n";
                    if (!string.IsNullOrEmpty(inputPhoneNumber.Value))
                        deliveryregister.Phone = inputHotelPhoneNumber.Value;
                    else
                        errormessage += "Please Input Delivery Phone\\n";
                    int Quality = 0;
                    if (int.TryParse(inputQuality.Value, out Quality))
                    {
                        deliveryregister.Quality = Convert.ToInt16(inputQuality.Value);
                    }
                    else {
                        errormessage += "Delivery Quality is not valid\\n";
                    }
                    if (!string.IsNullOrEmpty(inputEmail.Value))
                        deliveryregister.Email = inputEmail.Value;
                    else
                        errormessage += "Please Input Hotel Email\\n";
                    if (!string.IsNullOrEmpty(inputAddress.Value))
                        deliveryregister.Address = inputAddress.Value;
                    else
                        errormessage += "Please Input Hotel Address\\n";
                    if (!string.IsNullOrEmpty(inputCity.Value))
                        deliveryregister.City = inputCity.Value;
                    else
                        errormessage += "Please Input City\\n";
                    if (!string.IsNullOrEmpty(inputDistrict.Value))
                        deliveryregister.Disctrict = inputDistrict.Value;
                    else
                        errormessage += "Please Input District\\n";

                    if (decimal.TryParse(inputLowest.Value, out a))
                        deliveryregister.LowestPrice = Convert.ToDecimal(inputLowest.Value);
                    else
                        errormessage += "Please Input Lowest Price\\n";
                    if (decimal.TryParse(inputHighest.Value, out a))
                        deliveryregister.HighestPrice = Convert.ToDecimal(inputHighest.Value);
                    else
                        errormessage += "Please Input Highest Price\\n";
                    deliveryregister.Commission = Convert.ToDecimal(0);

                    deliveryregister.UserId = 0;
                    deliveryregister.User = null;
                    deliveryregister.DeliveryTypes = null;
                    deliveryregister.ClientComments = null;
                    deliveryregister.Bookings = null;
                    RegisterUser.Deliveries = new List<Delivery>();
                    RegisterUser.Deliveries.Add(deliveryregister);
                }
                if (!string.IsNullOrEmpty(errormessage))
                {
                    this.Page.RegisterClientScriptBlock("Key", string.Format("<script>alert('{0}')</script>", errormessage));
                    return;
                }
                var Result = tempClient.RegisterUser(RegisterUser);
                if (Result.IsSuccess)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    this.Page.RegisterClientScriptBlock("Key", string.Format("<script>alert('{0}')</script>", "Register Fails"));
                }
            }
            else {
                errormessage += "Password and Retype-Password not match\\n";
                this.Page.RegisterClientScriptBlock("Key", string.Format("<script>alert('{0}')</script>", errormessage));                
            }

        }
        catch (Exception ex)
        {
            this.Page.RegisterClientScriptBlock("Key", string.Format("<script>alert('{0}')</script>",ex.Message));
        }                   
    }
}