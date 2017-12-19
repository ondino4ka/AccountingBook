function initSelectsForSubject(selectContainer, selectUrl, selectId, selectedId, name) {
    var _selectHtml = "<select class=\"form-control\" id=\"" + [selectId] + "\"  name=\"" + [selectId] + "\"><option></option>";
    $.ajax({
        url: selectUrl,
        success: function (data) {
            console.log(data);
            var _selectedId = selectedId;
            for (var i = 0; i < data.length; i++) {
                if (_selectedId == data[i].Id) {
                    _selectHtml += "<option selected value=" + [data[i].Id] + ">" + [data[i][name]] + "</option>";
                }
                else {
                    _selectHtml += "<option value=" + [data[i].Id] + ">" + [data[i][name]] + "</option>";
                }
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            _selectHtml = 'Now the server is unavailable. Try later';
        },
        complete: function () {
            _selectHtml += "</select>";
            $("#" + selectContainer).prepend(_selectHtml);
            $("#" + selectId).select2({
                allowClear: true,
                placeholder: "Not chosen"
            });
        }
    });
};