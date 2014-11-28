<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="EZakaz.Web.UI.Test" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Тестовые данные" OnClick="Button1_Click" />  
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Mark read" />
	<asp:Button ID="Button3" runat="server" Text="Generate non-active users" OnClick="Button3_Click" />
    
</asp:Content>
