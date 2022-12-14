$(document).ready(function () {
    SearchBookTransaction();
});
function SearchBookTransaction() {
    var first = $('#firstDate').val();
    var second = $('#secondDate').val();

    $.ajax({
        url: "/booktransaction/search",
        data: { first, second },
        success: function (data) {
            CreateDataTable(data.data);
        }
    });
}
function CreateDataTable(data) {
    $('#bookTransactionList').DataTable({
        destroy: true,
        data: data,
        columns: [
            { data: "book" },
            { data: "member" },
            { data: "createDateString" },
            { data: "returnDateString" },
            { data: "penalty" }
        ]
    });
}
var today = new Date();
var dd = ("0" + (today.getDate())).slice(-2);
var mm = ("0" + (today.getMonth() + 1)).slice(-2);
var yyyy = today.getFullYear();
var mmm = ("0" + (today.getMonth())).slice(-2);
today = yyyy + '-' + mm + '-' + dd;
var beforeDate = yyyy + '-' + mmm + '-' + dd;
$("#firstDate").attr("value", beforeDate);
$("#secondDate").attr("value", today);

