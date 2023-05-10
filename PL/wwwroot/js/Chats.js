"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendPrivateButton").disabled = true;

connection.on("ReceivePrivateMessage", function (fromUser, message) {
    var msg = fromUser + ": " + message;
    var li = document.createElement("li");
    li.textContent = msg;
    document.getElementById("messageList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendPrivateButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendPrivateButton").addEventListener("click", function (event) {
    var user = document.getElementById("private-user").value;
    var message = document.getElementById("private-message").value;
    connection.invoke("SendPrivateMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("getHistoryButton").addEventListener("click", function (event) {
    var user = document.getElementById("private-user").value;
    connection.invoke("GetHistory", user).then(function (history) {
        debugger;
        var messages = JSON.parse(history);
        var messageList = document.getElementById("messageList");
        messageList.innerHTML = '';
        for (var i = 0; i < messages.length; i++) {
            var msg = messages[i].fromUser + ": " + messages[i].message;
            var li = document.createElement("li");
            li.textContent = msg;
            messageList.appendChild(li);
        }
    });
    event.preventDefault();
});