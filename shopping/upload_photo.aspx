<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="upload_photo.aspx.cs" Inherits="upload_photo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-group">              
        <div class="col-sm-8 ">
             <asp:FileUpload CssClass="form-control" ID="FileUpload1" runat="server" />            
        </div>
        <div  class="col-sm-8 "> 
            <textarea  cols="20" rows="2" id="inputDescription"  class="form-control" runat="server"  style="margin:auto"></textarea>           
        </div>
        <div  class="col-sm-8 ">
            <asp:Button ID="btnUpload" CssClass="form-control" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        </div>
        <div  class="col-sm-8 ">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
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

