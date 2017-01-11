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
                <input type="text" class="form-control"  runat="server" id="inputPass" />
            </div>

        </div>
        <div style="margin: 0 auto; width: 29%; margin-bottom: 12px;">
            <a href="register.aspx" style="margin-right: 22%;">Register</a>
            <a>Forgot password?</a>
        </div>
        <div class="form-group" style="margin: 0 auto; width: 31%">
            <div class="col-sm-12">
                <asp:Button runat="server" id="btnLogIn" style="margin-right: 20px" Text="Log In"></asp:Button>
                <button onclick="Login(); return false;">Clear</button>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        function Login() {            
            //$.ajax({
            //    url: "http://localhost:7368/RestfulService.svc/DoWork",                
            //    type: "GET",               
            //    dataType: "json",
            //    crossDomain :true,
            //    header:"http://localhost:7368/RestfulService.svc",
            //    success: function (result)
            //    {
            //        console.info(result);
            //    },
            //    xhrFields: {
            //        withCredentials: true,
                    
            //    }
            //});
            var request = createCORSRequest("GET", "http://localhost:7368/RestfulService.svc/DoWork");
            request.send();
            
        }
        function createCORSRequest(method, url) {
            var xhr = new XMLHttpRequest();
            if ("withCredentials" in xhr) {
                // Check if the XMLHttpRequest object has a "withCredentials" property.
                // "withCredentials" only exists on XMLHTTPRequest2 objects.
                xhr.open(method, url, true);

            } else if (typeof XDomainRequest != "undefined") {

                // Otherwise, check if XDomainRequest.
                // XDomainRequest only exists in IE, and is IE's way of making CORS requests.
                xhr = new XDomainRequest();
                xhr.open(method, url);
            } else {

                // Otherwise, CORS is not supported by the browser.
                xhr = null;
            }
            return xhr;
        }
        var xhr = createCORSRequest('GET', url);
        if (!xhr) {
            throw new Error('CORS not supported');
        }
    </script>
</asp:Content>

