using werwolfonline.Database.Model;

namespace werwolfonline.SignalR.Model
{
    public class PublicPlayer
    {
        public PublicPlayer(Player player)
        {
            Id = player.Id;
            Name = player.Name;
            IsHost = player.IsHost;
            IsAlive = player.IsAlive;
            VoteForId = player.VoteForId;
            IsMayor = player.IsMayor;
        }
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsHost { get; set; }
        public bool IsAlive { get; set; } = true;
        public int? VoteForId { get; set; }
        public bool IsMayor { get; set; }
    }
}