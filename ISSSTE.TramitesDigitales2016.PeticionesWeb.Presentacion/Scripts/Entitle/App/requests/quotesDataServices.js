(function () {
    'use strict';

    angular
        .module(appName)
        .factory('quotesDataServices', ['$http', 'common', 'appConfig', quotesDataServices]);

    function quotesDataServices($http, common, appConfig) {

        var factory = {
            getQuotesActive: getQuotesActive,
            getQuotesExpired: getQuotesExpired,
            getReportDownload: getReportDownload
        };

        return factory;

        function getQuotesActive() {
            var url = common.getBaseUrl() + 'api/Entitle/QuotationsActive';

            return $http.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'Issste-Tramites2015-UserIdentity': common.config.entitleInformation.CURP
                }
            });
        }

        function getQuotesExpired() {
            var url = common.getBaseUrl() + 'api/Entitle/QuotationsExpired';

            return $http.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'Issste-Tramites2015-UserIdentity': common.config.entitleInformation.CURP
                }
            });
        }

        function getReportDownload(quotationId) {
            var url = common.getBaseUrl() + 'api/Entitle/Report/' + quotationId;

            return url;

        }

      
    }

})();