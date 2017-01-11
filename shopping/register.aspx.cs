using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterService;
public partial class register : System.Web.UI.Page
{
    MasterService.MasterServiceClient tempClient;
    TextBox txtUsername;
    TextBox txtFullname;
    TextBox txtPassword;
    TextBox txtRePassword;
    TextBox txtAnswers;
    TextBox txtBirthday;
    TextBox txtPhone;
    TextBox txtEmail;
    RadioButton rdClient;
    RadioButton rdProduct;
    RadioButton rdDelivery;
    DropDownList drdQuestion;
    //Client
    #region Client
    RadioButton rdCash;
    RadioButton rdCCard;
    TextBox txtCreditCard;
    TextBox txtCreditCardNumber;
    TextBox txtMonth;
    TextBox txtYear;
    TextBox txtSecPin;
    #endregion
    //Product
    #region Product
    TextBox txtProDes;
    DropDownList drpLanguage1;
    DropDownList drpLanguage2;
    DropDownList drpProductType;
    DropDownList drpPreferrableArea;
    DropDownList drpBankName;
    TextBox txtPrice;
    TextBox txtPhotoLink;
    TextBox txtVideoLink;
    TextBox txtBankAccount;
    TextBox txtAccName;
    #endregion
    //Delivery
    #region Delivery
    TextBox txtDeliveryName;
    TextBox txtAddress;
    TextBox txtDistrict;
    TextBox txtCity;
    DropDownList drpDeliveryType;
    TextBox txtLowestPrice;
    TextBox txtHighestPrice;
    TextBox txtDeliveryPhone;
    TextBox txtDeliveryEmail;
    TextBox txtDeliveryType;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        tempClient = new MasterService.MasterServiceClient(); 
        #region Register
        txtUsername = FindControl("inputUsername") as TextBox;
        txtFullname = FindControl("inputDisplay") as TextBox;
        txtPassword = FindControl("inputPass") as TextBox;
        txtRePassword = FindControl("inputRetypePass") as TextBox;
        txtAnswers = FindControl("inputAnswer") as TextBox;
        txtBirthday = FindControl("inputBirthday") as TextBox;
        txtPhone = FindControl("inputPhoneNumber") as TextBox;
        txtEmail = FindControl("inputEmail") as TextBox;
        rdClient = FindControl("rdClient") as RadioButton;
        rdProduct = FindControl("rdProduct") as RadioButton;
        rdDelivery = FindControl("rdDelivery") as RadioButton;
        #endregion
        #region Client
        txtCreditCard = FindControl("inputCreditCard") as TextBox;
        txtCreditCardNumber = FindControl("inputCreditCardNumber") as TextBox;
        txtMonth = FindControl("inputMonth") as TextBox;
        txtYear = FindControl("inputYear") as TextBox;
        txtSecPin = FindControl("inputSecPin") as TextBox;
        rdCash = FindControl("rdCash") as RadioButton;
        rdCCard = FindControl("rdCCard") as RadioButton;
        #endregion
        #region Product
        txtProDes = FindControl("inputPrdDes") as TextBox;
        drpLanguage1 = FindControl("selectLanguage1") as DropDownList;
        drpLanguage2 = FindControl("selectLanguage2") as DropDownList;
        drpProductType = FindControl("selectPrTypeMember") as DropDownList;
        drpPreferrableArea = FindControl("selectPreferrableArea") as DropDownList;
        drpBankName = FindControl("selectBankName") as DropDownList;
        txtPrice = FindControl("inputPriceMember") as TextBox;
        txtPhotoLink = FindControl("inputPhotoMember") as TextBox;
        txtVideoLink = FindControl("inputVideoMember") as TextBox;
        txtBankAccount = FindControl("inputBankAccount") as TextBox;
        txtAccName = FindControl("inputAccountName") as TextBox;
        #endregion
        #region Delivery
        txtDeliveryName = FindControl("inputHotelName") as TextBox;
        txtAddress = FindControl("inputAddress") as TextBox;
        txtDistrict = FindControl("inputDistrict") as TextBox;
        txtCity = FindControl("inputCity") as TextBox;
        txtLowestPrice = FindControl("inputLowest") as TextBox;
        txtHighestPrice = FindControl("inputHighest") as TextBox;
        drpDeliveryType = FindControl("selectDeliveryType") as DropDownList;
        txtDeliveryPhone = FindControl("inputHotelPhoneNumber") as TextBox;
        txtDeliveryName = FindControl("inputHotelEmail") as TextBox;
        
