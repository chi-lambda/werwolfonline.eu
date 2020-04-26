using System.Threading.Tasks;

namespace werwolfonline.SignalR.Clients
{
    public interface IClient
    {
        Task SendPlayerUpdate(string playerJson);
        Task SendGameUpdate(string gameJson);
        Task SetConnectionId(string connectionId);
        Task RevealIdentity(string identity);
        Task NotFound();
        Task NotAuthorized();
        Task InformLover(int loverId);
        Task AskHunter();
        Task AskProtector();
        Task AskSlut();
        Task AskSeer();
        Task AskWitch();
        Task AskWerewolf();
        Task GoToSleep();
    }
}