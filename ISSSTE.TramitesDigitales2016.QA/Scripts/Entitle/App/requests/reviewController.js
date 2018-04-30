//######################################################################
//     ##Fecha de creación: 18/03/16
//     ##Fecha de última modificación: 18/04/16
//     ##Responsable: Emanuel De la Isla Vértiz
//     ##Módulos asociados: reviewDataServices.js
//     ##Id Tickets asociados al cambio: R-013165
//####################################################################

(function () {
    'use strict';

    var controllerId = 'reviewController';
    angular
        .module(appName)
        .controller(controllerId, ['common', 'reviewDataServices', quotesController]);


    function quotesController(common, reviewDataServices) {

        //#region Controller Members

        var vm = this;
        vm.quote = {};
        // Se modifica la variable para Grafica Base
        vm.idQuote = common.config.quoteInformation.idQuote;
        vm.report = [];

        vm.initReview = initReview;
        vm.confirmQuote = confirmQuote;
        vm.getReport = getReport;

        //#endregion

        //#region Functions

        function initReview() {
            getQuoteReview();
            completeControllerInit();

            $('#navinicio').addClass("active");
            $('#navabout').addClass("active");
            $('#navrequest').addClass("active");
        }

        function getQuoteReview() {
            if (common.config.requestInformation.infoQuotation != null) {
                vm.quote = common.config.requestInformation.infoQuotation.Quotation;
            }
            else {
                var dataPromise = null;
                dataPromise = reviewDataServices.getReviewQuote(vm.idQuote);

                dataPromise.success(function (data) {
                    vm.quote = data;
                })
                .error(function (data, status, headers, config) {
                    common.showErrorMessage(data, Messages.error.getReview);
                })
            }

        }


        function completeControllerInit() {
            common.logger.log(Messages.info.contollerLoaded, null, controllerId);
            common.activateController([], controllerId);
        }

        function confirmQuote() {
            var promise = null;

            common.displayLoadingScreen();

            promise = reviewDataServices.confirmQuote(common.config.requestInformation.infoQuotation);

            promise.success(function (data, status, headers, config) {
                common.config.requestInformation.QuotattionId = data;
                $('#exito').removeClass("hidden");
                $('#btnCotizar').addClass("disabled");
                $('#back').addClass("disabled");

                //Se agregan los botones a menu de pasos Grafica Base
                $('#info').addClass("hidden");
                $('#success').addClass("success");

                common.config.requestInformation.infoQuotation = null;
                common.config.requestInformation.SelectedPackage = null;
                common.config.requestInformation.MortuaryId = null;
                $("html, body").animate({ scrollTop: 700 }, 2000);
            })
            .error(function (data, status, headers, config) {
                common.showErrorMessage(data, Messages.error.quotationCreation);
                  $("html, body").animate({ scrollTop: 700 }, 2000);
            })
            .finally(function () {
                common.hideLoadingScreen();
            });
        }

        function getReport(quotationId) {
            vm.reportUrl = reviewDataServices.getReportDownload(quotationId);
        }

        //#endregion
    }
})();