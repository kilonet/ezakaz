<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="EZakaz.Web.UI.MyProfile" Title="Untitled Page" EnableViewState="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">
    <table>
        <tr>
            <td style="width: 150px">
                �����</td>
            <td style="width: 419px">
                <asp:Label ID="lblLogin" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 150px">
                ��������</td>
            <td style="width: 419px">
                <asp:TextBox ID="txtName" runat="server" Width="365px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                    ErrorMessage='���� "��������" ������ ���� ���������'>*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName"
                    ErrorMessage='���� "��������" ������ ��������� �� 4 �� 256 ��������' ValidationExpression=".{4,256}">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                Email</td>
            <td style="width: 419px">
                <asp:TextBox ID="txtEmail" runat="server" Width="365px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage='���� "Email" ������ ���� ���������'>*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage='������������ ������ ���� "EMail"' ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 150px; ">
                �����</td>
            <td style="width: 419px; ">
                <asp:TextBox ID="txtAdres" runat="server" Width="365px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdres"
                    ErrorMessage='���� "�����" ������ ���� ���������'>*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAdres"
                    ErrorMessage='���� "�����" ������ ��������� �� 4 �� 256 ��������' ValidationExpression=".{4,256}">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                �������</td>
            <td style="width: 419px">
                <asp:TextBox ID="txtPhone" runat="server" Width="365px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhone"
                    ErrorMessage='���� "�������" ������ ���� ���������'>*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPhone"
                    ErrorMessage='���� "�������" ������ ��������� �� 4 �� 256 ��������' ValidationExpression=".{4,256}">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 150px">
                ���������� ����</td>
            <td style="width: 419px; ">
                <asp:TextBox ID="txtContact" runat="server" Width="365px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContact"
                    ErrorMessage='���� "���������� ����" ������ ���� ���������'>*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtContact"
                    ErrorMessage='���� "���������� ����" ������ ��������� �� 4 �� 256 ��������' ValidationExpression=".{4,256}">*</asp:RegularExpressionValidator></td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <asp:Button ID="btnSave" runat="server" Text="���������" OnClick="btnSave_Click" />
</asp:Content>
