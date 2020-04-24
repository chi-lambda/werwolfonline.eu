using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public class Protector : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Enums.Character Identifier => Enums.Character.Protector;
        public override string Name => "Beschützer";
        public override string Description => "Sie können jede Nacht einen Spieler beschützen, der in dieser Nacht nicht sterben kann (Sie können sich auch selbst wählen). Sie dürfen nicht zwei Nächte hintereinander dieselbe Person schützen.";
    }
}