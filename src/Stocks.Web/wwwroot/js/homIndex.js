
const client = new signalR.HubConnectionBuilder().withUrl('http://localhost:40003/stockHub').configureLogging(signalR.LogLevel.Information).build();

client.on('StockUpdates', function (stocks) {
    cosole.log(stocks);
    console.log("here");
});

$.ready( async function () {
    await client.strat();
})