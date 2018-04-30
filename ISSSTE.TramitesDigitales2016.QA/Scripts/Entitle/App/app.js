//Variable global con el nombre del módulo
var appName = 'ISSSTE.Tramites2015.Velacion.Entitle.App';

(function () {
    'use strict';

    //Se crea la aplicación
    var app = angular.module(appName, [
        //Inyección de módulos angular
        'ngRoute',  //módulo para ruteo de la aplicación
        'ngSanitize', //Corrige hallazgos HTML en el bindeo
        //Inyección de módulos de la aplicación
        'common',
        'jcs-autoValidate',
        'ngFileUpload',
        'datetimepicker'
    ]);

    //Se obtiene una referncia al proveedor de rutas
    app.config(['$routeProvider', function ($routeProvider, routes) {
        $routeProviderReference = $routeProvider;
    }]);

    //código de arranque de la aplicación
    app.run(['$route', '$window', '$rootScope', 'common', 'defaultErrorMessageResolver', startup]);

    //#region Constants

    var ISSSTE_NUMBER_QUERY_PARAM = "noissste";
    var CURP_QUERY_STRING = "curp";

    //#endregion

    //#region Fields

    var $rootScopeReference;
    var $routeProviderReference;
    var $routeReference;
    var $windowReference;
    var commonReference;

    //#endregion

    //#region Información del usuario

    function startup($route, $window, $rootScope, common, defaultErrorMessageResolver) {
        //Asignación de objetos injectados para su utilización despues
        $rootScopeReference = $rootScope;
        $routeReference = $route;
        $windowReference = $window;
        commonReference = common;

        //So configura el resolutor de errores
        defaultErrorMessageResolver.getErrorMessages().then(function (errorMessages) {
            errorMessages['required'] = Messages.validation.required;
            errorMessages['email'] = Messages.validation.email;
            errorMessages['number'] = Messages.validation.numbers;
            errorMessages['minlength'] = Messages.validation.minLenght;
            errorMessages['rfc'] = Messages.validation.rfc;
            errorMessages['curp'] = Messages.validation.curp;
        });

        var isssteNumber = Utils.getQueryStringValue(ISSSTE_NUMBER_QUERY_PARAM);

        commonReference.config.entitleInformation.NoISSSTE = isssteNumber;

        //if (isssteNumber == undefined || isssteNumber == '') {
        //    commonReference.config.isEntitle = false;
        //    //commonReference.config.entitleInformation.CURP = 'EIVC900818HMCSLR09';            
        //}

        if (!isssteNumber) {
            commonReference.config.isEntitle = false;
            var curp = Utils.getQueryStringValue(CURP_QUERY_STRING);

            if (curp)
                commonReference.config.entitleInformation.CURP = curp;
        }

        //Se inzializan las rutas las rutas
        routeConfigurator()

        //Se forza un reprocesamiento de la ruta actual
        $routeReference.reload();
    }

    //#endregion

    //#region Rutas

    function routeConfigurator() {
        var routes = getRoutes();

        for (var i = 0; i < routes.length; i++) {
            $routeProviderReference.when(routes[i].url, routes[i].config);
        }

        $routeProviderReference.otherwise({ redirectTo: Routes.home.url });
    }

    function getRoutes() {
        return [
          {
              url: Routes.home.url,
              config: {
                  templateUrl: commonReference.getBaseUrl() + Routes.home.templateUrl,
                  resolve: {
                      "check": ['$location', function ($location) {
                          validateUrlAccess($location);
                      }]
                  }
              }
          },
          {
              url: Routes.notEntitle.url,
              config: {
                  templateUrl: commonReference.getBaseUrl() + Routes.notEntitle.templateUrl,
                  resolve: {
                      "check": ['$location', function ($location) {
                          validateUrlAccess($location);
                      }]
                  }
              }
          },
          {
              url: Routes.about.url,
              config: {
                  templateUrl: commonReference.getBaseUrl() + Routes.about.templateUrl,
                  resolve: {
                      "check": ['$location', function ($location) {
                          validateUrlAccess($location);
                      }]
                  }
              }
          },
          {
              url: Routes.quotationMortuaries.url,
              config: {
                  templateUrl: commonReference.getBaseUrl() + Routes.quotationMortuaries.templateUrl,
                  resolve: {
                      "check": ['$location', function ($location) {
                          validateUrlAccess($location);
                      }]
                  }
              }
          },
          {
              url: Routes.quotationPackages.url,
              config: {
                  templateUrl: commonReference.getBaseUrl() + Routes.quotationPackages.templateUrl,
                  resolve: {
                      "check": ['$location', function ($location) {
                          validateUrlAccess($location);
                      }]
                  }
              }
          },
          {
              url: Routes.quotationProducts.url,
              config: {
                  templateUrl: commonReference.getBaseUrl() + Routes.quotationProducts.templateUrl,
                  resolve: {
                      "check": ['$location', function ($location) {
                          validateUrlAccess($location);
                      }]
                  }
              }
          },
          {
              url:  Routes.quotationReview.url,
              config: {
                  templateUrl:  commonReference.getBaseUrl() + Routes.quotationReview.templateUrl,
                  resolve: {
                      "check": ['$location', function ($location) {
                          validateUrlAccess($location);
                      }]
                  }
              }
          },
          {
              url: Routes.quotationDetails.url,
              config: {
                  templateUrl: commonReference.getBaseUrl() + Routes.quotationDetails.templateUrl,
                  resolve: {
                      "check": ['$location', function ($location) {
                          validateUrlAccess($location);
                      }]
                  }
              }
          },
          {
              url: Routes.quotations.url,
              config: {
                  templateUrl: commonReference.getBaseUrl() + Routes.quotations.templateUrl,
                  resolve: {
                      "check": ['$location', function ($location) {
                          validateUrlAccess($location);
                      }]
                  }
              }
          }
        ];
    }

    //#endregion

    //#region UI

    //#endregion

    //#region Helper Functions

    function validateUrlAccess($location) {
        
        if (!commonReference.config.entitleInformation.NoISSSTE && !commonReference.config.entitleInformation.CURP)
            $location.path(Routes.notEntitle.url);
    }

    //#endregion

})();
