$("#add").click(function () {
    var gui = GetRandomGUI();
    var htm = '<div class="editorRow">';
    htm += '<div class = "row">';
    htm += '<div class="col-md-6">';
    htm += '<input type="hidden" name = "ListaImagenes.index" value = "' + gui + '"/>';
    htm += '<input type = "file" name = "ListaImagenes[' + gui + '].ImagenSubida" />';
    htm += '</div>';
    htm += '<div class="col-md-2">';
    htm += '<a href="#" class="deleteRow">Eliminar</a>';
    htm += '</div>';
    htm += '<div class="col-md-3">';
    htm += 'Es Portada <input class="radioEsPortada" type = "radio" name = "ListaImagenes[' + gui + '].EsPortada" />';
    htm += '</div>';
    htm += '</div>';
    htm += '<hr />';
    htm += '</div>';
    $('#divImagenesDTO').prepend(htm);

    return false;
});

$("#divImagenesDTO").on("change", ".radioEsPortada", function () {

    $("#divImagenesDTO .radioEsPortada").removeAttr('checked');
    $("#divImagenesDTO .radioEsPortada").val(false);

    $(this).prop('checked', true);
    $(this).val(true);
});

$("#divImagenesDTO").on("click", ".deleteRow", function () {
    var id = $(this)[0].id;
    $(this).parents("div.editorRow:first").remove();

    if (Number(id) > 0) {
        div
        var gui = GetRandomGUI();
        var htm = '<div class="editorRow">';
        htm += '<input type="hidden" name = "ListaImagenes.index" value = "' + gui + '"/>';
        htm += '<input type="hidden" name = "ListaImagenes[' + gui + '].Id" value="' + id + '"/>';
        htm += '<input type="hidden" name = "ListaImagenes[' + gui + '].ImagenEliminada" value="true"/></div>';
        $('#divImagenesDTO').append(htm);
    }

    return false;
});


function GetRandomGUI() {
    var val = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
    return val;
}