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

                $('.collegeOption').remove();

                if (data.statusCode !== 404) {
                    $(data).each(function (index, element) {
                        $('#collegeTime').append(`<option class="collegeOption" value="${element.id}">${element.period}</option>`);
                    });
                }

            }, function (request, status, error) {

            });
        });

    };

    var create = function () {

        var culturalExchangeViewModel = $('#form-create-culturalExchange').serialize();

        Util.request('/CulturalExchange/OnCreate', 'POST', culturalExchangeViewModel, 'JSON', false, function (data) {

            //Conflict
            if (data.statusCode === 409) {
                $(data.value).each(function (index, element) {
                    $('#body-div').append($(`<p>${element.errorMessage}</p>`));
                });

                $('#modal-warning').modal('show');
            }

        }, function (request, status, error) {

        });

    };

    var popUpOpenModalFileUpload = function (culturalExchangeId) {

        Util.request('/FileUpload/GetModalCulturalExchangeUploadFile', 'GET', { culturalExchangeId }, 'html', true, function (data) {

            $('#modalCulturalExchangeFileUpload').append(data);

            $('#fileUploadModal').modal('show');

        }, function (request, status, error) {

        });

    };

    var find = function () {

        let startArrivalDate = $('#startDateArrival').val();
        let finishArrivalDate = $('#finishDateArrival').val();
        let collegeId = $('#college').val();
        let accomodationId = $('#accomodation').val();

        Util.request('/CulturalExchange/FindByFilter', 'GET', { startArrivalDate, finishArrivalDate, collegeId, accomodationId }, 'html', true, function (data) {
            $('#culturalExchangeTBody').remove();

            $('#dataTable').append(data);

        }, function (request, status, error) {

        });
    };

    var clearFilter = function () {
        $('#startDateArrival').val("");
        $('#finishDateArrival').val("");
        $("#college").val($("#college option:first").val());
        $("#accomodation").val($("#accomodation option:first").val());

        find();
    };

    loadingPage();

    return { create, popUpOpenModalFileUpload, find, clearFilter };
}();