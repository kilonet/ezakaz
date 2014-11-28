<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="EZakaz.Web.UI.CreateUser" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">


	<script src="js/common.js" type="text/javascript"></script>
    <asp:Panel ID="panRegister" runat="server" >
    <table >
        <tr>
            <td>�����</td><td style="width: 495px">
                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLogin"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLogin"
                    ErrorMessage="����������� ������ ��������, �� ����� 4 ��������" ValidationExpression="[a-zA-Z0-9_\-]{4,256}"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>������</td>
            <td style="width: 495px">
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="���� '������' ������ ��������� ������ ������� ��������, �����, ���� ��� ������ ������������� � ����� ����� �� 4 �� 256 ��������" ControlToValidate="txtPassword" ValidationExpression="[a-zA-Z0-9]{4,256}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>��������</td><td style="width: 495px">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtName"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>�����</td><td style="width: 495px">
                <asp:TextBox ID="txtAdres" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAdres"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Email</td><td style="width: 495px">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="������������ ������" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>���������� ����</td><td style="width: 495px">
                <asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtContact"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>�������</td>
            <td style="width: 495px">
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPhone"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>����</td>
            <td style="width: 495px">
                <asp:DropDownList ID="ddlRoles" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="0">�����</asp:ListItem>
                        <asp:ListItem Value="1">���������</asp:ListItem>
                        <asp:ListItem Value="2">������</asp:ListItem>
                </asp:DropDownList>
            <%--<asp:RadioButtonList ID="rblRoles" runat="server" Width="89px">
                        <asp:ListItem Value="0">�����</asp:ListItem>
                        <asp:ListItem Value="1">���������</asp:ListItem>
                        <asp:ListItem Value="2">������</asp:ListItem>
                    </asp:RadioButtonList>--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRoles"
                        ErrorMessage="������� ����"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
               ��� ���� 
            </td>
            <td style="width: 495px">
            <asp:DropDownList ID="ddlPriceType" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="1">���� 1</asp:ListItem>
                        <asp:ListItem Value="2">���� 2</asp:ListItem>
                        <asp:ListItem Value="3">���� 3</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlPriceType"
                        ErrorMessage="������� ��� ����"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                ����� � Access</td>
            <td style="width: 495px">
                <asp:TextBox ID="txtAccesId" runat="server" Wrap="False" CssClass="input" onkeypress="return isNumber(event)"></asp:TextBox></td>
        </tr>
    
    </table>
    <asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" Text="������� ������������" />
    
    </asp:Panel>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>

</asp:Content>
