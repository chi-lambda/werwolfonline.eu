using System.Collections.Generic;
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
            Phase = game.Phase;
            MessageOfTheDay = game.MessageOfTheDay;
            Night = game.Night;
            Log = game.Log;
            Player = player;
        }
        public int Id { get; set; }
        public Phase Phase { get; set; }
        public string MessageOfTheDay { get; set; } = "";
        public int Night { get; set; }
        public string Log { get; set; } = "";
        public Player Player { get; set; } = null!;
        public List<PublicPlayer> Players { get; set; } = new List<PublicPlayer>();
    }
}