var student = function () {

    var create = function () {

        var student = $('#studentData').serialize();

        Util.request('/Student/Create/', 'POST', student, 'json', true, function (data) {

            if (data === 201) {
                return;
            }

        }, function (request, status, error) {

        });
    };

    var openModalImageUpload = function (studentId) {



    };


    return { create, openModalImageUpload };
}();