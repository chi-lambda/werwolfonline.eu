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

function getCharacterCount(game, character) {
    if (game == null) { return null; }
    let countEntities = game.characterCounts.filter(cc => cc.characterString === character);
    if (countEntities.length == 0) { return null; }
    return countEntities[0].count;
}

function setCharacterCount(game, character, count) {
    if (game == null) { return null; }
    let countEntities = game.characterCounts.filter(cc => cc.characterString === character);
    if (countEntities.length == 0) { return null; }
    countEntities[0].count = count;
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
                    this.connection.off('NotAuthorized');
                    this.connection.on('SendGameUpdate', game => {
                        this.game.players = game.players;
                        if (game.phaseString === 'Setup') {
                            this.page = 'setup';
                            this.game = game;
                            this.connection.off('SendGameUpdate');
                        }
                    });
                })
                this.connection.on('NotAuthorized', () => {
                    alert('Du kannst diesem Spiel nicht mehr beitreten.');
                });
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
                        if (game.phaseString === 'Setup') {
                            this.page = 'setup';
                            this.game = game;
                            this.connection.off('SendGameUpdate');
                        }
                    });
                })
                this.connection.invoke('CreateGame', this.name).catch(function (err) {
                    return console.error(err.toString());
                });
            },
            startSetup: function () {
                this.connection.invoke('StartSetup').catch(function (err) {
                    return console.error(err.toString());
                });
            },
        },
        computed: {
            werewolfCount: {
                get: function () {
                    return getCharacterCount(this.game, 'Werewolf');
                },
                set: function (count) {
                    setCharacterCount(this.game, 'Werewolf', count);
                }
            },
            hunterCount: {
                get: function () {
                    return getCharacterCount(this.game, 'Hunter');
                },
                set: function (count) {
                    setCharacterCount(this.game, 'Hunter', count);
                }
            },
            witchCount: {
                get: function () {
                    return getCharacterCount(this.game, 'Witch');
                },
                set: function (count) {
                    setCharacterCount(this.game, 'Witch', count);
                }
            },
            seerCount: {
                get: function () {
                    return getCharacterCount(this.game, 'Seer');
                },
                set: function (count) {
                    setCharacterCount(this.game, 'Seer', count);
                }
            },
            amorCount: {
                get: function () {
                    return getCharacterCount(this.game, 'Amor');
                },
                set: function (count) {
                    setCharacterCount(this.game, 'Amor', count);
                }
            },
            villagerCount: {
                get: function () {
                    return getCharacterCount(this.game, 'Villager');
                },
                set: function (count) {
                    setCharacterCount(this.game, 'Villager', count);
                }
            },
            totalCardCount: function () {
                return this.game.characterCounts.reduce((a, x) => (a | 0) + (x.count | 0), 0);
            },
            notEnoughCards: function () {
                return this.game.characterCounts.reduce((a, x) => (a | 0) + (x.count | 0), 0) < this.game.players.length;
            },
            fewCards: function () {
                return this.game.characterCounts.reduce((a, x) => (a | 0) + (x.count | 0), 0) < this.game.players.length + 2;
            }
        },
        created: function () {
            this.connection = new signalR.HubConnectionBuilder().withUrl('/gamehub').build();

            this.connection.start().catch(function () {
                return console.error(err.toString());
            });
        }
    });
    window.vue = vue;
});
