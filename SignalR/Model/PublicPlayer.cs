namespace werwolfonline.SignalR.Model
{
    public class PublicPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsHost { get; set; }
        public bool IsAlive { get; set; } = true;
        public int? VoteForId { get; set; }
        public int? AccusedId { get; set; }
        public bool IsMayor { get; set; }
    }
}