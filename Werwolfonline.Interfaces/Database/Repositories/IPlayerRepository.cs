using System.Collections.Generic;
using System.Threading.Tasks;
using werwolfonline.Database.Model;

namespace werwolfonline.Interfaces.Database.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player> Add(Player player);
        Task AssignRoles(IEnumerable<Player> players, IEnumerable<CharacterCount> characterCounts);
        Task<int> Count();
        Task<int> CountForGame(int gameId);
        Task<int> CountWolvesForGame(int gameId);
        Task<IEnumerable<Player>> GetAll();
        Task<Player> GetAmor(int gameId);
        Task<Player> GetByConnectionId(string connectionId);
        Task<Player> GetById(int id);
        Task<List<Player>> GetPlayersForGame(int gameId);
        Task<Player> GetProtector(int gameId);
        Task<Player> GetSeer(int gameId);
        Task<Player> GetSlut(int gameId);
        Task<Player> GetVillagers(int gameId);
        Task<int> GetWerewolfCount();
        Task<Player> GetWerewolfVictim(Game game);
        Task<IEnumerable<Player>> GetWerewolves(int gameId);
        Task<Player> GetWitch(int gameId);
        Task<bool> IsPlayerProtected(int playerId);
        Task ResetPlayer(Player player);
        Task Save();
        Task SetAssociate(Player player, Player associate);
        Task SetDiedTonight(Player player, bool state);
        Task VoteFor(Player voter, Player victim);
    }

}