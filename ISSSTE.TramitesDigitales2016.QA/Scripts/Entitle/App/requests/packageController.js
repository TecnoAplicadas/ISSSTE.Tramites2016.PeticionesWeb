(function () {
    'use strict';

    var controllerId = 'packageController';

    angular
        .module(appName)
        .controller(controllerId, ['common', 'packageDataService', packageController]);

    function packageController(common, packageDataService) {
        var vm = this;
        vm.error = false;
        vm.initPackages = initPackages;
        vm.choosePackage = choosePackage;        

        vm.packages = [];        

        function initPackages() {
            var promise = null;

            common.displayLoadingScreen();
            
            promise = getPackages();

            promise.finally(function () {
                common.hideLoadingScreen();
            });
        }        

        function getPackages() {
            var promise = null;

            promise = packageDataService.getPackages();

            promise.success(function (data, status, headers, config) {                
                vm.packages = data;
            }).error(function (data, status, headers, config) {
                common.showErrorMessage(data, Messages.error.getPackages);
                vm.error = true;
            });

            return promise;
        }

        function choosePackage(selectedPackage, navigate) {
            common.config.requestInformation.SelectedPackage = selectedPackage;
            navigate();
        }                

    }
})();