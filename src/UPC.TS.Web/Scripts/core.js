﻿
$(document).ready(function () {
    $("input[tmp='telefono']").inputmask("9-9999-99");
    $("input[tmp='celular']").inputmask("9999-99999");

    $('body').tooltip({
        title: function () {
            if ($(this).find("i.fa-search-plus").length) return "Ver";
            if ($(this).find("i.fa-search").length) return "Ver";
            if ($(this).find("i.fa-pencil").length) return "Editar";
            if ($(this).find("i.fa-trash-o").length) return "Eliminar";
            if ($(this).find("i.fa-folder-open").length) return "Abrir";
            if ($(this).find("i.fa-paperclip").length) return "Descargar";
            if ($(this).find("i.fa-upload").length) return "Adjuntar";
            return false;
        },
        placement: 'left',
        selector: 'a:has(i.fa-search-plus), a:has(i.fa-search), a:has(i.fa-pencil), a:has(i.fa-trash-o), a:has(i.fa-folder-open), a:has(i.fa-paperclip),a:has(i.fa-cog), a:has(i.fa-upload)'
    });

});



function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

function validarLetras(e) { // 1
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true; // backspace
    if (tecla == 32) return true; // espacio
    if (e.ctrlKey && tecla == 86) { return true; } //Ctrl v
    if (e.ctrlKey && tecla == 67) { return true; } //Ctrl c
    if (e.ctrlKey && tecla == 88) { return true; } //Ctrl x

    patron = /[a-zA-Z]/; //patron

    te = String.fromCharCode(tecla);
    return patron.test(te); // prueba de patron
}


function errorAjax() {
    alert("Se producjo un error inesperado mantengase en contacto con el administrador del Sistema");
}

function TrimString(x) {
    return x.replace(/^\s+|\s+$/gm, '');
}


$('.upctbgrid').DataTable({
    "sDom": '<"top">rt<"bottom"ip><"clear">',
    "language": {
        "sProcessing": "Procesando...",
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "Ningún dato disponible en esta tabla",
        "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
        "sInfoPostFix": "",
        "sSearch": "Buscar:",
        "sUrl": "",
        "sInfoThousands": ",",
        "sLoadingRecords": "Cargando...",
        "oPaginate": {
            "sFirst": "Primero",
            "sLast": "Último",
            "sNext": "Siguiente",
            "sPrevious": "Anterior"
        },
        "oAria": {
            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
        }
    }                                              
});

$.fn.datepicker.defaults.language = "es";
$.fn.datepicker.defaults.format = "dd/mm/yyyy";
$.fn.datepicker.defaults.autoclose =  true;


function showNotifyByData(data) {
    //var stack_bar_top = { "dir1": "down", "dir2": "right", "push": "top", "spacing1": 0, "spacing2": 0 };
    alert(data.Message);
    //new PNotify({
    //    title: data.Title,
    //    text: data.Message,
    //    type: data.TypeResponse 
    //});
}

function showNotify(title, message, typeMessage) {
    alert(message);
    //var stack_bar_top = { "dir1": "down", "dir2": "right", "push": "top", "spacing1": 0, "spacing2": 0 };
    //new PNotify({
    //    title: title,
    //    text: message,
    //    type: typeMessage
    //});
}

/*Extensiones*/
$.fn.updateValidation = function () {
    var form = this.closest("form").removeData("validator").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse(form);
    return this;
};

$.fn.cleanValidation = function () {
    $(this).find(".field-validation-error").each(function () {
        $(this).removeClass("field-validation-error").addClass("field-validation-valid");
    });
    $(this).find(".input-validation-error").each(function () {
        $(this).removeClass("input-validation-error").addClass("valid");
    });
    $(this).find(".validation-summary-errors").each(function () {
        $(this).find("ul").empty();
        $(this).removeClass("validation-summary-errors").addClass("validation-summary-valid");
    });
    $(this).updateValidation();
};

//$.validator.methods.number = function (value, element) {
//    //return !isNaN($.parseFloat(value));
//    return this.optional(element) || /^-?(?:d+|d{1,3}(?:[s.,]d{3})+)(?:[.,]d+)?$/.test(value);
//}


$.validator.addMethod('greaterThanNow', function (value, element, params) {
    if (!/Invalid|NaN/.test(new Date(value.replace(/(\d{2})\/(\d{2})\/(\d{4})/, "$2/$1/$3")))) {
        var today = new Date(); var tomorrow = new Date(today); tomorrow.setDate(today.getDate() - 1);
        return new Date(value.replace(/(\d{2})\/(\d{2})\/(\d{4})/, "$2/$1/$3")) > tomorrow;
    }
    return false;
}, '');

// and an unobtrusive adapter
$.validator.unobtrusive.adapters.add('futuredate', {}, function (options) {
    options.rules['greaterThanNow'] = true;
    options.messages['greaterThanNow'] = options.message;
});

jQuery.validator.addMethod("greaterthan", function (value, element, param) {
    return Date.parse(value.replace(/(\d{2})\/(\d{2})\/(\d{4})/, "$2/$1/$3")) > Date.parse($(param).val().replace(/(\d{2})\/(\d{2})\/(\d{4})/, "$2/$1/$3"));
});


jQuery.validator.unobtrusive.adapters.add("greaterthan", ["otherfield"], function (options) {
    options.rules["greaterthan"] = "#" + options.params.otherfield;
    options.messages["greaterthan"] = options.message;
});

