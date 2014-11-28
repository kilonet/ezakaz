<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="EZakaz.Web.UI.Feedback" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">
    <asp:Label ID="lblSucces" runat="server" ForeColor="Red" Text="Ваше сообщение успешно отправлено"
        Visible="False"></asp:Label><br />
Оставить сообщение для разработчика сайта:<br />
    <asp:TextBox ID="txtMessage" runat="server" Height="128px" TextMode="MultiLine" Width="383px" EnableViewState="False"></asp:TextBox>
    <br />
    <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Отправить" />
</asp:Content>
