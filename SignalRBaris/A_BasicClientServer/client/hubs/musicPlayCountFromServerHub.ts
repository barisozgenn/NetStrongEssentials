import * as signalR from "@microsoft/signalr";
export function configureMusicPlayCountFromServerHub() {


let btn = document.getElementById("btnPlayMusic");
let viewCountSpan = document.getElementById("musicPlayCount");

// create connection
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub/musicPlayers")
    .build();

btn.addEventListener("click", function (evt) {
    // send to hub
    connection.invoke("IncrementMusicPlayCountOnServer");
});

// client events
connection.on("incrementMusicPlayCount", (val) => {
    viewCountSpan.innerText = val;
    // For example after 1000 listeners we do not want to show/update the count
    if (val > 1000) connection.off("incrementMusicPlayCount");
    //if (val % 1000 === 0) connection.off("incrementMusicPlayCount");
});

// start the connection
function startSuccess() {
    console.log("Connected.");
    connection.invoke("IncrementMusicPlayCountOnServer");
}
function startFail() {
    console.log("Connection failed.");
}

connection.start().then(startSuccess, startFail);
}