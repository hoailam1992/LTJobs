<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .form-control {
            width: 43%;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form-horizontal" runat="Server">
        <div class="form-group">
            <label for="inputUserName" class="col-sm-4 control-label">User Name</label>
            <div class="col-sm-8 required">
                <input type="text" class="form-control" runat="server" id="inputUserName" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputPass" class="col-sm-4 control-label">Password</label>
            <div class="col-sm-8 required">
                <input type="text" class="form-control" runat="server" id="inputPass" />
            </div>

        </div>
        <div style="margin: 0 auto; width: 29%; margin-bottom: 12px;">
            <a href="register.aspx" style="margin-right: 22%;">Register</a>
            <a>Forgot password?</a>
        </div>
        <div class="form-group" style="margin: 0 auto; width: 31%">
            <div class="col-sm-12">
                <asp:Button runat="server" id="btnLogIn" style="margin-right: 20px" Text="Log In"></asp:Button>
                <button>Clear</button>
            </div>
        </div>
    </form>
</asp:Content>

