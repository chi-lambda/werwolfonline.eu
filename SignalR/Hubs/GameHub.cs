using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using werwolfonline.Database.Model;

namespace werwolfonline.SignalR.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendStatus(int gameId)
        {
            var game = new Game { Id = gameId };
            await Clients.All.SendAsync("ReceiveStatus", JsonConvert.SerializeObject(game));
        }
    }
}