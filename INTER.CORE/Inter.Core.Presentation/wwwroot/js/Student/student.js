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

    //var edit = function () {

    //    var student = $('#studentData').serialize();

    //    Util.request('/Student/Edit', 'POST', student, true, function (data) {

    //    }), function (request, status, error) {

    //    };
    //};

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



    return { create, loadingList, popUpConfirmDelete, confirmDelete };

}();