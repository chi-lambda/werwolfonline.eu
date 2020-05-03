using System.Collections.Generic;
using System.Threading.Tasks;
using werwolfonline.Database.Model;
using werwolfonline.Database.Model.Enums;

namespace werwolfonline.Interfaces.Database.Repositories
{
    public interface IGameRepository
    {
        Task<Game> Add(Game game);
        Task<int> Count();
        Task<IEnumerable<Game>> GetAll();
        Task<Game?> GetByGameNumber(string gameNumber);
        Task<Game> GetById(int id);
        Task Save();
        Task SetCharacterCounts(Game game, IEnumerable<CharacterCount> characterCounts);
        Task SetPhase(Game game, Phase phase);
    }


}