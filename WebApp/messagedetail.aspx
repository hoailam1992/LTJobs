<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="messagedetail.aspx.cs" Inherits="messagedetail" %>
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
            <label for="inputFrom" class="col-sm-4 control-label" id="lblCode">From</label>
            <div class="col-sm-8">
                <input type="text" readonly="true" class="form-control" runat="server" id="inputFrom" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputSubject" class="col-sm-4 control-label">Subject</label>
            <div class="col-sm-8">
                <input type="text" readonly="true"  class="form-control" runat="server" id="inputSubject" />
            </div>
        </div>
    <div class="form-group">
            <label for="inputBody" class="col-sm-4 control-label">Body</label>
            <div class="col-sm-8">
                 <textarea class="form-control" readonly="readonly" rows="5" runat="server" placeholder="Body Info" id="inputBody"></textarea>
            </div>
        
        </div>   
     <div class="form-group" aria-flowto="inputBody" style="margin: 0 auto; width: 31%">
            <div class="col-sm-4" >               
                <button  onclick="javascript:history.go(-1); return false;">Back</button>
            </div>
       </div>
</asp:Content>
