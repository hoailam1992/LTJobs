<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="productprice.aspx.cs" Inherits="productprice" %>
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

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
Sample Employee Information  
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
         onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
        onrowdatabound="GridView1_RowDataBound">
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
           <asp:TemplateField HeaderText="Product Type">
           <ItemTemplate>
               <asp:Label ID="Label1" runat="server" Text='<%# Eval
				("ProductTypeId") %>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate >
                <asp:Label ID="lbl2" runat="server"  Text='<%# Eval
				("ProductTypeId") %>'>                
               </asp:Label>             
           </EditItemTemplate>
           </asp:TemplateField> 
           <asp:TemplateField HeaderText="Price">
           <ItemTemplate>
               <asp:Label ID="Label5" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
           </ItemTemplate>
          <EditItemTemplate >
              <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" Text='<%#Eval("Price")%>'></asp:TextBox>
           </EditItemTemplate>
           </asp:TemplateField>              
           <asp:TemplateField HeaderText="Edit" ShowHeader="false">
               <ItemTemplate>
                   <asp:LinkButton ID="btnedit" runat="server" 
			CommandName="Edit" Text="Edit" ></asp:LinkButton>
               </ItemTemplate>
               <EditItemTemplate>
                   <asp:LinkButton ID="btnupdate" runat="server" 
			CommandName="Update" Text="Update" ></asp:LinkButton>
                   <asp:LinkButton ID="btncancel" runat="server" 
			CommandName="Cancel" Text="Cancel"></asp:LinkButton>
               </EditItemTemplate>
            </asp:TemplateField>
       </Columns>
    </asp:GridView>
</div>   
</asp:Content>