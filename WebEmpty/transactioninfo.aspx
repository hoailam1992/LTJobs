<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" Inherits="transactioninfo" Codebehind="transactioninfo.aspx.cs" %>

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
            <label for="inputCode" class="col-sm-4 control-label">Code</label>
            <div class="col-sm-8">
                <input type="text" readonly="true" class="form-control" runat="server" id="inputCode" />
            </div>
        </div>
    <div class="form-group">
            <label for="inputFrom" class="col-sm-4 control-label">From</label>
            <div class="col-sm-8">                
                <input type="text" class="form-control" readonly="true" runat="server" id="inputFrom" />                   
            </div>
        </div> 
     <div class="form-group">
            <label for="inputTo" class="col-sm-4 control-label">To</label>
            <div class="col-sm-8">                
                <input type="text" class="form-control" readonly="true" runat="server" id="inputTo" />                   
            </div>
        </div> 
        <div class="form-group">
            <label for="inputDate" class="col-sm-4 control-label">Transaction Date</label>
            <div class="col-sm-8">                
                <input type="text" class="form-control" readonly="true"  runat="server" id="inputDate" />                   
            </div>
        </div>     
    <div class="form-group">
            <label for="inputRemark" class="col-sm-4 control-label">Remark</label>
            <div class="col-sm-8">                
                <input type="text" class="form-control" readonly="true" runat="server" id="inputRemark" />                   
            </div>
        </div> 
      <div class="form-group">
            <label for="inputStatus" class="col-sm-4 control-label">Status</label>
            <div class="col-sm-8">                
                <input type="text" class="form-control" readonly="true" runat="server" id="inputStatus" />                   
            </div>
        </div> 
           <div class="form-group">
            <label for="inputPaymentDate" class="col-sm-4 control-label">Payment Date</label>
            <div class="col-sm-8">                
                <input type="text" class="form-control" readonly="true" runat="server" id="inputPaymentDate" />                   
            </div>
        </div> 
     <div class="form-group">
              <label class="col-sm-4 control-label">Payment Mode</label>
                <div class="col-sm-8">
                    <label class="radio-inline">
                        <input type="radio" name="paymentradio" disabled="disabled" runat="server" id="rdCCard" />Credit Card</label>
                    <label class="radio-inline">
                        <input type="radio" name="paymentradio" disabled="disabled" runat="server" id="rdCash" />Cash</label>
                </div>
            </div>
         <div class="form-group">
            <label for="inputValue" class="col-sm-4 control-label">Value </label>
            <div class="col-sm-8">                
               <input type="Text"  class="form-control" readonly="true" runat="server" id="inputValue" />
            </div>
        </div>  
          <div class="form-group">
            <label for="inputPhoto" class="col-sm-4 control-label">Receipt Photo</label>
            <div class="col-sm-8">          
                 <img alt="" ID="image1" height="300" width="300" runat="server" />                
            </div>
        </div> 
     <div class="form-group" runat="server" style="margin: 0 auto; width: 31%">
            <div class="col-sm-12">               
                <button onclick="javascript:history.go(-1); return false;">Back</button>
            </div>
       </div>   
</asp:Content>