using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using werwolfonline.Database.Model;
using werwolfonline.Database.Model.Enums;
using werwolfonline.Interfaces.Database.Repositories;
using werwolfonline.Utils;

namespace werwolfonline.Tests.Mocks.Database.Repositories
{
    public class MockGameRepository : IGameRepository
    {
        public ICollection<Game> Games{ get; }
        private ICollection<Player> Players { get; }
        private int currentId = 1;

        private CorrectHorseBatteryStaple chbs = new CorrectHorseBatteryStaple();

        public MockGameRepository(ICollection<Game> games, ICollection<Player> players){
            Games = games;
            Players = players;
        }

        public async Task<Game> Add(Game game)
        {
            game.Id = currentId;
            Games.Add(game);
            currentId++;
            return await Task.FromResult(game);
        }

        public async Task<int> Count()
        {
            return await Task.FromResult(Games.Count);
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await Task.FromResult(Games.ToList());
        }

        public async Task<Game?> GetByGameNumber(string gameNumber)
        {
            ulong gameNumberNumeric;
            if (!ulong.TryParse(gameNumber, out gameNumberNumeric))
            {
                gameNumberNumeric = chbs.FromGermanWords(gameNumber);
            }
            return await Task.FromResult(Games.SingleOrDefault(game => game.GameNumber == gameNumberNumeric));

        }

        public async Task<Game> GetById(int id)
        {
            return await Task.FromResult(Games.SingleOrDefault(game => game.Id == id));
        }

        public async Task Save()
        {
            //NOP
            await Task.CompletedTask;
        }

        public async Task SetCharacterCounts(Game game, IEnumerable<CharacterCount> characterCounts)
        {
            game.CharacterCounts = characterCounts.ToList();
            await Save();
        }

        public async Task SetPhase(Game game, Phase phase)
        {
            if (phase == Phase.NightAmor)
            {
                game.Night++;
                if (game.Night > 1 || !game.Players.Any(player => player.Character == Character.Amor))
                {
                    phase = Phase.NightSeer;
                }
            }
            if (phase == Phase.NightSeer && !game.Players.Any(player => player.Character == Character.Seer))
            {
                phase = Phase.NightWolves;
            }
            if (phase == Phase.NightWitch && !game.Players.Any(player => player.Character == Character.Witch))
            {
                phase = Phase.NightEnd;
            }
            game.Phase = phase;
            await Save();
        }
    }
}