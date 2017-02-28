<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="upload_photo" Codebehind="upload_photo.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-group">         
        <label for="FileUpload1" class="col-sm-3 control-label">File</label>  
        <div class="col-sm-8 ">
             <input type="file" class="form-control" onchange="loadFile(event)" id="FileUpload1" runat="server" />            
        </div>
        </div>
    <div class="form-group"> 
         <label for="inputDescription" class="col-sm-3 control-label">Description</label>  
        <div  class="col-sm-8 "> 
            <textarea  cols="20" rows="2" id="inputDescription"  class="form-control" runat="server"  style="margin:auto"></textarea>           
        </div>
        </div>
     <div class="row">
          <div class="col-sm-5"></div>
                <div class="col-sm-7" style="margin-top: 10px">
            <asp:Button ID="btnUpload"  runat="server" style="margin-right: 10px" Text="Upload" OnClick="btnUpload_Click" />
            <button onclick="javascript:history.go(-1);">Back</button>
        </div>
        </div>
    <div class="form-group"> 
        <div  class="col-sm-8 ">
            <asp:Label ID="lblMessage" CssClass="form-inline" runat="server"></asp:Label>
        </div>
        </div>
    <div class="form-group"> 
         <label for="uploadedimage" class="col-sm-3 control-label">Preview Photo</label>  
        <div  class="col-sm-8 ">
            <img data-u="image" class="col-sm-8 fill" height="300" width="350" id="uploadedimage" runat="server" />
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
    <script>
  var loadFile = function(event) {
      var output = document.getElementById('ContentPlaceHolder1_uploadedimage');
      output.src = URL.createObjectURL(event.target.files[0]);
  };
</script>
</asp:Content>

