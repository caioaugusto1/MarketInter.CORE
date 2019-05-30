var collegeCreate = function () {

    var loadingPartial = function () {

        if ($('#saveButton').length >= 1) {
            $('#saveButton').remove();
        }
            
        Util.request('/College/OnGetPartialCollegeTime', 'GET', null, 'html', function (data) {

            $('#table-create-college tbody tr td').append(data);
            
            $.when(saveButton).done(function (htmlButton) {
                $('#table-create-college tr td').append(htmlButton);
            });

            
        }, function (request, status, error) {

        });
    };

    var create = function () {

        var collegeForm = $('#table-create-college').serialize();
        var collegeTimeForm = $('.form-create-collegeTime').serialize();

        Util.request('/College/Create', 'POST', { collegeForm, collegeTimeForm }, 'JSON', function (data) {

        }, function (request, status, error) {

        });
    };

    var saveButton = function () {

        return '<div class="form-group" id="saveButton"><div class="col-md-8 inputGroupContainer"><div class="input-group"><span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span><input onclick="collegeCreate.create();" type="button" value="Save" class="btn btn-primary"/></div></div></div>';
    };

    return { create, loadingPartial };
}();