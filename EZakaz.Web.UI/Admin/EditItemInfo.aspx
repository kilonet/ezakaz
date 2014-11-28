<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditItemInfo.aspx.cs" Inherits="EZakaz.Web.UI.Admin.EditItemInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">

    <script src="../Content/jquery-lightbox-0.5/js/jquery.lightbox-0.5.pack.js" type="text/javascript"></script>
    <link href="../Content/jquery-lightbox-0.5/css/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function() {
        $('a.lightbox').lightBox({
        imageBtnClose: '<%= ResolveUrl("~/Content/jquery-lightbox-0.5/images/lightbox-btn-close.gif") %>',
        imageLoading: '<%= ResolveUrl("~/Content/jquery-lightbox-0.5/images/lightbox-ico-loading.gif") %>'
            });
        });
    </script>
   
    <asp:ScriptManager ID="ScriptManager1" runat="server">	</asp:ScriptManager>
    
		    <cc2:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
                <cc2:TabPanel runat="server" HeaderText="&#1054;&#1087;&#1080;&#1089;&#1072;&#1085;&#1080;&#1077;" ID="TabPanel1" >
                    <ContentTemplate>
                    <table style="border-width: 0px">
                        <tr>
                            <td><cc1:Editor ID="Editor1" runat="server" Width="640" Height="480"/></td>
                            <td style="vertical-align:top">
                                <asp:Button ID="btnSaveDescription" runat="server" Text="&#1057;&#1086;&#1093;&#1088;&#1072;&#1085;&#1080;&#1090;&#1100; &#1086;&#1087;&#1080;&#1089;&#1072;&#1085;&#1080;&#1077;" 
                                    onclick="btnSaveDescription_Click" /><br/>  
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                     ControlToValidate="Editor1" ErrorMessage="&#1052;&#1072;&#1082;&#1089;&#1080;&#1084;&#1072;&#1083;&#1100;&#1085;&#1072;&#1103; &#1076;&#1083;&#1080;&#1085;&#1072; &#1086;&#1087;&#1080;&#1089;&#1072;&#1085;&#1080;&#1103; - 5000 &#1089;&#1080;&#1084;&#1074;&#1086;&#1083;&#1086;&#1074;" ValidationExpression="^[\s\S]{0,5000}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                    </ContentTemplate>
                </cc2:TabPanel>
                <cc2:TabPanel runat="server" HeaderText="&#1060;&#1086;&#1090;&#1086;&#1075;&#1088;&#1072;&#1092;&#1080;&#1103;" ID="TabPanel2">
                    <ContentTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="lightbox">
                            <asp:Image ID="Image1" runat="server" />
                        </asp:HyperLink><br />	                        
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="btnUpload" runat="server" Text="&#1047;&#1072;&#1075;&#1088;&#1091;&#1079;&#1080;&#1090;&#1100; &#1082;&#1072;&#1088;&#1090;&#1080;&#1085;&#1082;&#1091;" 
                            onclick="btnUpload_Click" />
                        
                    </ContentTemplate>
                </cc2:TabPanel>
            </cc2:TabContainer>
            
	        
    </asp:Content>
