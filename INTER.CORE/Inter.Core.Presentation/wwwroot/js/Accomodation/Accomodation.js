var accomodation = function () {

    var getModalUpdateDate = function (culturalExchangeId) {

        if ($('.modal-date').length >= 1) {
            $('.modal-date').remove();
        }

        Util.request('/Accomodation/GetModalUpdateDate', 'GET', { culturalExchangeId }, 'html', true, function (data) {

            $('#divModalUpdateDateAccomodation').append(data);

            $('#modalDate').modal('show');

        }, function (request, status, error) {

        });
    };

    var updateDate = function () {
        
        var culturalExchangeId = $('#culturalExchangeId').val();
        var start = $('#startdate').val();
        var finish = $('#finishDate').val();

        var d1 = new Date(start);
        var d2 = new Date(finish);
        
        if (d1 >= d2) {
            alert('salve');
            return;
        }

        Util.request('/Accomodation/UpdateDateStartAndFinish', 'GET', { culturalExchangeId, start, finish }, 'json', true, function (data) {
            debugger;
            if (data == 200) {
                setTimeout(function () {
                    location.reload();
                }, 2000);
            }

        }, function (request, status, error) {

        });
    };

    return { getModalUpdateDate, updateDate };

}();