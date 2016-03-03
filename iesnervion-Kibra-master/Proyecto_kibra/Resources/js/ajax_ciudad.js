function cambiarCiudades() {
    var transpor;
    if (window.XMLHttpRequest) {
        transpor = new XMLHttpRequest();
    }
    else {
        transpor = new ActiveXObject("Microsoft.XMLHTTP");
    }

    var cmbCiudades = document.getElementById("cmbCiudades").innerHTML = "";


    var idprovincia = document.getElementById("cmbProvincias").value;

    transpor.open("POST", "listaCiudades", true);
    transpor.setRequestHeader("Content-type", "application/x-www-form-urlencoded");


    transpor.onreadystatechange = function () {
        if (transpor < 4) {
            //cargando
        }
        else if (transpor.readyState == 4 && transpor.status == 200) {

            cargarCiudades(transpor.responseXML);

        }

    };

    transpor.send("idprov=" + idprovincia);
}

function cargarCiudades(datos) {
    var cmbCiudades = document.getElementById("cmbCiudades");
    cmbCiudades.disabled = false;
    var elementos = datos.getElementsByTagName("ciudad");
    
    for (var i = 0; i < elementos.length; i++) {
        var opt = document.createElement("option");
        opt.value = elementos[i].getAttribute("id");
        opt.text = elementos[i].innerHTML;


        cmbCiudades.appendChild(opt);
        // alert(elementos[i].innerHTML);
    }


}