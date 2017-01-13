<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="detail.aspx.cs" Inherits="detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .title {
            font-weight: normal !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <legend style="text-align: center">Item Details</legend>
    <div style="width: 77%; margin: 0 auto">
        <div class="col-sm-6">
            <div class="row">
                <div class="col-sm-5">
                    <label>Name</label>
                </div>
                <div class="col-sm-7">LinDa</div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label>Age</label>
                </div>
                <div class="col-sm-7">24</div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label>Area</label>
                </div>
                <div class="col-sm-7">ho chi minh</div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label>Product Type</label>
                </div>
                <div class="col-sm-7">test 123</div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label>Product Description</label>
                </div>
                <div class="col-sm-7">test 456</div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label>Price</label>
                </div>
                <div class="col-sm-7">400$</div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label>Phone Number</label>
                </div>
                <div class="col-sm-7">56265989992</div>
            </div>
            <div class="row">
                <div class="col-sm-5"></div>
                <div class="col-sm-7" style="margin-top: 10px">
                    <button style="margin-right: 10px">Book</button>
                    <button>Back</button>
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
