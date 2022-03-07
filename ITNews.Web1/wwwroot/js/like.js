var connection1 = new signalR.HubConnectionBuilder().withUrl("/commentHub").build();
connection1.start();


$(".btn-sm").on("click", function (event) {
    var buttonId = $(this).attr("id");
    var commentId = document.getElementById("commentId" + " " + buttonId).value;
    var userId = document.getElementById("userId").value;
    if (userId == "") {
        alert("Please LogIn");
    }
    else {
        connection1.invoke("SendLike", commentId, userId, buttonId).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    }
});

connection1.on("ReceiveAction", function (action, buttonId) {
    if (action) {
        document.getElementById(buttonId).className = 'btn btn-info btn-sm';
        var count = document.getElementById("count" + " " + buttonId);
        var val = (parseInt(count.textContent) + 1).toString();
        count.innerHTML = val;
        
    }
    else {
        document.getElementById(buttonId).className = 'btn btn-default btn-sm';
        var count = document.getElementById("count" + " " + buttonId);
        var val = (parseInt(count.textContent) - 1).toString();
        count.innerHTML = val;
    }
});
