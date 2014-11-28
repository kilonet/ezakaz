<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintOrder.aspx.cs" Inherits="EZakaz.Web.UI.PrintOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        td, th, table {
            border-collapse: collapse;
            border: solid 1px;
        }        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
    <input type="button" value="Напечатать" onclick="window.print();this.style.display = 'none'"/><br />
    <asp:Label ID="lblDate" runat="server"></asp:Label>
    <table cellspacing="0">
        <tr>
            <th>Наименование</th>
            <th>Кол-во</th>
        </tr>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <tr>
                <td><%# Eval("Name") %></td>
                <td><%# Eval("N") %></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
    <asp:Label ID="lblSumm" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
