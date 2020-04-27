function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function setCookie(cname, cvalue, exdays) {
    let d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
} 

jQuery(document).ready(function () {
    "use strict"
    let vue = new Vue({
        el: '#app',
        data: {
            page: 'start',
            name: '',
            gameNumber: '',
            connection: null,
            game: null
        },
        methods: {
            joinGame: function () {
                this.connection.on('SendGameUpdate', game => {
                    this.game = game;
                    this.page = 'new-game';
                    this.connection.off('SendGameUpdate');
                    this.connection.on('SendGameUpdate', game => {
                        this.game.players = game.players;
                    });
                })
                this.connection.invoke('JoinGame', this.gameNumber, this.name).catch(function (err) {
                    return console.error(err.toString());
                });
            },
            createGame: function () {
                this.connection.on('SendGameUpdate', game => {
                    this.game = game;
                    this.page = 'new-game';
                    this.connection.off('SendGameUpdate');
                    this.connection.on('SendGameUpdate', game => {
                        this.game.players = game.players;
                    });
                })
                this.connection.invoke('CreateGame', this.name).catch(function (err) {
                    return console.error(err.toString());
                });
            }
        },
        created: function () {
            this.connection = new signalR.HubConnectionBuilder().withUrl('/gamehub').build();

            this.connection.start().catch(function () {
                return console.error(err.toString());
            });
        }
    });
});
