<%@ Page Title="Booking Respond" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="deliveryrespond.aspx.cs" Inherits="deliveryrespond" %>
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
            <label for="inputProductCode" class="col-sm-4 control-label" id="lblCode">Client Code</label>
            <div class="col-sm-8 required">
                <input type="text" readonly="true" class="form-control" runat="server" id="inputClientCode" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputDate" class="col-sm-4 control-label">Set Time</label>
            <div class="col-sm-8 required">
                <input type="datetime" readonly="true"  class="form-control" runat="server" id="inputDate" />
            </div>
        </div>
    <div class="form-group">
            <label for="datingtype" class="col-sm-4 control-label">Dating Type</label>
            <div class="col-sm-8 required">
                 <input type="text" readonly="true"  class="form-control" runat="server" id="datingtype" />
            </div>
        
        </div>
       <div class="form-group" hidden="hidden">
            <label for="deliveryId" class="col-sm-4 control-label">Delivery</label>
            <div class="col-sm-8 required">
               <input type="text" readonly="true"  class="form-control" runat="server" id="deliveryId" />
                <div>
            <asp:HyperLink ID="htView" NavigateUrl="#" runat="server">View</asp:HyperLink>
            </div>
            </div>          
        </div>        
        <div class="form-group">
                 <label for="inputOwnLocation" class="col-sm-4 control-label">Private Location</label>
                <div class="col-sm-8 required">
                    <textarea  cols="20" rows="2" id="inputOwnLocation" readonly="true" class="form-control" runat="server"  style="margin:auto"></textarea>
            </div> 
        </div>
         <div class="form-group">
              <label class="col-sm-4 control-label">Payment Mode</label>
                <div class="col-sm-8 required">
                    <label class="radio-inline">
                        <input type="radio" name="paymentradio" readonly="true" runat="server" id="rdCCard" />Credit Card</label>
                    <label class="radio-inline">
                        <input type="radio" name="paymentradio" readonly="true" runat="server" id="rdCash" />Cash</label>
                </div>
            </div>
     <%-- <div class="form-group">
            <label for="inputDate" class="col-sm-4 control-label">Feed back Price</label>
            <div class="col-sm-8 required">
                <input type="Text"  class="form-control" runat="server" id="inputCost" />
            </div>
        </div>--%>
     <div class="form-group" runat="server" style="margin: 0 auto; width: 31%">
            <div class="col-sm-12">
                <asp:Button runat="server" ID="btnAccept" OnClick="btnAccept_Click" Text="Accept" />
                <asp:Button runat="server" ID="btnReject" OnClick="btnReject_Click" Text="Reject" />
                <button onclick="javascript:history.go(-1); return false;">Back</button>
            </div>
       </div>
    <div class="form-group">    
              <label class="col-sm-4 control-label">Reason</label>
                <div class="col-sm-8 required">
                    <label class="radio-inline">
                        <input type="radio" name="reasonradio" runat="server" id="rdReason1" />Not Available At That Time</label>                    
                </div>
   </div>
      <div class="form-group">  
           <label class="col-sm-4 control-label"></label>
        <div class="col-sm-8 required">
        <label class="radio-inline">
                        <input type="radio" name="reasonradio" runat="server" id="rdReason2" />Out of Bussiness</label>
            </div>
          </div>
     <div class="form-group">  
    <label class="col-sm-4 control-label"></label>
        <div class="col-sm-8 required">
             
                     <label class="radio-inline">
                        <input type="radio" name="reasonradio" runat="server" id="rdReason3" />Other</label>
            </div>
        </div>   
     <div class="form-group">  
          <label class="col-sm-4 control-label"></label>
            <div class="col-sm-8 required">
                     <label class="radio-inline">
                        <input type="radio" name="reasonradio" runat="server" id="rdReasonOther" />Put Your Reason
                <input type="text" runat="server" id="otherreason" aria-multiline="true"/></label>
            
       </div>
   </div>
 <script type="text/javascript">
    function ShowPopup(message) {
        $(function () {
            $("#dialog").html(message);
            $("#dialog").dialog({
                title: "jQuery Dialog Popup",
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
        });
    };
</script>
<div id="dialog" style="display: none">
</div>
    <script type="text/javascript">      
        var hyperlink = function () {
            var url = $('#SelectDelivery').val();
            $('#hrefView').attr('href', "detail_delivery.aspx?DeliveryId=" + url);
        };
      </script>
     <script runat="server">
    
   </script>
</asp:Content>