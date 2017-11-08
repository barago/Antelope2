var dateTimeUtils = dateTimeUtils || {};

(function (service) {

    service.dateFormatJS = function (date) {
        var dateFormated = '';
        if (date != null) {
            dateFormated = date.substring(8, 10) + '/' + date.substring(5, 7) + '/' + date.substring(0, 4);
        }
        return dateFormated;
    };

    service.heureFormatJS = function (date) {
        var heureFormated = '';
        if (date != null) {
            heureFormated = date.substring(11, 16);
        }
        return heureFormated;
    };

    service.dateFormatMVC = function (date) {
        // De date FR à DateTime
        var dateFormated = date.substring(6, 10) + '-' + date.substring(3, 5) + '-' + date.substring(0, 2);
        return dateFormated;
    }

    service.dateTimeFormatMVC = function(date) {
        var dateFormated;
        if (date == '') {
            dateFormated = '';
        }
        else {
            dateFormated = date.substring(6, 10) + '-' + date.substring(3, 5) + '-' + date.substring(0, 2) + 'T' + '00:00:00.0';
        }
        return dateFormated;
    }

})(dateTimeUtils);

