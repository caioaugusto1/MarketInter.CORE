var college = function () {

    var loadingModalPartialInsertTimeCollege = function () {

        if ($('#saveButton').length >= 1) {
            $('#saveButton').remove();
        }



    };

    var saveCollegeTime = function () {

        var collegeTime = $('#form-create-collegeTime').serialize();

        Util.request('/College/CreateTimeCollege', 'POST', collegeTime, 'JSON', false, function (data) {
            debugger;

        }, function (request, status, error) {


        });
    };


    var create = function () {

        var college = $('#form-create-college').serialize();

        Util.request('/College/Create', 'POST', college, 'JSON', false, function (data) {

        }, function (request, status, error) {

        });
    };

    var saveButton = function () {

        return '<div class="form-group" id="saveButton"><div class="col-md-8 inputGroupContainer"><div class="input-group"><span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span><input onclick="college.loadingModalPartialPutTimeCollege();" type="button" value="Save" class="btn btn-primary"/></div></div></div>';
    };

    return { create, saveCollegeTime, loadingModalPartialInsertTimeCollege };
}();