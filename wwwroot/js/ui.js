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
