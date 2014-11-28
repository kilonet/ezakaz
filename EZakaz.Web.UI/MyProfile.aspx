<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="EZakaz.Web.UI.MyProfile" Title="Untitled Page" EnableViewState="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">
    <table>
        <tr>
            <td style="width: 150px">
                Логин</td>
            <td style="width: 419px">
                <asp:Label ID="lblLogin" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Название</td>
            <td style="width: 419px">
                <asp:TextBox ID="txtName" runat="server" Width="365px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                    ErrorMessage='Поле "Название" должно быть заполнено'>*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName"
                    ErrorMessage='Поле "Название" должно содержать от 4 до 256 символов' ValidationExpression=".{4,256}">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Email</td>
            <td style="width: 419px">
                <asp:TextBox ID="txtEmail" runat="server" Width="365px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage='Поле "Email" должно быть заполнено'>*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage='Неправильный формат поля "EMail"' ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 150px; ">
                Адрес</td>
            <td style="width: 419px; ">
                <asp:TextBox ID="txtAdres" runat="server" Width="365px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdres"
                    ErrorMessage='Поле "Адрес" должно быть заполнено'>*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAdres"
                    ErrorMessage='Поле "Адрес" должно содержать от 4 до 256 символов' ValidationExpression=".{4,256}">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Телефон</td>
            <td style="width: 419px">
                <asp:TextBox ID="txtPhone" runat="server" Width="365px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhone"
                    ErrorMessage='Поле "Телефон" должно быть заполнено'>*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPhone"
                    ErrorMessage='Поле "Телефон" должно содержать от 4 до 256 символов' ValidationExpression=".{4,256}">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Контактное лицо</td>
            <td style="width: 419px; ">
                <asp:TextBox ID="txtContact" runat="server" Width="365px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContact"
                    ErrorMessage='Поле "Контактное лицо" должно быть заполнено'>*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtContact"
                    ErrorMessage='Поле "Контактное лицо" должно содержать от 4 до 256 символов' ValidationExpression=".{4,256}">*</asp:RegularExpressionValidator></td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Сохранить" OnClick="btnSave_Click" />
</asp:Content>
