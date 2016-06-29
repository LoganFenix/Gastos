$('#btnSalvar').click(function () {

    var error = 0;

    $(':input[data-val-required]', '#ProductosForm').each(function () {

        if (!$(this).is('input:checkbox')) { //No quiero validar los checkbox, ya que su valor sera 1 o 0 y nunca nulo

            $(this).valid();

            if ($(this).val() == '') {
                if (error == 0) {

                    var tab = $(this).closest('.tab-pane').attr('id');

                    $('#MyTabs a[href="#' + tab + '"]').tab('show');

                    $(this).focus();
                }
                error = 1;
            }
        }
    });

    if (error == 1) {
        return false;
    } else {
        $("#ProductosForm").submit();
    }

});


