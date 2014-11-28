        function focusNext(form, elemName, evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : 
                ((evt.which) ? evt.which : evt.keyCode);
            if (charCode == 13 || charCode == 3) {
                // find 1st visible element
                //if (form.elements[elemName].style.display == 'none') {
                    elemName = findNextInput(elemName);                
                //} 
                form.elements[elemName].focus( );
                return false;
            }
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
        
        function findNextInput(elemName) {
            var table = $('#<%= gvItems.ClientID %>')[0];
            var elemNameFound = false;
            for (i = 1; i < table.rows.length; i++){
                if (!elemNameFound) {
                    var inputs = table.rows[i].getElementsByTagName('input');
                    var input = inputs[0];
                    var inputId = input.id;
                    elemNameFound = (inputId == elemName);
                    if (elemNameFound) continue;
                }
                
                if (elemNameFound && table.rows[i].style.display != 'none') {
                    return table.rows[i].getElementsByTagName('input')[0].id;
                }
                
            }
            return elemName;
        }
