$(document).ready(function () {
    $('#booksTable').DataTable();
});

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

function editBook(id) {
    $.ajax({
        url: '/Books/Get/' + id,
        method: 'GET',
        success: function (data) {
            $('#bookEdit').append(data);
            //$.validator.unobtrusive.parse('#bookEdit');
            $('#datePicker').daterangepicker({
                "singleDatePicker": true,
                "showCustomRangeLabel": false,
            }, function (start, end, label) {
                console.log("New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')");
            });

            $('.selectpicker').selectpicker();
        }
    });
}