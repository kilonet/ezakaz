<%@ Page EnableEventValidation="false" EnableViewState="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="EZakaz.Web.UI.ItemsAll1" Title="Untitled Page" %>

<%@ Register TagPrefix="jag" Namespace="JAGregory.Controls" Assembly="JAGregory.Controls.DeleGrid" %>
<%@ Import namespace="EZakaz.Domain"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">

    <script src="Content/jquery-lightbox-0.5/js/jquery.lightbox-0.5.js" type="text/javascript"></script>
    
    
    <div id="dialog"></div>
    
    <br />
    
    
    <table id="searchPanel" cellpadding="4"
        cellspacing="0">
        <tr>
            <td colspan="6" style="background-color: #BABABA;">
                <div  style="height: 7px">
                </div>
            </td>
        </tr>
        <tr style="vertical-align: top;">
            <td>
            &#1048;&#1089;&#1082;&#1072;&#1090;&#1100; &#1090;&#1086;&#1074;&#1072;&#1088;:<br />
                 <input runat="server" ID="txtSearch" type="text" style="width: 200px;" onkeydown="javascript:EnterKeyFilter();" />
            </td>
            <td>
            &#1042; &#1082;&#1072;&#1090;&#1077;&#1075;&#1086;&#1088;&#1080;&#1080;:<br />
                <asp:DropDownList runat="server" ID="ddlCat" Width="200px" style="border: thin solid;"></asp:DropDownList>
            </td>
            <td rowspan="2">
            &#1050;&#1086;&#1084;&#1084;&#1077;&#1085;&#1090;&#1072;&#1088;&#1080;&#1081;<br />
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtComment" Height="50px" 
                    Width="260px" />
            </td>
            <td  rowspan="2">
            
            </td>
            <td  rowspan="2">
            
            </td>
            <td  width="100%" rowspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <table cellspacing="0">
                    <tr>
                        <td style="vertical-align: bottom">
                            <input type="checkbox" id="chbOrder" onchange="toggleOrder()" />
                        </td>
                        <td>
                            <label for="chbOrder">
                                &#1054;&#1090;&#1086;&#1073;&#1088;&#1072;&#1078;&#1072;&#1090;&#1100; &#1090;&#1086;&#1083;&#1100;&#1082;&#1086;
                                &#1079;&#1072;&#1082;&#1072;&#1079; |</label></td>
                        <td style="font-weight: bold; vertical-align: bottom;">
                            &#1057;&#1091;&#1084;&#1084;&#1072; &#1079;&#1072;&#1082;&#1072;&#1079;&#1072;:
                            <span id="summ">0&#1088;.</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Button runat="server" Text="&#1054;&#1090;&#1087;&#1088;&#1072;&#1074;&#1080;&#1090;&#1100; &#1079;&#1072;&#1082;&#1072;&#1079;" ID="btnSubmit" OnClick="btnSubmit_Click" ></asp:Button></td>
                        <td><input id="btnFilterReset" onclick="resetFilter()" type="button" value="&#1057;&#1073;&#1088;&#1086;&#1089;" /></td>
                        
                    </tr>
                </table>
            
                </td>
        </tr>
    </table>
    
    
    
    <jag:DeleGrid ID="gvItems" runat="server" OnRowDataBound="gvItems_RowDataBound"
        AutoGenerateColumns="False" CssClass="zebra"
        AllowSorting="False"
        CellPadding="4"
        ForeColor="#333333"
        GridLines="Vertical" BorderColor="#D0D0BF"
        SortingDirection="Ascending" SortingField="" OnPageDataRequest="gvItems_PageDataRequest" OnSorting="gvItems_Sorting" OnTotalRecordCountRequest="gvItems_TotalRecordCountRequest">
            
         <Columns>
            <asp:TemplateField HeaderText="&#1053;&#1072;&#1080;&#1084;&#1077;&#1085;&#1086;&#1074;&#1072;&#1085;&#1080;&#1077;" >
                <ItemTemplate>
                    <% if (Presenter.CurrentUser.IsAdmin)
                       {%>
                        <a id="<%# "a" + ((Item)Container.DataItem).Id %>" href="Admin/EditItemInfo.aspx?id=<%# ((Item)Container.DataItem).Id %>"><%# ((Item)Container.DataItem).Name %></a>
                    <% }
                       else
                       { %>
                       <a href="ItemInfo.aspx?id=<%# ((Item)Container.DataItem).Id %>"><%# ((Item)Container.DataItem).Name %></a>
                    <% } %>
                    
                    <%-- 
                        <span style="text-decoration: underline; color: #FF6600" onclick="showInfo(<%# ((Item)Container.DataItem).ItemInfo.ProductId %>, $('#<%# "a" + ((Item)Container.DataItem).Id %>').html())">modal</span>
                    --%>
                    
                    <%# string.IsNullOrEmpty(((Item)Container.DataItem).ItemInfo.Image) ? "" : "<img alt='&#1077;&#1089;&#1090;&#1100; &#1092;&#1086;&#1090;&#1086;&#1075;&#1088;&#1072;&#1092;&#1080;&#1103;' title='&#1077;&#1089;&#1090;&#1100; &#1092;&#1086;&#1090;&#1086;&#1075;&#1088;&#1072;&#1092;&#1080;&#1103;' src='Content/img/photo.gif'/>"%>
                    <%# string.IsNullOrEmpty(((Item)Container.DataItem).ItemInfo.Description) ? "" : "<img alt='&#1077;&#1089;&#1090;&#1100; &#1086;&#1087;&#1080;&#1089;&#1072;&#1085;&#1080;&#1077;' title='&#1077;&#1089;&#1090;&#1100; &#1086;&#1087;&#1080;&#1089;&#1072;&#1085;&#1080;&#1077;' src='Content/img/2.png'/>"%>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="&#1062;&#1077;&#1085;&#1072;" SortExpression="Price1">
                <ItemTemplate>
                    <%# ((Item)Container.DataItem).GetPrice(Presenter.CurrentUser.PriceType).ToString("C") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Rest" HeaderText="&#1054;&#1089;&#1090;&#1072;&#1090;&#1086;&#1082;" SortExpression="Rest"/>
            <asp:TemplateField HeaderText="&#1047;&#1072;&#1082;&#1072;&#1079;">
                <ItemTemplate>
					<asp:TextBox id="txtOrder" runat="server" CssClass="input"></asp:TextBox> 
                    <asp:HiddenField ID="hfItemId" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Manufacter" HeaderText="&#1055;&#1088;&#1086;&#1080;&#1079;&#1074;&#1086;&#1076;&#1080;&#1090;&#1077;&#1083;&#1100;" SortExpression="Manufacter"/>
            <asp:BoundField DataField="Pack" HeaderText="&#1059;&#1087;&#1072;&#1082;&#1086;&#1074;&#1082;&#1072;" SortExpression="Pack"/>
            <asp:BoundField DataField="Date" HeaderText="&#1057;&#1088;&#1086;&#1082; &#1075;&#1086;&#1076;&#1085;&#1086;&#1089;&#1090;&#1080;"  SortExpression="Date" DataFormatString="{0:MMM yyyy}"/>
            
            <asp:TemplateField HeaderText="&#1062;&#1077;&#1085;&#1072;1" SortExpression="Price1">
                <ItemTemplate>
                    <%# ((Item)Container.DataItem).Price1.ToString("C") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#1062;&#1077;&#1085;&#1072;2" SortExpression="Price2">
                <ItemTemplate>
                    <%# ((Item)Container.DataItem).Price2.ToString("C")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#1062;&#1077;&#1085;&#1072;3" SortExpression="Price3">
                <ItemTemplate>
                    <%# ((Item)Container.DataItem).Price3.ToString("C")%>
                </ItemTemplate>
            </asp:TemplateField>
             
        </Columns>   
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#E8E8E8" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        
    </jag:DeleGrid>
    
    <script language="javascript" type="text/javascript">

        $(document).ready(function() {
            $(".zebra tr:even").addClass("alt");
            <%--            $('.input').numeric();--%>
            $("#searchPanel").css("width", $("#<%= gvItems.ClientID %>").css("width"));
        });
	    
        String.prototype.trim = function () {
            return this.replace(/^\s*/, "").replace(/\s*$/, "");
        }
        
        function showCat(number, _search) {
            var table = $('#<%= gvItems.ClientID %>')[0];
            var search = _search.trim().toLocaleLowerCase();
            var count = 0;
            for (i = 1; i < table.rows.length; i++) {
                var productName = table.rows[i].cells[0].innerHTML.toLocaleLowerCase();
                if (table.rows[i].id != 'notFoundRow' && (table.rows[i].id == number || number == '-1') && productName.indexOf(search) != -1) {
                    table.rows[i].style.display = '';
                    count++;
                } else {
                    table.rows[i].style.display = 'none'
                }
            }
            if (count == 0){
                var row = table.insertRow(1);
                row.id = 'notFoundRow';
                var cell = row.insertCell(0);
                cell.colSpan = 7;
                cell.innerHTML = '<em>&#1047;&#1072;&#1076;&#1072;&#1085;&#1085;&#1099;&#1084; &#1087;&#1072;&#1088;&#1072;&#1084;&#1077;&#1090;&#1088;&#1072;&#1084; &#1085;&#1077; &#1089;&#1086;&#1086;&#1090;&#1074;&#1077;&#1089;&#1090;&#1074;&#1091;&#1077;&#1090; &#1085;&#1080; &#1086;&#1076;&#1085;&#1072; &#1087;&#1086;&#1079;&#1080;&#1094;&#1080;&#1103;<em/>';
                cell.align = 'center';
            }
            
            count = 0;
            for (i = 1; i < table.rows.length; i++) {
                if (table.rows[i].style.display != 'none'){
                    count++;
                    if (count % 2 == 0)
                        table.rows[i].className = 'alt';
                    else
                        table.rows[i].className = '';
                }
            }  
        }
        
        function resetFilter(){
            var table = $('#<%= gvItems.ClientID %>')[0];
            for (i = 1; i < table.rows.length; i++)
                if (table.rows[i].id != 'notFoundRow')
                    table.rows[i].style.display = '';
                else
                    table.rows[i].style.display = 'none';
            $('#<%= txtSearch.ClientID %> ')[0].value = '';
            $('#<%= ddlCat.ClientID %> ')[0].selectedIndex = 0;
            //$$('#notFoundRow').invoke('hide');
        }
        
         function calcSumm() {
            var table = document.getElementById('<%= gvItems.ClientID %>');
            var summ = 0;
            for (i = 1; i < table.rows.length; i++) {
                var cell = table.rows[i].cells[3];
                var n = parseInt(cell.getElementsByTagName('input')[0].value);
                if (n > 0) {
                    cell = table.rows[i].cells[1];
                    var price = parseFloat(cell.innerHTML.trim().substr(0, cell.innerHTML.trim().length - 2).replace(',', '.'));
                    summ += n * price;
                }
            }
            summ = Math.round(summ * 100) / 100;
            $('#summ').html(summ + '&#1088;.');
            //var d2 = new Date();
            //alert(d2.getTime() - d1.getTime());
        }
        
        function toggleOrder() {
            var showOrder = document.getElementById('chbOrder').checked;
            var table = $('#<%= gvItems.ClientID %>')[0];
            if (showOrder) {
                for (i = 1; i < table.rows.length; i++) {
                    var cell = table.rows[i].cells[3];
                    if (cell == null) continue;
                    var n = parseInt(cell.getElementsByTagName('input')[0].value);
                    if (isNaN(n) || n < 1)
                        table.rows[i].style.display = 'none';
                    else
                        table.rows[i].style.display = '';
                }
            } else {
                showCat($('#<%= ddlCat.ClientID %>')[0].options[$('#<%= ddlCat.ClientID %>')[0].selectedIndex].value,
                 $('#<%= txtSearch.ClientID %>')[0].value,
                 '<%= ddlCat.ClientID %>');
            }
        }

        
    <%-- 
            function showInfo(infoId, title) {
            $.get('<%= ResolveUrl("~/GetItemInfo.ashx?id=") %>' + infoId, function(response){
                $('#dialog').html(response);
                $('#dialog').dialog('option', 'title', title);
                $("#dialog").dialog('open');
                $('a.lightbox').lightBox({
                    imageBtnClose: '<%= ResolveUrl("~/Content/jquery-lightbox-0.5/images/lightbox-btn-close.gif") %>',
                    imageLoading: '<%= ResolveUrl("~/Content/jquery-lightbox-0.5/images/lightbox-ico-loading.gif") %>'
                }); 
            });
        }
    --%>
        
        <!-- #Include File="~/js/focusNextInput.js" -->    
        
    </script>
    
</asp:Content>
