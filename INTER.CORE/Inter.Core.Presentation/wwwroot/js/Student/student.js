var student = function () {

    var create = function () {

        var student = $('#studentData').serialize();
        
        Util.request('/Student/OnCreate/', 'POST', student, 'json', true, function (data) {

            alert('included');

        }, function (request, status, error) {

        });
    };

    return { create };
}();