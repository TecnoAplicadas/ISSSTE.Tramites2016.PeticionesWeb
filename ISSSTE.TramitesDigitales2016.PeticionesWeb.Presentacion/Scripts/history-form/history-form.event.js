window.onload = function () {
    document.getElementById('uploader').onsubmit = function () {
        var formdata = new FormData(); //FormData object
        var fileInput = document.getElementById('fileInput');
        //Iterating through each files selected in fileInput
        for (i = 0; i < fileInput.files.length; i++) {
            formdata.append(fileInput.files[i].name, fileInput.files[i]);
            //Appending each file to FormData object
        }
        //Creating an XMLHttpRequest and sending
        document.getElementById('btnFile').disabled = true;
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '../BandejaDepeticiones/Upload');
        xhr.send(formdata);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                location.reload();
            }
            else {

            }
        }
        return false;
    };

    function comprueba_extension(archivo) {
        extensiones_permitidas = new Array(".jpeg", ".xls", ".xlsx", ".jpg", ".png", ".doc", ".docx", ".pdf", ".ppt", ".txt");
        if (!archivo) {
            return false;
        } else {
            //recupero la extensión de este nombre de archivo
            extension = (archivo.substring(archivo.lastIndexOf("."))).toLowerCase();
            //compruebo si la extensión está entre las permitidas
            permitida = false;
            for (var i = 0; i < extensiones_permitidas.length; i++) {
                if (extensiones_permitidas[i] == extension) {
                    permitida = true;
                    break;
                }
            }
            if (!permitida) {
                return false;
            } else {
                return true;
            }
        }
        return false;
    };
}
function CambiaArchivo() {

    if (document.getElementById('fileInput').value == "" || document.getElementById('fileInput').value == undefined || document.getElementById('fileInput').value == null) {
        document.getElementById('btnFile').disabled = true;
        document.getElementById("ValArchivoExt").hidden = true;
        document.getElementById("ValArchivoTam").hidden = true;
    }
    else {
        document.getElementById('btnFile').disabled = false;
        document.getElementById("ValArchivoExt").hidden = true;
        document.getElementById("ValArchivoTam").hidden = true;
        debugger;
        var fileInput = document.getElementById('fileInput');
        //Iterating through each files selected in fileInput
        for (i = 0; i < fileInput.files.length; i++) {
            var msg = '';
            var extensionValida = true;
            var tamanioValido = true;

            var extensionValida = comprueba_extension(fileInput.files[i].name);
            if (fileInput.files[i].size > 20000000) {
                tamanioValido = false;
            }
            if (!extensionValida) {
                document.getElementById("ValArchivoExt").hidden = false;
                document.getElementById('btnFile').disabled = true;
                return false;
            }
            else {
                document.getElementById("ValArchivoExt").hidden = true;
            }

            if (!tamanioValido) {
                document.getElementById("ValArchivoTam").hidden = false;
                document.getElementById('btnFile').disabled = true;
                return false;
            }
            else {
                document.getElementById("ValArchivoTam").hidden = true;
            }

            if (!extensionValida || !tamanioValido) {
                return false;
            }
        }
    }
    function comprueba_extension(archivo) {
        extensiones_permitidas = new Array(".jpeg", ".xls", ".xlsx", ".jpg", ".png", ".doc", ".docx", ".pdf", ".ppt", ".txt");
        if (!archivo) {
            return false;
        } else {
            //recupero la extensión de este nombre de archivo
            extension = (archivo.substring(archivo.lastIndexOf("."))).toLowerCase();
            //compruebo si la extensión está entre las permitidas
            permitida = false;
            for (var i = 0; i < extensiones_permitidas.length; i++) {
                if (extensiones_permitidas[i] == extension) {
                    permitida = true;
                    break;
                }
            }
            if (!permitida) {
                return false;
            } else {
                return true;
            }
        }
        return false;
    };
};

$('#descrTxt').on('input', function (evt) {
    $(this).val(function (_, val) {

        val = val.toUpperCase();
        val = val.replace(/[ÁÄÀÂ]/gi, "A");
        val = val.replace(/[ÉËÈÊ]/gi, "E");
        val = val.replace(/[ÍÏÌÎ]/gi, "I");
        val = val.replace(/[ÓÖÒÔ]/gi, "O");
        val = val.replace(/[ÚÜÙÛ]/gi, "U");
        val = val.replace(/¨/gi, "");
        val = val.replace(/'/gi, "");
        val = val.replace(/´/gi, "");
        val = val.replace(/`/gi, "");
        val = val.replace(/^/gi, "");

        return val;
    });
});