var college = function () {


    var saveCollegeTime = function () {

        var collegeTime = $('#form-create-collegeTime').serialize();

        Util.request('/College/CreateTimeCollege', 'POST', collegeTime, 'JSON', false, function (data) {
            
            if (data === 200) {
                $('#description').append(`College Time included`);
                $('#sub-information').append(`Time etc etc etc`);
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

        Util.request('/College/GetCollegeTime', 'GET', { idCollegeTime }, 'html', true, function (data) {

            $('#div-modal-edit-college-time').append(data);
            $('#div-modal-edit-college-time').modal('show');

        }, function (request, status, error) {

        });
    }
    

    return { create, saveCollegeTime, editCollegeTime };
}();