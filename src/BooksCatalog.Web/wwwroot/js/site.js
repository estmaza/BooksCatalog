$(document).ready(function () {
    $('#booksTable').DataTable();
})

function cancelForm(form) {
    $('#' + form + 'Edit').empty();
}

function editAuthor(id) {
    $.ajax({
        url: '/Author/Get/' + id,
        method: 'GET',
        success: function (data) {
            $('#authorEdit').append(data);
        }
    });
}