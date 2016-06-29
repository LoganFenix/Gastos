
//Oculta el gif
$('#loading').hide();

// Agregar un nuevo tipo de gasto
$('#btnNuevo').click(function (evt)
{
   
    $('#modal-cont').load('/TipoGastos/Agregar');
});


// Muestra los mensajes de toastr
$('#Mensaje').click(function (evt) {
    $('#Mensaje').prop('disabled', true);
    delayToasts();
});

//Busquedas de datos con ajax

$('#Buscar').click(function (evt) {
    var campoabuscar = $('#SearchString').val();

    $('#loading').show();
    $.ajax({
        url: '/TipoGastos/Buscar',
        data: {
            SearchString:campoabuscar
            
        },
        type: "post",
        cache: false,

        success: function (retorno) {
            $('#loading').hide();
            $("#Lista_Tiposgastos_Parcial").html(retorno);
        },
        error: function () {
            $('#loading').hide();
        }
    });
});

//Activa el autocompeltado

$('#SearchString').autocomplete({
    source: '/TipoGastos/Autocompletado'
});















