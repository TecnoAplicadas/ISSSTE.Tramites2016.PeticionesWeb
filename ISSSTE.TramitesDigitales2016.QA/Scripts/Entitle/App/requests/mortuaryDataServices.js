(function () {
    'use strict';

    angular
        .module(appName)
        .factory('mortuaryDataService', ['$http', 'common', 'appConfig', mortuaryDataService]);

    function mortuaryDataService($http, common, appConfig) {

        var factory = {
            getStates: getStates,
            getMortuaries: getMortuaries
        };

        return factory;

        function getStates() {
            var url = common.getBaseUrl() + 'api/Entitle/States';

            return $http.get(url, {
                headers: {
                    'Content-Type': JSON_CONTENT_TYPE,
                    'Issste-Tramites2015-UserIdentity': common.config.entitleInformation.CURP
                }
            });
        }

        function getMortuaries(stateId) {
            var url = common.getBaseUrl() + 'api/Entitle/States/' + stateId + '/Mortuaries';

            return $http.get(url, {
                headers: {
                    'Content-Type': JSON_CONTENT_TYPE,
                    'Issste-Tramites2015-UserIdentity': common.config.entitleInformation.CURP
                }
            });
        }
       
    }


})();