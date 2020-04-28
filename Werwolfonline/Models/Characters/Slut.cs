using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public class Slut : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Enums.Character Identifier => Enums.Character.Slut;
        public override string Name => "Schlampe";
        public override string Description => "Jede Nacht können Sie sich zu einem anderen Spieler ins Bett legen. Wenn die Wölfe Sie fressen wollen, fressen sie stattdessen den anderen Spieler. Wenn Sie sich zu einem Werwolf ins Bett legen, sterben Sie.";
    }
}