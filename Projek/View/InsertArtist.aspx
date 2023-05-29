<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertArtist.aspx.cs" Inherits="Projek.View.InsertArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



        <label for="inputArtistName">Artist Name</label>
        <asp:TextBox ID="ArtistNameTxt" runat="server"></asp:TextBox>
        <br />
        <label>Image</label>
        <asp:FileUpload ID="FileUpload1" runat="server" />

      
        </div>
        <asp:Label ID="ErrorTxt" runat="server" Text=""></asp:Label>
            <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click"/>
        <a>
            <asp:Button ID="CancelBtn" runat="server" Text="Cancel" OnClick="CancelBtn_Click"/>
        </a>


</asp:Content>
