(function () {
    var app = angular.module("followupForm", []);

    app.directive('inputLetras', [function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attr, ngModelCtrl) {

                var pattern = /[^a-zA-Z ñÑ]*/g;

                function fromUser(text) {

                    if (!text) {
                        return text;
                    }

                    var transformedInput = text;
                    transformedInput = transformedInput.toUpperCase();
                    transformedInput = transformedInput.replace(/[ÁÄÀÂ]/gi, "A");
                    transformedInput = transformedInput.replace(/[ÉËÈÊ]/gi, "E");
                    transformedInput = transformedInput.replace(/[ÍÏÌÎ]/gi, "I");
                    transformedInput = transformedInput.replace(/[ÓÖÒÔ]/gi, "O");
                    transformedInput = transformedInput.replace(/[ÚÜÙÛ]/gi, "U");

                    transformedInput = transformedInput.replace(pattern, '').toUpperCase();

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

    app.controller('FollowupController', ['$q', '$http', '$filter', '$window', function ($q, $http, $filter, $window) {

        var vm = this;
        vm.personalDetails = [];
        //vm.personalTypeColl = [];

        vm.IdPeticion = "";
        vm.IdOperador = "";
        vm.IdRol = "";
        vm.IdEstatusInterno = "";
        vm.enabledButton = false;
        vm.msgError = "";
        vm.errorList = [];

        vm.resetError = function () {
            vm.msgError = "";
        }

        vm.auxPersonaDetails = {
            type: 0,
            name: '',
            firstName: '',
            lastName: ''
        };

        $http.get('../BandejaDepeticiones/DatosPeticionJson/').then(function (response) {
            vm.IdPeticion = response.data[0].IdPeticion;
            vm.IdOperador = response.data[0].IdOperador;
            vm.IdRol = response.data[0].IdRol;
            vm.IdEstatusInterno = response.data[0].IdEstatusInterno;
            vm.AsigPeticion = response.data[0].AsigPeticion;
            vm.record = {
                followupIdRol: vm.IdRol
            }

            var auxdata = {
                IdPeticion: vm.IdPeticion
            };

            //var promGetTypeColl = 
            $http.post('../BandejaDepeticiones/Obtener_PersonalInvolucrado/', auxdata).then(function (response) {
                vm.personalDetails = response.data;
            }, function (response) {
                vm.msgError = "Error al cargar la información";
            });
            //var promGetFollowUpData =
            $http.get('../BandejaDepeticiones/Obtener_TiposPersonal').then(function (response) {
                vm.personalTypeColl = response.data;
                vm.auxPersonaDetails.type = vm.personalTypeColl[0];
            }, function (response) {
                vm.msgError = "Error al cargar la información";
            });
        });

        vm.seekForClick = function () {
            var iterations = 0;
            angular.forEach(vm.personalDetails, function (selectedseek) {

                if (selectedseek.selected) {
                    vm.enabledButton = true;
                } else {
                    iterations = iterations + 1;
                }
            });

            if (vm.personalDetails.length == iterations) {
                vm.enabledButton = false;
            }
        };


        //$q.all([promGetTypeColl, promGetFollowUpData]).then(function (data) {
        //    vm.personalTypeColl = data[0].data;
        //    vm.personalDetails = data[1].data;
        //    vm.auxPersonaDetails.type = vm.personalTypeColl[0];
        //});

        vm.cambia = function () {
            if (vm.auxPersonaDetails.type.IdTipoPersonal != 0) {
                document.getElementById("ValTipo").hidden = true;
            }
        }

        vm.addNew = function () {

            if (vm.auxPersonaDetails.type.IdTipoPersonal != 0 && ((vm.auxPersonaDetails.name != '' && vm.auxPersonaDetails.name != undefined) || (vm.auxPersonaDetails.firstName != '' && vm.auxPersonaDetails.firstName != undefined))) {
                document.getElementById("ValTipo").hidden = true;
                if (vm.auxPersonaDetails.firstName != '' || vm.auxPersonaDetails.name != '') {
                    document.getElementById("ValNom").hidden = true;
                    var data = {
                        TipoPersonal: vm.auxPersonaDetails.type.IdTipoPersonal,
                        Nombre: vm.auxPersonaDetails.name,
                        ApellidoPaterno: vm.auxPersonaDetails.firstName,
                        ApellidoMaterno: vm.auxPersonaDetails.lastName,
                        IdUsuarioRegistro: vm.IdOperador,
                        IdPeticion: vm.IdPeticion
                    };

                    $http.post('../BandejaDepeticiones/Insertar_PersonalInvolucrado/', data).then(function (response) {
                        vm.personalDetails = [];
                        $http.post('../BandejaDepeticiones/Obtener_PersonalInvolucrado/', data).then(function (response) {
                            vm.personalDetails = response.data;
                            vm.auxPersonaDetails = {
                                type: vm.personalTypeColl[0],
                                name: '',
                                firstName: '',
                                lastName: ''
                            };
                        }, function (response) {
                            vm.msgError = "Error al cargar la información";
                        });

                    });
                }

            }
            else {
                if (vm.auxPersonaDetails.type.IdTipoPersonal == 0) {
                    document.getElementById("ValTipo").hidden = false;
                    vm.msgError = "Falta seleccionar tipo de personal";
                    if ((vm.auxPersonaDetails.name == '' || vm.auxPersonaDetails.name == undefined) && (vm.auxPersonaDetails.firstName == '' || vm.auxPersonaDetails.firstName == undefined)) {
                        document.getElementById("ValNom").hidden = false;
                        vm.msgError = "Falta llenar los datos obligatorios";
                    }
                }
                else {
                    if ((vm.auxPersonaDetails.name == '' || vm.auxPersonaDetails.name == undefined) && (vm.auxPersonaDetails.firstName == '' || vm.auxPersonaDetails.firstName == undefined)) {
                        document.getElementById("ValNom").hidden = false;
                        vm.msgError = "El nombre o apellido paterno es obligatorio";
                    }
                    else {
                        document.getElementById("ValNom").hidden = true;
                    }
                }

            }
        };

        vm.remove = function () {
            var newDataList = [];
            var deleteDataList = [];
            vm.enabledButton = false;
            angular.forEach(vm.personalDetails, function (selected) {
                if (!selected.selected) {
                    newDataList.push(selected);
                } else {
                    deleteDataList.push(selected);
                }
            });

            $http.post('../BandejaDepeticiones/Eliminar_PersonalInvolucrado', deleteDataList).then(function () {
                vm.personalDetails = newDataList;
            }, function (response) {
                vm.msgError = "Error al cargar la información";
            });


        };

        //vm.saveNewPersonal = function () {

        //var data = {
        //    'type': vm.auxPersonaDetails.type.description,
        //    'name': vm.auxPersonaDetails.name,
        //    'firstName': vm.auxPersonaDetails.firstName,
        //    'lastName': vm.auxPersonaDetails.lastName
        //};

        //    $http.post('/Peticion/SavePersonal', data).then(function () {

        //    });
        //}

    }]);

})();


