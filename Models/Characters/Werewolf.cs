using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public class Werewolf : Character
    {
        public override bool IsWerewolf => true;
        public override bool LooksLikeWerewolf => true;
        public override Enums.Character Identifier => Enums.Character.Werewolf;
        public override string Name => "Werwolf";
        public override string Description => "Die Werwölfe töten jede Nacht einen Dorfbewohner, verhalten sich aber am Tag, als gehörten sie zu ihnen. Achtung: Die Dorfbewohner wollen den Werwölfen auf die Schliche kommen.";
    }
}