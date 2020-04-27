using System.Threading.Tasks;
using werwolfonline.SignalR.Model;

namespace werwolfonline.SignalR.Clients
{
    public interface IClient
    {
        Task SendPlayerUpdate(PublicPlayer player);
        Task SendGameUpdate(PublicGame game);
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
        Task WaitForHunter();
    }
}