var culturalExchange = function () {

    var loadingPage = function () {

        $('#accomodationIncludedCheck').click(function () {
            
            $('.date-accomodation').prop("disabled", true);
        });

    };

    loadingPage();

    return {  };
}();