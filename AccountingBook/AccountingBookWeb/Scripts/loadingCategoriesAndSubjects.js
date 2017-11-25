﻿
$(function () {
    $("#categoriesBar").load('/Home/CategoriesBar');
})

function getSubjectsById(objectCategory, isCategory) {
    if (objectCategory != null) {
        $("[name=category]").text("Category: " + objectCategory.text);
        $("#content").load('/Home/Subjects?id=' + objectCategory.id + '&isCategory=' + isCategory)
    }
};

function getDetailsSubject(InventoryNumber) {
    $("#content").load('/Home/ViewSubject?inventoryNumberSubject=' + InventoryNumber);
};