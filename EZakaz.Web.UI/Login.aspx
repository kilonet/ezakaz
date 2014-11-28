<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EZakaz.Web.UI.Login" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">
<div style="text-align: center;">Оптовая продажа медицинских изделий и диетических продуктов в Калуге.<br/>Телефон склада (4842) 2-28-95</div>
	<table style="WIDTH: 100%; HEIGHT: 100%;">
        <tr>
            <td align="center" valign="middle">
               <table>
               <tr>
                <td colspan="2" align="center"><h1>Вход</h1></td>
               </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Логин"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtLogin" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Пароль"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Panel ID="panFailure" runat="server" Visible="false">
                    Неверное сочетание логин - пароль. Попробуйте еще раз. <br />
                    
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnLogin" runat="server" Text="Вход" />
                <asp:Button ID="btnCreateAdmin" runat="server" OnClick="btnCreateAdmin_Click" Text="Create admin" Visible="False"/></td>
        </tr>
    </table> 
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/RecoverPassword.aspx">Забыли пароль?</asp:HyperLink>
    
            </td>
        </tr>
    </table>
</asp:Content>
