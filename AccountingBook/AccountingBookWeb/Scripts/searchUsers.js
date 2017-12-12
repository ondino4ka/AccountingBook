window.Search = function () {

    var _inProgress = false;

    function MakeSearch(userName) {
        var _userName = userName
        if (!_inProgress) {
            console.log(1231321);
            $.ajax({
                url: '/User/GetUsersByName',
                type: 'GET',
                data: {
                    userName: _userName
                },
                beforeSend: function () {
                    _inProgress = true;
                    $('#before-load').show();
                },
                success: function (result) {
                    $("#users").html(result);
                },
                complete: function () {
                    _inProgress = false;
                    $('#before-load').fadeOut('slow').delay(400);
                }
            });
        }
    }

    return {
        MakeSearch: MakeSearch
    };
}