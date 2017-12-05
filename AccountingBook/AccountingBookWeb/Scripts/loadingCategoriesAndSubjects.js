$(function () {
    $("#categoriesBar").load('/Category/CategoriesBar');
})

function getSubjectsByCategoryId(categoryId, categoryName) {
    $("[name=category]").text("Category: " + name);
    $('#before-load').show();   
    $("#content").load('/Subject/Subjects?categoryId=' + categoryId, function (responseText, textStatus, XMLHttpRequest) {
        $('#before-load').find('i').fadeOut().end().delay(400).fadeOut('slow');
    })
};

function getDetailsSubject(inventoryNumber) {
    $("#content").load('/Subject/ViewSubject?inventoryNumber=' + inventoryNumber);
};
