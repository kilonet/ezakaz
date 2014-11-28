<%@ Page EnableEventValidation="false" EnableViewState="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemsAll1.aspx.cs" Inherits="EZakaz.Web.UI.ItemsAll1" Title="Untitled Page" %>
<%@ Register TagPrefix="jag" Namespace="JAGregory.Controls" Assembly="JAGregory.Controls.DeleGrid" %>
<%@ Import namespace="EZakaz.Domain"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">

     <script language="javascript" type="text/javascript">
     
        String.prototype.trim = function () {
            return this.replace(/^\s*/, "").replace(/\s*$/, "");
        }
        
        function showCat(number, _search) {
            var table = $('<%= gvItems.ClientID %>');
            var search = _search.trim().toLocaleLowerCase();
            var count = 0;
            for (i = 1; i < table.rows.length; i++) {
                var productName = table.rows[i].cells[0].innerHTML.toLocaleLowerCase();
                if (table.rows[i].id == number && productName.indexOf(search) != -1) {
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
                cell.innerHTML = '<em>Заданным параметрам не соотвествует ни одна позиция<em/>';
                cell.align = 'center';
            }
            
        }
        
        function resetFilter(){
            var table = $('<%= gvItems.ClientID %>');
            for (i = 1; i < table.rows.length; i++)
                table.rows[i].style.display = '';
            $('txtSearch').value = '';
            $$('#notFoundRow').invoke('hide');
        }
    
    </script>

    <input id="txtSearch" type="text" />
    <asp:DropDownList ID="ddlCat" runat="server" >
    </asp:DropDownList>
    <input id="btnFilterReset" type="button" value="Сброс" onclick="resetFilter()"/>
    <br />
    <br />
    <asp:GridView ID="gvItems" runat="server" OnRowDataBound="gvItems_RowDataBound"
        AutoGenerateColumns="false" >
         <Columns>
            <asp:BoundField DataField="Name" HeaderText="Наименование" />
            <asp:TemplateField HeaderText="Цена">
                <ItemTemplate>
                    <%# ((Item)Container.DataItem).GetPrice(PriceType.Price1).ToString("C") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Rest" HeaderText="Остаток" />
            <asp:TemplateField HeaderText="Заказ">
                <ItemTemplate>
					<asp:TextBox id="txtOrder" runat="server" CssClass="input"></asp:TextBox> 
                    <asp:HiddenField ID="hfItemId" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Manufacter" HeaderText="Производитель" />
            <asp:BoundField DataField="Pack" HeaderText="Упаковка" />
            <asp:BoundField DataField="Date" HeaderText="Срок годности" />
            
        </Columns>   
    </asp:GridView>
    <asp:Button ID="btnSubmit" runat="server" Text="Сформировать заказ" OnClick="btnSubmit_Click" />
</asp:Content>
