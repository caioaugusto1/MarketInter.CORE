
var Util = function () {

    var loading = function () {

        $('.dateRangePicker').daterangepicker({
            locale: {
                format: 'DD/MM/YYYY'
            }
        });

        $('.dateRangePicker').val('');
    };


    function request(endpoint, type, param, dataType, async, callbackSuccess, callbackError) {

        $.ajax({
            url: endpoint,
            type: type,
            data: param,
            dataType: dataType,
            async: async,
            //cache: false,
            success: function (data) {
                callbackSuccess(data);
            }, error: function (request, status, error) {
                callbackError(request, status, error);
            }
        });
    };

    loading();

    return { request };
}();

