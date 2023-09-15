<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Projek.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Artist List</h1>

    <asp:Button ID="InsertBtn" runat="server" Style="cursor: pointer;text-decoration: none; color: white; font-size: 15px; background-color: deepskyblue; padding: 4px 8px;" Text="Insert" Visible ="false" OnClick="InsertBtn_Click"/>

<asp:Repeater ID="CardRepeater" runat="server" OnItemDataBound="CardRepeater_ItemDataBound">
    <ItemTemplate>
        <%# Container.ItemIndex % 5 == 0 ? "<div style='display: grid; grid-template-columns: repeat(5, 1fr); gap: 8px; '>" : "" %>
        <div style="width: 200px; height: 200px; position: relative; margin: 8px; margin-bottom:55px;">
            <asp:LinkButton ID="OpenDetail" runat="server" Style="cursor: pointer; position: relative; text-align: center; display: block; width: 100%; height: 100%;" CommandArgument='<%#Eval("ArtistId") %>' OnClick="OpenDetail_Click">
                <div style="position: absolute; top: 0; left: 0; right: 0; bottom: 0;">
                    <img src='<%# "../Assets/Artist/" + Eval("ArtistImage") %>' alt="Artist Image" style="width: 100%; height: 100%; object-fit: cover;" />
                    <div style="position: absolute; bottom: 0; left: 0; right: 0; background-color: rgba(0, 0, 0, 0.7); padding: 8px; color: white;">
                        <p style="margin: 0; text-align: center;"><%# Eval("ArtistName") %></p>
                    </div>
                </div>
            </asp:LinkButton>
            
            <div style="display: flex; justify-content: center; margin:5px;">
                <asp:LinkButton ID="UpdateBtn" runat="server" Style="text-decoration: none; color: white; font-size: 15px; background-color: green; padding: 4px 8px;" CommandArgument='<%#Eval("ArtistId") %>' OnClick="UpdateBtn_Click">
                    Update
                </asp:LinkButton>
            </div>
            <div style="display: flex; justify-content: center;margin:5px;">
                <asp:LinkButton ID="DeleteBtn" runat="server" Style="text-decoration: none; color: white; font-size: 15px; background-color: red; padding: 4px 8px;" CommandArgument='<%#Eval("ArtistId") %>' OnClick="DeleteBtn_Click">
                    Delete
                </asp:LinkButton>
            </div>
        </div>
        <%# Container.ItemIndex % 5 == 4 ? "</div>" : "" %>
    </ItemTemplate>
</asp:Repeater>

</asp:Content>
