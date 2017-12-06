function getSubjectsByCategoryId(categoryId, categoryName) {
    $("[name=category]").text("Category: " + categoryName);
    $('#before-load').show();
    $("#content").load('/Subject/Subjects?categoryId=' + categoryId, function (responseText, textStatus, XMLHttpRequest) {
        $('#before-load').find('i').fadeOut().end().delay(400).fadeOut('slow');
    })
};
