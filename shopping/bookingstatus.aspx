<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="bookingstatus.aspx.cs" Inherits="bookingstatus" %>
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
<LayoutTemplate>
    <table border="1">
        <tr>
            <th>
                Id
            </th>
            <th>
                Date Time
            </th>
            <th>
                Booking Date
            </th>
              <th>
                Last Respond Date
            </th>
            <th>
                Dating Type
            </th>
             <th>
                Payment Mode
            </th>
            <th>
                Status
            </th>
             <th>
                Product Respond
            </th>
               <th>
                Delivery Respond
            </th>
            <th>
                View
            </th>
        </tr>
        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        <tr>
            <td colspan = "10">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="bookinglist" PageSize="10">
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
        <%# Eval("DateTime") %>
    </td>
     <td>
        <%# Eval("CreatedDate") %>
    </td>
     <td>
        <%# Eval("ModifiedDate") %>
    </td>
    <td>
        <%# Eval("ProductType") %>
    </td>
       <td>
        <%# Eval("PaymentMode") %>
    </td>
       <td>
        <%# Eval("Status") %>
    </td>
    <td>
        <%#Eval("ProductRespond")%>
    </td>
     <td>
        <%# Eval("DeliveryRespond") %>
    </td>
       <td>
      <a href="bookingrespond.aspx?BookingId=<%# Eval("Id") %>">View Detail  </a>
    </td>
</ItemTemplate>
</asp:ListView>
     </div>
</asp:Content>