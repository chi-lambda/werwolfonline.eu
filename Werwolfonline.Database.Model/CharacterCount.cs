using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using werwolfonline.Database.Model.Enums;

namespace werwolfonline.Database.Model
{
    public class CharacterCount
    {
        public int Id { get; set; }
        public Character Character { get; set; }
        [NotMapped]
        public string CharacterString => Character.ToString();
        public int GameId { get; set; }
        [JsonIgnore]
        public virtual Game Game { get; set; } = null!;
        public int Count { get; set; }
    }
}