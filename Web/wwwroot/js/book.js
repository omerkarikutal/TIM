function SearchBook() {
    var bookName = $('#book').val();
    var authorName = $('#author').val();
    var isbn = $('#isbn').val();

    $.ajax({
        url: "/book/search",
        data: { bookName, authorName, isbn },
        succes: function (data) {
            CreateFormDataTable(data.Data);
        }
    });
}
function CreateFormDataTable(data) {
    $('#bookList').DataTable({
        data: data,
        columns: [
            { data: "book" },
            { data: "author" },
            { data: "isbn" }
        ]
    });
}
function Add() {
    var mode = {
        BookId: $('#book').val(),
        MemberId: $('#member').val()
    };

    $.ajax({
        url: "/book/add",
        data: mode,
        succes: function (data) {
        }
    });

}