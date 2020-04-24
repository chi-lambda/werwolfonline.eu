using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public class None : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Enums.Character Identifier => Enums.Character.None;
        public override string Name => "Keiner";
        public override string Description => "keine";
    }
}