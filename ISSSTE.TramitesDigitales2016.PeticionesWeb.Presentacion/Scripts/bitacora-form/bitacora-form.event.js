//$().ready(function () {
//   $("#startDateTxt").datepicker({
//      maxDate: 0,
//      onSelect: function (date) {
//         debugger;
//         var dt2 = $('#endDateTxt');
//         var dt1 = $("#startDateTxt");
//         var date1 = String(dt1["0"].value);
//         var date2 = String(dt2["0"].value);
         
//         if (date2 <= date1) {
//            var startDate = $(this).datepicker('getDate');
//            var minDate = $(this).datepicker('getDate');
//            dt2.datepicker('option', 'maxDate', 0);
//            dt2.datepicker('option', 'minDate', minDate);
//            dt2.datepicker('setDate', minDate);
//            startDate.setDate(startDate.getDate() + 30);

//            dt2.datepicker('option', 'maxDate', 0);
//            dt2.datepicker('option', 'minDate', minDate);
//            dt1.val(date1);
//            dt2.val(date2);
//         }
//         else {
//            var startDate = $(this).datepicker('getDate');
//            var minDate = $(this).datepicker('getDate');
//            dt2.datepicker('option', 'maxDate', 0);
//            dt2.datepicker('option', 'minDate', minDate);
//            dt1.val(date1);
//            dt2.val(date2);
//         }
//      }
//   });

//   $("#endDateTxt").datepicker({
//      maxDate: 0,
//   });
//   $("#endDateSpan").click(function () {
//      $("#endDateTxt").datepicker("show");
//   });
//   $("#startDateSpan").click(function () {
//      $("#startDateTxt").datepicker("show");
//   });
//});



$().ready(function () {

   $("#startDateTxt").datepicker({ changeYear: true, maxDate: 0 });
   $("#endDateTxt").datepicker({ changeYear: true, maxDate: 0 });

   $("#endDateSpan").click(function () {
      $("#endDateTxt").datepicker("show");
   });

   $("#startDateSpan").click(function () {
      $("#startDateTxt").datepicker("show");
   });

   $("#startDateTxt").change(function(){
      var initialDate = $("#startDateTxt").datepicker("getDate");
      $("#endDateTxt").datepicker("option", "minDate", initialDate);

   });

});

