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

            if (collegeId === "notselected") {

                $("#collegeTime").prop('disabled', true);
                return;
            }

            $("#collegeTime").prop('disabled', false);

            Util.request('/College/GetCollegeTimeByCollegeId', 'GET', { "collegeId": collegeId }, 'json', true, function (data) {

                $(data).each(function (index, element) {
                    $('#collegeTime').append(`<option value="${element.id}">${element.period}</option>`);
                });

            }, function (request, status, error) {

            });
        });

    };

    loadingPage();


    var create = function () {

        var culturalExchangeViewModel = $('#form-create-culturalExchange').serialize();

        Util.request('/CulturalExchange/OnCreate', 'POST', culturalExchangeViewModel, 'JSON', false, function (data) {

            if (data.statusCode === 409) {

            }

        }, function (request, status, error) {
        });

    };

    return { create };
}();