<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewOrder.aspx.cs" Inherits="EZakaz.Web.UI.NewOrder" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	
	<script type="text/javascript" >
	
	    function sitePopup(categoryId){
			var vWinUsers = window.open('Items.aspx?category=' + categoryId, 'popup', 'location=no,status=yes,resizable=yes,scrollbars=yes,width=640, height=545');
			vWinUsers.opener = self;
			vWinUsers.focus();
			window.onunload = function() {
				if (!vWinUsers.closed)
					vWinUsers.close();
			}	
		}	
			
			
        function addRowToTable(name, count){
            if (count == "")
                return;
              var tbl = document.getElementById('orderTable');
              var lastRow = tbl.rows.length;
              // if there's no header row in the table, then iteration = lastRow + 1
              var iteration = lastRow;
              var row = tbl.insertRow(lastRow);
              
              // left cell
              var cellLeft = row.insertCell(0);
              var textNode = document.createTextNode(name);
              cellLeft.appendChild(textNode);
              
              // right cell
              var cellRight = row.insertCell(1);
              var el = document.createElement('input');
              el.value = count;
              el.type = 'text';
              el.name = 'txtRow' + iteration;
              el.id = 'txtRow' + iteration;
              el.size = 40;
              
              cellRight.appendChild(el);
            }

		
</script>
	
	<asp:Table ID="Table1" runat="server">
	</asp:Table>
	
    <table id='orderTable'>

    </table>
    <input id="Button1" type="button" value="button" onclick="addRowToTable('cola', 10)"/>
</asp:Content>
