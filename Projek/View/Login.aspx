<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Projek.View.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Login</h2>

    <div class="cardbox"> 
        <div class="card">
            <span>Email : </span>
            <asp:TextBox ID="EmailBox" runat="server" class=""></asp:TextBox>
            <asp:Label ID="EmailLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        </div>
        <div class="card">
            <span>Password : </span>
            <asp:TextBox ID="PasswordBox" runat="server" class=""></asp:TextBox>
            <asp:Label ID="PasswordLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        </div>
    </div>

    <p>
       <asp:Button ID="loginBtn" runat="server" Text="Login" class=""
            onClick="loginBtn_Click"/>
    </p>


</asp:Content>
