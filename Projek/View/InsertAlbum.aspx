<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertAlbum.aspx.cs" Inherits="Projek.View.InsertAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add Album</h1>

    <div class="cardbox"> 
        <div>
            <asp:Label ID="InsertAlbumNameLbl" runat="server" Text="Album Name"></asp:Label>
            <asp:TextBox ID="InsertAlbumNameTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="InsertAlbumNameError" runat="server" ForeColor="Red"></asp:Label>
        </div>

        <div>
            <asp:Label ID="InsertAlbumDescriptionLbl" runat="server" Text="Album Description"></asp:Label>
            <asp:TextBox ID="InsertAlbumDescriptionTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="InsertAlbumDescriptionError" runat="server" ForeColor="Red"></asp:Label>
        </div>
        

        <div>
            <asp:Label ID="InsertAlbumPriceLbl" runat="server" Text="Album Price"></asp:Label>
            <asp:TextBox ID="InsertAlbumPriceTxt" runat="server"></asp:TextBox>
        </div>
        
        <div>
            <asp:Label ID="InsertAlbumPriceError" runat="server" ForeColor="Red"></asp:Label>
        </div>


        <div>
            <asp:Label ID="InsertAlbumStockLbl" runat="server" Text="Album Stock"></asp:Label>
            <asp:TextBox ID="InsertAlbumStockTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="InsertAlbumStockError" runat="server" ForeColor="Red"></asp:Label>
        </div>

        
        <div>
            <asp:Label ID="InsertAlbumImageLbl" runat="server" Text="Album Image"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>

        <div>
            <asp:Button ID="InsertAlbumBtn" runat="server" Text="Insert" OnClick="InsertAlbumBtn_Click"/>
        </div>
    </div>


</asp:Content>
