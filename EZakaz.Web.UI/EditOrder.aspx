<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="EZakaz.Web.UI.EditOrder" Title="Untitled Page" EnableViewState="true"   %>
<%@ Import namespace="EZakaz.Domain"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">

<%--    <script language="javascript" type="text/javascript" src="js/jquery.alphanumeric.js"></script>
    <script language="javascript" type="text/javascript" src="js/jquery.alphanumeric.pack.js" ></script>--%>
    <script language="javascript" type="text/javascript">
        $(document).ready(function(){
            $(".zebra tr:even").addClass("alt");
        })
        function focusNext(form, elemName, evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode :
                ((evt.which) ? evt.which : evt.keyCode);
            if (charCode == 13 || charCode == 3) {
                form.elements[elemName].focus( );
                return false;
            }
            return true;
        } 
    </script>
    <asp:HyperLink ID="linkPrint" runat="server">Версия для печати</asp:HyperLink><br/>
    <asp:Panel ID="panClient" runat="server">
        Клиент:
        <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
    </asp:Panel>
    <asp:Label ID="lblOrderPrice" runat="server"></asp:Label><br />
    <asp:Label ID="lblDateCreated" runat="server"></asp:Label><br />
    <asp:Label ID="lblDateSent" runat="server"></asp:Label><br />
    <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="red" Text="Ошибка: введены некорректные значения"></asp:Label><br />
    <asp:HyperLink ID="hlZakazCsv" runat="server">Файл для экспорта в Access</asp:HyperLink>
    <br />
    <asp:Label ID="lblSuccesMessage" runat="server" Font-Bold="True" ForeColor="Blue"
        Text="Заказ успешно отправлен" Visible="False"></asp:Label>
    <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvItems_RowDataBound"  CellPadding="4" ForeColor="#333333"
        ShowFooter="true" OnRowCreated="gvItems_RowCreated"
        CssClass="zebra" GridLines="Vertical" BorderColor="#D0D0BF">
    
        <Columns>
            
            <asp:TemplateField HeaderText="Наименование">
                <ItemTemplate>
                    <%# ((OrderItem)Container.DataItem).Name %>
                    <asp:HiddenField ID="hfItemId" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Количество">
                <ItemTemplate>
                    <asp:TextBox ID="txtOrder" runat="server" CssClass="input" 
                        Text="<%# ((OrderItem)Container.DataItem).N.ToString() %>"></asp:TextBox>
                    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="N" HeaderText="Количество"/>
            
            
        </Columns>
        
        <FooterStyle BackColor="#E8E8E8" Font-Bold="True" />
        <PagerStyle BackColor="#E8E8E8" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#E8E8E8" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        
    </asp:GridView>
    Комментарий к заказу:<br />
    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Height="50px" Width="225px"></asp:TextBox>
    <asp:Label ID="lblComment" runat="server"></asp:Label><br />
    <asp:Button ID="btnSave" runat="server" Text="Сохранить" OnClick="btnSave_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Удалить" OnClick="btnDelete_Click"/>
    <asp:Button ID="btnSend" runat="server" Text="Отправить" OnClick="btnSend_Click" />
    <asp:Panel ID="panRead" runat="server" Height="50px" Width="125px" Wrap="False">
        <asp:CheckBox ID="chkRead" runat="server"
            Text="Прочитан" />
        <asp:Button ID="btnApply" runat="server" Text="Применить" OnClick="btnSave_Click" /></asp:Panel>
    
</asp:Content>
