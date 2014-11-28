<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="EZakaz.Web.UI.WebForm1" Title="Untitled Page" EnableViewState="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">
    <table>
        <tr>
            <td >
                Старый пароль</td>
            <td >
                <asp:TextBox ID="txtOldPass" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtOldPass"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td >
                Новый пароль</td>
            <td >
                <asp:TextBox ID="txtNewPass" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtNewPass"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" runat="server" ErrorMessage="Допускается латиница и цифры, не менее 4 символов" ControlToValidate="txtNewPass" ValidationExpression="[a-zA-Z0-9]{4,256}"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td >
                Подтвердите новый пароль</td>
            <td >
                <asp:TextBox ID="txtNewPassConfirm" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewPassConfirm"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator
                    ID="CompareValidator1" runat="server" ErrorMessage="Пароли не совпадают" ControlToCompare="txtNewPass" ControlToValidate="txtNewPassConfirm" ></asp:CompareValidator></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Сменить пароль" /></td>
        </tr>
    </table>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
</asp:Content>
