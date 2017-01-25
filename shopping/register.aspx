<%@ Page Title="Register" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        label {
            font-weight: normal !important;
        }

        .required:after {
            content: "*";
            color: red;
        }

        .form-control {
            width: 57%;
            float: left;
        }

        .clientInformation, .hotelInformation, .memberInfomation {
            width: 65%;
            margin: 0 auto;
            display: none;
        }

        .title {
            font-weight: bold;
            border-bottom: 1px solid #e5e5e5;
            width: 100%;
            display: block;
            margin-bottom: 10px;
        }

        .slash {
            width: 3%;
            float: left;
            vertical-align: middle;
            text-align: center;
            line-height: 32px;
        }

        .expiredWidth {
            width: 27% !important;
        }

        .file {
            visibility: hidden;
            position: absolute;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <legend style="text-align: center">Register</legend>
    <%--<form class="form-horizontal" runat="server">--%>
        <div class="form-group">
            <label for="inputDisplay" class="col-sm-4 control-label">Display Name</label>
            <div class="col-sm-8 required">
                <input type="text" class="form-control" runat="server" id="inputDisplay" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputUsername" class="col-sm-4 control-label">User Name</label>
            <div class="col-sm-8  required">
                <input type="text" class="form-control" runat="server" id="inputUsername" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputPass" class="col-sm-4 control-label">Password</label>
            <div class="col-sm-8  required">
                <input type="password" class="form-control" runat="server" id="inputPass" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputRetypePass" class="col-sm-4 control-label">Retype-Password</label>
            <div class="col-sm-8  required">
                <input type="password" class="form-control" runat="server" id="inputRetypePass" />
            </div>
        </div>
        <div class="form-group">
            <label for="selectQuestion" class="col-sm-4 control-label">Security Question</label>
            <div class="col-sm-8">
                <select class="custom-select form-control" runat="server" id="selectQuestion">
                    <option value="">Please Choose...</option>
                    <option value="1">One</option>
                    <option value="2">Two</option>
                    <option value="3">Three</option>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label for="inputAnswer" class="col-sm-4 control-label">Your Answer</label>
            <div class="col-sm-8">
                <input type="text" class="form-control" runat="server" id="inputAnswer" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputBirthDay" class="col-sm-4 control-label">Birthday</label>
            <div class="col-sm-8  required">
                <input type="text" class="form-control" runat="server" id="inputBirthDay" placeholder="dd/MM/YYYY" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputPhoneNumber" class="col-sm-4 control-label">Phone Number</label>
            <div class="col-sm-8  required">
                <input type="text" class="form-control" runat="server" id="inputPhoneNumber" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputEmail" class="col-sm-4 control-label">Email</label>
            <div class="col-sm-8">
                <input type="email" class="form-control" runat="server" id="inputEmail" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-4 control-label">Account Type</label>
            <div class="col-sm-8">
                <label class="radio-inline">
                    <input type="radio" name="accounttyperadio" id="rdClient" runat="server" onclick="setAccountType(this);" value="client" />Client</label>
                <label class="radio-inline">
                    <input type="radio" name="accounttyperadio" id="rdProduct" runat="server" onclick="setAccountType(this);" value="member" />Product</label>
                <label class="radio-inline">
                    <input type="radio" name="accounttyperadio" id="rdDelivery" runat="server" onclick="setAccountType(this);" value="hotel" />Delivery</label>
            </div>
        </div>
        <!-- client register -->
        <div class="clientInformation">
            <span class="title">Billing Information</span>
            <div class="form-group">
                <div class="col-sm-12">
                    <label class="radio-inline">
                        <input type="radio" name="paymentradio" runat="server" id="rdCCard" />Credit Card</label>
                    <label class="radio-inline">
                        <input type="radio" name="paymentradio" runat="server" id="rdCash" />Cash</label>
                    <label class="radio-inline">(Please make payment on deposit later)</label>
                </div>
            </div>
            <span class="title">Credit Card</span>
            <div class="form-group">
                <label for="inputCreditCard" class="col-sm-3 control-label">Credit Card Name</label>
                <div class="col-sm-8 required">
                    <input type="text" class="form-control" runat="server" id="inputCreditCard" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputCreditCardNumber" class="col-sm-3 control-label">Credit Card Number</label>
                <div class="col-sm-8 required">
                    <input type="text" class="form-control" runat="server" id="inputCreditCardNumber" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputExp" class="col-sm-3 control-label">Expired</label>
                <div class="col-sm-8 form-inline">
                    <input type="text" id="inputMonth" runat="server" class="form-control expiredWidth" placeholder="Month" />
                    <div class="slash">/</div>
                    <input type="text" id="inputYear" runat="server" class="form-control expiredWidth" placeholder="Year" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputSecPin" class="col-sm-3 control-label">Security PIN</label>
                <div class="col-sm-8  required">
                    <input type="text" class="form-control" runat="server" id="inputSecPin" />
                </div>
            </div>
        </div>
        <!-- delivery register -->
        <div class="hotelInformation">
            <span class="title">Hotel Information</span>
            <div class="form-group">
                <label for="inputHotelName" class="col-sm-3 control-label">Hotel Name</label>
                <div class="col-sm-8 required">
                    <input type="text" class="form-control" runat="server" id="inputHotelName" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputAddress" class="col-sm-3 control-label">Address</label>
                <div class="col-sm-8 required">
                    <input type="text" class="form-control" runat="server" id="inputAddress" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputDistrict" class="col-sm-3 control-label">District</label>
                <div class="col-sm-8 required">
                    <input type="text" class="form-control" runat="server" id="inputDistrict" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputCity" class="col-sm-3 control-label">City</label>
                <div class="col-sm-8 required">
                    <input type="text" class="form-control" runat="server" id="inputCity" />
                </div>
            </div>
            <div class="form-group">
                <label for="selectProductType" class="col-sm-3 control-label">Product Type</label>
                <div class="col-sm-8">
                    <select class="custom-select form-control" runat="server" id="selectDeliveryType">
                        <option value="">Please Choose...</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label">Price Range</label>
                <div class="col-sm-8 form-inline">
                    <input type="text" id="inputLowest" runat="server" class="form-control expiredWidth" style="margin-right: 3%;" placeholder="Lowest" />
                    <input type="text" id="inputHighest" runat="server" class="form-control expiredWidth" placeholder="Highest" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputHotelPhoneNumber" class="col-sm-3 control-label">Phone Number</label>
                <div class="col-sm-8  required">
                    <input type="text" class="form-control" runat="server" id="inputHotelPhoneNumber" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputHotelEmail" class="col-sm-3 control-label">Email</label>
                <div class="col-sm-8">
                    <input type="email" class="form-control" runat="server" id="inputHotelEmail" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputPhoto" class="col-sm-3 control-label">Upload Photo</label>
                <div class="col-sm-8">
                    <input type="file" name="img[]" class="file" />
                    <input type="text" class="form-control" style="width: 39%" id="inputPhoto" placeholder="Upload Photo" />
                    <span class="input-group-btn">
                        <button class="browse btn btn-primary" type="button"><i class="glyphicon glyphicon-search"></i>Browse</button>
                    </span>
                </div>
                <div class="form-group" style="width: 60%; margin: 0 auto">
                    <img src="img/love.jpg" class="img-rounded" alt="Cinque Terre" width="280" height="180" style="margin-top: 12px" />
                </div>
            </div>

        </div>
        <!-- product register -->
        <div class="memberInfomation">
            <span class="title">Member Information</span>
            <div class="form-group">
                <label for="inputprdDes" class="col-sm-3 control-label">Product Description</label>
                <div class="col-sm-8 required">
                    <input type="text" class="form-control" runat="server" id="inputPrdDes" />
                </div>
            </div>
            <div class="form-group">
                <label for="selectLanguage1" class="col-sm-3 control-label">Other Language 1</label>
                <div class="col-sm-8">
                    <select class="custom-select form-control" runat="server" id="selectLanguage1">
                        <option value="">Please Choose...</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label for="selectLanguage2" class="col-sm-3 control-label">Other Language 2</label>
                <div class="col-sm-8 required">
                    <select class="custom-select form-control" runat="server" id="selectLanguage2">
                        <option value="">Please Choose...</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label for="selectPrTypeMember" class="col-sm-3 control-label">Product Type</label>
                <div class="col-sm-8">
                    <select class="custom-select form-control" runat="server" id="selectPrTypeMember">
                        <option value="">Please Choose...</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label for="inputPriceMember" class="col-sm-3 control-label">Price</label>
                <div class="col-sm-8 required">
                    <input type="text" class="form-control" runat="server" id="inputPriceMember" />
                </div>
            </div>
          <%--  <div class="form-group">
                <label for="inputPhotoMember" class="col-sm-3 control-label">Upload Photo</label>
                <div class="col-sm-8">
                    <input type="file" name="img[]" class="file" />
                    <input type="text" class="form-control" style="width: 39%" id="inputPhotoMember" placeholder="Upload Photo" />
                    <span class="input-group-btn">
                        <button class="browse btn btn-primary" type="button"><i class="glyphicon glyphicon-search"></i>Browse</button>
                    </span>
                </div>
                <div class="form-group" style="width: 46%; margin: 0 auto;">
                    <img src="img/love.jpg" class="img-rounded" alt="Cinque Terre" width="275" height="180" style="margin-top: 12px" />
                </div>
            </div>--%>
          <%--  <div class="form-group">
                <label for="inputVideoMember" class="col-sm-3 control-label">Upload Video</label>
                <div class="col-sm-8">
                    <input type="file" name="img[]" class="file" />
                    <input type="text" class="form-control" style="width: 39%" id="inputVideoMember" placeholder="Upload Video" />
                    <span class="input-group-btn">
                        <button class="browse btn btn-primary" type="button"><i class="glyphicon glyphicon-search"></i>Browse</button>
                    </span>
                </div>
            </div>--%>
            <div class="form-group">
                <label for="selectPreferrableArea" class="col-sm-3 control-label">Preferrable Area</label>
                <div class="col-sm-8 required">
                    <select class="custom-select form-control" runat="server" id="selectPreferrableArea">
                        <option value="">Please Choose...</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
            <span class="title">Build Information</span>
            <div class="form-group">
                <label for="selectBankName" class="col-sm-3 control-label">Bank Name</label>
                <div class="col-sm-8">
                    <select class="custom-select form-control" runat="server" id="selectBankName">
                        <option value="">Please Choose...</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label for="inputBankAccount" class="col-sm-3 control-label">Bank Account</label>
                <div class="col-sm-8 required">
                    <input type="text" class="form-control" runat="server" id="inputBankAccount" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputAccountName" class="col-sm-3 control-label">Account Name</label>
                <div class="col-sm-8 required">
                    <input type="text" class="form-control" runat="server" id="inputAccountName" />
                </div>
            </div>
        </div>
        <div class="form-group" style="margin: 0 auto; width: 31%">
            <div class="col-sm-12">
                <asp:Button runat="server" ID="btnRegister" OnClick="BtnRegister_Click" Text="Register" />
                <button>Clear All</button>
            </div>
        </div>
   <!-- </form>-->
    <script src="js/register.js">
    
    </script>
</asp:Content>

