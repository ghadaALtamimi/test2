$('.deleteFolderModal').on('shown.bs.modal', function ()
{
    $('#CancelButton').focus();
});

$('.addGenreModal').on('shown.bs.modal', function () {
    $('#ContentPlaceHolder1_GenreTextBox').focus();
});

$('#popoverData').popover();
$('#popoverOption').popover({ trigger: "hover" });
 

function openModal() {
    $('.loginModal').modal('show');
    $('#UserNameTextBox').focus();
}

function openErrorModal() {
    $('.errorModal').modal('show');
}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}
