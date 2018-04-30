(function () {
   var app = angular.module("historyForm", [], function () {
   });

   app.controller('HistoryController', ['$q', '$http', '$filter', '$window', function ($q, $http, $filter, $window) {

      var vm = this;
      vm.currentUser = "";
      vm.recordsList = [];
      vm.recordsListFile = [];
      vm.Idseguimiento = "";
      vm.IdseguimientoOperador = "";
      vm.msgError = "";

      vm.regexCURP = /^([A-Z]{4})([0-9]{6})([A-Z]{6})([0-9]{2})$/;

      vm.bufferRecordsListFile = [];
      vm.IdPeticion = "";
      vm.IdOperador = "";
      vm.UserName = "";
      vm.IdRol = "";
      vm.IdEstatusInterno = "";
      vm.enabledButton = false;
      vm.enabledButtonFile = false;
      vm.resetError = function () {
         vm.msgError = "";
      }


      $http.get('../BandejaDepeticiones/DatosPeticionJson/').then(function (response) {
         vm.IdPeticion = response.data[0].IdPeticion;
         vm.IdOperador = response.data[0].IdOperador;
         vm.UserName = response.data[0].UserName;
         vm.IdRol = response.data[0].IdRol;
         vm.IdEstatusInterno = response.data[0].IdEstatusInterno;
         vm.AsigPeticion = response.data[0].AsigPeticion;

         vm.record = {
            historyIdPeticion: '',
            historyUser: '',
            historyDescription: '',
            historyUserName: vm.UserName,
            historyIdSeguimientoOperador: '',
            historyIdRol: vm.IdRol,
         };


         var auxdata = {
            IdPeticion: vm.IdPeticion,
            IdUsuario: vm.IdOperador
         };

         var auxdata1 = {
            IdPeticion: vm.IdPeticion
         };

         $http.post('../BandejaDepeticiones/ListaSeguimiento/', auxdata).then(function (response) {
            vm.recordsList = response.data;
         }, function (response) {
            vm.msgError = response.data;
         });

         $http.post('../BandejaDepeticiones/Obtener_Adjuntos/', auxdata1).then(function (response) {
            vm.recordsListFile = response.data;
         }, function (response) {
            vm.msgError = response.data;
         });


      });
      ////////////////////////////////
      vm.Seguimiento = function() {
         // Definimos los caracteres que queremos eliminar
         //var specialChars = "!@#$^&%*()+=-[]\/{}|:<>?,.";

         //// Los eliminamos todos
         //for (var i = 0; i < specialChars.length; i++) {
         //   cadena = cadena.replace(new RegExp("\\" + specialChars[i], 'gi'), '');
         //}

         // Lo queremos devolver limpio en minusculas
         cadena = cadena.toUpperCase();

         // Quitamos espacios y los sustituimos por _ porque nos gusta mas asi
         //cadena = cadena.replace(/ /g, "_");

         // Quitamos acentos y "ñ". Fijate en que va sin comillas el primer parametro
         cadena = cadena.replace(/á/gi, "a");
         cadena = cadena.replace(/é/gi, "e");
         cadena = cadena.replace(/í/gi, "i");
         cadena = cadena.replace(/ó/gi, "o");
         cadena = cadena.replace(/ú/gi, "u");
         cadena = cadena.replace(/ñ/gi, "n");
          
      }
      ///////

      vm.ActualizarTabla = function () {
         $http.post('../BandejaDepeticiones/Obtener_Adjuntos/', auxdata1).then(function (response) {
            vm.recordsListFile = response.data;
         }, function (response) {
            vm.msgError = response.data;
         });
      }

      vm.seekForClick = function () {
         var iterations = 0;
         angular.forEach(vm.recordsList, function (selectedseek) {

            if (selectedseek.selected) {
               vm.enabledButton = true;
            } else {
               iterations = iterations + 1;
            }
         });

         if (vm.recordsList.length == iterations) {
            vm.enabledButton = false;
         }
      };

      vm.seekForClickfile = function () {
         var iterations = 0;
         angular.forEach(vm.recordsListFile, function (selectedseekfile) {

            if (selectedseekfile.selectedfile) {
               vm.enabledButtonFile = true;
            } else {
               iterations = iterations + 1;
            }
         });

         if (vm.recordsListFile.length == iterations) {
            vm.enabledButtonFile = false;
         }
      };

      vm.addNew = function () {

         if (vm.record.historyDescription != '') {
            document.getElementById("ValDesr").hidden = true;
            var auxdata = {
               IdSeguimientoOperador: vm.record.historyIdSeguimientoOperador,
               IdOperador: vm.IdOperador,
               IdPeticion: vm.IdPeticion,
               Comentarios: vm.record.historyDescription
            };

            $http.post('../BandejaDepeticiones/InsertarSeguimientoOperador/', auxdata).then(function (response) {

               var auxdata2 = {
                  IdPeticion: vm.IdPeticion,
                  IdUsuario: vm.IdOperador
               };

               $http.post('../BandejaDepeticiones/ListaSeguimiento/', auxdata2).then(function (response) {
                  debugger;
                  vm.recordsList = response.data;
               }, function (response) {
                  vm.msgError = response.data;
               });

            }, function (response) {
               vm.msgError = response.data;
            });

            vm.record.historyDescription = '';
         }
         else {
            document.getElementById("ValDesr").hidden = false;
            vm.msgError = "Falta agregar Seguimiento";
         }
      };

      vm.removeRecords = function () {
         vm.enabledButton = false;
         var bufferRecordList = [];
         var removeRecordList = [];

         var Indata = {removeRecordList:removeRecordList, IdOperador : vm.IdOperador }
         angular.forEach(vm.recordsList, function (selected) {
            if (!selected.selected) {
               bufferRecordList.push(selected);
            } else {
               removeRecordList.push(selected);
            }
         });

         debugger;
         $http.post('../BandejaDepeticiones/Eliminar_SeguimientoOperador', Indata).then(function (response) {
            vm.recordsList = bufferRecordList;
         }, function (response) {
            vm.msgError = response.data;
         });

      };

      vm.removeRecordsFile = function () {
         vm.enabledButtonFile = false;
         var bufferRecordListFile = [];
         var removeRecordListFile = [];

         angular.forEach(vm.recordsListFile, function (selected) {
            if (!selected.selectedfile) {
               bufferRecordListFile.push(selected);
            } else {
               removeRecordListFile.push(selected);
            }
         });

         $http.post('../BandejaDepeticiones/Eliminar_Adjuntos', removeRecordListFile).then(function (response) {
            vm.recordsListFile = bufferRecordListFile;
         }, function (response) {
            vm.msgError = response.data;
         });

      };

      vm.closeRequest = function () {
         var auxdata3 = {
            IdPeticion: vm.IdPeticion,
            IdUsuario: vm.IdOperador
         };
                  $.ajaxSetup({
                  global: false,
                  type: "GET",
                  url: "http://www.telize.com/jsonip",
                  beforeSend: function () {
                      $(".modal").show();
                  },
                  complete: function () {
                      $(".modal").hide();
                  }
              });
              $.ajax({
                  data: "{}",
                  success: function (r) {
                      $("#lblSeguimiento").html("Listo ");
                  }
              });

         $http.post('../BandejaDepeticiones/ConcluirPeticion', auxdata3).then(function (response) {
            //$window.alert("La petición ha sido concluida");
            $('#modalConcluirPeticion').modal('toggle');
            $window.location = "../BandejaDepeticiones/bandejaindex/";
         }, function (response) {
            vm.msgError = response.data;
            //$window.alert("Ha ocurrido un error." + response.data);
         });



      };
   }]);
})();