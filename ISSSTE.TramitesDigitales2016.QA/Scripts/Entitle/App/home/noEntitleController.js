(function () {
    'use strict';

    var controllerId = 'noEntitleController';

    angular
        .module(appName)
        .controller(controllerId, ['common', noEntitleController]);


    function noEntitleController(common) {
        //#region Controller Members

        var vm = this;
        vm.init = init;
        vm.saveCurp = saveCurp;

        //#endregion

        //#region Functions

        function init() {
            common.overrideNavigationMenu(true);
            common.logger.log("controller loaded", null, controllerId);
            common.activateController([], controllerId);
        }

        function saveCurp(navigate) {
            var tmp
            common.config.entitleInformation.CURP = vm.noEntitleCURP;
            navigate();
        }

     
        //#endregion
    }
})();