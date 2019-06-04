var student = function () {

    var create = function () {

        var student = $('#studentData').serialize();

        console.log(student);

        //$.ajax({
        //    url: '/Student/Create/',
        //    type: 'POST',
        //    dataType: 'HTML',
        //    async: true,
        //    //cache: false,
        //    data: {
        //        studentViewModel: $('#studentData').serialize()
        //    },
        //    contentType: 'application/json',
        //    success: function (data) {
       
        //    }, error: function (request, status, error) {
               
        //    }
        //});

        Util.request('/Student/Create/', 'POST', { student }, 'JSON', true, function (data) {

        }, function (request, status, error) {

        });
    };

    return { create };
}();