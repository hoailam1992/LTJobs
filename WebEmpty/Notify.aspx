<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Notify" Codebehind="Notify.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .form-control {
            width: 43%;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <div class="form-group">
     <asp:ListView ID="messagelist" runat="server" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
          <EmptyDataTemplate>
            <table>
                <tr>
                    <td>No Data was returned</td>
                </tr>
            </table>
        </EmptyDataTemplate>
<LayoutTemplate>
    <table border="1">
        <tr>
            <th>
                From
            </th>
            <th>
                Subject
            </th>
            <th>
                Date Time
            </th>
              <th>
                Read
            </th>            
            <th>
                View
            </th>
        </tr>
        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        <tr>
            <td colspan = "5">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="messagelist" PageSize="5">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>
    </table>
</LayoutTemplate>
<GroupTemplate>
    <tr>
        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
    </tr>
</GroupTemplate>
<ItemTemplate>
    <td>
        <%# Eval("From") %>
    </td>
    <td>
        <%# Eval("Subject") %>
    </td>
     <td>
        <%# Eval("DateTime") %>
    </td>
     <td>
      <%# Eval("Status") %> 
    </td>    
      <td>
      <a href="messagedetail.aspx?Id=<%# Eval("Id") %>">View Detail  </a>
    </td>
</ItemTemplate>
</asp:ListView>
     </div>
</asp:Content>