<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="upload_photo.aspx.cs" Inherits="upload_photo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-group">              
        <div>
             <asp:FileUpload ID="FileUpload1" runat="server" />            
        </div>
        <div>
            <input type="text" id="inputDescription" runat="server"/>
        </div>
        <div>
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        </div>
        <div>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div>
            <asp:HyperLink ID="hyperlink" runat="server">View Uploaded Image</asp:HyperLink>
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

