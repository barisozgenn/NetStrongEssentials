import * as signalR from "@microsoft/signalr";
import { CustomLogger } from "../logger/customLogger";

export function configureProductViewersHubWithLogging() {

    var counterDiv = document.getElementById("productViewersCounterDiv");
    //NOTE: create connection on our MapHub path in startup.cs
    let connection = new signalR.HubConnectionBuilder()
    //  .configureLogging(signalR.LogLevel.Trace)
        .configureLogging(new CustomLogger())
        .withUrl("/hub/productViewers",{
            transport: signalR.HttpTransportType.WebSockets | //if WebSockets is not available
                        signalR.HttpTransportType.ServerSentEvents //then it use ServerSentEvents
        })
        .build();
    //NOTE: Connect our client method in ProductViewersHub.cs/NotifyProductViewers/SendAsync method name
    connection.on("productViewersCountUpdate", (value: number) => {
        counterDiv.innerText = value.toString();
    });
    //NOTE: notify server we're listening to ProductViewersHub.cs/NotifyProductViewers method
    function notifyOnProductViewers(){
        connection.send("notifyProductViewers");
    }
    
    
    function startSuccess(){ notifyOnProductViewers(); }
    function startFail(){console.log("Connection failed");}
    connection.start().then(startSuccess, startFail);
}