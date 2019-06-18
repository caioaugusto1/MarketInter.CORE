var receivePayments = function () {

    var popUpOpenModalFileUpload = function (id) {

        Util.request('/FileUpload/GetModalReceivePaymentsUploadFile', 'GET', { id }, 'html', true, function (data) {

            $('#modalReceivePaymentsFileUpload').append(data);

            $('#fileUploadModal').modal('show');

        }, function (request, status, error) {

        });
    };


    return { popUpOpenModalFileUpload };
}();