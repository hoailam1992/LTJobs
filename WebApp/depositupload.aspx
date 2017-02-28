<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="depositupload.aspx.cs" Inherits="depositupload" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-group">     
        <label for="FileUpload1" class="col-sm-4 control-label">File</label>         
        <div class="col-sm-8 ">
             <asp:FileUpload CssClass="form-control" ID="FileUpload1" runat="server" />            
        </div>
        </div>
     <div class="form-group">    
         <label for="inputvalue" class="col-sm-4 control-label">Value</label>
        <div  class="col-sm-8 "> 
            <asp:TextBox TextMode="Number"  id="inputvalue"  class="form-control" runat="server" ></asp:TextBox>           
        </div>
         </div>
    <div class="form-group">
    <cc:CaptchaControl ID="CaptchaControl" runat="server" Height="50px" Width="180px" on CaptchaLength="5" BackColor="White" EnableViewState="False" />
    <asp:TextBox class="sn-form-fields" ID="CaptchaInput" runat="server"></asp:TextBox>
    </div>
     <div class="form-group">    
        <div  class="col-sm-8 ">
            <asp:Button ID="btnUpload" CssClass="form-control" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        </div>
         </div>
     <div class="form-group">    
                 <div  class="col-sm-8 ">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
         </div>
     <div class="form-group">    
                 <label for="uploadedimage" class="col-sm-4 control-label">Uploaded Image</label>         
        <div  class="col-sm-8 ">
            <img data-u="image" class="fill" height="300" width="350" ID="uploadedimage" runat="server" />
        </div>
   </div>
<script type="text/javascript">
    $(document).on('click', '.browse', function () {
        var file = $(this).parent().parent().parent().find('.file');
        file.trigger('click');
    });
    $(document).on('change', '.file', function () {
        $(this).parent().find('.form-control').val($(this).val().replace(/C:\\fakepath\\/i, ''));
    });
</script>
</asp:Content>

