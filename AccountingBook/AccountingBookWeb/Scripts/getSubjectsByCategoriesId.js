window.Subject = function () {

    var _inProgress = false;

    function GetSubjectsByCategoryId(categoryId, categoryName) {
        var _categoryId = categoryId;
        var _categoryName = categoryName;
        $("[name=category]").text("Category: " + categoryName);
        $('#before-load').show();
        if (!_inProgress) {
            console.log("jdu");
            $.ajax({
                url: '/Subject/GetSubjectsByCategoryId',
                type: 'GET',
                data: {
                    categoryId: _categoryId
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
    };

    return {
        GetSubjectsByCategoryId: GetSubjectsByCategoryId
    };
}
