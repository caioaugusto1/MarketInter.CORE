var accomodation = function () {

    var loadingPage = function () {
        
    };

    var dayPilotLoading = function (startDate, finishDate) {

        let accomodationId = $('#accomodationId').val();

        Util.request('/Accomodation/GetReservationByAccomodationId', 'GET', { accomodationId, startDate, finishDate }, 'json', true, function (data) {

            if (data.statusCode === 200) {

                buildCalendar(data, startDate, finishDate);
            }
        }, function (request, status, error) {

        });


        var buildCalendar = function (data, startDate, finishDate) {

            var dp = new DayPilot.Month("dp-calendar");

            dp.startDate = startDate;

            $(data.value).each(function (index, element) {

                var rgbColor = Util.rgbSort();

                var e = new DayPilot.Event({
                    start: new DayPilot.Date(element.startAccomodation),
                    end: new DayPilot.Date(element.finishAccomodation),
                    id: DayPilot.guid(),
                    text: element.studentViewModel.customerId + ' - ' + element.studentViewModel.fullName,
                    backColor: "rgb(" + rgbColor.x + "," + rgbColor.y + "," + rgbColor.z + " )",
                    fontColor: 'white'
                });

                dp.events.add(e);

                //dp.onEventMoved = function (args) {
                //    args.e.text();
                //};

                //dp.onEventClicked = function (args) {
                //    alert("clicked: " + args.e.id());
                //};

                dp.init();
            });
        };


        // view
        //dp.startDate = "2013-03-25";  // or just dp.startDate = "2013-03-25";

        // generate and load events


        // event creating on calendar
        //dp.onTimeRangeSelected = function (args) {
        //    var name = prompt("New event name:", "Event");
        //    dp.clearSelection();
        //    if (!name) return;
        //    var e = new DayPilot.Event({
        //        start: args.start,
        //        end: args.end,
        //        id: DayPilot.guid(),
        //        text: name
        //    });
        //    dp.events.add(e);
        //};

    };

    var clearFilterDetailsAccomodation = function () {
        $('#startAccomodationDate').val('');
        $('#finishAccomodationDate').val('');
        $('#dp-calendar div').remove();
    };

    var findDetailsAccomodationByFilter = function () {

        let startDate = $('#startAccomodationDate').val();
        let finishDate = $('#finishAccomodationDate').val();

        var vstartDate = new Date(startDate);
        var vfinishDate = new Date(finishDate);

        if (vstartDate >= vfinishDate)
            return;

        dayPilotLoading(startDate, finishDate);

    };

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

            if (data === 200) {
                setTimeout(function () {
                    location.reload();
                }, 2000);
            }

        }, function (request, status, error) {

        });
    };

    loadingPage();

    return { getModalUpdateDate, updateDate, clearFilterDetailsAccomodation, findDetailsAccomodationByFilter };

}();