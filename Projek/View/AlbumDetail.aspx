<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="Projek.View.AlbumDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h2>Artist Detail</h2>

    <div class="cardbox"> 
        <asp:Image ID="AlbumImage" runat="server" />
        <asp:Label ID="AlbumName" runat="server"></asp:Label>
        <asp:Label ID="AlbumPrice" runat="server"></asp:Label>
        <asp:Label ID="AlbumDescription" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Button ID="InsertAlbumPageBtn" runat="server" Text="Insert Album" OnClick="InsertAlbumPageBtn_Click"/>
        <asp:Button ID="UpdateAlbumPageBtn" runat="server" Text="Update Album" OnClick="UpdateAlbumPageBtn_Click"/>
        <asp:Button ID="DeleteAlbumPageBtn" runat="server" Text="Delete Album" OnClick="DeleteAlbumPageBtn_Click"/>
    </div>


</asp:Content>
