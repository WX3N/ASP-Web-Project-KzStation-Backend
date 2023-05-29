<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Projek.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Artist List</p>

    <asp:Repeater ID="CardRepeater" runat="server"> 
        <ItemTemplate>
            <div style="display: grid; grid-template-columns: repeat(5, minmax(0, 1fr)); gap: 1rem;" id="post-data">

                <asp:LinkButton ID="OpenDetail" runat="server" Style="cursor: pointer" CommandArgument='<%#Eval("ArtistId") %>' OnClick="OpenDetail_Click">
                    <div>
                        <img src="../Assets/Artist/<%# Eval("ArtistImage") %>" alt="..." style="width: 200px;">
                        <div>
                            <p><%# Eval("ArtistName") %></p>
                        </div>
                    </div>

                </asp:LinkButton>
                
            </div>
            <asp:Button ID="UpdateBtn" runat="server" Text="Update Artist" onClick="UpdateBtn_Click" Visible="true"/>
            <asp:Button ID="DeleteBtn" runat="server" Text="Delete Artist" onClick="DeleteBtn_Click" Visible="true"/>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
