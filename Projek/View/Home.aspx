<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Projek.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Repeater ID="CardRepeater" runat="server">    
    <ItemTemplate>
        <div>
            <asp:Button ID="InsertBtn" runat="server" Text="Button" />
            <asp:Button ID="DeleteBtn" runat="server" Text="Button" />
            <asp:LinkButton ID="OpenDetail" runat="server" Style="cursor: pointer" CommandArgument='<%#Eval("Id") %>' OnClick="OpenDetail_Click">
                <div>
                    <img src="../Assets/<%# Eval("ArtistImage") %>" alt="...">
                    <div class="card-body">
                        <p><%# Eval("ItemName") %></p>
                    </div>
                </div>
            </asp:LinkButton>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>
