<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="EZakaz.Web.UI.News" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
	TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">
	<script language="javascript" type="text/javascript">
		function confirmPublish() {
		var agree = confirm("Опубликовать новость?");
			if (agree)
				return true;
			else
				return false;
		}
	</script>
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<cc1:Editor ID="Editor1" runat="server" Width="640" Height="480" />
	<asp:Label ID="lblNewsText" runat="server" Text=""></asp:Label>
	<asp:Button ID="btnPublish" runat="server" Text="Опубликовать" 
		onclick="btnPublish_Click" OnClientClick="return confirmPublish()"/>
</asp:Content>
