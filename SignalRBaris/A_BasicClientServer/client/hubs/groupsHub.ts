import * as signalR from "@microsoft/signalr";
export function configureGroupsHub() {

    let btnJoinIT = document.getElementById("btnJoinIT");
    let btnJoinMarketing = document.getElementById("btnJoinMarketing");
    let btnJoinFinance = document.getElementById("btnJoinFinance");
    let btnTriggerIT = document.getElementById("btnTriggerIT");
    let btnTriggerMarketing = document.getElementById("btnTriggerMarketing");
    let btnTriggerFinance = document.getElementById("btnTriggerFinance");

    // create connection
    let connection = new signalR.HubConnectionBuilder()
        .withUrl("/hub/groups")
        .build();

    btnJoinIT.addEventListener("click", () => { connection.invoke("JoinGroup", "IT"); });
    btnJoinMarketing.addEventListener("click", () => { connection.invoke("JoinGroup", "Marketing"); });
    btnJoinFinance.addEventListener("click", () => { connection.invoke("JoinGroup", "Finance"); });

    btnTriggerIT.addEventListener("click", () => { connection.invoke("SendMessageToGroup", "IT"); });
    btnTriggerMarketing.addEventListener("click", () => { connection.invoke("SendMessageToGroup", "Marketing"); });
    btnTriggerFinance.addEventListener("click", () => { connection.invoke("SendMessageToGroup", "Finance"); });

    // client events
    connection.on("GroupMessage", (message) => {
        let dateTime = new Date()
        document.getElementById("groupmessages").innerText += message + ' - ' + dateTime.toUTCString;
    });

    // start the connection
    function startSuccess() {
        console.log("Connected.");
        connection.invoke("SendMessageToGroup");
    }
    function startFail() {
        console.log("Connection failed.");
    }

    connection.start().then(startSuccess, startFail);
}