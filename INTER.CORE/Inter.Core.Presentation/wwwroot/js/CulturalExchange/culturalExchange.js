var culturalExchange = function () {

    var loadingPage = function () {

        $('#accomodationIncludedCheck').click(function () {

            if (!$(this).is(':checked')) {
                $('.date-accomodation').prop("disabled", true);
            } else {
                $('.date-accomodation').prop("disabled", false);
            }
        });


        $('#college').change(function () {

            let collegeId = $(this).val();

            Util.request('/College/GetCollegeTimeByCollegeId', 'GET', { "collegeId": 1 }, 'json', true, function (data) {

            }, function (request, status, error) {

            });
        });

    };

    loadingPage();

    return {};
}();