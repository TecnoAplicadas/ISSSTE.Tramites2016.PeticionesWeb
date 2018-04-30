﻿var REQUEST_ID_PARAM = "requestId";
var MORTUARY_ID_PARAM = "mortuaryId";
var PACKAGE_ID_PARAM = "packageId";
var QUOTATION_ID_PARAM = "quatationId";

var JSON_CONTENT_TYPE = "application/json";

var Constants =
{
    documentTypes: {
        ine: 1,
        retiredId: 2,
        curp: 3,
        payment: 4
    },
    aboutPrintView: {
        pageTemplate: '<!DOCTYPE html><html><head><link href="https://framework-gb.cdn.gob.mx/assets/styles/main.css" rel="stylesheet"></head><body>{0}</body></html>',
        tabHeaderTemplate: '<h2>{0}</h2>',
        tabContentTemplate: '<h3>{0}</h3>',
        tabSeparator: '<br/>'
    }
};
