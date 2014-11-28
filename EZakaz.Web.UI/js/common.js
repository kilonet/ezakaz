function isNumber(evt) {
	var charCode = (evt.charCode) ? evt.charCode :
									((evt.which) ? evt.which : evt.keyCode);
	if (charCode > 31 && (charCode < 48 || charCode > 57)) {
		return false;
	}
}

function EnterKeyFilter() {
    if (window.event.keyCode == 13) {
        event.returnValue = false;
        event.cancel = true;
    }
}