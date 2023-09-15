<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertAlbum.aspx.cs" Inherits="Projek.View.InsertAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Insert Album</h2>

    <label>Album Name</label>
    <asp:TextBox ID="AlbumNameTxt" Text="" runat="server"></asp:TextBox>
    <asp:Label ID="AlbumNameLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    
    <br />  

    <label>Album Description</label>
    <br />  
    <asp:TextBox ID="AlbumDescriptionTxt" Text="" runat="server" Rows="5" TextMode="MultiLine" Width="200px"></asp:TextBox>
    <asp:Label ID="AlbumDescriptionLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
   
    <br /> 

    <label>Album Price</label>
    <asp:TextBox ID="AlbumPriceTxt" Text="0" runat="server"></asp:TextBox>
    <asp:Label ID="AlbumPriceLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    
    <br /> 

    <label>Album Stock</label>
    <asp:TextBox ID="AlbumStockTxt" Text="0" runat="server"></asp:TextBox>
    <asp:Label ID="AlbumStockLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
  

    <br />

    <label>Album Image</label>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Label ID="AlbumImageLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>

      
    <div>
        <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click"/>
        <br />
        <asp:Button ID="CancelBtn" runat="server" Text="Cancel" OnClick="CancelBtn_Click"/>
    </div>



</asp:Content>
