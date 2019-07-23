var culturalExchange = function () {

    $(function () {
        loadingPage();
    });


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

        $('#renew').click(function () {

            if ($(this).is(':checked')) {
                $('#company').prop('disabled', true);
                $('#flightNumber').prop('disabled', true);
                $('#arrivalDateTime').prop('disabled', true);
            } else {
                $('#company').prop('disabled', false);
                $('#flightNumber').prop('disabled', false);
                $('#arrivalDateTime').prop('disabled', false);
            }
        });

        $('#flyTicket').click(function () {

            if ($(this).is(':checked')) {
                $('#company').prop('disabled', false);
                $('#flightNumber').prop('disabled', false);
                $('#arrivalDateTime').prop('disabled', false);

                if ($('#accomodationIncludedCheck').is(':checked')) {
                    $('#fakeDateAccomodation').prop('disabled', false);
                }
            } else {
                $('#company').prop('disabled', true);
                $('#flightNumber').prop('disabled', true);
                $('#arrivalDateTime').prop('disabled', true);
                $('#fakeDateAccomodation').prop('disabled', true);

            }
        });

    };

    var create = function () {

        if ($('.accomodationDate').val() !== undefined) {
            $('#startAccomodation').val($('.accomodationDate').val().split('-')[0]);
            $('#finishAccomodation').val($('.accomodationDate').val().split('-')[1]);
        }

        var culturalExchangeViewModel = $('#form-create-culturalExchange').serialize();

        Util.request('/CulturalExchange/OnCreate', 'POST', culturalExchangeViewModel, 'JSON', false, function (data) {

            //Conflict
            if (data.statusCode === 409) {
                $(data.value).each(function (index, element) {
                    $('#body-div').append($(`<p>${element.errorMessage}</p>`));
                });

                $('#modal-warning').modal('show');
            } else {

                $('#description').append('Cultural Exchange Included in System');
                $('#modalSuccess').modal('show');

                setTimeout(function () {
                    let url = '/CulturalExchange/Index';
                    window.location.href = url;
                }, 2000);
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
        let startDate = $('#startDate').val();
        let startDateFinish = $('#finishDate').val();

        Util.request('/CulturalExchange/FindByFilter', 'GET', { startArrivalDate, finishArrivalDate, startDate, startDateFinish, collegeId, accomodationId }, 'html', true, function (data) {
            $('#culturalExchangeTBody').remove();

            $('#dataTable').append(data);

        }, function (request, status, error) {

        });
    };

    var clearFilter = function () {
        $('#startDateArrival').val("");
        $('#finishDateArrival').val("");
        $('#startDate').val("");
        $('#finishDate').val("");
        $("#college").val($("#college option:first").val());
        $("#accomodation").val($("#accomodation option:first").val());

        find();
    };

    var popUpConfirmDeleteFile = function (id, fileName, culturalExchangeId) {

        $('#modalDelete').modal('show');
        $('#deleteButton').attr('onclick', `culturalExchange.confirmDeleteFile('${id}', '${fileName}', '${culturalExchangeId}')`);
    };

    var confirmDeleteFile = function (id, fileName, culturalExchangeId) {

        Util.request('/FileUpload/CulturalExchangeDeleteFile', 'GET', { id, fileName, culturalExchangeId }, 'json', true, function (data) {
            setTimeout(function () {
                location.reload();
            }, 2000);

        }, function (request, status, error) {

        });
    };

    var confirmInactive = function (id) {

        Util.request('/CulturalExchange/Inactive', 'GET', { id }, 'json', true, function (data) {
            setTimeout(function () {
                let url = '/CulturalExchange/Index';
                window.location.href = url;
            }, 2000);

        }, function (request, status, error) {

        });
    };

    var popUpConfirmInactive = function (id) {
        $('#modalDelete').modal('show');
        $('#deleteButton').attr('onclick', `culturalExchange.confirmInactive('${id}')`);
    };



    return { create, popUpOpenModalFileUpload, find, clearFilter, popUpConfirmDeleteFile, confirmDeleteFile, popUpConfirmInactive, confirmInactive };
}();