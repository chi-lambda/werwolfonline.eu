using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public class Seer : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Enums.Character Identifier => Enums.Character.Seer;
        public override string Name => "Seherin";
        public override string Description => "Sie können jede Nacht die Nachtidentität eines Spielers sehen. Alternative: Sie sehen, welcher Gruppe derjenige angehört";
    }
}