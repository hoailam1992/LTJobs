<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <asp:ListView ID="ProductList" runat="server" DataKeyNames="Id" GroupItemCount="5" ItemType="MasterService.Product" SelectMethod="ProductList_GetData">
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
                <table>
                    <tr>
                        <td>
                            <a href="detail_product.aspx?Id=<%#:Item.Id %>">
                                <img src="img/love.jpg" width="100" height="75" style="border:solid" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <a href="detail_product.aspx?Id=<%#:Item.Id %>">
                            <span>
                                <%#:Item.Code %>
                            </span>
                        </a>
                        <br />
                          <span>
                             <b> Price:</b>  <%#:String.Format("{0:c}", Item.Price) %>
                            </span>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </ItemTemplate>
          <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
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
</asp:Content>

