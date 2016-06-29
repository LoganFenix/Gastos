$(".btnEditar").on('click', function (evt) {
    $('#modal-cont').load('/TipoGastos/Editar/' + $(this).data("id"));
});

$(".btnEliminar").on('click', function (evt) {
    $('#modal-cont').load('/TipoGastos/Eliminar/' + $(this).data("id"));
});