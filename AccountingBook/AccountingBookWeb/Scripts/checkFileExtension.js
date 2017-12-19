var extensions = ["jpeg", "jpg", "png"]

function checkFile() {
    var file = document.getElementById("upload").files[0];
    if (file != null) {

        var parts = file.name.split('.');
        if (parts.length > 1) {
            var fileExtension = parts.pop();
        }

        if (file.size > 10485760) {
            $("#fileError").text("File size:" + Math.round(file.size / 1024 / 1024) + "Mb" + ". Maximum file size is 10Mb");
            $('input[type="submit"]').prop('disabled', true);
        }
        else if (extensions.indexOf(fileExtension) == -1) {
            $("#fileError").text("Invalid file type: " + fileExtension + ". Valid file type: " + extensions.map(function (name) {
                return name;
            })
            );
            $('input[type="submit"]').prop('disabled', true);
        }
        else {
            $('input[type="submit"]').prop('disabled', false);
            $("#fileError").text("");
        }
    }
    else {
        $('input[type="submit"]').prop('disabled', false);
        $("#fileError").text("");
    }
}