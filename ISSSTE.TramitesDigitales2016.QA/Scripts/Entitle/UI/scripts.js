var ALERT_TEMPLATE = '<div class="alert alert-{0} {1}" role="alert"><button type="button" class="close" aria-label="Close"><span aria-hidden="true">&times;</span></button><span>{2}</span></div>';
var ALERT_TEMPLATE_WITH_TITLE = '<div class="alert alert-{0} {1}" role="alert"><button type="button" class="close" aria-label="Close"><span aria-hidden="true">&times;</span></button><strong>{2}</strong><br/><span>{3}</span></div>';
var ALERT_ID_TEMPLATE = 'alert-{0}';

var UI =
{
    getBaseUrl: function () {
        return $("#baseUrl").val()
    },
    initTabs: function () {
        $('.nav-tabs a').click(function (e) {
            e.preventDefault();
            $(this).tab('show');
        });
    },
    initToolTips: function () {
        $('.brWizard-dot').tooltip();
    },
    initPrintButtons: function () {
        $("#printButton").on("click", function () {

            var tabsInfo = [];
            var printContent = "";


            $(".bottom-buffer").map(function () {
                var name = $(this).text();

                var contentId = $(this).attr("href");
                var content = $(contentId).html();

                tabsInfo.push({ name: name, content: content });
            }).get();

            $(".list-group").map(function () {
                var name = $(this).text();

                var contentId = $(this).attr("href");
                var content = $(contentId).html();

                tabsInfo.push({ name: name, content: content });
            }).get();

            printContent += Constants.aboutPrintView.tabContentTemplate.format($("title").text());


            tabsInfo.forEach(function (actualTab) {
                printContent += Constants.aboutPrintView.tabContentTemplate.format(actualTab.name);
                // printContent += actualTab.content;
                printContent += Constants.aboutPrintView.tabSeparator;
            });

            var params = [
                'height=' + screen.height,
                'width=' + screen.width,
                'fullscreen=yes' // only works in IE, but here for completeness
            ].join(',');

            var winPrint = window.open('', '', params);
            winPrint.document.write(Constants.aboutPrintView.pageTemplate.format(printContent));

            window.managedPrint(winPrint);
        })
    },
    initNotifications: function () {

        var element = $('#theFixed');
        var originalY = element.offset().top;
        var height = element.height();
        var maxY = $('body').height() - height;
        var maxTop = $('body').outerHeight() - ($('#abl-closepage').position().top + $('#abl-closepage').outerHeight());

        var topMargin = 80;

        element.css('position', 'relative');

        $(window).on('scroll', function (event) {
            var scrollTop = $(window).scrollTop();

            element.css("top", scrollTop < originalY - topMargin ? 0 : scrollTop - originalY + topMargin);

            if (scrollTop > (maxY - maxTop - 100)) {
                element.css({
                    //position: 'absolute',
                    top: maxY - maxTop - height - 100
                });
            }
        });
    },
    createInfoMessage: function (message, title) {
        UI.createMessage('info', message, title, false)
    },
    createWarningMessage: function (message, title) {
        UI.createMessage('warning', message, title, false)
    },
    createSuccessMessage: function (message, title) {
        UI.createMessage('success', message, title, true)
    },
    createErrorMessage: function (message, title) {
        UI.createMessage('danger', message, title, false)
    },
    createMessage: function (alertClass, message, title, fadeOut) {
        var alertsContainer = $(".alerts");

        if (alertsContainer) {

            var alertId = ALERT_ID_TEMPLATE.format(Guid.newGuid());
            var alertMessage = "";

            if (message != null) {
                if (angular.isString(message))
                    alertMessage = message.replaceAll('\n', "<br />");
                else
                    alertMessage = JSON.stringify(message);
            }

            if (title)
                alertsContainer.append(ALERT_TEMPLATE_WITH_TITLE.format(alertClass, alertId, title, alertMessage));
            else
                alertsContainer.append(ALERT_TEMPLATE.format(alertClass, alertId, alertMessage));

            if (fadeOut) {
                window.setTimeout(function () {
                    $(".{0}".format(alertId)).fadeTo(500, 0, function () {
                        $(this).remove();
                    });
                }, 3000);
            }

            $(".{0}>.close".format(alertId)).on("click", function () {
                $(".{0}".format(alertId)).remove();
            });
        }
    }
};