
$(document).ready(function () {
    $('#startDate').datepicker(
        {
            maxDate: 0
        }
        );
    $('#endDate').datepicker(
        {
            maxDate: 0
        }
        );
    $('#txtDate').datepicker(
        {
            minDate: 0
        }
        );
    $("#datepickerStart").datepicker({
        maxDate: 0,
        onSelect: function (date) {
            var dt2 = $('#datepickerEnd');
            var dt1 = $("#datepickerStart");
            if (dt2.datepicker('getDate') <= dt1.datepicker('getDate')) {
                var startDate = $(this).datepicker('getDate');
                var minDate = $(this).datepicker('getDate');

                
                dt2.datepicker('option', 'maxDate', 0);
                dt2.datepicker('option', 'minDate', minDate);
                dt2.datepicker('setDate', minDate);
                startDate.setDate(startDate.getDate() + 30);
            }
            else {
                var startDate = $(this).datepicker('getDate');
                var minDate = $(this).datepicker('getDate');
                dt2.datepicker('option', 'maxDate', 0);
                dt2.datepicker('option', 'minDate', minDate);
            }

        }
    });

    $("#startDateFechaRegistro").datepicker({
        maxDate: 0,
        onSelect: function (date) {
            var dt2 = $('#startDateFechaRegistroFin');
            var dt1 = $("#startDateFechaRegistro");
            if (dt2.datepicker('getDate') <= dt1.datepicker('getDate')) {
                var startDate = $(this).datepicker('getDate');
                var minDate = $(this).datepicker('getDate');

                //sets dt2 maxDate to the last day of 30 days window
                dt2.datepicker('option', 'maxDate', 0);
                dt2.datepicker('option', 'minDate', minDate);
                dt2.datepicker('setDate', minDate);
                startDate.setDate(startDate.getDate() + 30);
            }
            else {
                var startDate = $(this).datepicker('getDate');
                var minDate = $(this).datepicker('getDate');
                dt2.datepicker('option', 'maxDate', 0);
                dt2.datepicker('option', 'minDate', minDate);
            }
        }
    });

    $("#startDateFechaRegistroFin").datepicker({
        maxDate: 0
    });

    $("#datepickerSpan1").click(function () {
        $("#datepickerStart").datepicker("show");
    });
    $("#datepickerEnd").datepicker({
        maxDate: 0
    });
    $("#datepickerSpan2").click(function () {
        $("#datepickerEnd").datepicker("show");
    });
    $("#datepickerSpanFechaHechos").click(function () {
        $("#startDate").datepicker("show");
    });
    $("#datepickerSpan4").click(function () {
        $("#txtDate").datepicker("show");
    });
    $("#datepickerSpanFechaRegistro").click(function () {
        $("#startDateFechaRegistro").datepicker("show");
    });
    $("#datepickerSpanFechaRegistroFin").click(function () {
        $("#startDateFechaRegistroFin").datepicker("show");
    });
});

$(document).ready(function () {
    $.datepicker.regional['es'] = {
        closeText: 'Cerrar',
        prevText: '< Ant',
        nextText: 'Sig >',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'S\u00E1bado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'S\u00E1b'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S\u00E1'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['es']);

    $('#startDate').datepicker();
    $('#endDate').datepicker();
});