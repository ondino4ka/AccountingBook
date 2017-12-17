function getSubjectDetails(inventoryNumber) {
    $("#content").load('/Subject/ViewSubject?inventoryNumber=' + inventoryNumber);
};

function deleteSubjectByInventoryNumber(inventoryNumber) {
    event.stopPropagation();
    window.location = '/Subject/DeleteSubject?inventoryNumber=' + inventoryNumber;
};  
