window.Search = function () {

    var _inProgress = false;

    function MakeSearch(urlWithParameter, selectorContainer) {
        if (!_inProgress) {
            $.ajax({
                url: urlWithParameter,
                type: 'GET',             
                beforeSend: function () {
                    _inProgress = true;
                    $('#before-load').show();
                },
                success: function (result) {
                    $("#" + selectorContainer).html(result);
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