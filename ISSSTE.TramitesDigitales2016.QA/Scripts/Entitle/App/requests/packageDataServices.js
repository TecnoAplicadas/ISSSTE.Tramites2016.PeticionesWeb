(function () {
    'use strict';

    angular
        .module(appName)
        .factory('packageDataService', ['$http', 'common', 'appConfig', packageDataService]);

    function packageDataService($http, common, appConfig) {

        var factory = {
            getPackages: getPackages
        };

        return factory;

        function getPackages() {
            var url = common.getBaseUrl() + 'api/Entitle/Packages';

            return $http.get(url, {
                headers: {
                    'Content-Type': JSON_CONTENT_TYPE,
                    'Issste-Tramites2015-UserIdentity': common.config.entitleInformation.CURP
                }
            });
        }
    

    }


})();