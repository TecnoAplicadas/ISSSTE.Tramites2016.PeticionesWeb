
(function () {
    'use strict';

    angular
        .module(appName)
        .factory('homeDataService', ['$http', 'common', 'appConfig', homeDataService]);

    function homeDataService($http, common, appConfig) {

        //#region Members

        var factory = {
            getEntitle: getEntitle,
            getNotEntitle: getNotEntitle,
            updateEntitle: updateEntitle,
        };

        return factory;

        //#endregion 

        //#region Fields

        //#endregion

        //#region Methods

        function getEntitle(isssteNumber) {
            var url = common.getBaseUrl() + 'api/Entitle/Information';

            return $http.get(url, {
                headers: {
                    'Content-Type': JSON_CONTENT_TYPE,
                    'Issste-Tramites2015-UserIdentity': isssteNumber
                }
            });
        }

        function getNotEntitle(curp) {
            var url = common.getBaseUrl() + 'api/Entitle/Information/NotEntitle';

            return $http.get(url, {
                headers: {
                    'Content-Type': JSON_CONTENT_TYPE,
                    'Issste-Tramites2015-UserIdentity': curp
                }
            });
        }

        //route: Update (Derechohabiente) ó General (Público en general)
        function updateEntitle(entitle, route, entitleId) {
            var url = common.getBaseUrl() + 'api/Entitle/' + route;

            return $http.post(url, entitle, {
                headers: {
                    'Content-Type': JSON_CONTENT_TYPE,
                    'Issste-Tramites2015-UserIdentity': entitleId
                }
            });
        }
     
        //#endregion
    }
})();