function getValue(id){
	var select = document.getElementById(id);
	return select.options[select.selectedIndex].text;
}

function contrasenaIncorrecta(mensaje) {
	alert(mensaje);
}

function getSelectedValues(id){
	var checkbox = document.getElementById(id);
	if(checkbox.checked == true){
		return parseInt(checkbox.value);
	} else {
		return -1;
	}
}

function resetOption(id){
	document.getElementById(id).value = "";
}

function enabled(id){
	document.getElementById(id).disabled = false;
}

function alerta(message){
	alert(message);
}

function setRequired(id){
	document.getElementById(id).setAttribute("required", "");
}

function jsSaveAsFile(filename, byteBase64) {
	var link = document.createElement('a');
	link.download = filename;
	link.href = "data:application/octet-stream;base64," + byteBase64;
	document.body.appendChild(link);
	link.click();
	document.body.removeChild(link);
}