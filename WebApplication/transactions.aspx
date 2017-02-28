<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="transactions.aspx.cs" Inherits="transactions" %>
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

     <div class="form-group">
     <asp:ListView ID="bookinglist" runat="server" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
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
                Id
            </th>
            <th>
                Code
            </th>
            <th>
                Receipt PhoTo
            </th>
              <th>
                Value
            </th>
            <th>
                Remark
            </th>
             <th>
                Status
            </th>
            <th>
                Source Id
            </th>
             <th>
                Destination Id
            </th>
               <th>
                Payment Date
            </th>
            <th>
                View Detail
            </th>
        </tr>
        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        <tr>
            <td colspan = "10">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="bookinglist" PageSize="5">
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
        <%# Eval("Id") %>
    </td>
    <td>
        <%# Eval("Code") %>
    </td>
     <td>
         <img height="150" width="150"  data-u='image' class='fill' src='<%# Eval("ImgSrc") %>' />
    </td>
     <td>
        <%# Eval("Value") %>
    </td>
    <td>
        <%# Eval("Remark") %>
    </td>
       <td>
        <%# Eval("Status") %>
    </td>
       <td>
        <%# Eval("SourceId") %>
    </td>
    <td>
        <%#Eval("DestinationId")%>
    </td>
     <td>
        <%# Eval("PaymentDate") %>
    </td>
       <td>
      <a href="<%= Session["UserType"].ToString()=="3" ?"deliveryrespond":"productrespond" %>.aspx?BookingId=<%# Eval("Id") %>">View Detail  </a>
    </td>
</ItemTemplate>
</asp:ListView>
     </div>
</asp:Content>