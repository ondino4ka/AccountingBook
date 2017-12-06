function getSubjectDetails(inventoryNumber) {
    $("#content").load('/Subject/ViewSubject?inventoryNumber=' + inventoryNumber);
};
