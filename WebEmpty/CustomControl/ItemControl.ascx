<%@ Control Language="C#" AutoEventWireup="true" Inherits="CustomControl_ItemControl" Codebehind="ItemControl.ascx.cs" %>

 <asp:HyperLink id="urlDetail" runat="server">
            <ul class="list-unstyled" style="width: 200px;height :250px">
                <img src="../img/love1.jpg" height="100" class="img-rounded photo" alt="Cinque Terre" id="imgDetail" style="width: 200px;height:200px" />
                <li><span class="title">Price:</span><label id="lblPrice" runat="server"> Price</label></li>
                <li><span class="title">Code:</span><label id="lblCode" runat="server"> Code</label></li>
            </ul>
 </asp:HyperLink>
