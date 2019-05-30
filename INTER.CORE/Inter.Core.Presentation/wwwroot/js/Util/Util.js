
var Util = function () {

    function request(endpoint, type, param, dataType, callbackSuccess, callbackError) {

        $.ajax({
            url: endpoint,
            type: type,
            dataType: dataType,
            cache: false,
            data: param,
            success: function (data) {
                callbackSuccess(data);
            }, error: function (request, status, error) {
                callbackError(request, status, error);
            }
        });
    };

    return { request }
}();