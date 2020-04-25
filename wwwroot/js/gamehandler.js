(function () {
    "use strict"
    let connection = new signalR.HubConnectionBuilder().withUrl('/gamehub').build();
    window.connection = connection;
    console.log(connection);

    connection.on('ReceiveStatus', function (json) {
        console.log(json);
        console.log(JSON.parse(json));
    });

    connection.start().then(function () {
        connection.invoke('SendStatus', 1000).catch(function (err) {
            return console.error(err.toString());
        })
    }).catch(function () {
        return console.error(err.toString());
    })

})()