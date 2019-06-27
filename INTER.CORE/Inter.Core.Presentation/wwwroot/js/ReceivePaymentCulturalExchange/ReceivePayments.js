var receivePayments = function () {

    var popUpOpenModalFileUpload = function (id) {

        Util.request('/FileUpload/GetModalReceivePaymentsUploadFile', 'GET', { id }, 'html', true, function (data) {

            $('#modalReceivePaymentsFileUpload').append(data);

            $('#fileUploadModal').modal('show');

        }, function (request, status, error) {

        });
    };


    var loadingPage = function () {

        $('#dropDownCulturalExchange').change(function () {

            let id = $(this).val();

            if (id == 0)
                return;

            Util.request('/CulturalExchange/GetCustomerIdByCulturalExchangeId', 'POST', { id }, 'json', true, function (data) {

                $('#customerId').val(data);

            }, function (request, status, error) {

            });

        });
    };

    loadingPage();

    return { popUpOpenModalFileUpload };
}();