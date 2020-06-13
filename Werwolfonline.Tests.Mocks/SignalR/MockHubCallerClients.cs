using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using werwolfonline.SignalR.Clients;
using Moq;

namespace werwolfonline.Tests.Mocks.SignalR
{
    class MockHubCallerClients : IHubCallerClients<IClient>
    {

        private readonly List<IClient> clients = new List<IClient>();
        private readonly HubCallerContext context;
        public MockHubCallerClients(HubCallerContext context)
        {
            this.context = context;
        }
        public IClient Caller => new Mock<IClient>().Object;

        public IClient Others => new Mock<IClient>().Object;

        public IClient All => new Mock<IClient>().Object;

        public IClient AllExcept(IReadOnlyList<string> excludedConnectionIds)
        {
            throw new System.NotImplementedException();
        }

        public IClient Client(string connectionId)
        {
            throw new System.NotImplementedException();
        }

        public IClient Clients(IReadOnlyList<string> connectionIds)
        {
            throw new System.NotImplementedException();
        }

        public IClient Group(string groupName)
        {
            throw new System.NotImplementedException();
        }

        public IClient GroupExcept(string groupName, IReadOnlyList<string> excludedConnectionIds)
        {
            throw new System.NotImplementedException();
        }

        public IClient Groups(IReadOnlyList<string> groupNames)
        {
            throw new System.NotImplementedException();
        }

        public IClient OthersInGroup(string groupName)
        {
            throw new System.NotImplementedException();
        }

        public IClient User(string userId)
        {
            throw new System.NotImplementedException();
        }

        public IClient Users(IReadOnlyList<string> userIds)
        {
            throw new System.NotImplementedException();
        }
    }
}