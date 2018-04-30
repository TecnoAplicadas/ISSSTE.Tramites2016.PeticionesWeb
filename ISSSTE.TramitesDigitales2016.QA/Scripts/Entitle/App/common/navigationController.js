//######################################################################
//     ##Fecha de creación: 18/03/16
//     ##Fecha de última modificación: 18/04/16
//     ##Responsable: Emanuel De la Isla Vértiz
//     ##Módulos asociados: 
//     ##Id Tickets asociados al cambio: R-013165
//####################################################################

(function () {
    'use strict';

    var controllerId = 'navigationController';

    angular
        .module(appName)
        .controller(controllerId, ['$rootScope', '$routeParams', '$location', 'common', 'appConfig', 'homeDataService', navigationService]);

    function navigationService($rootScope, $routeParams, $location, common, appConfig,homeDataService) {

        //#region Constants

        var REQUEST_ID_TEMPLATE_PARAM = ":" + REQUEST_ID_PARAM;
        var REQUEST_ID_TEMPLATE_PARAM = ":" + REQUEST_ID_PARAM;
        var MORTUARY_ID_TEMPLATE_PARAM = ":" + MORTUARY_ID_PARAM;
        var PACKAGE_ID_TEMPLATE_PARAM = ":" + PACKAGE_ID_PARAM;
        var QUOTATION_ID_TEMPLATE_PARAM = ":" + QUOTATION_ID_PARAM;

        var REQUEST_URL_LIST = [
            Routes.quotationMortuaries.url,
            Routes.quotationPackages.url,
            Routes.quotationProducts.url,
            Routes.quotationReview.url,
            Routes.quotationDetails.url,
        ];

        //#endregion

        //#region Members

        var vm = this;
        vm.initEntitleData = initEntitleData;
        vm.homeUrl = Routes.home.url;
        vm.aboutUrl = Routes.about.url;
        vm.newRequestUrl = Routes.quotationMortuaries.url.replace(REQUEST_ID_TEMPLATE_PARAM, null);
        vm.requestsUrl = Routes.quotations.url;
        //vm.pitAndDocumentUrl = Routes.requestPitAndDocuments.url;
        //vm.beneficiariesUrl = Routes.requestBeneficiaries.url;
        vm.isHomeSelected = false;
        vm.isAbouSelected = false;
        vm.isNewRequestSelected = false;
        vm.isRequestsSelected = false;
        vm.isOverrided = false;

        vm.selectHome = selectHome;
        vm.selectAbout = selectAbout;
        vm.selectNewRequest = selectNewRequest;
        vm.selectRequests = selectRequests;
        vm.navigateToLastRequestUrl = navigateToLastRequestUrl;
        vm.navigateToNextRequestUrl = navigateToNextRequestUrl;
        vm.navigateToMortuariesUrl = navigateToMortuariesUrl;
        vm.navigateToPackagesUrl = navigateToPackagesUrl;
        vm.navigateToProductsUrl = navigateToProductsUrl;
        vm.navigateToReviewUrl = navigateToReviewUrl;
        vm.navigateToDetailsUrl = navigateToDetailsUrl;
        vm.navigateToHomeUrl = navigateToHomeUrl;
        vm.error = false;
        vm.entitle = {};

        vm.init = init;
        vm.isEntitle = isEntitle;
        vm.initEntitleData = initEntitleData;
        vm.updateEntitle = updateEntitle;
        vm.isFormValid = isFormValid;
        vm.isInformationComplete = isInformationComplete;

        var isInfoUpdated = true;


        //#endregion

        //#region Fields

        var currentRequestUrl = null;
        var currentRequesId = null;

        //#endregion

        //#region Properties

        //#endregion

        //#region Initialization

        $rootScope.$on(appConfig.events.navigationMenuOverrided, function (event, data) {
            common.logger.log(Messages.info.navigationMenuOverrided, data, controllerId);
            vm.isOverrided = data.override;
        });

        $rootScope.$on(appConfig.events.changeRequestId, function (event, data) {
            common.logger.log(Messages.info.navigationMenuOverrided, data, controllerId);
            currentRequesId = data.requestId;
        });

        $rootScope.$on('$routeChangeSuccess',
            function (event, current, previous) {
                currentRequestUrl = current.originalPath;
                currentRequesId = $routeParams[REQUEST_ID_PARAM];

                if (currentRequestUrl == vm.homeUrl)
                    selectHome();
                else if (currentRequestUrl == vm.aboutUrl)
                    selectAbout();
                else if (currentRequestUrl == vm.requestsUrl)
                    selectRequests();
                else
                    selectNewRequest();
            });

        //#endregion

        //#region Functions

        function selectHome() {
            deselectAllPages();

            vm.isHomeSelected = true;
            //vm.isOverrided = true;
        }

        function selectAbout() {
            deselectAllPages();

            vm.isAbouSelected = true;
        }

        function selectNewRequest() {
            deselectAllPages();

            vm.isNewRequestSelected = true;
        }

        function selectRequests() {
            deselectAllPages();

            vm.isRequestsSelected = true;
        }

        function navigateToLastRequestUrl() {
            var resultUrl = "";

            var nextUrlIndex = null;

            for (var i = REQUEST_URL_LIST.length - 1; i >= 0; i--) {
                if (currentRequestUrl == REQUEST_URL_LIST[i])
                    nextUrlIndex = i - 1;
            }

            if (nextUrlIndex != null && nextUrlIndex >= 0) {
                resultUrl = REQUEST_URL_LIST[nextUrlIndex].replace(REQUEST_ID_TEMPLATE_PARAM, currentRequesId);

                $location.path(resultUrl);
            }
        }

        function navigateToNextRequestUrl() {
            var resultUrl = "";

            var nextUrlIndex = null;

            for (var i = 0; i < REQUEST_URL_LIST.length; i++) {
                if (currentRequestUrl == REQUEST_URL_LIST[i])
                    nextUrlIndex = i + 1;
            }

            if (nextUrlIndex != null && nextUrlIndex < REQUEST_URL_LIST.length) {
                resultUrl = REQUEST_URL_LIST[nextUrlIndex].replace(REQUEST_ID_TEMPLATE_PARAM, currentRequesId);

                $location.path(resultUrl);
            }
        }

        function navigateToMortuariesUrl() {
            $location.path(Routes.quotationMortuaries.url);
        }

        function navigateToPackagesUrl() {
            var mortuaryId = common.config.requestInformation.MortuaryId;
            $location.path(Routes.quotationPackages.url.replace(MORTUARY_ID_TEMPLATE_PARAM, mortuaryId));
        }

        function navigateToProductsUrl() {
            var mortuaryId = common.config.requestInformation.MortuaryId;
            var packageId = common.config.requestInformation.SelectedPackage.PackageId;
            $location.path(Routes.quotationProducts.url.replace(MORTUARY_ID_TEMPLATE_PARAM, mortuaryId).replace(PACKAGE_ID_TEMPLATE_PARAM, packageId));
        }

        function navigateToReviewUrl() {
            $location.path(Routes.quotationReview.url);
        }

        function navigateToDetailsUrl() {
            //Cambio de variable para Grafica Base
            //var quotationId = common.config.requestInformation.QuotationId;
            // quoteId
            var quoteId = common.config.quoteInformation.idQuote;
            $location.path(Routes.quotationDetails.url.replace(QUOTATION_ID_TEMPLATE_PARAM, quoteId));
        }

        function navigateToHomeUrl() {
            $location.path(Routes.home.url);
        }
        //#endregion

        //#region Helper functions

        function deselectAllPages() {
            vm.isHomeSelected = false;
            vm.isAbouSelected = false;
            vm.isNewRequestSelected = false;
            vm.isRequestsSelected = false;

            vm.isOverrided = false;
        }

        function isEntitle() {
            return common.config.isEntitle;
        }

        function init() {
            completeControllerInit();



            common.overrideNavigationMenu(false);


        }


        function initEntitleData() {
            var dataPromise = null;
            var originalEntitle = common.config.entitleInformation;
            var key = null;

            //Se agrega el Breadcrumbs Grafica Base
            $('#navinicio').addClass("active");
            $('#navabout').addClass("hidden");
            $('#navrequest').addClass("hidden");

            if (vm.isEntitle())
                dataPromise = getEntitle(common.config.entitleInformation.NoISSSTE);
            else
                dataPromise = getNotEntitle(common.config.entitleInformation.CURP);

            dataPromise
                .success(function (data, status, headers, config) {
                    if (!vm.isEntitle() && data == "")
                        //if (!vm.isEntitle())
                        finishLoadingEntitleInformation(originalEntitle);
                    else
                        finishLoadingEntitleInformation(data);
                })
                .error(function (data, status, headers, config) {
                    completeControllerInit();
                });
        }


        function isFormValid(form, phone, email) {
            if (vm.isEntitle()) {
                if (phone.$valid) {
                    $('#divContacto').removeClass("has-success has-feedback ");
                    $('#spantel').removeClass("form-text-error");
                    $('#inpttel').removeClass("form-control-error");
                }

                if (email.$valid) {
                    $('#divContacto').removeClass("has-success has-feedback ");
                    $('#spanemail').removeClass("form-text-error");
                    $('#inptemail').removeClass("form-control-error");
                }
                return phone.$valid && email.$valid;
            }
            else {
                return form.$valid;
            }
        }

        function isInformationComplete(form, telephone, email) {
            var isComplete = isFormValid(form, telephone, email) && isInfoUpdated

            common.overrideNavigationMenu(!isComplete);

            return isComplete;
        }

        function updateEntitle() {
            common.displayLoadingScreen();

            var promise;

            vm.entitle.EntitleId = vm.entitle.CURP;

            promise = homeDataService.updateEntitle(vm.entitle, vm.isEntitle() ? 'Update' : 'Update/NotEntitle', common.config.entitleInformation.EntitleId);

            promise.success(function (data, status, headers, config) {
                common.showSuccessMessage(Messages.success.informationUpdated);


                isInfoUpdated = true;

            }).error(function (data, status, headers, config) {
                common.showErrorMessage(data, Messages.error.informationUpdated);
            }).finally(function () {

                common.hideLoadingScreen();
            });
        }


        function getEntitle(isssteNumber) {
            return homeDataService.getEntitle(isssteNumber)
                .success(function (data, status, headers, config) {
                    if (data != "")
                        common.config.entitleInformation = data;
                })
                .error(function (data, status, headers, config) {
                    common.showErrorMessage(data, Messages.error.getEntitleInformation);
                    vm.error = true;
                });
        }

        function getNotEntitle(curp) {
            return homeDataService.getNotEntitle(curp)
                .success(function (data, status, headers, config) {
                    if (data != "")
                        common.config.entitleInformation = data;

                    common.config.entitleInformation.EntitleId = curp;
                })
                .error(function (data, status, headers, config) {
                    common.showErrorMessage(data, Messages.error.getEntitleInformation);
                    vm.error = true;
                });
        }

        function finishLoadingEntitleInformation(entitleInformation) {
            vm.entitle = jQuery.extend({}, entitleInformation);

            if (vm.entitle.Phone == null || vm.entitle.Email == null)
                isInfoUpdated = false;

            completeControllerInit();
        }

        function completeControllerInit() {
            common.logger.log(Messages.info.contollerLoaded, null, controllerId);
            common.overrideNavigationMenu(true);
            common.activateController([], controllerId);

        }

        $gmx(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

        //#enregion
    }
})();