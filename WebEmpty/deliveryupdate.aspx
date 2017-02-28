<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" Inherits="deliveryupdate" Codebehind="deliveryupdate.aspx.cs" %>



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
            <label for="inputCode" class="col-sm-4 control-label">Time</label>
            <div class="col-sm-8">
                <input type="text" readonly="true" class="form-control" runat="server" id="inputCode" />
            </div>
        </div>
     <div class="form-group" id="divRadio1" runat="server">
              <label class="col-sm-4 control-label">Payment Mode</label>
                <div class="col-sm-8">
                    <label class="radio-inline">
                        <input type="radio" name="paymentradio"  onchange="setAccountType(this);" runat="server" id="rdStart" />Start Job</label>                   
                </div>
            </div>
     <div class="form-group" id="divRadio" runat="server">
         <label class="col-sm-4 control-label"></label>
         <div class="col-sm-8">
              <label class="radio-inline">
                        <input type="radio" name="paymentradio"  onchange="setAccountType(this);" runat="server" id="rdFinish" />Finish</label>
            </div>    
    </div>
   <div class="form-group">
       <label class="col-sm-4 control-label"></label>
         <div class="col-sm-8">
              <label class="radio-inline">
                  <input type="radio" name="paymentradio" onchange="setAccountType(this);" runat="server"  value="Cancel" id="rdCancel" />Cancel</label>
            </div>    
    </div>
     <div class="form-horizontal" id="divHidden" hidden="hidden">
         <label for="inputRemark" class="col-sm-4 control-label">Reason</label>
         <div class="col-sm-8 required">             
                 <textarea class="form-control" row="2" runat="server" id="inputRemark" />
         </div>    
</div>
    <div class="form-group" runat="server" style="margin: 0 auto; width: 31%">
            <div class="col-sm-12">               
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"/>
                <button onclick="javascript:history.go(-1); return false;">Back</button>
            </div>
       </div>   
    <script type="text/javascript">
        var setAccountType = function (typeRadio) {
            if (typeRadio.value == "Cancel") {
                $('#divHidden').show(1000);
            } else {
                $('#divHidden').hide(1000);
            }
        };       
    </script>
    <input id="idhidden" runat="server" type="hidden" />
    <input id="idbooking" runat="server" type="hidden" />
    <input id="clconfirm" runat="server" type="hidden" />
    <input id="proconfirm" runat="server" type="hidden" />
    <input id="deliveryconfirm" runat="server" type="hidden" />
    <input id="clremark" runat="server" type="hidden" />
    <input id="proremark" runat="server" type="hidden" />
    <input id="deliremark" runat="server" type="hidden" />
    <input id="createddate" runat="server" type="hidden" />
    <input id="modifieddate" runat="server" type="hidden" />
    <input id="datetime" runat="server" type="hidden" />
</asp:Content>
