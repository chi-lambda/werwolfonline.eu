using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public class Spy : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Enums.Character Identifier => Enums.Character.Spy;
        public override string Name => "Spion";
        public override string Description => "Sie können jede Nacht einen Spieler auswählen und eine Identität, die dieser Spieler haben könnte. Sie erfahren, ob dieser Spieler tatsächlich diese Identität besitzt";
    }
}