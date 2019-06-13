var college = function () {

    var saveCollegeTime = function () {

        var collegeTime = $('#form-create-collegeTime').serialize();

        Util.request('/College/CreateTimeCollege', 'POST', collegeTime, 'JSON', false, function (data) {

            if (data === 200) {
                $('#description').append(`College Time included`);

                $('#sub-information').append(`Time`);
                $('#modalSuccess').modal('show');

                setTimeout(function () {
                    location.reload();
                }, 2000);
            }

        }, function (request, status, error) {

        });
    };

    var createCollegeTime = function () {

        var collegeTime = $('#form-create-collegeTime').serialize();

        Util.request('/College/CreateTimeCollege', 'POST', collegeTime, 'JSON', false, function (data) {

            if (data === 200) {
                $('#description').append(`College Edited`);

                $('#sub-information').append(`Time`);
                $('#modalSuccess').modal('show');

                setTimeout(function () {
                    location.reload();
                }, 2000);
            }

        }, function (request, status, error) {

        });

    };

    var create = function () {

        var college = $('#form-create-college').serialize();

        Util.request('/College/Create', 'POST', college, 'JSON', false, function (data) {

            $('#description').append(`College Included`);
            $('#sub-information').append(`${data.collegeName}`);
            $('#modalSuccess').modal('show');

            setTimeout(function () {
                let url = '/College/Index';
                window.location.href = url;
            }, 2000);

        }, function (request, status, error) {

        });
    };

    var edit = function () {

        var college = $('#form-edit-college').serialize();

        Util.request('/College/Edit', 'POST', college, 'JSON', false, function (data) {

            location.reload();

        }, function (request, status, error) {

        });
    };

    var editCollegeTime = function (idCollegeTime) {

        Util.request('/College/LoadingPartialEditCollegeTime', 'GET', { idCollegeTime }, 'html', true, function (data) {

            $('#div-modal-edit-college-time').append(data);
            $('#div-modal-edit-college-time').modal('show');

        }, function (request, status, error) {

        });
    };

    var openModalAddCollegeTime = function () {

        let collegeId = $('#collegeId');

        $('#div-modal-edit-college-time #modal').remove();

        Util.request('/College/GetPartialCreateCollegeTime', 'GET', collegeId, 'html', true, function (data) {

            $('#div-modal-edit-college-time').append(data);
            $('#div-modal-edit-college-time').modal('show');

        }, function (request, status, error) {

        });
    };

    var popUpConfirmDeleteCollegeTime = function (id) {
        $('#modalDelete').modal('show');
        $('#deleteButton').attr('onclick', `college.deleteConfirmCollegeTime(${id})`);
    };

    var deleteConfirmCollegeTime = function (id) {
        console.log(id);
        Util.request('/College/DeleteConfirmedTimeCollege', 'GET', { id }, 'json', true, function (data) {

            location.reload();

        }, function (request, status, error) {

        });
    };

    return { create, edit, saveCollegeTime, editCollegeTime, openModalAddCollegeTime, createCollegeTime, deleteConfirmCollegeTime, popUpConfirmDeleteCollegeTime };
}();