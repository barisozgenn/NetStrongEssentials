import { RetryContext } from "@microsoft/signalr";

export default class CustomReconnectionPolicy implements signalR.IRetryPolicy {
    maxRetryAttempts = 0;

    nextRetryDelayInMilliseconds(retryContext: RetryContext): number {
        console.info(`Retry :: ${retryContext.retryReason}`);
        //NOT: if after 10 times trying to reconnect, websocket hub still disable just stop trying
        if (retryContext.previousRetryCount === 10) return null; // stawp!
        //NOT: try to reconnect every 10 sec
        var nextRetry = retryContext.previousRetryCount * 1000 || 1000;
        console.log(`Retry in ${nextRetry} milliseconds`);
        return nextRetry;
    }

}