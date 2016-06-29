function Toast(type, css, msg) {
    this.type = type;
    this.css = css;
    this.msg = 'Registro Guardado Correctamente';
}

var toasts = [

    new Toast('success', 'toast-top-right', '')
];

toastr.options.positionClass = 'toast-top-full-width';
toastr.options.extendedTimeOut = 0; //1000;
toastr.options.timeOut = 10000;
toastr.options.fadeOut = 250;
toastr.options.fadeIn = 250;
toastr.options.progressBar = true;

var i = 0;


function delayToasts() {
    if (i === toasts.length) { return; }
    var delay = i === 0 ? 0 : 2100;
    window.setTimeout(function () { showToast(); }, delay);

    // re-enable the button        
    if (i === toasts.length - 1) {
        window.setTimeout(function () {
            $('#Mensaje').prop('disabled', false);
            i = 0;
        }, delay + 1000);
    }
}

function showToast() {
    var t = toasts[i];
    toastr.options.positionClass = t.css;
    toastr[t.type](t.msg);
    i++;
    delayToasts();
}

