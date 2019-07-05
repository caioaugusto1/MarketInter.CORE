var paymentCulturalExchange = function () {

    var loadingPage = function () {

        $('#dropDownCulturalExchange').change(function () {

            let id = $(this).val();

            if (id == 0)
                return;

            Util.request('/CulturalExchange/GetCustomerIdByCulturalExchangeId', 'POST', { id }, 'json', true, function (data) {
                alert('eaeaee')
                $('#customerId').val(data);

            }, function (request, status, error) {

            });

        });
    };

    loadingPage();

}();