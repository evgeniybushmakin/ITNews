"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/commentHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (message, commentId) {
    if (message != "") {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var username = document.getElementById("userName").value;
        if (username == "") {
            alert("Please LogIn")
        }
        else {
            var template = $('#hidden-template').html();
            var item = $(template).clone();
            $(item).find('#content').html(msg);
            item.find('.btn-sm').on('click', (event) => like(commentId, event));
            $('#target').append(item);
            document.getElementById('messageInput').value = "";
        }
    }
    else {
        return;
    }
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    var postId = document.getElementById("postId").value;
    var userId = document.getElementById("userId").value;
    connection.invoke("SendMessage", message, postId, userId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});