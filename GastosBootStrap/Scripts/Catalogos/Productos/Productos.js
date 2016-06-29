$('#btnNuevo').click(function (evt) {
    $('#modal-cont').load('/Productos/Agregar');
});

$(".btnEditar").on('click', function (evt) {
    $('#modal-cont').load('/Productos/Editar/' + $(this).data("id"));
});

$(".btnEliminar").on('click', function (evt) {
    $('#modal-cont').load('/Productos/Eliminar/' + $(this).data("id"));
});


$(".btnVistaPrevia").click(function (evt) {

    $("#modal-cont").load("/Productos/VistaPrevia/" + $(this).data("id"));

});




