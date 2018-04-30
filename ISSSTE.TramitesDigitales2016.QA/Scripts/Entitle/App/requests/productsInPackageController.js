(function () {
    'use strict';

    var controllerId = 'productsInPackageController';

    angular
        .module(appName)
        .controller(controllerId, ['common', 'productsInPackageDataService', productsInPackageController]);


    function productsInPackageController(common, productsInPackageDataService) {

        var vm = this;
        vm.error = false;
        vm.initProductsPackages = initProductsPackages;
        vm.addItemToQuotation = addItemToQuotation;
        vm.isProductTypeSelected = isProductTypeSelected;
        vm.removeItemFromQuotation = removeItemFromQuotation;
        vm.sendToConfirmation = sendToConfirmation;


        vm.package = {};
        vm.quotation = {};
        vm.productTypes = [];

        vm.productsInPackage = [];

        function initProductsPackages() {
            var promise = null;

            if (common.config.requestInformation.infoQuotation != null) {
                vm.quotation = common.config.requestInformation.infoQuotation.Quotation;
            }
            else {
                vm.quotation.EntitleId = common.config.entitleInformation.CURP;
                vm.quotation.MortuaryId = common.config.requestInformation.MortuaryId;
                vm.quotation.EntitleTotal = 0;
                vm.quotation.PublicTotal = 0;
                vm.quotation.QuotationItems = [];
            }

            vm.package = common.config.requestInformation.SelectedPackage;

            common.displayLoadingScreen();

            promise = getProductsInPackage();

            promise.finally(function () {
                common.hideLoadingScreen();
                $('#cotizar').addClass("disabled");
            });
        }

        function getProductsInPackage() {
            var promise = null;

            promise = productsInPackageDataService.getProductsInPackage(common.config.requestInformation.MortuaryId, vm.package.PackageId);

            promise.success(function (data, status, headers, config) {
                vm.productsInPackage = data;
                initProductType();
            }).error(function (data, status, headers, config) {
                common.showErrorMessage(data, Messages.error.getPackages);
                vm.error = true;
            });

            return promise;
        }

        function addItemToQuotation(productType, product) {

            productType.isSelected = true;

            vm.quotation.QuotationItems.push({
                SirvelProductId: product.ProductFromSirvel.IdProductServcie,
                Name: product.ProductFromSirvel.Name,
                Description: product.ProductFromSirvel.Description,
                EntitlePrice: product.ProductFromSirvel.EntitlePrice,
                PublicPrice: product.ProductFromSirvel.NoEntitlePrice,
                Quantity: 1,
                ServiceDescription: product.ProductFromSirvel.Description
            });

            productType.SelectedProductId = product.ProductFromSirvel.IdProductServcie;
            productType.SelectedPriceIssste = product.ProductFromSirvel.EntitlePrice;
            productType.SelectedPricePublic = product.ProductFromSirvel.NoEntitlePrice;

            vm.quotation.EntitleTotal += product.ProductFromSirvel.EntitlePrice;
            vm.quotation.PublicTotal += product.ProductFromSirvel.NoEntitlePrice;

            //vm.quotation.EntitleTotal = vm.quotation.EntitleTotal.toFixed(2);
            //vm.quotation.PublicTotal = vm.quotation.PublicTotal.toFixed(2);


            if (vm.quotation.QuotationItems.length == vm.productsInPackage.length)
                $('#cotizar').removeClass("disabled");

            $("html, body").animate({ scrollTop: 700 }, 2000);
        }

        function removeItemFromQuotation(productType) {
            for (var i = 0; i < vm.quotation.QuotationItems.length; i++) {
                if (vm.quotation.QuotationItems[i].SirvelProductId == productType.SelectedProductId) {
                    vm.quotation.QuotationItems.splice(i, 1);
                    vm.quotation.EntitleTotal -= productType.SelectedPriceIssste;
                    vm.quotation.PublicTotal -= productType.SelectedPricePublic;
                    productType.isSelected = false;

                    $('#cotizar').addClass("disabled");
                }
            }
        }

        function isProductTypeSelected(productType) {
            return productType.isSelected;
        }


        function initProductType() {
            for (var i = 0; i < vm.productsInPackage.length; i++) {
                vm.productsInPackage[i].ProductType.isSelected = false;
            }
        }

        function sendToConfirmation(navigate) {
            var infoQuotation = {
                Quotation: vm.quotation,
                IsEntitle: common.config.isEntitle,
                UserId: common.config.entitleInformation.CURP
            };

            common.config.requestInformation.infoQuotation = infoQuotation;

            navigate();
        }

    }


})();