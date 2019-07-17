var accomodation = function () {

    var loadingPage = function () {

        var dayPilotLoading = function () {

            let accomodationId = $('#accomodationId').val();

            Util.request('/Accomodation/GetReservationByAccomodationId', 'POST', { accomodationId }, 'json', true, function (data) {


            }, function (request, status, error) {

            });

            var dp = new DayPilot.Month("dp-calendar");

            for (var i = 0; i < 10; i++) {

                var duration = Math.floor(Math.random() * 1.2);
                var start = Math.floor(Math.random() * 6) - 3; // -3 to 3

                var e = new DayPilot.Event({
                    start: new DayPilot.Date("2013-03-04T00:00:00").addDays(start),
                    end: new DayPilot.Date("2013-03-04T12:00:00").addDays(start).addDays(duration),
                    id: DayPilot.guid(),
                    text: "Event " + i
                });
                dp.events.add(e);

                dp.onEventClicked = function (args) {
                    alert("clicked: " + args.e.id());
                };

                dp.init();
            }

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

        dayPilotLoading();

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

    return { getModalUpdateDate, updateDate };

}();