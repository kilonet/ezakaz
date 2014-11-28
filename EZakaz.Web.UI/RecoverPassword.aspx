<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="EZakaz.Web.UI.RecoverPassword" Title="Untitled Page" EnableViewState="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">
    <asp:Panel ID="Panel1" runat="server" >
        <table>
            <tr>
                <td>¬ведите ваш логин:</td>
                <td><asp:TextBox ID="txtLogin" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>¬ведите EMail: </td>
                <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="btnResetPass" runat="server" Text="—бросить пароль" OnClick="btnResetPass_Click" /><br /><br />
    </asp:Panel>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>

</asp:Content>
