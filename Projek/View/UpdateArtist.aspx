<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateArtist.aspx.cs" Inherits="Projek.UpdateArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



        <label for="inputArtistName">Artist Name</label>
        <asp:TextBox ID="ArtistNameTxt" runat="server"></asp:TextBox>
        <asp:Label ID="ArtistNameLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
         <br />  
        <label>Image</label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Label ID="ArtistImageLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>


    <div>
        <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click"/>
        <br />
        <asp:Button ID="CancelBtn" runat="server" Text="Cancel" OnClick="CancelBtn_Click"/>
    </div>

 


</asp:Content>
