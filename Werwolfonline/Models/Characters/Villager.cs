using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public class Villager : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Enums.Character Identifier => Enums.Character.Villager;
        public override string Name => "Dorfbewohner";
        public override string Description => "Beunruhigt durch das Auftauchen von Werwölfen, versuchen die Dorfbewohner wieder Frieden in das Dorf zu bringen, indem sie alle Werwölfe ausforschen und töten wollen.";
    }
}