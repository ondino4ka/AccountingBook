function initSelect2Categories(selector) {
    var _selectHtml;
    $.ajax({
        url: '/Category/GetCategoriesByName?categoryName=',
        dataType: 'json',
        success: function (data) {
            _selectHtml = '<option value="0">-- All Categories --</option><option value="">-- Without Categories --</option>';
            for (var i = 0; i < data.length; i++) {
                _selectHtml += '<option value="' + data[i].Id + '">' + data[i].Name + '</option>';
                console.log(_selectHtml)
            }        
        },
        error: function(jqXHR, textStatus, errorThrown){
            _selectHtml = '<option>Now the server is unavailable. Try later</option>';
        },
        complete: function(){
            $("#" + selector).append(_selectHtml);
            $("#" + selector).select2({});
        }
    });
};


$.ajax({
    url: '/Subject/GetStates',
    success: function (data) {
        var opts = '<option value=0>-- All States --</option><option>-- Without States --</option>';
        for (var i = 0; i < data.length; i++) {
            opts += '<option value="' + data[i].Id + '">' + data[i].StateName + '</option>';
        }
        $('#stateId').append(opts);
    },
    error: function (jqXHR, textStatus, errorThrown) {
        var opts = '<option>Now the server is unavailable. Try later</option>';
        $('#stateId').append(opts);
    }
});