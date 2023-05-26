<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Projek.View.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <h2>Register</h2>

    <div class="cardbox"> 
        <div class="card">
            <span>Name : </span>
            <asp:TextBox ID="NameTxt" runat="server" class=""></asp:TextBox>
            <asp:Label ID="NameLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        </div>

        <div class="card">
            <span>Email : </span>
            <asp:TextBox ID="EmailTxt" runat="server" class=""></asp:TextBox>
            <asp:Label ID="EmailLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        </div>

        <div class="card">
            
            <span>Gender : </span>

            <asp:RadioButtonList ID="GenderList" runat="server">
            <asp:ListItem Text="Male" Value="M" />
            <asp:ListItem Text="Female" Value="F" />
            </asp:RadioButtonList>

       </div>
     
        
        <div class="card">
            <span>Address : </span>
            <asp:TextBox ID="AddressTxt" runat="server" class=""></asp:TextBox>
            <asp:Label ID="AddressLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        </div>

        <div class="card">
            <span>Password : </span>
            <asp:TextBox ID="PasswordTxt" runat="server" class=""></asp:TextBox>
            <asp:Label ID="PasswordLbl" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        </div>
    </div>

    <div>
        <p>
            <asp:Button ID="registerBtn" runat="server" Text="Register" class=""
            onClick="registerBtn_Click"/>
        </p>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Login.aspx"><input type="button" value="Login" class=""/></asp:HyperLink>
        </p>
                
   </div>
 


</asp:Content>
