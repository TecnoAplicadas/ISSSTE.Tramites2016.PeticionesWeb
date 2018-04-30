(function () {
    'use strict';

    angular
        .module(appName)
        .factory('reviewDataServices', ['$http', 'common', 'appConfig', reviewDataServices]);

    function reviewDataServices($http, common, appConfig) {

        var factory = {
            getReviewQuote: getReviewQuote,
            confirmQuote: confirmQuote,
            getReportDownload: getReportDownload
        };

        return factory;

        function getReviewQuote(quotationId) {
            var url = common.getBaseUrl() + 'api/Entitle/Quotations/' + quotationId;

            return $http.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'Issste-Tramites2015-UserIdentity': common.config.entitleInformation.CURP
                }
            });
        }

        function confirmQuote(infoQuotation) {
            var url = common.getBaseUrl() + 'api/Entitle/Quotations/Add';

            return $http.post(url,
                 infoQuotation,
                 {
                     headers: {
                         'Content-Type': JSON_CONTENT_TYPE,
                         'Issste-Tramites2015-UserIdentity': common.config.entitleInformation.CURP
                     }
                 }
           );
        }

        function getReportDownload(quotationId) {
            var url = common.getBaseUrl() + 'api/Entitle/Report/' + quotationId;

            return url;

        }

    }
})();