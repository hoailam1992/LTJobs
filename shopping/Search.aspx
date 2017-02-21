<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .photo {
            width: 215px;
            height: 145px;
        }
        .title{
            margin-right:10px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">       
    <div style="width: 77%; margin: 0 auto">
      <h1>Search</h1>
    <div class="form-group">
            <label for="inputCode" class="col-sm-3 control-label">Product Code</label>
            <div class="col-sm-8  required">
                <input type="text" class="form-control" runat="server" id="inputCode" />
            </div>
        </div>
    <div class="form-group">
            <label for="inputMinAge" class="col-sm-3 control-label">Age</label>
            <div class="col-sm-8  required">
                <input type="text" class="form-control" runat="server" id="inputMinAge" />     To       
                <input type="text" class="form-control" runat="server" id="inputMaxAge" />
            </div>
        </div>       
         <div class="form-group">
            <label for="inputMinPrice" class="col-sm-3 control-label">Price</label>
            <div class="col-sm-8  required">
                <input type="text" class="form-control" runat="server" id="inputMinPrice" />     To       
                <input type="text" class="form-control" runat="server" id="inputMaxPrice" />
            </div>
        </div>        
        <%--  <div class="form-group">
            <label for="inputCode" class="col-sm-4 control-label">Age</label>
            <div class="col-sm-8  required">
                <input type="text" class="form-control" runat="server" id="Text1" />             
                <input type="text" class="form-control" runat="server" id="Text2" />
            </div>
        </div>        --%>
     <div class="form-group">
                <label for="selectLanguage1" class="col-sm-3 control-label">Other Language 1</label>
                <div class="col-sm-8">
                    <select class="custom-select form-control" runat="server" id="selectLanguage1">
                        <option value="">Please Choose...</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label for="selectLanguage2" class="col-sm-3 control-label">Other Language 2</label>
                <div class="col-sm-8 required">
                    <select class="custom-select form-control" runat="server" id="selectLanguage2">
                        <option value="">Please Choose...</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label for="selectPrTypeMember" class="col-sm-3 control-label">Product Type</label>
                <div class="col-sm-8">
                    <select class="custom-select form-control" runat="server" id="selectPrTypeMember">
                        <option value="">Please Choose...</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
     <div class="form-group">
                <label for="selectPreferrableArea" class="col-sm-3 control-label">Preferrable Area</label>
                <div class="col-sm-8 required">
                    <select class="custom-select form-control" runat="server" id="selectPreferrableArea">
                        <option value="">Please Choose...</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
        <div class="form-group" style="margin: 0 auto; width: 31%">
            <div class="col-sm-12">
                <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="Search" />
                <button>Clear All</button>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div style="width: 77%; margin: 0 auto">
    <asp:ListView ID="ProductList" runat="server" DataKeyNames="Id" GroupItemCount="4" ItemType="MasterService.ProductItem" SelectMethod="ProductList_GetData">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>No Data was returned</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <td />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceHolderContainer" runat="server">
                <td id="itemPlaceHolder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>  
            <td runat="server">               
                <a href="detail_product.aspx?Id=<%#:Item.Id %>">
                     <asp:Panel ID="Panel1" BorderStyle="Solid" ToolTip="<%#:Item.ProductDescription%>" runat="server" Wrap="true" ScrollBars="Auto"
                          Height="100%" Width="100%">
                <table>
                    <tr>
                        <td>
                            <a href="detail_product.aspx?Id=<%#:Item.Id %>">
                                <img src="<%#:Item.DefaultImage%>"" width="100" height="75" style="border:solid" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                       <b>Code:<//b>                     
                            <span>
                                <%#:Item.Code %>
                            </span>
                        <br />
                       <b>Age:</b>
                             <span>
                                <%#:Item.Age %>
                            </span>
                        <br />                    
                          <span>
                             <b>Price:</b><%#:String.Format("{0:c}", Item.Price) %>
                            </span>
                    </tr>                  
                </table>
                    </asp:Panel>
                </a>                     
            </td>               
        </ItemTemplate>
          <LayoutTemplate>
                    <table style="width:100%;height:auto;margin:auto">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%;height:auto">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
    </asp:ListView>
        </div>
    </asp:Content>