(function () {
    var app = angular.module("bitacoraForm", ['angularUtils.directives.dirPagination']);

    app.directive('inputUsuario', [function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attr, ngModelCtrl) {

                var pattern = /[^a-zA-Z ñÑ0-9\-\_]*/g;

                function fromUser(text) {

                    if (!text) {
                        return text;
                    }

                    var transformedInput = text.replace(pattern, '').toUpperCase();
                    if (transformedInput !== text) {
                        ngModelCtrl.$setViewValue(transformedInput);
                        ngModelCtrl.$render();
                    }
                    return transformedInput;
                }
                ngModelCtrl.$parsers.push(fromUser);
            }
        };
    }]);

    app.directive('inputFolio', [function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attr, ngModelCtrl) {

                var pattern = /[^a-zA-Z ñÑ0-9//]*/g;

                function fromUser(text) {

                    if (!text) {
                        return text;
                    }

                    var transformedInput = text.replace(pattern, '').toUpperCase();
                    if (transformedInput !== text) {
                        ngModelCtrl.$setViewValue(transformedInput);
                        ngModelCtrl.$render();
                    }
                    return transformedInput;
                }
                ngModelCtrl.$parsers.push(fromUser);
            }
        };
    }]);

    app.controller('bitacoraController', ['$q', '$http', function ($q, $http) {

       var vm = this;
        
        vm.bitacoraTable = [];
        vm.msgError = "";
        vm.resetError = function () {
           vm.msgError = "";
        };
        vm.noDatos = "";
        vm.resetnoDatos = function () {
           vm.noDatos = "";
        };
        
        vm.limpia = function () {
           debugger;
           vm.usuarioSearch = "";
           vm.startDateSearch = "";
           vm.endDateSearch = "";
           vm.folioSearch = "";
        }
         
        vm.setSameValue = function () {
           if (vm.endDateSearch == "" || vm.endDateSearch == undefined)
           {
              vm.endDateSearch = vm.startDateSearch;
           }
           if(vm.endDateSearch < vm.startDateSearch)
           {
              vm.endDateSearch = vm.startDateSearch;
           }
        };

        vm.getBitacoraDetails = function (form) {
            var dataRequest = {
                pUsuario: vm.usuarioSearch == undefined ? "" : vm.usuarioSearch,
                pFechaInicio: vm.startDateSearch == undefined ? "" : vm.startDateSearch,
                pFechaFinal: form.endDateTxt == undefined ? "" : vm.endDateSearch,
                pFolio: vm.folioSearch == undefined ? "" : vm.folioSearch
            };
               
               if ((vm.usuarioSearch == "" || vm.usuarioSearch == undefined) && (vm.startDateSearch == "" || vm.startDateSearch == undefined) && (vm.folioSearch == "" || vm.folioSearch == undefined) && (vm.endDateSearch == "" || vm.endDateSearch == undefined)) {
               
               vm.msgError = "Por favor ingrese al menos un campo.";
                //alert("Debes mencionar al menos un criterio de busqueda");
            } else {
                  $http.post('../Bitacora/GetBitacoraDetail', dataRequest).then(function (response) {
                     vm.msgError = "";
                     debugger;
                     vm.bitacoraTable = response.data;
                     if(vm.bitacoraTable.length == 0)
                     {
                        vm.noDatos = "No se encontro información.";
                     }
                     else {
                        vm.noDatos = "";
                     }
                }, function (response) {
                   vm.msgError = "No se pudo recopilar la información.";
                })
            }
        };

       
    }]);
})();

