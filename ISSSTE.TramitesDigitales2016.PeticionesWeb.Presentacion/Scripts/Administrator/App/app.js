//Variable global con el nombre del módulo
var appName = 'ISSSTE.TramitesDigitales.PeticionesWeb.App';

(function () {
    'use strict';

    //Se crea la aplicación
    var app = angular.module(appName, [
        //Inyección de módulos angular
        'ngRoute',  //módulo para ruteo de la aplicación
        'ngSanitize', //Corrige hallazgos HTML en el bindeo
        //Inyección de módulos de la aplicación
        'common',
        "LocalStorageModule",
        'jcs-autoValidate',
        'ngFileUpload'
        //,
        //'datetimepicker'
    ]);


    //Se obtiene una referncia al proveedor de rutas
    app.config(['$routeProvider', function ($routeProvider, routes) {
        $routeProviderReference = $routeProvider;
    }]);

    //código de arranque de la aplicación
    app.run(['$route', '$window', '$rootScope', 'common', 'authenticationService', 'webApiService', 'defaultErrorMessageResolver', startup]);

    //#region Constants

    //#endregion

    //#region Fields

    var $rootScopeReference;
    var $routeProviderReference;
    var $routeReference;
    var $windowReference;
    var commonReference;
    var authenticationServiceReference;
    var webApiServiceReference;

    //#endregion

    //#region Información del usuario

    function startup($route, $window, $rootScope, common, authenticationService, webApiService, defaultErrorMessageResolver) {
        //Asignación de objetos injectados para su utilización despues
        $rootScopeReference = $rootScope;
        $routeReference = $route;
        $windowReference = $window;
        commonReference = common;
        authenticationServiceReference = authenticationService;
        webApiServiceReference = webApiService;

        //So configura el resolutor de errores
        defaultErrorMessageResolver.getErrorMessages().then(function (errorMessages) {
            errorMessages['required'] = Messages.validation.required;
            errorMessages['email'] = Messages.validation.email;
            errorMessages['number'] = Messages.validation.numbers;
            errorMessages['minlength'] = Messages.validation.minLenght;
            errorMessages['rfc'] = Messages.validation.rfc;
            errorMessages['curp'] = Messages.validation.curp;
        });


        //Si no se encuentra en alguna de las páginas de login o logout...
        if ($windowReference.location.pathname.toLocaleLowerCase().indexOf("account", 0) == -1) {
            //Se obtienen los roles del usuario logueado
            getUserRoles()
                .finally(function () {
                    //Se inzializan las rutas las rutas
                    routeConfigurator();

                    //Se forza un reprocesamiento de la ruta actual para que se apliquen las validaciones y se obtenga el html correspondiente
                    $routeReference.reload();
                })
        }
    }

    //#endregion

    //#region Rutas

    function routeConfigurator() {
        var routes = getRoutes();

        for (var i = 0; i < routes.length; i++) {
            $routeProviderReference.when(routes[i].url, routes[i].config);
        }

        $routeProviderReference.otherwise({ redirectTo: Routes.quotes.url });
    }

    function getRoutes() {
        return [
            {
                url: Routes.packages.url,
                config: {
                    templateUrl: commonReference.getBaseUrl() + Routes.packages.templateUrl,
                    resolve: {
                        "check": ['$location', function ($location) {
                            validateUrlAccess($location, Routes.packages.roles);
                        }]
                    }
                }
            },
            {
                url: Routes.editionPackages.url,
                config: {
                    templateUrl: commonReference.getBaseUrl() + Routes.editionPackages.templateUrl,
                    resolve: {
                        "check": ['$location', function ($location) {
                            validateUrlAccess($location, Routes.editionPackages.roles);
                        }]
                    }
                }
            },
            {
                url: Routes.products.url,
                config: {
                    templateUrl: commonReference.getBaseUrl() + Routes.products.templateUrl,
                    resolve: {
                        "check": ['$location', function ($location) {
                            validateUrlAccess($location, Routes.products.roles);
                        }]
                    }
                }
            },
            {
                url: Routes.quotes.url,
                config: {
                    templateUrl: commonReference.getBaseUrl() + Routes.quotes.templateUrl,
                    resolve: {
                        "check": ['$location', function ($location) {
                            validateUrlAccess($location, Routes.quotes.roles);
                        }]
                    }
                }
            },
            {
                url: Routes.quoteDetail.url,
                config: {
                    templateUrl: commonReference.getBaseUrl() + Routes.quoteDetail.templateUrl,
                    resolve: {
                        "check": ['$location', function ($location) {
                            validateUrlAccess($location, Routes.quoteDetail.roles);
                        }]
                    }
                }
            },
            {
                url: Routes.support.url,
                config: {
                    templateUrl: commonReference.getBaseUrl() + Routes.support.templateUrl,
                    resolve: {
                        "check": ['$location', function ($location) {
                            validateUrlAccess($location, Routes.support.roles);
                        }]
                    }
                }
            },
            {
                url: Routes.indicators.url,
                config: {
                    templateUrl: commonReference.getBaseUrl() + Routes.indicators.templateUrl,
                    resolve: {
                        "check": ['$location', function ($location) {
                            validateUrlAccess($location, Routes.indicators.roles);
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

    function getUserRoles() {
        return webApiServiceReference.makeRetryRequest(1, function () {
            return authenticationServiceReference.getUserRoles();
        })
            .then(function (data) {
                commonReference.config.userRoles = data;
            })
            .catch(function (reason) {
                commonReference.showErrorMessage(reason, Messages.error.userRoles)
            });
    }

    function validateUrlAccess($location, necessaryRoles) {
        //Si caduco la sesión (token) y no se puede renovar, se enviara a la pantalla de logout
        webApiServiceReference.makeRetryRequest(1, function () {
            return authenticationServiceReference.validateToken();
        });
        if (!commonReference.doesUserHasNecessaryRoles(necessaryRoles))
            $windowReference.location.href = Constants.accountRoutes.login;
    }

    //#endregion

})();
