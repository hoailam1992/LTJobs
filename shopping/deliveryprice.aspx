<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="deliveryprice.aspx.cs" Inherits="deliveryprice" %>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
            <label for="inputProductCode" class="col-sm-4 control-label">Code</label>
            <div class="col-sm-8 required">
                <input type="text" class="form-control" runat="server" id="inputProductCode" />
            </div>
        </div>     
    <div class="form-group">
            <label for="inputDescription" class="col-sm-4 control-label">Description</label>
             <div class="col-sm-8 required">
                <input type="text" class="form-control" runat="server" id="inputDescription" />
            </div>
        </div>  
        <div class="form-group">
                 <label for="inputExtraFee" class="col-sm-4 control-label">Extra Fee</label>
                <div class="col-sm-8 required">
                    <textarea  cols="20" rows="2" id="inputExtraFee"  class="form-control" runat="server"  style="margin:auto"></textarea>
            </div> 
        </div>
      <div class="form-group">
            <label for="inputPrice" class="col-sm-4 control-label">Price</label>
            <div class="col-sm-8 required">
                <input type="Text"  class="form-control" runat="server" id="inputPrice" />
            </div>
        </div>
     <div class="form-group" runat="server">
            <div class="col-sm-12">
                <asp:Button runat="server" ID="btnBook" OnClick="btnBook_Click" Text="Add" />
            </div>
       </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
Delivery Type Info  
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
         onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
        onrowdatabound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
           <Columns>
           <asp:TemplateField HeaderText="ID">
           <ItemTemplate >
               <asp:Label ID="Label6" runat="server" Text='<%# Eval("Id") %>' >
		    </asp:Label>
           </ItemTemplate>
           </asp:TemplateField>
          <%-- <asp:TemplateField HeaderText="Active">
           <ItemTemplate >
              <asp:CheckBox runat="server" Text='<%# Eval("Active") %>' >
		    </asp:CheckBox>
           </ItemTemplate>
           <EditItemTemplate >
               <asp:CheckBox ID="CheckBoxList2" runat="server" Text='<%# Eval("Active")%>'></asp:CheckBox>
           </EditItemTemplate>
               </asp:TemplateField>--%>
           <asp:TemplateField HeaderText="Delivery Type">
           <ItemTemplate>
               <asp:Label ID="Label1" runat="server" Text='<%# Eval
				("Code") %>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate >
                <asp:TextBox ID="tx1" runat="server"  Text='<%# Eval
				("Code") %>'>                
               </asp:TextBox>             
           </EditItemTemplate>
           </asp:TemplateField> 
               <asp:TemplateField HeaderText="Description">
           <ItemTemplate>
               <asp:Label ID="LabelDesc" runat="server" Text='<%# Eval
				("DeliveryDescription") %>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate >
                <asp:TextBox ID="tx2" runat="server"  Text='<%# Eval
				("DeliveryDescription") %>'>                
               </asp:TextBox>             
           </EditItemTemplate>
           </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Extra Fee">
           <ItemTemplate>
               <asp:Label ID="Label5" runat="server" Text='<%# Eval("ExtraFee") %>'></asp:Label>
           </ItemTemplate>
          <EditItemTemplate >
               <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("ExtraFee")%>'></asp:TextBox>
           </EditItemTemplate>
           </asp:TemplateField>    
           <asp:TemplateField HeaderText="Price">
           <ItemTemplate>
               <asp:Label ID="LabelPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
           </ItemTemplate>
          <EditItemTemplate >
               <asp:TextBox ID="TextBoxPrice" runat="server" Text='<%# Eval("Price")%>'></asp:TextBox>
           </EditItemTemplate>
           </asp:TemplateField>              
           <asp:TemplateField HeaderText="Edit" ShowHeader="false">
               <ItemTemplate>
                   <asp:LinkButton ID="btnedit" runat="server" 
			CommandName="Edit" Text="Edit"></asp:LinkButton>                 
               </ItemTemplate>
               <EditItemTemplate>
                   <asp:LinkButton ID="btnupdate" runat="server" 
			CommandName="Update" Text="Update" ></asp:LinkButton>
                 
                   <asp:LinkButton ID="btncancel" runat="server" 
			CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                   <asp:LinkButton ID="btnDelete" runat="server" 
			CommandName="Delete" Text="Delete"></asp:LinkButton>
               </EditItemTemplate>
            </asp:TemplateField>
       </Columns>
    </asp:GridView>
</div>   
</asp:Content>