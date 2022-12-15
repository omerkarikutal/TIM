$(document).ready(function () {
    SearchBook();
});
function SearchBook() {
    var bookName = $('#book').val();
    var authorName = $('#author').val();
    var isbn = $('#isbn').val();

    $.ajax({
        url: "/book/search",
        data: { bookName, authorName, isbn },
        success: function (data) {
            console.log(data);
            CreateFormDataTable(data.data);
        }
    });
}
function CreateFormDataTable(data) {
    $('#bookList').DataTable({
        data: data,
        destroy: true,
        columns: [
            { data: "name" },
            { data: "author" },
            { data: "isbn" },
            {
                render: function (data, type, row) {
                    return "<button onclick='Members(" + row.isbn + ");'>Üye Seç</button>";
                }
            }
        ]
    });
}
function Members(isbn) {
    $('#memberModal').modal('show');
    $('#isbn').val(isbn);
    $('input[name="isbn"]').val(isbn);
    $.ajax({
        url: '/book/memberlist',
        success: function (data) {
            if (data.status) {
                console.log(data.data);
                $.each(data.data, function (i, item) {
                    $('#memberDropdown').append('<option id=' + item.id + '>' + item.nameSurname + '</option>');
                });
            }
        }
    });

}

function SaveBookTransaction() {
    var isbn = $('#isbn').val();
    var member = $('#memberDropdown option:selected').attr("id");

    var model = {
        BookId: isbn,
        MemberId: member
    };

    $.ajax({
        url: "/book/add",
        method: "post",
        data: model,
        succes: function (data) {
            if (data.status) {
                SearchBook();
                $('#memberModal').modal('hide');
            }
            else {
                //alert çıkarılmalı
            }
        }
    });

}
