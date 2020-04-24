namespace werwolfonline.Database.Model
{
    public class CharacterCount
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int Count { get; set; }
    }
}