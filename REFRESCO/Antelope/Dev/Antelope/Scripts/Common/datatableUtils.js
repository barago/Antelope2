var datatableUtils = datatableUtils || {};

(function (service) {

    service.getDatatableLength = function () {
        var datatableLengthRes = $.cookie('DATATABLE_LENGTH');
        if (!datatableLengthRes) {
            datatableLengthRes = 10;
        }
        return datatableLengthRes;
    };
 

})(datatableUtils);

