<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="Projek.View.ArtistDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Artist Detail</h1>

    <div class="cardbox"> 
        <asp:Image ID="ArtistImage" runat="server" />
        <asp:Label ID="ArtistName" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Button ID="AlbumDetailsBtn" runat="server" Text="Album Details" OnClick="AlbumDetailsBtn_Click"/>
    </div>


</asp:Content>
