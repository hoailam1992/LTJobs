<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="booking.aspx.cs" Inherits="booking" %>
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
        <div class="form-group">
            <label for="inputProductCode" class="col-sm-4 control-label">Product Code</label>
            <div class="col-sm-8 required">
                <input type="text" readonly="true" class="form-control" runat="server" id="inputProductCode" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputDate" class="col-sm-4 control-label">Set Time</label>
            <div class="col-sm-8 required">                
                <input type="date" class="form-control" runat="server" id="inputDate" />    
                <input type="time" class="form-control input-time" runat="server" lang="en" id="inputtime"/>
            </div>
        </div>
   <%-- <div class="form-groupDate" id="setDate" hidden="hidden">     
        <label for="datetimepicker" class="col-sm-4 control-label">Please Select One</label>
        <div id="datetimepicker" class="col-sm-8 required"></div>
    </div>--%>
    <div class="form-group">
            <label for="SelectType" class="col-sm-4 control-label">Dating Type</label>
            <div class="col-sm-8 required">
                <asp:DropDownList id="SelectType" runat="server" OnSelectedIndexChanged="SelectType_SelectedIndexChanged">   
                   <asp:ListItem value="0">Please Select Type</asp:ListItem>              
                </asp:DropDownList>
            </div>
        </div>
       <div class="form-group">
            <label for="SelectDelivery" class="col-sm-4 control-label">Select Delivery</label>
            <div class="col-sm-8 required">
               <asp:DropDownList id="SelectDelivery" runat="server" OnSelectedIndexChanged="SelectDelivery_SelectedIndexChanged">   
                   <asp:ListItem value="0">Please Select Location</asp:ListItem>              
                </asp:DropDownList>
                 <asp:Button ID="btnLinkView" runat="server" Text="View" OnClick="btnLinkView_Click" />
                 <asp:Button ID="btnTake" runat="server" Text="Take" OnClick="btnTake_Click" />
                 <asp:DropDownList id="SelectDeliveryType" runat="server" OnSelectedIndexChanged="SelectDeliveryType_SelectedIndexChanged" >   
                   <asp:ListItem value="0">Please Select Delivery Type</asp:ListItem>              
                </asp:DropDownList>
                <%--<a id="hrefView" runat="server">View</a>--%>
            </div>          
        </div>
        <div class="form-group">     
                        <label for="SelectDelivery" class="col-sm-4 control-label"></label>
                <div>
                     <label class="radio-inline">
                     <input type="checkbox" id="ckSetLocation" onclick="setAccountType();" runat="server"/> Set own location  </label>
                </div> 
        </div>
        <div class="form-group" id="setownlocation" hidden="hidden">
                 <label for="inputOwnLocation" class="col-sm-4 control-label">Delivery</label>
                <div class="col-sm-8 required">
                    <textarea  cols="20" rows="2" id="inputOwnLocation"  class="form-control" runat="server"  style="margin:auto"></textarea>
            </div> 
        </div>
         <div class="form-group">
              <label class="col-sm-4 control-label">Payment Mode</label>
                <div class="col-sm-8 required">
                    <label class="radio-inline">
                        <input type="radio" name="paymentradio" checked="true" runat="server" id="rdCCard" />Credit Card</label>
                    <label class="radio-inline">
                        <input type="radio" name="paymentradio" runat="server" id="rdCash" />Cash</label>
                </div>
            </div>
        <div class="form-group">
            <label for="inputProductCost" class="col-sm-4 control-label">Product Price </label>
            <div class="col-sm-8">                
               <input type="Text"  class="form-control" readonly="true" runat="server" id="inputProductCost" />
            </div>
        </div>  
        <div class="form-group">
            <label for="inputDeliveryCost" class="col-sm-4 control-label">Delivery Price </label>
            <div class="col-sm-8">                
                <input type="Text"  class="form-control" readonly="true" runat="server" id="inputDeliveryCost" />
            </div>
        </div
      <div class="form-group">
            <label for="inputCost" class="col-sm-4 control-label">Total</label>
            <div class="col-sm-8">                
                <input type="Text"  class="form-control" readonly="true" runat="server" id="inputCost" />
            </div>
        </div>
     <div class="form-group" runat="server" style="margin: 0 auto; width: 31%">
            <div class="col-sm-12">
                <asp:Button runat="server" ID="btnCalculate" OnClick="btnCalculate_Click" Text="Calculate Total" />
                <asp:Button runat="server" ID="btnBook" OnClick="btnBook_Click" Text="Book" />
                <button onclick="javascript:history.go(-1); return false;">Back</button>
            </div>
       </div>
    <asp:HiddenField runat="server" ID="inputProductPrice"/>
    <asp:HiddenField runat="server" ID="inputDeliveryPrice"/>
<script type="text/javascript" src="lib/jquery.1.4.2.js"></script>
<script type="text/javascript" src="lib/jsDatePick.jquery.min.1.3.js"></script>
<link rel="stylesheet" type="text/css" media="all" href="lib/jsDatePick_ltr.min.css" />

<script type="text/javascript">
    $(function(){
      // bind change event to select
        $('#dynamic_select').on('change', function () {
          var url = $(this).val(); // get selected value
          if (url) { // require a URL
              document.getElementById("hrefView").href = "detail_delivery.aspx?DeliveryId=" + url;; // redirect
          }
          return false;
      });
    });
     
</script>
    <script type="text/javascript">
        var setAccountType = function () {   
            $('#setownlocation').toggle(1000);
        };
        var hyperlink = function () {
            var url = $('#SelectDelivery').val();
            $('#hrefView').attr('href', "detail_delivery.aspx?DeliveryId=" + url);
        };
        $('#inputDate').datepicker({
            minDate: new Date(Date.now),
            maxDate: new Date(Date.now),
            setDate: new Date(Date.now)
        });
    </script>
</asp:Content>