(function () {
    'use strict';

    var controllerId = 'quotesController';
    angular
        .module(appName)
        .controller(controllerId, ['common', 'quotesDataServices', quotesController]);


    function quotesController(common, quotesDataServices) {
        //#region Controller Members

        var vm = this;
        vm.quotesActive = [];
        vm.quotesExpired = [];

        vm.initQuotes = initQuotes;
        vm.getReview = getReview;
        vm.getReport = getReport;
        vm.reportUrl;

        //#endregion

        //#region Functions

        function initQuotes() {
            var quotesPromises = [];

            quotesPromises.push(getQuotesActive());
            quotesPromises.push(getQuotesExpired());

       

            common.$q.all(quotesPromises).finally(function (data) {
                completeControllerInit();
            });

            //getQuotesActive();

            completeControllerInit();
        }



        function getQuotesActive() {
            var dataPromise = null;
            dataPromise = quotesDataServices.getQuotesActive();

            dataPromise.success(function (data) {
                vm.quotesActive = data;
            })
            .error(function (data, status, headers, config) {
                common.showErrorMessage(data, Messages.error.getQuotes);
            })
        }

        function getQuotesExpired() {
            var dataPromise = null;
            dataPromise = quotesDataServices.getQuotesExpired();

            dataPromise.success(function (data) {
                vm.quotesExpired = data;
            })
            .error(function (data, status, headers, config) {
                common.showErrorMessage(data, Messages.error.getSates);
            })
        }

        function getReview(idQuote, navigate) {
            common.config.quoteInformation.idQuote = idQuote;
            navigate();
        }

        function getReport(quotationId) {
            vm.reportUrl = quotesDataServices.getReportDownload(quotationId);
        }

        function completeControllerInit() {
            common.logger.log(Messages.info.contollerLoaded, null, controllerId);
            common.activateController([], controllerId);
        }

   
    }
})();