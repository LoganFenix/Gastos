$(".AgregarTipo").hide("fast");
$('#AgregarTi').on('click', function () {

    $(".AgregarTipo").show("slow");
});


$("#GuardTipo").on('click', function () {

 
    var Tipo = $('#NombreTipo').val();

    if (Tipo == '' || Tipo == null) {

        alert("Capture un tipo")
        $('#NombreTipo').focus();

        return false;

    }

    else {


        $.ajax({
            
          
            url: '/Productos/GuardarTipo',
          
            data: {
                NombreTipo: Tipo,


            },
            type: "post",
            cache: false,

            success: function (retorno) {

                $('#NombreTipo').val('');
                $("#Lista_Tiposgastos_Parcial").html(retorno);

            },
            error: function () {
                $('#commonMessage').html("¡Error! Favor de reportalo...");
                $('#commonMessage').delay(400).slideDown(400).delay(3000).slideUp(400);
            }
        });
    }
});

