<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Projek.View.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<asp:Repeater ID="CartRepeater" runat="server" OnItemCommand="CartRepeater_ItemCommand">
    <ItemTemplate>
    <div style="display: flex; align-items: center; margin-bottom: 10px;">
        <div>
            <img src='<%# GetImageUrl(Eval("AlbumImage")) %>' alt="Album Image" style="width: 150px; height: 150px;" />
        </div>
        <div style="margin-left: 10px;">
            <h3><%# Eval("AlbumName") %></h3>
            <p>Quantity: <%# Eval("Quantity") %></p>
            <p>Album Price: <%# Eval("AlbumPrice", "{0:C}") %></p>
            <asp:Button ID="RemoveBtn" runat="server" Text="Remove" CssClass="remove-btn" CommandName="Remove" CommandArgument='<%# Eval("AlbumId") %>' />
        </div>
    </div>
</ItemTemplate>
</asp:Repeater>



    <div style="margin-top: 20px;">
        <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" CssClass="checkout-btn" OnClick="CartCheckout_Click" />
    </div>


</asp:Content>
