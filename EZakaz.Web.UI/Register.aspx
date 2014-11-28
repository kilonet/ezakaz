<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EZakaz.Web.UI.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head" runat="server">
    <title>�����������</title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="RegistrationForm" runat="server">
        <table>
        <tr>
            <td style="width: 180px;">
                �����</td>
            <td style="width: 242px;">
                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage='��������� ���� "�����"' ControlToValidate="txtLogin">*</asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator
					ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLogin"
					ErrorMessage="���� '�����' ������ ��������� ������ ������� ��������, �����, ���� ��� ������ ������������� � ����� ����� �� 4 �� 256 ��������"
					ValidationExpression="[a-zA-Z0-9_\-]{4,256}">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 180px">
                �������� �����������</td>
            <td style="width: 242px; white-space: nowrap;">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="��������� �������� �����������" ControlToValidate="txtName" style="display: none">*</asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"								ErrorMessage="���� '�������� �����������' ������ ����� ����� �� 4 �� 256 ��������" ControlToValidate="txtName"
					ValidationExpression=".{4,256}" style="display: none">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 180px">
                ������</td>
            <td style="width: 242px">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="��������� ���� '������'" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" ValidationExpression="[a-zA-Z0-9]{4,256}" ErrorMessage="���� '������' ������ ��������� ������ ������� ��������, �����, ���� ��� ������ ������������� � ����� ����� �� 4 �� 256 ��������">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 180px">
                ����������� ������</td>
            <td style="width: 242px">
                <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="����������� ������" ControlToValidate="txtPasswordConfirm">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="��������� ������ �� ���������" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm">*</asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 180px; height: 26px">
                Email</td>
            <td style="width: 242px; height: 26px">
                <asp:TextBox ID="txtEMail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="������� EMail" ControlToValidate="txtEMail">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="������������ ������ ������ ����������� �����"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEMail">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 180px; height: 17px;">
                �����</td>
            <td style="width: 242px; height: 17px;">
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
			<asp:RegularExpressionValidator ID="revAddress" runat="server" ErrorMessage="���� '�����' ������ ����� ����� �� 4 �� 256 ��������" ControlToValidate="txtAddress" ValidationExpression=".{4,256}">*</asp:RegularExpressionValidator></tr>
        <tr>
            <td style="width: 180px; height: 26px;">
                �������</td>
            <td style="width: 242px; height: 26px;">
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revPhone" runat="server" ErrorMessage="���� '�������' ������ ����� ����� �� 4 �� 256 ��������" ControlToValidate="txtPhone" ValidationExpression=".{4,256}">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhone"
                    ErrorMessage='���� "�������" ������ ���� ���������'>*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 180px">
                ���������� ����</td>
            <td style="width: 242px">
                <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>
				<asp:RegularExpressionValidator ID="revContactName" runat="server" ErrorMessage="���� '���������� ����' ������ ����� ����� �� 4 �� 256 ��������" ControlToValidate="txtContactName" ValidationExpression=".{4,256}">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtContactName"
                    ErrorMessage='���� "���������� ����" ������ ���� ���������'>*</asp:RequiredFieldValidator></td>
        </tr>
       <%-- <tr>
            <td style="width: 180px">
                ����</td>
            <td style="width: 242px">
                <asp:RadioButtonList ID="rblRoles" runat="server">
                    <asp:ListItem Value="0">�����</asp:ListItem>
                    <asp:ListItem Value="1">���������</asp:ListItem>
                    <asp:ListItem Value="2">������</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>--%>
		<tr>
			<td colspan="2">
				<asp:ValidationSummary ID="ValidationSummary1" runat="server" />
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Button ID="btnRegister" runat="server" Text="�����������" /></td>
		</tr>
    </table>
    </asp:Panel>
	&nbsp;
    
    <asp:Label ID="lblRegisterResult" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>


