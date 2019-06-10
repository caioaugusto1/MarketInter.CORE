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
                    debugger;
                    $('#collegeTime').append(`<option value="${element.id}">${element.period}</option>`);
                });

            }, function (request, status, error) {

            });
        });

    };

    var create = function () {

        var culturalExchangeViewModel = $('#form-create-culturalExchange').serialize();

        Util.request('/CulturalExchange/OnCreate', 'POST', culturalExchangeViewModel, 'JSON', false, function (data) {

            if (data.statusCode === 409) {
                alert('eaeea');
            }

        }, function (request, status, error) {

        });

    };

    var popUpOpenModalFileUpload = function () {

        Util.request('/FileUpload/GetModalCulturalExchangeUploadFile', 'GET', null, 'html', true, function (data) {

            $('#modalHere').append(data);

            $('#fileUploadModal').modal('show');

        }, function (request, status, error) {

        });

    };

    loadingPage();

    return { create, popUpOpenModalFileUpload };
}();