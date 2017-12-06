function initSelect2Categories(selector)
{
    $(selector).select2({
        placeholder: "-- Category --",
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
        console.log(data);
        var opts = '<option>-- State --</option>';
        for (var i = 0; i < data.length; i++) {
            opts += '<option value="' + data[i].Id + '">' + data[i].StateName + '</option>';
        }
        $('#stateId').append(opts);
    }
});