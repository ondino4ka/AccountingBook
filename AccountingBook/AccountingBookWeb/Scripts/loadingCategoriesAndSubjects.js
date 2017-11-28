$(function () {
    $("#categoriesBar").load('/Category/CategoriesBar');
})

function getSubjectsById(id, name, isCategory) {       
        $("[name=category]").text("Category: " + name);
        $("#content").load('/Subject/Subjects?id=' + id + '&isCategory=' + isCategory)
    
};

function getDetailsSubject(inventoryNumber) {
    $("#content").load('/Subject/ViewSubject?inventoryNumber=' + inventoryNumber);
};
