<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemInfo.aspx.cs" Inherits="EZakaz.Web.UI.ItemInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">

    <script src="Content/jquery-lightbox-0.5/js/jquery.lightbox-0.5.pack.js" type="text/javascript"></script>
    <link href="Content/jquery-lightbox-0.5/css/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function() {
        $('a.lightbox').lightBox({
            imageBtnClose: '<%= ResolveUrl("~/Content/jquery-lightbox-0.5/images/lightbox-btn-close.gif") %>',
            imageLoading: '<%= ResolveUrl("~/Content/jquery-lightbox-0.5/images/lightbox-ico-loading.gif") %>'
            }); 
        });
    </script>

    
<table>
    <tr>
        <td style="padding-right: 10px">
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="lightbox">
                <asp:Image ID="Image1" runat="server" />
            </asp:HyperLink>
        </td>
        <td>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </td>
    </tr>
</table>
</asp:Content>
