<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="Projek.View.AlbumDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <h2>Album Detail</h2>
    <div>
        
        <div>
           <asp:Image ID="AlbumImage" Width="200px" runat="server" />
        </div>
        <div>
            <h3>Album Name: <asp:Label ID="AlbumName" runat="server"></asp:Label></h3>
            <p>Album Price: <asp:Label ID="AlbumPrice" runat="server"></asp:Label></p>
            <p>Album Stock: <asp:Label ID="AlbumStock" runat="server"></asp:Label></p>
            <p>Album Description: <asp:Label ID="AlbumDescription" runat="server"></asp:Label></p>
        </div>
    </div>

    <div>
        <asp:Label ID="Quantity" runat="server" Text="Quantity" Visible="false"></asp:Label>
        <asp:TextBox ID="QuantityTxt" runat="server" Text="0" Visible="false"></asp:TextBox>
        <asp:Label ID="QuantityLbl" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <asp:Button ID="AddToCartBtn" runat="server" Text="Add To  Cart" Visible="false" onClick="AddToCartBtn_Click"/>

</asp:Content>
