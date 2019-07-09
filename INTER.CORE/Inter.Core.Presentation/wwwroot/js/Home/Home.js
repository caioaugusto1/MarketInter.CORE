var home = function () {

    var loadingPage = function () {
        
        Util.request('/CulturalExchange/HomeGetInfoDashboard', 'POST', null, 'json', true, function (data) {

            $('#culturalExchangeDashboardTotal').text(data.totalThisMonth);

            loadingOverviewGraphicsSaleLast12Month(data.totalPerMonth);

        }, function (request, status, error) {

        });
    };

    loadingPage();
}();