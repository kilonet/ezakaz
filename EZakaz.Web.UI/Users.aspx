<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="EZakaz.Web.UI.Users" Title="Untitled Page" 
 EnableEventValidation="false"%>
<%@ Import namespace="EZakaz.Domain"%>

<%@ Register Assembly="JAGregory.Controls.DeleGrid" Namespace="JAGregory.Controls"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">
    <script language="javascript" type="text/javascript">
        var hfId;
        $(document).ready(function() {
            $(".zebra tr:even").addClass("alt");
            $("#confirmDelete").dialog({
                width: 480,
                autoOpen: false,
                modal: true,
                overlay: {
                    backgroundColor: '#000',
                    opacity: 0.5
                },
                buttons: {
                    "Отмена": function() { $(this).dialog("close"); },
                    "Удалить": function() {
                        var hf = document.getElementById(hfId);
                        eval(hf.value);
                        $(this).dialog("close");
                    }
                }
            });
        })

        function confirmDelete(id, name) {
            hfId = id;
            $("#userName").html(name);
            $("#confirmDelete").dialog("open"); 
        }
        
    </script>
    
    <div id="confirmDelete" style="display:none">
        &#1042;&#1099; &#1091;&#1074;&#1077;&#1088;&#1077;&#1085;&#1099; &#1095;&#1090;&#1086;, &#1093;&#1086;&#1090;&#1080;&#1090;&#1077; &#1091;&#1076;&#1072;&#1083;&#1080;&#1090;&#1100; &#1087;&#1086;&#1083;&#1100;&#1079;&#1086;&#1074;&#1072;&#1090;&#1077;&#1083;&#1103; <span style="font-weight:bold" id="userName"></span> ? <br />
        (&#1074;&#1089;&#1103; &#1080;&#1085;&#1092;&#1086;&#1088;&#1084;&#1072;&#1094;&#1080;&#1103; &#1086; &#1079;&#1072;&#1082;&#1072;&#1079;&#1072;&#1093; &#1090;&#1072;&#1082; &#1078;&#1077; &#1073;&#1091;&#1076;&#1077;&#1090; &#1091;&#1076;&#1072;&#1083;&#1077;&#1085;&#1072;)        
    </div>
    
    <cc1:DeleGrid AllowPaging="True" ID="gvUsers" runat="server" AutoGenerateColumns="False" PageSize="25"
     AllowSorting="True" CssClass="zebra"
     CellPadding="4"
     ForeColor="#333333"
     GridLines="Vertical" BorderColor="#D0D0BF"
     SortingDirection="Ascending" SortingField=""
     OnRowDataBound="gvUsers_rowDataBound">
        
        <Columns>
            <asp:HyperLinkField HeaderText="&#1051;&#1086;&#1075;&#1080;&#1085;" DataTextField="Login"  SortExpression="Login" DataNavigateUrlFields="Id" 
            DataNavigateUrlFormatString="~\User.aspx?id={0}"/>
            <asp:BoundField HeaderText="&#1053;&#1072;&#1079;&#1074;&#1072;&#1085;&#1080;&#1077; &#1086;&#1088;&#1075;&#1072;&#1085;&#1080;&#1079;&#1072;&#1094;&#1080;&#1080;" DataField="Name" SortExpression="Name"/>
            <asp:BoundField HeaderText="E-Mail" DataField="Email" SortExpression="Email"/>
            <asp:BoundField HeaderText="&#1040;&#1076;&#1088;&#1077;&#1089;" DataField="Address" SortExpression="Address"/>
            <asp:BoundField HeaderText="&#1058;&#1077;&#1083;&#1077;&#1092;&#1086;&#1085;" DataField="Phone" SortExpression="Phone"/>
            <asp:BoundField HeaderText="&#1058;&#1080;&#1087; &#1094;&#1077;&#1085;&#1099;" DataField="PriceType" SortExpression="PriceType"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="hdnBtnPostback"/>
                    <asp:HyperLink runat="server" ID="hlDeleteUser" style="text-decoration: underline; color: #FF6600; cursor: pointer;">&#1091;&#1076;&#1072;&#1083;&#1080;&#1090;&#1100;1</asp:HyperLink>
                    <asp:LinkButton runat="server" ID="lbtnDeleteUser" OnCommand="deleteUserClick" Visible="false">&#1091;&#1076;&#1072;&#1083;&#1080;&#1090;&#1100;</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        <FooterStyle BackColor="#E8E8E8" Font-Bold="True" />
        <PagerStyle BackColor="#E8E8E8" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#E8E8E8" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
    </cc1:DeleGrid>

</asp:Content>