        #endregion
    }

    public void BtnRegister_Click(object sender, EventArgs e)
    {
        User RegisterUser = new User();
        //RegisterUser.username = txtUsername.Text;        
        RegisterUser.username = inputDisplay.Value;
        RegisterUser.fullname = txtFullname.Text;
        RegisterUser.email = txtEmail.Text;
        RegisterUser.id = 0;
        RegisterUser.isblocked = false;
        RegisterUser.phone = txtPhone.Text;
        //RegisterUser.securityquestionid = (short)drdQuestion.SelectedIndex;
        RegisterUser.securityquestionid = (short)selectQuestion.SelectedIndex;
        RegisterUser.securityanswer = txtAnswers.Text;
        if (txtPassword.Text == txtRePassword.Text)
        {
            RegisterUser.password = txtPassword.Text;
        }
        var resultuser = tempClient.SaveUser(RegisterUser);
        if (resultuser.IsSuccess && resultuser.Result != null)
        {
            if (rdClient.Checked)
            {
                client clientregister = new client();
                clientregister.id = 0;
                clientregister.isvalid = false;
                clientregister.balance = 0;
                clientregister.cancelcount = 0;
                clientregister.ccexpiredmonth = Convert.ToInt16(txtMonth.Text);
                clientregister.ccexpiredyear = Convert.ToInt16(txtYear.Text);
                clientregister.ccholder = txtCreditCard.Text;
                clientregister.ccnumber = txtCreditCardNumber.Text;
                clientregister.ccpin = txtSecPin.Text;
                clientregister.createddate = DateTime.Now;
                clientregister.paymentmode = rdCash.Checked ? 1 : rdCCard.Checked ? 2 : 0;
                clientregister.userid = resultuser.Result.id;
                var ClientResult = tempClient.SaveClient(clientregister);
            }
            if (rdProduct.Checked)
            {
                product productregister = new product();
                productregister.id = 0;
                productregister.isactive = false;
                productregister.isavailable = false;
                productregister.language1 = drpLanguage1.Text;
                productregister.language2 = drpLanguage2.Text;
                productregister.preferrablelocation = drpPreferrableArea.Text;
                productregister.price = Convert.ToDecimal(txtPrice.Text);
                productregister.productdescription = txtProDes.Text;
                productregister.cancelcount = 0;
                productregister.balance = 0;
                productregister.bankname = drpBankName.Text;
                productregister.bankaccnumber = txtBankAccount.Text;
                productregister.bankaccount = txtAccName.Text;
                productregister.commission = 0;
                productregister.userid = resultuser.Result.id;
                var ProductResult = tempClient.SaveProduct(productregister);
            }
            if (rdDelivery.Checked)
            {
                delivery deliveryregister = new delivery();
                deliveryregister.id = 0;
                deliveryregister.name = txtDeliveryName.Text;
                deliveryregister.phone = txtDeliveryPhone.Text;
                deliveryregister.quality = Convert.ToInt16(txtDeliveryType.Text);
                deliveryregister.email = txtDeliveryEmail.Text;
                deliveryregister.address = txtAddress.Text;
                deliveryregister.city = txtCity.Text;
                deliveryregister.disctrict = txtDistrict.Text;
                deliveryregister.lowestprice = Convert.ToDecimal(txtLowestPrice.Text);
                deliveryregister.highestprice = Convert.ToDecimal(txtHighestPrice.Text);
                deliveryregister.commission = Convert.ToDecimal(0);
                deliveryregister.userid = resultuser.Result.id;
                var DeliveryRegister = tempClient.SaveDelivery(deliveryregister);

            }
        }
    }

    public void btnRegister_Click(object sender, EventArgs e)
    {
        user RegisterUser = new user();
        RegisterUser.username = txtUsername.Text;
        RegisterUser.fullname = txtFullname.Text;
        RegisterUser.email = txtEmail.Text;
        RegisterUser.id = 0;
        RegisterUser.isblocked = false;
        RegisterUser.phone = txtPhone.Text;
        RegisterUser.securityquestionid = (short)drdQuestion.SelectedIndex;
        RegisterUser.securityanswer = txtAnswers.Text;
        if (txtPassword.Text == txtRePassword.Text)
        {
            RegisterUser.password = txtPassword.Text;
        }
        var resultuser = tempClient.SaveUser(RegisterUser);
        if (resultuser.IsSuccess && resultuser.Result != null)
        {
            if (rdClient.Checked)
            {
                client clientregister = new client();
                clientregister.id = 0;
                clientregister.isvalid = false;
                clientregister.balance = 0;
                clientregister.cancelcount = 0;
                clientregister.ccexpiredmonth = Convert.ToInt16(txtMonth.Text);
                clientregister.ccexpiredyear = Convert.ToInt16(txtYear.Text);
                clientregister.ccholder = txtCreditCard.Text;
                clientregister.ccnumber = txtCreditCardNumber.Text;
                clientregister.ccpin = txtSecPin.Text;
                clientregister.createddate = DateTime.Now;
                clientregister.paymentmode = rdCash.Checked ? 1 : rdCCard.Checked ? 2 : 0;
                clientregister.userid = resultuser.Result.id;
                var ClientResult = tempClient.SaveClient(clientregister);
            }
            if (rdProduct.Checked)
            {
                product productregister = new product();
                productregister.id = 0;
                productregister.isactive = false;
                productregister.isavailable = false;
                productregister.language1 = drpLanguage1.Text;
                productregister.language2 = drpLanguage2.Text;
                productregister.preferrablelocation = drpPreferrableArea.Text;
                productregister.price = Convert.ToDecimal(txtPrice.Text);
                productregister.productdescription = txtProDes.Text;
                productregister.cancelcount = 0;
                productregister.balance = 0;
                productregister.bankname = drpBankName.Text;
                productregister.bankaccnumber = txtBankAccount.Text;
                productregister.bankaccount = txtAccName.Text;
                productregister.commission = 0;
                productregister.userid = resultuser.Result.id;
                var ProductResult = tempClient.SaveProduct(productregister);
            }
            if (rdDelivery.Checked)
            {
                delivery deliveryregister = new delivery();
                deliveryregister.id = 0;
                deliveryregister.name = txtDeliveryName.Text;
                deliveryregister.phone = txtDeliveryPhone.Text;
                deliveryregister.quality = Convert.ToInt16(txtDeliveryType.Text);
                deliveryregister.email = txtDeliveryEmail.Text;
                deliveryregister.address = txtAddress.Text;
                deliveryregister.city = txtCity.Text;
                deliveryregister.disctrict = txtDistrict.Text;
                deliveryregister.lowestprice = Convert.ToDecimal(txtLowestPrice.Text);
                deliveryregister.highestprice = Convert.ToDecimal(txtHighestPrice.Text);
                deliveryregister.commission = Convert.ToDecimal(0);
                deliveryregister.userid = resultuser.Result.id;
                var DeliveryRegister = tempClient.SaveDelivery(deliveryregister);

            }
        }
    }
}