<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="EZakaz.Web.UI.User" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">
    <table border="1" cellspacing="0" style="border-collapse: collapse;" >
        <tr>
            <td>�����</td>
            <td><asp:Label ID="lblLogin" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td>�������� �����������</td>
            <td><asp:Label ID="lblname" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td>EMail</td>
            <td><asp:Label ID="lblEmail" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td>�����</td>
            <td><asp:Label ID="lblAdres" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td>�������</td>
            <td><asp:Label ID="lblPhone" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td>���������� ����</td>
            <td><asp:Label ID="lblContact" runat="server" ></asp:Label></td>
        </tr>
        <asp:Panel ID="panClientId" runat="server">
        <tr>
            <td>
                Id ������� � Access 
            </td>
            <td>
                <asp:TextBox ID="txtClientId" runat="server"></asp:TextBox>
            </td>
        </tr>
        </asp:Panel>
        <asp:Panel ID="panRoles" runat="server" >
        <tr>
            <td>����:</td>
            <td>
                    <asp:DropDownList ID="ddlRole" runat="server">
                      <asp:ListItem Value=""></asp:ListItem>
                      <asp:ListItem Value="0">�������������</asp:ListItem>
                      <asp:ListItem Value="1">���������</asp:ListItem>
                      <asp:ListItem Value="2">������</asp:ListItem>
                    </asp:DropDownList>  
    				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="���������� ������� ����" ControlToValidate="ddlRole"></asp:RequiredFieldValidator>
            </td>
        </tr>
        </asp:Panel>
        <asp:Panel ID="panPriceType" runat="server">
        <tr>
            <td>��� ����
                    
             </td>
             <td>
                    <asp:DropDownList ID="ddlPriceType" runat="server">
                        <asp:ListItem Value="1">���� 1</asp:ListItem>
                        <asp:ListItem Value="2">���� 2</asp:ListItem>
                        <asp:ListItem Value="3">���� 3</asp:ListItem>
                    </asp:DropDownList> 
             </td>
        </tr>
        </asp:Panel>
        <tr>
            <td colspan="2" >
                <asp:CheckBox ID="chkActive" runat="server" Text="����������" /></td>
        </tr>
    </table>
	<asp:Panel ID="panIsNew" runat="server" style="background-color: #ff9999" Width="480px" >
		������������ ������� ����������� 
		<asp:Button ID="btnAccept" runat="server" Text="���������" OnClick="btnAccept_Click" /> 
		<asp:Button ID="btnCancel" runat="server" Text="���������" OnClick="btnCancel_Click" />
	</asp:Panel>
    <asp:Button ID="btnSave" runat="server" Text="���������" OnClick="btnSave_Click" />
</asp:Content>
