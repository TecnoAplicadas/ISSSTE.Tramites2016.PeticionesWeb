 //######################################################################
//     ##Fecha de creación: 18/03/16
//     ##Fecha de última modificación: 18/04/16
//     ##Responsable: Emanuel De la Isla Vértiz
//     ##Módulos asociados: mortuaryDataService.js
//     ##Id Tickets asociados al cambio: R-013165
//####################################################################

(function () {
    'use strict';

    var controllerId = 'mortuaryController';

    angular
        .module(appName)
        .controller(controllerId, ['common', 'mortuaryDataService', mortuaryController]);

    function mortuaryController(common, mortuaryDataService) {

        var vm = this;
        vm.error = false;
        vm.initMortuariesData = initMortuariesData;
        vm.showMortuaries = showMortuaries;
        vm.chooseMortuary = chooseMortuary;

        vm.state = { IdState: 0, Name: "Seleccione" };
        vm.states = [];
        vm.mortuaries = [];

        function initMortuariesData() {
            var promise = null;
            common.displayLoadingScreen();
            promise = getStates();
            
            promise.finally(function () {
                common.hideLoadingScreen();
            });
        }



        function getStates() {
            var dataPromise = null;

            dataPromise = mortuaryDataService.getStates();

            dataPromise.success(function (data, status, headers, config) {
                vm.states = jQuery.extend([], data);
            })
             .error(function (data, status, headers, config) {
                 common.showErrorMessage(data, Messages.error.getSates);
                 vm.error = true;
             });

            return dataPromise;
        }

        function showMortuaries(state) {
            //Se agrego que el estado a consulta sea diferente de 0 Grafica Base
            if (state.IdState != 0) {
                var dataPromise = null;
                common.displayLoadingScreen();
                var valueState = state;


                dataPromise = getMortuariesByState(state.IdState);

                dataPromise.finally(function () {
                    common.hideLoadingScreen();
                });
            }
        }



        function getMortuariesByState(stateId) {

            return mortuaryDataService.getMortuaries(stateId)
            .success(function (data, status, headers, config) {
                vm.mortuaries = jQuery.extend([], data);
            })
             .error(function (data, status, headers, config) {
                 common.showErrorMessage(data, Messages.error.getMortuaries);
                 vm.error = true;
             });

        }

        function chooseMortuary(mortuaryId, navigate) {
            common.config.requestInformation.MortuaryId = mortuaryId;
            //common.changeNavigationRequestId(mortuaryId);
            navigate();
        }

        function completeControllerInit() {
            common.logger.log(Messages.info.contollerLoaded, null, controllerId);
            common.overrideNavigationMenu(true);
            common.activateController([], controllerId);
        }
    };

})();