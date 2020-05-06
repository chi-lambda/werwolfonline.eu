using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using werwolfonline.Database.Model;
using werwolfonline.Database.Model.Enums;
using werwolfonline.SignalR.Clients;
using werwolfonline.SignalR.Hubs;
using werwolfonline.SignalR.Model;
using werwolfonline.Tests.Mocks.Database.Repositories;
using werwolfonline.Utils;
using Xunit;

namespace werwolfonline.Test.SignalR.Hubs
{
    public class GameHub_Test
    {
        [Fact]
        public async Task CreateAndJoinTest()
        {
            var games = new List<Game>();
            var players = new List<Player>();
            var gameRepo = new MockGameRepository(games, players);
            var rng = new RNGesus();
            var playerRepo = new MockPlayerRepository(games, players, rng);
            var logger = NullLogger.Instance;
            var gameHub = new GameHub(gameRepo, playerRepo, logger);
            gameHub.Context = CreateMockHubCallerContext();
            gameHub.Clients = CreateMockHubCallerClients();
            SetConnectionId(gameHub, "1");

            await gameHub.CreateGame("P1");
            Assert.Single(games);
            Assert.Single(games.First().Players);
            Assert.Equal("1", players.First().ConnectionId);
            Assert.True(players.First().IsHost);

            SetConnectionId(gameHub, "2");
            await gameHub.JoinGame(games.First().GameNumberWords, "P2");
            Assert.Single(games);
            Assert.Equal(2, games.First().Players.Count);
            Assert.Contains(players, player => player.ConnectionId == "2");
            Assert.False(players.First(player => player.ConnectionId == "2").IsHost);

            SetConnectionId(gameHub, "3");
            await gameHub.JoinGame(games.First().GameNumberWords, "P3");
            Assert.Single(games);
            Assert.Equal(3, games.First().Players.Count);
            Assert.Contains(players, player => player.ConnectionId == "3");
            Assert.False(players.First(player => player.ConnectionId == "3").IsHost);

            SetConnectionId(gameHub, "1");
            await gameHub.StartSetup();
            Assert.Equal(Phase.Setup, games.First().Phase);
        }
        private static IClient CreateClient()
        {
            var client = Mock.Of<IClient>();
            var mock = Mock.Get(client);
            mock.Setup(client => client.AskAmor()).Returns(Task.CompletedTask);
            mock.Setup(client => client.AskHunter()).Returns(Task.CompletedTask);
            mock.Setup(client => client.AskProtector()).Returns(Task.CompletedTask);
            mock.Setup(client => client.AskSeer()).Returns(Task.CompletedTask);
            mock.Setup(client => client.AskSlut()).Returns(Task.CompletedTask);
            mock.Setup(client => client.AskWerewolf()).Returns(Task.CompletedTask);
            mock.Setup(client => client.AskWitch()).Returns(Task.CompletedTask);
            mock.Setup(client => client.GoToSleep()).Returns(Task.CompletedTask);
            mock.Setup(client => client.InformLover(It.IsAny<int>())).Returns(Task.CompletedTask);
            mock.Setup(client => client.NotAuthorized()).Returns(Task.CompletedTask);
            mock.Setup(client => client.NotFound()).Returns(Task.CompletedTask);
            mock.Setup(client => client.RevealIdentity(It.IsAny<string>())).Returns(Task.CompletedTask);
            mock.Setup(client => client.SendGameUpdate(It.IsAny<PublicGame>())).Returns(Task.CompletedTask);
            mock.Setup(client => client.SendPlayerUpdate(It.IsAny<PublicPlayer>())).Returns(Task.CompletedTask);
            return client;
        }

        private HubCallerContext CreateMockHubCallerContext()
        {
            var context = Mock.Of<HubCallerContext>();
            return context;
        }

        private IHubCallerClients<IClient> CreateMockHubCallerClients()
        {
            var clients = Mock.Of<IHubCallerClients<IClient>>();
            var mock = Mock.Get(clients);
            mock.Setup(clients => clients.Caller).Returns(CreateClient());
            return clients;
        }

        private void SetConnectionId(GameHub hub, string connectionId)
        {
            Mock.Get(hub.Context).Setup(ctx => ctx.ConnectionId).Returns(connectionId);
        }
    }
}