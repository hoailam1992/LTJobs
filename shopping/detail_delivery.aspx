<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="detail_delivery.aspx.cs" Inherits="detail_delivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .title {
            font-weight: normal !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <legend style="text-align: center">Delivery Details</legend>
    <div style="width: 77%; margin: 0 auto">
        <div class="col-sm-6">
            <div class="row">
                <div class="col-sm-5">
                    <label>Name</label>
                </div>
                <div class="col-sm-7" id="lblName" runat="server">5 Stars</div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label>Lowest Price</label>
                </div>
                <div class="col-sm-7" id="lblLowestPrice" runat="server">2000USD</div>
            </div>
              <div class="row">
                <div class="col-sm-5">
                    <label>Highest Price</label>
                </div>
                <div class="col-sm-7" id="lblHighestPrice" runat="server">2000USD</div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label>Address</label>
                </div>
                <div class="col-sm-7" id="lblAddress" runat="server">ho chi minh</div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label>Quality</label>
                </div>
                <div class="col-sm-7" id="lblQuality" runat="server">2 stars</div>
            </div>          
            <div class="row">
                <div class="col-sm-5"></div>
                <div class="col-sm-7" style="margin-top: 10px">                    
                    <button onclick="javascript:history.go(-1);">Back</button>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <img src="img/love.jpg" class="img-rounded" alt="Cinque Terre" width="280" height="180" style="margin-bottom: 10px" /><br />
            <a href="https://www.youtube.com/watch?v=G_jYqw-UPe4">Video Link</a>
        </div>
    </div>
    <div style="width: 77%; margin: 0 auto">
        <div class="col-sm-8">
            <div class="form-group">
                <label for="comment">Comment:</label>
                <textarea class="form-control" rows="5" id="comment"></textarea>
            </div>
        </div>
    </div>

</asp:Content>
