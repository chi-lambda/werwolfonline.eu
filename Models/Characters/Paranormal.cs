using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public class Paranormal : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Enums.Character Identifier => Enums.Character.Paranormal;
        public override string Name => "Paranormaler Ermittler";
        public override string Description => "Sie können einmal im Spiel einen Spieler bestimmen und erfahren, ob sich unter diesem und den beiden Nachbarn zumindest ein Werwolf befindet.";
    }
}