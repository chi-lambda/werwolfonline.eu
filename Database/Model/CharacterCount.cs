namespace werwolfonline.Database.Model
{
    public class CharacterCount
    {
        public int Id { get; set; }
        public Models.Enums.Character Character { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
        public int Count { get; set; }
    }
}