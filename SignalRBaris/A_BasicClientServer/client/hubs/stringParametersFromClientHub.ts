import * as signalR from "@microsoft/signalr";

export function configureStringParametersHub() {

//NOTE: CLIENT HUB METHODS : Client sending messages to StringParametersHub
let btn = document.getElementById("btnGetUserName");

let connection2 = new signalR.HubConnectionBuilder()
    .withUrl("/hub/stringParameters")
    .build();

btn.addEventListener("click", function (evt) {
    var firstName = (document.getElementById("inputFirstName") as HTMLInputElement).value;
    var lastName = (document.getElementById("inputLastName") as HTMLInputElement).value;

    connection2
        .invoke("getUserName", firstName, lastName)
        .then((name: string) => { alert(name); });
});

function startSuccess2(){ console.log("Connected successfully.");}
function startFail2(){console.log("Connection failed");}
connection2.start().then(startSuccess2, startFail2);
}