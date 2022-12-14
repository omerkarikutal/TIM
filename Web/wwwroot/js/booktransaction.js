function SearchBookTransaction() {
    var firstDate = $('#firstDate').val();
    var secondDate = $('#secondDate').val();

    $.ajax({
        url: "/booktransaction/search",
        data: { firstDate, secondDate },
        succes: function (data) {
            CreateDataTable(data.Data);
        }
    });
}
function CreateDataTable(data) {
    $('#bookTransactionList').DataTable({
        data: data,
        columns: [
            { data: "book" },
            { data: "author" },
            { data: "date" }
        ]
    });
}