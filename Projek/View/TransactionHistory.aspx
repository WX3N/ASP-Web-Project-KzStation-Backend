<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="Projek.View.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Transaction History</h1>

    <div style="margin-top: 20px;">
        <table style="width: 100%; border-collapse: collapse;">
            <tr>
                <th style="border: 1px solid black; padding: 5px;">Transaction ID</th>
                <th style="border: 1px solid black; padding: 5px;">Transaction Date</th>
                <th style="border: 1px solid black; padding: 5px;">Customer Name</th>
                <th style="border: 1px solid black; padding: 5px;">Album Price</th>
                <th style="border: 1px solid black; padding: 5px;">Album Name</th>
                <th style="border: 1px solid black; padding: 5px;">Qty</th>
                <th style="border: 1px solid black; padding: 5px;">Total Price</th>
            </tr>
            <asp:Repeater ID="rptTransactionHistory" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="border: 1px solid black; padding: 5px;"><%# Eval("TransactionId") %></td>
                        <td style="border: 1px solid black; padding: 5px;"><%# Eval("TransactionDate", "{0:dd/MM/yyyy}") %></td>
                        <td style="border: 1px solid black; padding: 5px;"><%# Eval("CustomerName") %></td>
                        <td style="border: 1px solid black; padding: 5px;"><%# Eval("AlbumPrice", "{0:C}") %></td>
                        <td style="border: 1px solid black; padding: 5px;"><%# Eval("AlbumName") %></td>
                        <td style="border: 1px solid black; padding: 5px;"><%# Eval("Qty") %></td>
                        <td style="border: 1px solid black; padding: 5px;"><%# Eval("TotalPrice", "{0:C}") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>
