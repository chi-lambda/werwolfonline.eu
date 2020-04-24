using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public class Lycanthrope : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => true;
        public override Enums.Character Identifier => Enums.Character.Lycanthrope;
        public override string Name => "Lykanthrop";
        public override string Description => "Sie sehen aus wie ein Werwolf, sind aber keiner. Sie spielen also für die Dorfbewohner";
    }
}