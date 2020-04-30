using System.Collections.Generic;
using System.Linq;
using werwolfonline.Database.Model;
using werwolfonline.Models.Enums;

namespace werwolfonline.SignalR.Model
{
    public class PublicGame
    {
        public PublicGame() { }
        public PublicGame(Game game, Player player)
        {
            Id = game.Id;
            GameNumber = game.GameNumber;
            GameNumberWords = game.GameNumberWords;
            Phase = game.Phase;
            MessageOfTheDay = game.MessageOfTheDay;
            RevealCharacters = game.RevealCharacters;
            SeerSeesIdentity = game.SeerSeesIdentity;
            PassOnMayor = game.PassOnMayor;
            Night = game.Night;
            Log = game.Log;
            Player = player;
            Players = game.Players.Select(player => new PublicPlayer(player)).ToList();
            CharacterCounts = game.CharacterCounts;
        }
        public int Id { get; set; }
        public ulong GameNumber { get; set; }
        public string GameNumberWords { get; private set; } = "";
        public Phase Phase { get; set; }
        public string PhaseString => Phase.ToString();
        public string MessageOfTheDay { get; set; } = "";
        public bool RevealCharacters{ get; set; }
        public bool SeerSeesIdentity{ get; set; }
        public bool PassOnMayor{ get; set; }
        public int Night { get; set; }
        public string Log { get; set; } = "";
        public Player Player { get; set; } = null!;
        public List<PublicPlayer> Players { get; set; } = new List<PublicPlayer>();
        public List<CharacterCount> CharacterCounts { get; set; } = new List<CharacterCount>();
    }
}