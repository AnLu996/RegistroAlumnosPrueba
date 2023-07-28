function limpiar_contenido() {
    var vacio = "";
    document.getElementById("name").value = vacio;
    document.getElementById("lastname").value = vacio;
    document.getElementById("sexM").checked = false;
    document.getElementById("sexF").checked = false;
    document.getElementById("mail").value = vacio;
    document.getElementById("adress").value = vacio;
    document.getElementById("city").value = "Elija una ciudad"; //no usar value
    document.getElementById("req").value = vacio;
    return false;
}

function validar_contenido() {
    var vacio = "";
    var caracteres = /^[a-zA-Z\s]+$/;
    var FechaActual = new Date().toLocaleDateString();

    if (document.getElementById("name").value === vacio) {
        alert('Es necesario ingresar un nombre.');
        return false;
    }
    if (!caracteres.test(document.getElementById("name").value)) {
        alert('El campo no es válido. Ingrese solo letras.');
        return false;
    }
    if (document.getElementById("lastname").value === vacio) {
        alert('Es necesario ingresar un apellido.');
        return false;
    }
    if (!caracteres.test(document.getElementById("lastname").value)) {
        alert('El campo no es válido. Ingrese solo letras.');
        return false;
    }
    if (!(document.getElementById("sexM").checked || document.getElementById("sexF").checked)) {
        alert('Es necesario seleccionar un sexo.');
        return false;
    }
    if (document.getElementById("mail").value === vacio || !document.getElementById("mail").value.endsWith("@unsa.edu.pe")) {
        alert('Es necesario ingresar un correo electrónico con el dominio @unsa.edu.pe');
        return false;
    }

    if (document.getElementById("city").value === "Elija una ciudad") {
        alert('Es necesario seleccionar una ciudad.');
        return false;
    }

    alert('Registro exitoso.\n' + FechaActual);
    return true;
}