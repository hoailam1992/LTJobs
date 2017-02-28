<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="account" Codebehind="account.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .form-control {
            width: 43%;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <a href="upload_photo.aspx">Upload Photo</a>       
    </div>    
     <div class="form-group">
        <a href="bookingstatus.aspx">Booking Status</a>       
    </div>    
    <div class="form-group">
        <a href="editUser.aspx">Update Info</a>       
    </div>  
       <div class="form-group">
        <a href="productprice.aspx">Product Price</a>       
    </div>  
     <div class="form-group">
        <a href="deliveryprice.aspx">Delivery Price</a>       
    </div>  
    <div class="form-group">
        <a href="transactions.aspx">Transactions</a>       
    </div>  
        <div class="form-group">
        <a href="depositupload.aspx">Deposit</a>       
    </div>  
</asp:Content>
