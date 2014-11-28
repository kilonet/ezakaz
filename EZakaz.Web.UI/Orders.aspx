<%@ Page Language="C#" MasterPageFile="~/Interchange.Master" AutoEventWireup="true" Codebehind="Orders.aspx.cs"
    Inherits="EZakaz.Web.UI.Orders" Title="Untitled Page" %>

<%@ Import Namespace="EZakaz.Server.Core" %>
<%@ Import Namespace="EZakaz.Domain" %>
<%@ Register Assembly="JAGregory.Controls.DeleGrid" Namespace="JAGregory.Controls"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph1" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            $(".zebra tr:even").addClass("alt");
            $('#<%=gvOrders.ClientID %> >tbody >tr >th:last >input:checkbox').click(selectAll);
            $('#<%=gvOrders.ClientID %> >tbody >tr >td >input:checkbox').click(checkSelectAll);
        })
        
        function selectAll(e) {
            $('#<%=gvOrders.ClientID %> >tbody >tr >td >input:checkbox').attr('checked',this.checked);
        }
        
        function checkSelectAll(e) {
            var expr1 = '#<%=gvOrders.ClientID %> >tbody >tr >td >input:checkbox:checked';
            var expr2 = '#<%=gvOrders.ClientID %> >tbody >tr >td >input:checkbox';
                
            var selectAll = $(expr1).length == $(expr2).length;
            $('#<%=gvOrders.ClientID %> >tbody >tr >th:last >input:checkbox').attr('checked',selectAll);
        }
        function confirmDelete() {
            var agree = confirm("Удалить отмеченные заказы?");
            if (agree)
	            return true ;
            else
	            return false ;

        }
    </script>
    <cc1:DeleGrid AllowPaging="True" ID="gvOrders" runat="server" AutoGenerateColumns="False"
        OnRowDataBound="gvOrders_RowDataBound" CellPadding="4" ForeColor="#333333"
        AllowSorting="true" SortingDirection="Ascending" SortingField=""
        GridLines="Vertical" BorderColor="#D0D0BF" CssClass="zebra">
        <Columns>
        
            <asp:TemplateField HeaderText="Заказчик" SortExpression="user.Name">
                <itemtemplate>
					<%# ((Order)Container.DataItem).User.Name %>
                </itemtemplate>
            </asp:TemplateField>

            <asp:HyperLinkField HeaderText="Дата создания заказа" DataTextField="DateCreated" DataNavigateUrlFields="Id" DataTextFormatString="{0:D} {0:t}"
            DataNavigateUrlFormatString="~\EditOrder.aspx?id={0}" SortExpression="DateCreated"/>

            <asp:BoundField HeaderText="Дата отправки заказа" DataField="DateSent" DataFormatString="{0:D} {0:t}" SortExpression="DateSent"/>

            <asp:TemplateField HeaderText="Статус" SortExpression="State">
                <itemtemplate>
                    <%# StatusToString(((Order)Container.DataItem).State) %>
                </itemtemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="Comment" HeaderText="Комментарий" SortExpression="Comment"/>
            
            <asp:TemplateField HeaderText="Прочитан" SortExpression="IsRead">
                <itemtemplate>
                  <asp:CheckBox runat="server" Enabled="false" Checked="<%# ((Order)Container.DataItem).IsRead %>"></asp:CheckBox>  
                </itemtemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Сумма" >
                <ItemTemplate>
                    <%# ((Order)Container.DataItem).GetPrice().ToString("c")%>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Удалить">
                <ItemTemplate>
                    <asp:CheckBox runat="server" Id="chkSelect"></asp:CheckBox>
                    <asp:HiddenField ID="hfOrderId" runat="server"></asp:HiddenField>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        
        <FooterStyle BackColor="#E8E8E8" Font-Bold="True" />
        <PagerStyle BackColor="#E8E8E8" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#E8E8E8" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        
        
        
    </cc1:DeleGrid>
    <% if (gvOrders.Rows.Count > 0) {%>
        <asp:Button ID="btnDelete" runat="server" Text="Удалить" OnClientClick="return confirmDelete()" OnClick="btnDelete_Click"/>
    <% } %>
</asp:Content>
