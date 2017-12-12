function initSelect2Categories(selector) {
    $(selector).select2({
        placeholder: "-- All Categories --",
        allowClear: true,
        minimumInputLength: 2,
        ajax: {
            url: '/Category/GetCategoriesByName',
            dataType: 'json',
            data: function (params) {
                var query = {
                    categoryName: params.term
                }
                return query;
            },
            processResults: function (data) {
                var items = $.map(data, function (item) {
                    return {
                        id: item.Id,
                        text: item.Name,
                    };
                });
                return { results: items };
            }
        }
    });
};
$.ajax({
    url: '/Subject/GetStates',
    success: function (data) {
        var opts = '<option>-- All States --</option>';
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