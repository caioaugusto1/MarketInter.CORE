var home = function () {

    var loadingPage = function () {
        
        Util.request('/CulturalExchange/GetAllLast12MonthToShowGraphics', 'POST', null, 'json', true, function (data) {
            
            loadingOverviewGraphicsSaleLast12Month(data);

        }, function (request, status, error) {

        });
    };

    loadingPage();
}();