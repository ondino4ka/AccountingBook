window.Search = function () {

    var _inProgress = false;

    function MakeSearch(subjectName, categoryId, stateId) {
        var _subjectName = subjectName
        var _categoryId = categoryId;
        var _stateId = stateId;
        if (!_inProgress) {
            $.ajax({
                url: '/Subject/GetSubjectsByNameCategoryIdAndStateId',
                type: 'POST',
                data: {
                    categoryId: _categoryId,
                    stateId: _stateId,
                    subjectName: _subjectName
                },
                beforeSend: function () {
                    _inProgress = true;
                    $('#before-load').show();
                },
                success: function (result) {
                    $('#content').html(result);
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