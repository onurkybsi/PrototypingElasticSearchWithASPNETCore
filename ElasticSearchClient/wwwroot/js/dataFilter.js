$(document).ready(function () {
    $("#myInput").keypress(function (e) {
        $.ajax({
            url: "http://localhost:5001/api/ElasticSearch/" + e.key,
            method: "GET",
            success: function (data) {
                listData(data);
            }
        })
    });
});

var listData = function (data) {
    $("#myUL").append("<li>" +
        data["firstName"] +
        "</li>");
};
