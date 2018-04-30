(function () {
    'use strict';

    angular
        .module(appName)
        .factory('productsInPackageDataService', ['$http', 'common', 'appConfig', productsInPackageDataService]);

    function productsInPackageDataService($http, common, appConfig) {

        var factory = {            
            getProductsInPackage: getProductsInPackage
        };

        return factory;

        function getProductsInPackage(mortuaryId, packageId) {
            var url = common.getBaseUrl() + 'api/Entitle/Mortuaries/' + mortuaryId + '/Packages/' + packageId + '/Products';

            return $http.get(url, {
                headers: {
                    'Content-Type': JSON_CONTENT_TYPE,
                    'Issste-Tramites2015-UserIdentity': common.config.entitleInformation.CURP
                }
            });
        }        
    }
})();