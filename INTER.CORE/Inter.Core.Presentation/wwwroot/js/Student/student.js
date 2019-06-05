var student = function () {

    var create = function () {

        var student = $('#studentData').serialize();

        Util.request('/Student/Create/', 'POST', student, 'json', true, function (data) {

            if (data.statusCode === 200) {

                $('#description').append(`Student Included`);
                $('#sub-information').append(`${student.studentName}`);
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

    var openModalImageUpload = function (studentId) {

    };


    return { create, openModalImageUpload, loadingList };
}();