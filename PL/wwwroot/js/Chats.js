const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

connection.on("ReceiveMessage", (user, message) => {
    const encodedMessage = $("<div>").text(`${user}: ${message}`);
    $("#messagesList").append(encodedMessage);
});

connection.start().catch(err => console.error(err.toString()));

$("#sendButton").on("click", () => {
    const user = $("#userInput").val();
    const message = $("#messageInput").val();
    connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
});

// Add a click event listener for contacts
$("#contactsList").on("click", "li", function () {
    const contactId = $(this).data("contact-id");

    // Clear the existing messages and load the new conversation
    $("#messagesList").empty();
    loadConversation(contactId);

    // Set the selected contact as active
    $("#contactsList li").removeClass("active");
    $(this).addClass("active");
});

// Function to load a conversation with a given contactId
function loadConversation(contactId) {
    // Load messages from the server and populate the chat area
    // You can call your API to get the conversation data and append it to the messagesList
}