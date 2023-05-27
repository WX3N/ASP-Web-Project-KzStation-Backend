<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Projek.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Repeater ID="CardRepeater" runat="server">    
    <ItemTemplate>
        <div class="card m-2 card-cloth">
            <asp:LinkButton ID="OpenDetail" runat="server" Style="cursor: pointer" CommandArgument='<%#Eval("Id") %>' OnClick="OpenDetail_Click">
                <div>
                    <img src="../Assets/<%# Eval("ItemImage") %>" alt="...">
                    <div class="card-body">
                        <p class="card-text title-hover"><%# Eval("ItemName") %></p>
                    </div>
                    <div class="list-group list-group-flush">
                        <p class="list-group-item text-right" style="font-size: 18px;"><b>$<%# Eval("ItemPrice") %></b></p>
                    </div>
                </div>
            </asp:LinkButton>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>
