
var Util = function () {

    $('#document').ready(function () {

        loadingPage();

    });

    var loadingPage = function () {

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

    var rgbSort = function () {

        var rgb = {
            x: 0,
            y: 0,
            z: 0
        };

        rgb.x = Math.floor(Math.random() * 256);
        rgb.y = Math.floor(Math.random() * 256);
        rgb.z = Math.floor(Math.random() * 256);

        return rgb;
    };

    return { request, rgbSort };

}();


