
//######################################################################
//     ##Fecha de creación: 18/03/16
//     ##Fecha de última modificación: 18/04/16
//     ##Responsable: Emanuel De la Isla Vértiz
//     ##Módulos asociados: index.html, validaetNoEntitle.html, homeDataService.js
//     ##Id Tickets asociados al cambio: R-013165
//####################################################################

(function () {
    'use strict';

    var controllerId = 'homeController';

    angular
        .module(appName)
        .controller(controllerId, ['common', 'homeDataService', homeController]);


    function homeController(common, homeDataService) {
        //#region Controller Members

        var vm = this;
        vm.error = false;
        vm.entitle = {};
        vm.lada;
        vm.telefono;
        vm.init = init;
        vm.isEntitle = isEntitle;
        vm.initEntitleData = initEntitleData;
        vm.updateEntitle = updateEntitle;
        vm.isFormValid = isFormValid;
        vm.isInformationComplete = isInformationComplete;
        vm.entitle.phone;


        var isInfoUpdated = true;

        function isEntitle() {
            return common.config.isEntitle;
        }

        function init() {
            completeControllerInit();



            common.overrideNavigationMenu(false);


        }


        function initEntitleData() {
            var dataPromise = null;
            var originalEntitle = common.config.entitleInformation;
            var key = null;

            //Se agrega el Breadcrumbs Grafica Base
            $('#navinicio').addClass("active");
            $('#navabout').addClass("hidden");
            $('#navrequest').addClass("hidden");

            if (vm.isEntitle())
                dataPromise = getEntitle(common.config.entitleInformation.NoISSSTE);
            else
                dataPromise = getNotEntitle(common.config.entitleInformation.CURP);

            dataPromise
                .success(function (data, status, headers, config) {
                    if (!vm.isEntitle() && data == "")
                        //if (!vm.isEntitle())
                        finishLoadingEntitleInformation(originalEntitle);
                    else
                        finishLoadingEntitleInformation(data);
                })
                .error(function (data, status, headers, config) {
                    completeControllerInit();
                });
        }

        /*
        function isFormValid(form, phone,lada, email) {
            vm.entitle.phone = vm.lada + vm.telefono;
            form.phone = form.phone + form.lada;
           
            if (vm.isEntitle()) {
               /*if (phone.$valid) {
                    $('#divContacto').removeClass("has-success has-feedback ");
                    $('#spantel').removeClass("form-text-error");
                    $('#inpttel').removeClass("form-control-error");
                }
     


                if (email.$valid) {
                    $('#divContacto').removeClass("has-success has-feedback ");
                    $('#spanemail').removeClass("form-text-error");
                    $('#inptemail').removeClass("form-control-error");
                
                return phone.$valid && email.$valid;
            }
            else {
                return form.$valid;
            }
        }
        
        */
        //function isFormValid(form, lada, telefono, correo) {

        //    return form.$valid;
        //}

        function isFormValid(form, telephone, email) {
            if (vm.isEntitle())
                return telephone.$valid && email.$valid;
            else
                return form.$valid;
        }

        function isInformationComplete(form, telephone, email) {
            var isComplete = isFormValid(form, telephone, email) && isInfoUpdated
            //var isComplete = isFormValid(form) && isInfoUpdated
            common.overrideNavigationMenu(!isComplete);

            return isComplete;
        }

        function updateEntitle() {
            vm.entitle.phone = vm.lada + vm.telefono;
            common.displayLoadingScreen();

            var promise;

            vm.entitle.EntitleId = vm.entitle.CURP;

            promise = homeDataService.updateEntitle(vm.entitle, vm.isEntitle() ? 'Update' : 'Update/NotEntitle', common.config.entitleInformation.EntitleId);

            promise.success(function (data, status, headers, config) {
                common.showSuccessMessage(Messages.success.informationUpdated);


                isInfoUpdated = true;

            }).error(function (data, status, headers, config) {
                common.showErrorMessage("Error al actualizar los datos.", "¡Error!");
                // common.showErrorMessage(data, Messages.error.informationUpdated);
            }).finally(function () {

                common.hideLoadingScreen();
            });
        }


        function getEntitle(isssteNumber) {
            return homeDataService.getEntitle(isssteNumber)
                .success(function (data, status, headers, config) {
                    if (data != "")
                        common.config.entitleInformation = data;
                    if (((common.config.entitleInformation.Phone + " ").substring(0, 2) == '55') || ((common.config.entitleInformation.Phone + " ").substring(0, 2) == '33') || ((common.config.entitleInformation.Phone + " ").substring(0, 2) == '81')) {
                        vm.lada = (common.config.entitleInformation.Phone + " ").substring(0, 2);
                        //  vm.information.Entitle.Telephone = vm.entitleInformation.Telephone.substring(2);
                        vm.telefono = (common.config.entitleInformation.Phone + " ").substring(2).trim();
                    }
                    else {
                        vm.lada = (common.config.entitleInformation.Phone + " ").substring(0, 3);
                        //  vm.information.Entitle.Telephone = vm.entitleInformation.Telephone.substring(2);
                        vm.telefono = (common.config.entitleInformation.Phone + " ").substring(3).trim();
                    }
                })
                .error(function (data, status, headers, config) {
                    common.showErrorMessage("Error al obtener los datos.", "¡Error!");
                    // common.showErrorMessage(data, Messages.error.getEntitleInformation);
                    vm.error = true;
                });
        }

        function getNotEntitle(curp) {
            return homeDataService.getNotEntitle(curp)
                .success(function (data, status, headers, config) {
                    if (data != "")
                        common.config.entitleInformation = data;

                    common.config.entitleInformation.EntitleId = curp;
                })
                .error(function (data, status, headers, config) {
                    common.showErrorMessage("Error al obtener los datos.", "¡Error!");
                    //common.showErrorMessage(data, Messages.error.getEntitleInformation);
                    vm.error = true;
                });
        }

        function finishLoadingEntitleInformation(entitleInformation) {
            vm.entitle = jQuery.extend({}, entitleInformation);

            if (vm.entitle.Phone == null || vm.entitle.Email == null)
                isInfoUpdated = false;

            completeControllerInit();
        }

        function completeControllerInit() {
            common.logger.log(Messages.info.contollerLoaded, null, controllerId);
            common.overrideNavigationMenu(true);
            common.activateController([], controllerId);

        }

        //#endregion
    };
})();