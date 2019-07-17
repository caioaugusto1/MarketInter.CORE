var student = function () {

    var create = function () {

        var student = $('#studentData').serialize();

        Util.request('/Student/Create/', 'POST', student, 'json', true, function (data) {

            if (data.statusCode === 200) {

                $('#description').append(`Student Included`);
                $('#sub-information').append(`${data.studentName}`);
                $('#modalSuccess').modal('show');
                setTimeout(function () {
                    let url = '/Student/Index';
                    window.location.href = url;
                }, 2000);
            }

        }, function (request, status, error) {

        });
    };

    var loadingList = function () {

        Util.request('/Student/Index/', 'GET', null, 'html', true, function (data) {

        }, function (request, status, error) {

        });
    };

    var popUpConfirmDelete = function (studentId) {
        $('#modalDelete').modal('show');
        $('#deleteButton').attr('onclick', `student.confirmDelete('${studentId}')`);
    };


    var confirmDelete = function (studentId) {

        Util.request('/Student/DeleteConfirmed/', 'GET', { studentId }, 'json', true, function (data) {

            if (data.statusCode === 200) {

                setTimeout(function () {
                    let url = '/Student/Index';
                    window.location.href = url;
                }, 2000);
            }

        }, function (request, status, error) {

        });
    };

    var dp = new DayPilot.Month("dp");

    // view
    dp.startDate = "2013-03-25";  // or just dp.startDate = "2013-03-25";

    // generate and load events
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
    }

    // event creating
    dp.onTimeRangeSelected = function (args) {
        var name = prompt("New event name:", "Event");
        dp.clearSelection();
        if (!name) return;
        var e = new DayPilot.Event({
            start: args.start,
            end: args.end,
            id: DayPilot.guid(),
            text: name
        });
        dp.events.add(e);
    };

    dp.onEventClicked = function (args) {
        alert("clicked: " + args.e.id());
    };

    dp.init();

    return { create, loadingList, popUpConfirmDelete, confirmDelete };

}();